using System;
using System.IO;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// シリアライズ可能な動的フォントを扱うクラス
    /// </summary>
    [Serializable]
    public sealed class UIGeneratorDynamicFont : UIGeneratorFontBase, ISerializable, IDeserializationCallback
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
        /// 指定したファイルパスからフォントを読み込みインスタンスを初期化する
        /// </summary>
        /// <param name="path">使用するファイルパス</param>
        /// <param name="color">フォントの色</param>
        /// <param name="size">フォントサイズ</param>
        /// <param name="outLineColor">枠線の色</param>
        /// <param name="outLineSize">枠線の太さ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>または<paramref name="outLineSize"/>が0以下</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが存在しない</exception>
        /// <exception cref="IOException">フォントを読み込めなかった</exception>
        public UIGeneratorDynamicFont(string path, ColorPlus color, int size, ColorPlus outLineColor, int outLineSize) : base(path)
        {
            if (size <= 0 || outLineSize <= 0) throw new ArgumentOutOfRangeException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            Color = color;
            Size = size;
            OutLineColor = outLineColor;
            OutLineSize = outLineSize;
            Font = GetFont(path) ?? throw new IOException();
        }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private UIGeneratorDynamicFont(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// 指定したパスからフォントを読み込む
        /// </summary>
        /// <param name="path">使用するパス</param>
        /// <returns>読み込まれたフォント</returns>
        protected override Font GetFont(string path) => Engine.Graphics.CreateDynamicFont(path, Size, Color, OutLineSize, OutLineColor);
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
