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
    /// テクスチャの情報を格納するクラス
    /// 継承不可能
    /// </summary>
    [Serializable]
    public sealed class TextureInfo : IEquatable<TextureInfo>, ISerializable
    {
        #region SerializeName
        private const string S_Name = "S_Name";
        private const string S_Buffer = "S_Buffer";
        private const string S_Path = "S_Path";
        #endregion
        /// <summary>
        /// テクスチャの名前を取得する
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// テクスチャを取得する
        /// </summary>
        public Texture2D Texture { get; private set; }
        private readonly string path;
        /// <summary>
        /// フォントデータのバッファを取得する
        /// </summary>
        public byte[] Buffer { get; }
        private TextureInfo(Texture2D texture, string name, string path)
        {
            Texture= texture;
            Name = name;
            this.path = path;
            Buffer = Engine.File.CreateStaticFile(path).Buffer;
        }
        private TextureInfo(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString(S_Name);
            path = info.GetString(S_Path);
            Buffer = (byte[])info.GetValue(S_Buffer, typeof(byte[]));
            SetTexture();
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
            Central.ThrowHelper.ThrowArgumentNullException(path);
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
        /// <summary>
        /// シリアル化する情報を設定する
        /// </summary>
        /// <param name="info">シリアル化情報の設定先</param>
        /// <param name="context">送信先</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            info.AddValue(S_Name, Name);
            info.AddValue(S_Buffer, Buffer, typeof(byte[]));
            info.AddValue(S_Path, path);
        }
        private void SetTexture()
        {
            var path = fslib.StringHelper.GetRandomString(40) + ".pretexture";
            using (var stream = new FileStream(path, FileMode.CreateNew))
                stream.Write(Buffer, 0, Buffer.Length);
            Texture = Engine.Graphics.CreateTexture2D(path);
            System.IO.File.Delete(path);
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返す
        /// </summary>
        /// <returns>現在のオブジェクトを表す文字列</returns>
        public override string ToString() => $"{Name} ({path})";
    }
}
