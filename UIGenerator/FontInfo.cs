using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// フォントのタイプを表す
    /// </summary>
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
    public abstract class FontInfoBase : IEquatable<FontInfoBase>
    {
        /// <summary>
        /// 内部に格納されている<see cref="asd.Font"/>を取得する
        /// </summary>
        public Font Font { get; }
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
        protected private FontInfoBase(Font font, string name, FontType type)
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
        public Color Color { get; }
        /// <summary>
        /// 縁の太さを取得する
        /// </summary>
        public int OutLineSize { get; }
        /// <summary>
        /// 縁の色を取得する
        /// </summary>
        public Color OutLineColor { get; }
        private DynamicFontInfo(Font font, string name, int size, Color color, int outlinesize, Color outlinecolor) : base(font, name, FontType.Dynamic)
        {
            if (size <= 0 || outlinesize <= 0) throw new ArgumentOutOfRangeException();
            Size = size;
            Color = color;
            OutLineSize = outlinesize;
            OutLineColor = outlinecolor;
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
            Central.ThrowHelper.ThrowArgumentNullException(path, null);
            if (size <= 0 || outlinesize <= 0) throw new ArgumentOutOfRangeException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            var font = Engine.Graphics.CreateDynamicFont(path, size, color, outlinesize, outlinecolor) ?? throw new IOException();
            return new DynamicFontInfo(font, name, size, color, outlinesize, outlinecolor);
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
    public sealed class StaticFontInfo : FontInfoBase
    {
        private StaticFontInfo(Font font, string name) : base(font, name, FontType.Static) { }
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
            Central.ThrowHelper.ThrowArgumentNullException(path, null);
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            var font = Engine.Graphics.CreateFont(path) ?? throw new IOException();
            return new StaticFontInfo(font, name);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({Type})";
    }
}
