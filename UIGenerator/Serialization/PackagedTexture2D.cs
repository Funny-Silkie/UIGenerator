using System;
using System.IO;
using System.Runtime.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// byte配列を用いてテクスチャをシリアライズするためのクラス
    /// </summary>
    [Serializable]
    public sealed class PackagedTexture2D : PackagedFile, ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// 指定したパスからデータを読み込んでインスタンスを初期化する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="IOException">ファイルが読み込めなかった</exception>
        public PackagedTexture2D(string path) : base(path) { }
        /// <summary>
        /// byte配列とファイルパスからインスタンスを初期化する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="buffer">ファイルのデータ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="buffer"/>がnull</exception>
        public PackagedTexture2D(string path, byte[] buffer) : base(path, buffer) { }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private PackagedTexture2D(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// このインスタンスの複製を作成する
        /// </summary>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        /// <returns>このインスタンスの複製</returns>
        public override PackagedFile Clone()
        {
            ThrowIfDisposed();
            return new PackagedTexture2D(Path, Buffer);
        }
        /// <summary>
        /// テクスチャに変換する
        /// </summary>
        /// <returns>テクスチャ</returns>
        public UIGeneratorTexture2D ToTexture() => new UIGeneratorTexture2D(Path);
    }
}
