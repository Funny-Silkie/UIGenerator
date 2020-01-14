using System;
using System.IO;
using System.Runtime.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// byte配列を用いてフォントデータをシリアライズするためのクラス
    /// </summary>
    [Serializable]
    public abstract class PackagedFont : PackagedFile, ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// 指定したパスからデータを読み込んでインスタンスを初期化する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="IOException">ファイルが読み込めなかった</exception>
        protected PackagedFont(string path) : base(path) { }
        /// <summary>
        /// byte配列とファイルパスからインスタンスを初期化する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="buffer">ファイルのデータ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="buffer"/>がnull</exception>
        protected PackagedFont(string path, byte[] buffer):  base(path, buffer) { }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected PackagedFont(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// <see cref="UIGeneratorFontBase"/>のインスタンスを生成する
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>が存在しない</exception>
        /// <exception cref="IOException">フォントの読み込みに失敗した</exception>
        /// <returns>フォント</returns>
        protected abstract UIGeneratorFontBase CreateFont(string path);
        /// <summary>
        /// フォントに変換する
        /// </summary>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        public UIGeneratorFontBase ToFont() => IsDisposed ? throw new ObjectDisposedException(GetType().ToString()) : CreateFont(Path);
    }
}
