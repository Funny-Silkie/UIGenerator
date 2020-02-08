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
    public sealed class PackagedDynamicFont : PackagedFont, ISerializable, IDeserializationCallback
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
        public PackagedDynamicFont(string path, ColorPlus color, int size, ColorPlus outLineColor, int outLineSize) : base(path)
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
        public PackagedDynamicFont(string path, byte[] buffer, ColorPlus color, int size, ColorPlus outLineColor, int outLineSize) : base(path, buffer)
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
        private PackagedDynamicFont(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// このインスタンスの複製を作成する
        /// </summary>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        /// <returns>このインスタンスの複製</returns>
        public override PackagedFile Clone()
        {
            ThrowIfDisposed();
            return new PackagedDynamicFont(Path, Buffer, Color, Size, OutLineColor, OutLineSize);
        }
        /// <summary>
        /// <see cref="UIGeneratorFontBase"/>のインスタンスを生成する
        /// </summary>
        /// <param name="path">フォントファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>が存在しない</exception>
        /// <exception cref="IOException">フォントの読み込みに失敗した</exception>
        /// <returns>フォント</returns>
        protected override UIGeneratorFontBase CreateFont(string path) => new UIGeneratorDynamicFont(path, Color, Size, OutLineColor, OutLineSize);
        /// <summary>
        /// もう1つの<see cref="PackagedFile"/>との同値性を判定する
        /// </summary>
        /// <param name="other">同値性を判定するもう一つの<see cref="PackagedFile"/>のインスタンス</param>
        /// <returns>このインスタンスと<paramref name="other"/>が同値だったらtrue，それ以外でfalse</returns>
        /// <remarks>このインスタンス又は<paramref name="other"/>が破棄されている場合無条件でfalseを返す</remarks>
        public override bool Equals(PackagedFile other) => other is PackagedDynamicFont f ? Equals(f) : false;
        private bool Equals(PackagedDynamicFont other) => !IsDisposed && Color == other.Color && Size == other.Size && OutLineColor == other.OutLineColor && OutLineSize == other.OutLineSize && base.Equals(other);
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected override void GetObjectData(SerializationInfo info)
        {
            base.GetObjectData(info);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Size, Size);
            info.AddValue(S_OutLineColor, OutLineColor);
            info.AddValue(S_OutLineSize, OutLineSize);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected override void OnDeserialization()
        {
            if (SeInfo == null) return;
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            Size = SeInfo.GetInt32(S_Size);
            OutLineColor = SeInfo.GetValue<ColorPlus>(S_OutLineColor);
            OutLineSize = SeInfo.GetInt32(S_OutLineSize);
            base.OnDeserialization();
        }
    }
}
