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
    /// テクスチャの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    public sealed class TextureInfo : IEquatable<TextureInfo>
    {
        /// <summary>
        /// テクスチャの名前を取得する
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// テクスチャを取得する
        /// </summary>
        public Texture2D Texture { get; }
        private readonly string path;
        private TextureInfo(Texture2D texture, string name, string path)
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
            Central.ThrowHelper.ThrowArgumentNullException(path, null);
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            var texture = Engine.Graphics.CreateTexture2D(path) ?? throw new IOException();
            var name = Path.GetFileName(path);
            return new TextureInfo(texture, name, path);
        }
        /// <summary>
        /// もう一つの<see cref="TextureInfo"/>との同値性を確かめる
        /// </summary>
        /// <param name="other">確認するもう一つの<see cref="TextureInfo"/></param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(TextureInfo other) => path == other.path;
    }
}
