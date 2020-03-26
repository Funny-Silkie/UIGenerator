using System;
using System.IO;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// フォントの情報を格納するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class FontInfoBase : IEquatable<FontInfoBase>
    {
        /// <summary>
        /// 内部に格納されている<see cref="UIGeneratorFontBase"/>を取得する
        /// </summary>
        public UIGeneratorFontBase Font { get; }
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
        protected FontInfoBase(UIGeneratorFontBase font, string name, FontType type)
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
        /// <summary>
        /// <see cref="PackagedFont"/>からインスタンスを生成する
        /// </summary>
        /// <param name="package">インスタンス生成に用いるフォントのパッケージ</param>
        /// <returns>フォントの情報</returns>
        public static FontInfoBase FromPackage(PackagedFont package)
        {
            Central.ThrowHelper.ThrowIfNull(package);
            var e = File.Exists(package.Path);
            if(!e) package.Save();
            var result = FromPackagePrivate(package);
            if(!e) File.Delete(package.Path);
            return result;
        }
        private static FontInfoBase FromPackagePrivate(PackagedFont package)
        {
            switch (package)
            {
                case PackagedDynamicFont d: return DynamicFontInfo.GetInstance(d.Path, d.Size, d.Color, d.OutLineSize, d.OutLineColor);
                case PackagedStaticFont s: return StaticFontInfo.GetInstance(s.Path);
                default: throw new ArgumentException();
            }
        }
    }
}
