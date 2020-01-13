using fslib;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// byte配列を用いて動的フォントデータをシリアライズするためのクラス
    /// </summary>
    [Serializable]
    public sealed class PackageDynamicFont : PackageFont, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Color = "S_Color";
        private const string S_OutLineColor = "S_OutLineColor";
        private const string S_OutLineSize = "S_OutLineSize";
        private const string S_Size = "S_Size";
        #endregion
        /// <summary>
        /// 色を取得する
        /// </summary>
        public ColorPlus Color { get; private set; }
        /// <summary>
        /// 枠線の太さを取得する
        /// </summary>
        public int OutLineSize { get; private set; }
        /// <summary>
        /// 枠線の色を取得する
        /// </summary>
        public ColorPlus OutLineColor { get; private set; }
        /// <summary>
        /// 大きさを取得する
        /// </summary>
        public int Size { get; private set; }
        /// <summary>
        /// 指定したパスからデータを読み込んでインスタンスを初期化する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <param name="color">フォントの色</param>
        /// <param name="size">フォントサイズ</param>
        /// <param name="outLineColor">枠線の色</param>
        /// <param name="outLineSize">枠線の太さ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>または<paramref name="outLineSize"/>が0以下</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="IOException">ファイルが読み込めなかった</exception>
        public PackageDynamicFont(string path, ColorPlus color, int size, ColorPlus outLineColor, int outLineSize) : base(path)
        {
            if (size <= 0 || outLineSize <= 0) throw new ArgumentOutOfRangeException();
            Color = color;
            Size = size;
            OutLineColor = outLineColor;
            OutLineSize = outLineSize;
        }
        /// <summary>
        /// byte配列とファイルパスからインスタンスを初期化する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="buffer">ファイルのデータ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="buffer"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>または<paramref name="outLineSize"/>が0以下</exception>
        public PackageDynamicFont(string path, byte[] buffer, ColorPlus color, int size, ColorPlus outLineColor, int outLineSize) : base(path, buffer)
        {
            if (size <= 0 || outLineSize <= 0) throw new ArgumentOutOfRangeException();
            Color = color;
            Size = size;
            OutLineColor = outLineColor;
            OutLineSize = outLineSize;
        }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private PackageDynamicFont(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// もう1つの<see cref="PackagedFile"/>との同値性を判定する
        /// </summary>
        /// <param name="other">同値性を判定するもう一つの<see cref="PackagedFile"/>のインスタンス</param>
        /// <returns>このインスタンスと<paramref name="other"/>が同値だったらtrue，それ以外でfalse</returns>
        /// <remarks>このインスタンス又は<paramref name="other"/>が破棄されている場合無条件でfalseを返す</remarks>
        public override bool Equals(PackagedFile other) => other is PackageDynamicFont f ? Equals(f) : false;
        private bool Equals(PackageDynamicFont other) => Color == other.Color && Size == other.Size && OutLineColor == other.OutLineColor && OutLineSize == other.OutLineSize && base.Equals(other);
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Size, Size);
            info.AddValue(S_OutLineColor, OutLineColor);
            info.AddValue(S_OutLineSize, OutLineSize);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public override void OnDeserialization(object sender)
        {
            if (SeInfo == null) return;
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            Size = SeInfo.GetInt32(S_Size);
            OutLineColor = SeInfo.GetValue<ColorPlus>(S_OutLineColor);
            OutLineSize = SeInfo.GetInt32(S_OutLineSize);
            base.OnDeserialization(sender);
        }
    }
}
