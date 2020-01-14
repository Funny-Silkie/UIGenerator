using System;
using System.IO;
using fslib;
using fslib.Collections.BasicModel;

namespace UIGenerator
{
    /// <summary>
    /// リソース保存用のクラス
    /// </summary>
    [Serializable]
    public sealed class ResourcePackage
    {
        /// <summary>
        /// フォントを格納するコレクション
        /// </summary>
        public BasicCollection<PackagedFont> Fonts { get; }
        /// <summary>
        /// テクスチャを格納するコレクション
        /// </summary>
        public BasicCollection<PackagedTexture2D> Textures { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResourcePackage()
        {
            Fonts = PackageFonts(DataBase.Fonts);
            Textures = PackageTextures(DataBase.Textures);
        }
        /// <summary>
        /// フォントを使用できる形にする
        /// </summary>
        /// <returns>利用できる形のフォントのコレクション</returns>
        public FontCollection OpenPackageFonts()
        {
            var array = Fonts.ToArray();
            var collection = new FontCollection(array.Length);
            for (int i = 0; i < array.Length; i++) collection.Add(FontInfoBase.FromPackage(array[i]));
            return collection;
        }
        /// <summary>
        /// テクスチャを使用できる形にする
        /// </summary>
        /// <returns>利用できる形のテクスチャのコレクション</returns>
        public TextureCollection OpenPackageTextures()
        {
            var array = Textures.ToArray();
            var collection = new TextureCollection(array.Length);
            for (int i = 0; i < array.Length; i++) collection.Add(TextureInfo.FromPackage(array[i]));
            return collection;
        }
        /// <summary>
        /// フォントをパッケージ化する
        /// </summary>
        /// <param name="fonts">パッケージするフォントのコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="fonts"/>がnull</exception>
        /// <exception cref="IOException">ファイルのパッケージ化に失敗した</exception>
        /// <returns>パッケージされたフォントのコレクション</returns>
        private static BasicCollection<PackagedFont> PackageFonts(FontCollection fonts)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, fonts);
            var array = fonts.ToFontArray();
            var collection = new BasicCollection<PackagedFont>(array.Length);
            for (int i = 1; i < array.Length; i++) collection.Add(array[i].ToPackageFont());
            return collection;
        }
        /// <summary>
        /// テクスチャをパッケージ化する
        /// </summary>
        /// <param name="textures">パッケージするテクスチャのコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="textures"/>がnull</exception>
        /// <exception cref="IOException">ファイルのパッケージ化に失敗した</exception>
        /// <returns>パッケージされたテクスチャのコレクション</returns>
        private static BasicCollection<PackagedTexture2D> PackageTextures(TextureCollection textures)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, textures);
            var array = textures.ToTextureArray();
            var collection = new BasicCollection<PackagedTexture2D>(array.Length);
            for (int i = 1; i < array.Length; i++) collection.Add(array[i].ToPackageTexture());
            return collection;
        }
    }
}
