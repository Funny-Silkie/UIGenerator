using System;
using System.IO;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// フォントの情報を格納するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class FontInfoBase : IEquatable<FontInfoBase>
    {
        /// <summary>
        /// 内部に格納されている<see cref="SerializableFont"/>を取得する
        /// </summary>
        public SerializableFont Font { get; }
        /// <summary>
        /// フォントの名前を取得する
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 登録されているフォントのタイプを取得する
        /// </summary>
        public FontType Type { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="font">格納されるフォント</param>
        /// <param name="name">格納される名前</param>
        /// <param name="type">フォントのタイプ</param>
        /// <exception cref="ArgumentNullException"><paramref name="font"/>又は<paramref name="name"/>がnull</exception>
        protected FontInfoBase(SerializableFont font, string name, FontType type)
        {
            Font = font ?? throw new ArgumentNullException();
            Name = name ?? throw new ArgumentNullException();
            Type = type;
        }
        /// <summary>
        /// 2つの<see cref="FontInfoBase"/>のインスタンスの同値性を確かめる
        /// </summary>
        /// <param name="other">比較する<see cref="FontInfoBase"/>のインスタンス</param>
        /// <returns>同値かどうか</returns>
        public bool Equals(FontInfoBase other) => ToString() == other.ToString();
    }
    /// <summary>
    /// 動的なフォントの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class DynamicFontInfo : FontInfoBase
    {
        /// <summary>
        /// フォントの大きさを取得する
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// フォントの色を取得する
        /// </summary>
        public ColorPlus Color { get; }
        /// <summary>
        /// 縁の太さを取得する
        /// </summary>
        public int OutLineSize { get; }
        /// <summary>
        /// 縁の色を取得する
        /// </summary>
        public ColorPlus OutLineColor { get; }
        private DynamicFontInfo(SerializableDynamicFont font, string name) : base(font, name, FontType.Dynamic)
        {
            Size = font.Size;
            Color = font.Color;
            OutLineSize = font.OutLineSize;
            OutLineColor = font.OutLineColor;
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
            Central.ThrowHelper.ThrowArgumentNullException(null, values: path);
            if (size <= 0 || outlinesize <= 0) throw new ArgumentOutOfRangeException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            return new DynamicFontInfo(new SerializableDynamicFont(path, size, outlinesize, color, outlinecolor), name);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({Size}-{Color.ToString()}-{OutLineSize}-{OutLineColor.ToString()})";
    }
    /// <summary>
    /// affファイルから生成したフォントの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class StaticFontInfo : FontInfoBase
    {
        private StaticFontInfo(SerializableStaticFont font, string name) : base(font, name, FontType.Static) { }
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
            Central.ThrowHelper.ThrowArgumentNullException(null, values: path);
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            return new StaticFontInfo(new SerializableStaticFont(path), name);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({Type})";
    }
}
