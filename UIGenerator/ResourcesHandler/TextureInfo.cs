using System;
using System.IO;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// テクスチャの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class TextureInfo : IEquatable<TextureInfo>
    {
        /// <summary>
        /// テクスチャの名前を取得する
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// テクスチャを取得する
        /// </summary>
        public UIGeneratorTexture2D Texture { get; }
        private readonly string path;
        private TextureInfo(UIGeneratorTexture2D texture, string name, string path)
        {
            Texture= texture;
            Name = name;
            this.path = path;
        }
        /// <summary>
        /// 指定したパスから<see cref="TextureInfo"/>のインスタンスを生成する
        /// </summary>
        /// <param name="path">テクスチャのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>が存在しない</exception>
        /// <exception cref="IOException">テクスチャを読み込めなかった</exception>
        /// <returns>指定したテクスチャを格納した<see cref="TextureInfo"/>のインスタンス</returns>
        public static TextureInfo GetInstance(string path)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: path);
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var name = Path.GetFileName(path);
            return new TextureInfo(new UIGeneratorTexture2D(path), name, path);
        }
        /// <summary>
        /// もう一つの<see cref="TextureInfo"/>との同値性を確かめる
        /// </summary>
        /// <param name="other">確認するもう一つの<see cref="TextureInfo"/></param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(TextureInfo other) => path == other.path;
        /// <summary>
        /// パッケージからインスタンス生成する
        /// </summary>
        /// <param name="package">インスタンス生成に用いるパッケージ</param>
        /// <exception cref="ArgumentNullException"><paramref name="package"/>がnull</exception>
        /// <returns>テクスチャ</returns>
        public static TextureInfo FromPackage(PackagedTexture2D package)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, package);
            var e = System.IO.File.Exists(package.Path);
            if(!e) package.Save();
            var result = GetInstance(package.Path);
            if(!e) System.IO.File.Delete(package.Path);
            return result;
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({path})";
    }
}
