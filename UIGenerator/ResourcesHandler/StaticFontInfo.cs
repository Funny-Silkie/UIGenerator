using System;
using System.IO;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// affファイルから生成したフォントの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class StaticFontInfo : FontInfoBase
    {
        private StaticFontInfo(UIGeneratorStaticFont font, string name) : base(font, name, FontType.Static) { }
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
            Central.ThrowHelper.ThrowIfNull(values: path);
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileNameWithoutExtension(path);
            return new StaticFontInfo(new UIGeneratorStaticFont(path), name);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({Type})";
    }
}
