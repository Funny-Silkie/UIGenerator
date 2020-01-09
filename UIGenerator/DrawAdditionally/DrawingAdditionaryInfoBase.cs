using System;
using System.ComponentModel;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// 追加描画を扱うクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class DrawingAdditionaryInfoBase : IUIGeneratorInfo
    {
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public DrawingAdditionalMode DrawingAdditionalMode { get; }
        [NonSerialized]
        private System.Windows.Forms.Form _handleForm = null;
        /// <summary>
        /// このインスタンスを操作するフォームを取得または設定する
        /// </summary>
        public System.Windows.Forms.Form HandleForm { get => _handleForm; set => _handleForm = value; }
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満</exception>
        public int Mode
        {
            get => _mode;
            set => _mode = value >= 0 ? value : throw new ArgumentOutOfRangeException();
        }
        private int _mode;
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public string Name
        {
            get => _name; 
            set => _name = value ?? throw new ArgumentNullException();
        }
        private string _name;
        /// <summary>
        /// 使用するアルファブレンドの設定を取得または設定する
        /// </summary>
        public AlphaBlendMode AlphaBlend { get; set; }
        /// <summary>
        /// 描画優先度を取得または設定する
        /// </summary>
        public int DrawingPriority { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <param name="drawingAdditionalMode">追加描画のモード</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        protected DrawingAdditionaryInfoBase(int mode, string name, DrawingAdditionalMode drawingAdditionalMode)
        {
            Mode = mode >= 0 ? mode : throw new ArgumentOutOfRangeException();
            Name = name ?? throw new ArgumentNullException();
            DrawingAdditionalMode = drawingAdditionalMode;
        }
        /// <summary>
        /// <see cref="DrawingAdditionaryInfoBase"/>のインスタンスを取得する
        /// </summary>
        /// <param name="drawingAdditionalMode">追加描画のタイプ</param>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="drawingAdditionalMode"/>の値が不正</exception>
        /// <returns></returns>
        public static DrawingAdditionaryInfoBase GetInstance(DrawingAdditionalMode drawingAdditionalMode, int mode, string name)
        {
            switch (drawingAdditionalMode)
            {
                case DrawingAdditionalMode.Arc: return new DrawingArcInfo(mode, name);
                case DrawingAdditionalMode.Circle: return new DrawingCircleInfo(mode, name);
                case DrawingAdditionalMode.Line: return new DrawingLineInfo(mode, name);
                case DrawingAdditionalMode.Rectangle: return new DrawingRectangleInfo(mode, name);
                case DrawingAdditionalMode.RotatedRectangle: return new DrawingRotatedRectangleInfo(mode, name);
                case DrawingAdditionalMode.Sprite: return new DrawingSpriteInfo(mode, name);
                case DrawingAdditionalMode.Text: return new DrawingTextInfo(mode, name);
                case DrawingAdditionalMode.Triangle: return new DrawingTriangleInfo(mode, name);
                default: throw new InvalidEnumArgumentException();
            }
        }
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public abstract void Operate(Layer2D layer);
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public abstract string ToCSharp();
    }
    public partial class DrawingArcInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawArcAdditionally(Center, OuterDiameter, InnerDiameter, Color, VertNum, StartingVerticalAngle, EndingVerticalAngle, Angle, Texture.Texture, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingCircleInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawCircleAdditionally(Center, OuterDiameter, InnerDiameter, Color, VertNum, Angle, Texture.Texture, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingLineInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawLineAdditionally(Point1, Point2, Thickness, Color, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingRectangleInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawRectangleAdditionally(DrawingArea, Color, UV, Texture.Texture, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingRotatedRectangleInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawRotatedRectangleAdditionally(DrawingArea, Color, RotationCenter, Angle, UV, Texture.Texture, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingSpriteInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawSpriteAdditionally(UpperLeftPos, UpperRightPos, LowerLeftPos, LowerRightPos, UpperLeftColor, UpperRightColor, LowerLeftColor, LowerRightColor, UpperLeftUV, UpperRightUV, LowerLeftUV, LowerRightUV, Texture.Texture, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingTextInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawTextAdditionally(Position, Color, FontInfo.Font.Font, Text, WritingDirection, AlphaBlend, DrawingPriority);
        }
    }
    public partial class DrawingTriangleInfo
    {
        /// <summary>
        /// 描画処理を実行する
        /// </summary>
        /// <param name="layer">描画処理を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public override void Operate(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            layer.DrawTriangleAdditionally(Position1, Position2, Position3, Color, UV1, UV2, UV3, Texture.Texture, AlphaBlend, DrawingPriority);
        }
    }
}
