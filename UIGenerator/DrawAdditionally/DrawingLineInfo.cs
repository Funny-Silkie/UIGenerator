using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawLineAdditionally(Vector2DF, Vector2DF, float, Color, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingLineInfo : DrawingAdditionaryInfoBase
    {
        /// <summary>
        /// 端点の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Point1 { get; set; }
        /// <summary>
        /// 端点の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Point2 { get; set; }
        /// <summary>
        /// 線の太さを取得または設定する
        /// </summary>
        public float Thickness { get; set; }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingLineInfo(int mode, string name) : base(mode, name, DrawingAdditionalMode.Line) { }
    }
}
