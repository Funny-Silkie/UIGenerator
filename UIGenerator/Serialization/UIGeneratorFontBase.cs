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
        private string path;
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
            this.path = path ?? throw new ArgumentNullException();
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
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            info.AddValue(S_Path, path);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public virtual void OnDeserialization(object sender)
        {
            if (SeInfo == null) return;
            path = SeInfo.GetString(S_Path);
            Font = GetFont(path) ?? throw new SerializationException();
            SeInfo = null;
        }
        /// <summary>
        /// byte配列で保存するフォントに変換する
        /// </summary>
        /// <exception cref="IOException">ファイルの読み込みに失敗した</exception>
        public PackagedFont ToPackageFont() => CreatePackageFont(path);
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
