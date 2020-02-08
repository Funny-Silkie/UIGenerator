using System;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawLineAdditionally(Vector2DF, Vector2DF, float, Color, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingLineInfo : DrawingAdditionaryInfoBase, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Color = "S_Color";
        private const string S_Point1 = "S_Point1";
        private const string S_Point2 = "S_Point2";
        private const string S_Thickness = "S_Thickness";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public override DrawingAdditionalMode DrawingAdditionalMode => DrawingAdditionalMode.Line;
        /// <summary>
        /// 端点の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Point1 { get; set; } = DataBase.CenterPosition - new Vector2DF(50, 0);
        /// <summary>
        /// 端点の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Point2 { get; set; } = DataBase.CenterPosition + new Vector2DF(50, 0);
        /// <summary>
        /// 線の太さを取得または設定する
        /// </summary>
        public float Thickness { get; set; } = 3;
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; } = new ColorPlus(ColorSet.White);
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingLineInfo(int mode, string name) : base(mode, name) { }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private DrawingLineInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected override void GetObjectData(SerializationInfo info)
        {
            base.GetObjectData(info);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Point1, Point1);
            info.AddValue(S_Point2, Point2);
            info.AddValue(S_Thickness, Thickness);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected override void OnDeserialization()
        {
            if (SeInfo == null) return;
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            Point1 = SeInfo.GetValue<SerializableVector2DF>(S_Point1);
            Point2 = SeInfo.GetValue<SerializableVector2DF>(S_Point2);
            Thickness = SeInfo.GetSingle(S_Thickness);
            base.OnDeserialization();
        }
    }
}
