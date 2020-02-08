using System;
using System.IO;
using System.Runtime.Serialization;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// シリアライズ可能なフォントの基底クラス
    /// </summary>
    [Serializable]
    public abstract class UIGeneratorFontBase : ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Path = "S_Path";
        #endregion
        /// <summary>
        /// パスを取得する
        /// </summary>
        public string Path { get; private set; }
        /// <summary>
        /// 使用できるフォントを取得または設定する
        /// </summary>
        public Font Font { get; protected set; }
        /// <summary>
        /// デシリアライズ時の情報を格納するオブジェクトを取得する
        /// </summary>
        protected SerializationInfo SeInfo { get; private set; }
        /// <summary>
        /// 指定したファイルパスからフォントを読み込みインスタンスを初期化する
        /// </summary>
        /// <param name="path">使用するファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        protected UIGeneratorFontBase(string path)
        {
            this.Path = path ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected UIGeneratorFontBase(SerializationInfo info, StreamingContext context)
        {
            SeInfo = info;
        }
        /// <summary>
        /// 指定したパスからフォントを読み込む
        /// </summary>
        /// <param name="path">使用するパス</param>
        /// <returns>読み込まれたフォント</returns>
        protected abstract Font GetFont(string path);
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected virtual void GetObjectData(SerializationInfo info)
        {
            if (info == null) throw new ArgumentNullException();
            info.AddValue(S_Path, Path);
        }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info);
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected virtual void OnDeserialization()
        {
            if (SeInfo == null) return;
            Path = SeInfo.GetString(S_Path);
            Font = GetFont(Path) ?? throw new SerializationException();
            SeInfo = null;
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization();
        /// <summary>
        /// byte配列で保存するフォントに変換する
        /// </summary>
        /// <exception cref="IOException">ファイルの読み込みに失敗した</exception>
        public PackagedFont ToPackageFont() => CreatePackageFont(Path);
        /// <summary>
        /// パッケージ化する
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>が存在しない</exception>
        /// <exception cref="IOException">読み込みに失敗した</exception>
        /// <returns>パッケージ化されたフォント</returns>
        protected abstract PackagedFont CreatePackageFont(string path);
        public static implicit operator Font(UIGeneratorFontBase f) => f.Font;
    }
}
