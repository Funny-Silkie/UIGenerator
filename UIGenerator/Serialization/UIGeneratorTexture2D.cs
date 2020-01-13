using System;
using System.IO;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// シリアライズ可能なテクスチャのクラス
    /// </summary>
    [Serializable]
    public sealed class UIGeneratorTexture2D : ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion
        private string path;
        private SerializationInfo seInfo;
        /// <summary>
        /// テクスチャを取得する
        /// </summary>
        public Texture2D Texture { get; private set; }
        /// <summary>
        /// 指定したファイルパスからテクスチャを読み込みインスタンスを初期化する
        /// </summary>
        /// <param name="path">読み込むテクスチャのファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルがぞんざいしない</exception>
        /// <exception cref="IOException">テクスチャを読み込めなかった</exception>
        public UIGeneratorTexture2D(string path)
        {
            this.path = path ?? throw new ArgumentNullException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            Texture = Engine.Graphics.CreateTexture2D(path) ?? throw new IOException();
        }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private UIGeneratorTexture2D(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
        }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            info.AddValue(S_Path, path);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public void OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            path = seInfo.GetString(S_Path);
            Texture = Engine.Graphics.CreateTexture2D(path) ?? throw new SerializationException();
            seInfo = null;
        }
        /// <summary>
        /// byte配列で保存するテクスチャに変換する
        /// </summary>
        /// <exception cref="IOException">ファイルの読み込みに失敗した</exception>
        public PackagedTexture2D ToPackageTexture() => new PackagedTexture2D(path);
        public static implicit operator Texture2D(UIGeneratorTexture2D t) => t.Texture;
    }
}
