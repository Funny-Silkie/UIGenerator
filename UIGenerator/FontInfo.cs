using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// フォントのタイプを表す
    /// </summary>
    [Serializable]
    public enum FontType
    {
        /// <summary>
        /// <see cref="Graphics.CreateDynamicFont(string, int, Color, int, Color)"/>によって生成されるフォント
        /// </summary>
        Dynamic,
        /// <summary>
        /// <see cref="Graphics.CreateFont(string)"/>によってaffファイルから生成されたフォント
        /// </summary>
        Static
    }
    /// <summary>
    /// フォントの情報を格納するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class FontInfoBase : IEquatable<FontInfoBase>, ISerializable
    {
        #region SerializeName
        private const string S_Name = "S_Name";
        private const string S_Buffer = "S_Buffer";
        private const string S_Type = "S_Type";
        #endregion
        /// <summary>
        /// 内部に格納されている<see cref="asd.Font"/>を取得する
        /// </summary>
        public Font Font { get; protected set; }
        /// <summary>
        /// フォントの名前を取得する
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 登録されているフォントのタイプを取得する
        /// </summary>
        public FontType Type { get; }
        /// <summary>
        /// フォントデータのバッファを取得する
        /// </summary>
        public byte[] Buffer { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">フォント情報のファイルのパス</param>
        /// <param name="font">格納されるフォント</param>
        /// <param name="name">格納される名前</param>
        /// <param name="type">フォントのタイプ</param>
        /// <exception cref="ArgumentNullException"><paramref name="font"/>又は<paramref name="name"/>がnull</exception>
        protected private FontInfoBase(string path, Font font, string name, FontType type)
        {
            Font = font ?? throw new ArgumentNullException();
            Name = name ?? throw new ArgumentNullException();
            Type = type;
            Buffer = Engine.File.CreateStaticFile(path).Buffer;
        }
        /// <summary>
        /// シリアル化されたデータをもとにインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアル化された情報</param>
        /// <param name="context">送信元</param>
        protected private FontInfoBase(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString(S_Name);
            Type = (FontType)Enum.ToObject(typeof(FontType), info.GetInt32(S_Type));
            Buffer = (byte[])info.GetValue(S_Buffer, typeof(byte[]));
        }
        /// <summary>
        /// 2つの<see cref="FontInfoBase"/>のインスタンスの同値性を確かめる
        /// </summary>
        /// <param name="other">比較する<see cref="FontInfoBase"/>のインスタンス</param>
        /// <returns>同値かどうか</returns>
        public bool Equals(FontInfoBase other) => ToString() == other.ToString();
        /// <summary>
        /// シリアル化する情報を設定する
        /// </summary>
        /// <param name="info">シリアル化情報の設定先</param>
        /// <param name="context">送信先</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            info.AddValue(S_Name, Name);
            info.AddValue(S_Type, (int)Type);
            info.AddValue(S_Buffer, Buffer, typeof(byte[]));
        }
    }
    /// <summary>
    /// 動的なフォントの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class DynamicFontInfo : FontInfoBase, ISerializable
    {
        #region SerializeName
        private const string S_Size = "S_Size";
        private const string S_Color= "S_Color";
        private const string S_OutLineSize= "S_OutLineSize";
        private const string S_OutLineColor= "S_OutLineColor";
        #endregion
        /// <summary>
        /// フォントの大きさを取得する
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// フォントの色を取得する
        /// </summary>
        public Color Color { get; }
        /// <summary>
        /// 縁の太さを取得する
        /// </summary>
        public int OutLineSize { get; }
        /// <summary>
        /// 縁の色を取得する
        /// </summary>
        public Color OutLineColor { get; }
        private DynamicFontInfo(string path, Font font, string name, int size, Color color, int outlinesize, Color outlinecolor) : base(path, font, name, FontType.Dynamic)
        {
            if (size <= 0 || outlinesize <= 0) throw new ArgumentOutOfRangeException();
            Size = size;
            Color = color;
            OutLineSize = outlinesize;
            OutLineColor = outlinecolor;
        }
        private DynamicFontInfo(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Size = info.GetInt32(S_Size);
            OutLineSize = info.GetInt32(S_OutLineSize);
            Color = (S_Color)info.GetValue(S_Color, typeof(S_Color));
            OutLineColor = (S_Color)info.GetValue(S_OutLineColor, typeof(S_Color));
            SetFont();
        }
        /// <summary>
        /// 指定した引数から<see cref="DynamicFontInfo"/>のインスタンスを取得する
        /// </summary>
        /// <param name="path">フォントの情報が格納されているファイルのパス</param>
        /// <param name="size">フォントサイズ</param>
        /// <param name="color">フォントの色</param>
        /// <param name="outlinesize">縁の太さ</param>
        /// <param name="outlinecolor">縁の色</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>又は<paramref name="outlinesize"/>が0以下</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>が存在しない</exception>
        /// <exception cref="IOException">フォントが生成できなかった</exception>
        /// <returns>生成された動的フォントを格納した<see cref="DynamicFontInfo"/>の新しいインスタンスを返す</returns>
        public static DynamicFontInfo GetInstance(string path, int size, Color color, int outlinesize, Color outlinecolor)
        {
            Central.ThrowHelper.ThrowArgumentNullException(path);
            if (size <= 0 || outlinesize <= 0) throw new ArgumentOutOfRangeException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            var font = Engine.Graphics.CreateDynamicFont(path, size, color, outlinesize, outlinecolor) ?? throw new IOException();
            return new DynamicFontInfo(path, font, name, size, color, outlinesize, outlinecolor);
        }
        /// <summary>
        /// シリアル化する情報を設定する
        /// </summary>
        /// <param name="info">シリアル化情報の設定先</param>
        /// <param name="context">送信先</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(S_Color, (S_Color)Color);
            info.AddValue(S_Size, Size);
            info.AddValue(S_OutLineSize, OutLineSize);
            info.AddValue(S_OutLineColor, (S_Color)Color);
        }
        private void SetFont()
        {
            var path = fslib.StringHelper.GetRandomString(40) + ".prefont";
            using (var stream = new FileStream(path, FileMode.CreateNew))
                stream.Write(Buffer, 0, Buffer.Length);
            Font = Engine.Graphics.CreateDynamicFont(path, Size, Color, OutLineSize, OutLineColor);
            System.IO.File.Delete(path);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({Size}-{Color.ToStringEx()}-{OutLineSize}-{OutLineColor.ToStringEx()})";
    }
    /// <summary>
    /// affファイルから生成したフォントの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class StaticFontInfo : FontInfoBase, ISerializable
    {
        private StaticFontInfo(string path, Font font, string name) : base(path, font, name, FontType.Static) { }
        private StaticFontInfo(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            SetFont();
        }
        /// <summary>
        /// 指定した引数から<see cref="StaticFontInfo"/>のインスタンスを取得する
        /// </summary>
        /// <param name="path">フォントの情報が格納されているファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>が存在しない</exception>
        /// <exception cref="IOException">フォントが生成できなかった</exception>
        /// <returns>生成された動的フォントを格納した<see cref="StaticFontInfo"/>の新しいインスタンスを返す</returns>
        public static StaticFontInfo GetInstance(string path)
        {
            Central.ThrowHelper.ThrowArgumentNullException(path);
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            var font = Engine.Graphics.CreateFont(path) ?? throw new IOException();
            return new StaticFontInfo(path, font, name);
        }
        private void SetFont()
        {
            var path = fslib.StringHelper.GetRandomString(40) + ".prefont";
            using (var stream = new FileStream(path, FileMode.CreateNew))
                stream.Write(Buffer, 0, Buffer.Length);
            Font = Engine.Graphics.CreateFont(path);
            System.IO.File.Delete(path);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({Type})";
    }
}
