using System;
using System.IO;
using System.Runtime.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// byte配列を用いて静的フォントデータをシリアライズするためのクラス
    /// </summary>
    [Serializable]
    public sealed class PackageStaticFont : PackageFont, ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// 指定したパスからデータを読み込んでインスタンスを初期化する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="IOException">ファイルが読み込めなかった</exception>
        public PackageStaticFont(string path) : base(path) { }
        /// <summary>
        /// byte配列とファイルパスからインスタンスを初期化する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="buffer">ファイルのデータ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="buffer"/>がnull</exception>
        public PackageStaticFont(string path, byte[] buffer) : base(path, buffer) { }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private PackageStaticFont(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
