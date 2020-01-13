using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="UIWindow"/>を参照に持つ<see cref="UIInfo{T}"/>の実装
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed partial class WindowInfo : UIInfo<UIWindow>
    {
        /// <summary>
        /// オブジェクトのタイプを取得する
        /// </summary>
        public override UITypes Type => UITypes.Window;
        /// <summary>
        /// クリック可能かどうかを取得または設定する
        /// </summary>
        public bool IsClickable
        {
            get => UIObject.IsClickable;
            set => UIObject.IsClickable = value;
        }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public Color Color
        {
            get => UIObject.Color;
            set => UIObject.Color = value;
        }
        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public Vector2DF Position
        {
            get => UIObject.Position;
            set => UIObject.Position = value;
        }
        /// <summary>
        /// 大きさを取得または設定する
        /// </summary>
        public Vector2DF Size
        {
            get => UIObject.Size;
            set => UIObject.Size = value;
        }
        /// <summary>
        /// 描画優先度を取得または設定する
        /// </summary>
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        /// <summary>
        /// 枠線の色を取得または設定する
        /// </summary>
        public Color LineColor
        {
            get => UIObject.LineColor;
            set => UIObject.LineColor = value;
        }
        /// <summary>
        /// 枠線の大きさを取得または設定する
        /// </summary>
        public int LineThickness
        {
            get => UIObject.Thickness;
            set => UIObject.Thickness = value;
        }
        /// <summary>
        /// 枠線の有無を取得または設定する
        /// </summary>
        public bool GeneratingFlame
        {
            get => UIObject.GeneratingFlame;
            set => UIObject.GeneratingFlame = value;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public WindowInfo(int mode, string name) : base(UITypes.Window, mode, name)
        {

        }
    }
}
