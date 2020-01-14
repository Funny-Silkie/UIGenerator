using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// 追加描画を扱うクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class DrawingAdditionaryInfoBase : IUIGeneratorInfo, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Mode = "S_Mode";
        private const string S_Name = "S_Name";
        private const string S_Priority = "S_Priority";
        private const string S_AlphaBlend = "S_AlphaBlend";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public abstract DrawingAdditionalMode DrawingAdditionalMode { get; }
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
        /// デシリアライズ時の情報を格納するオブジェクトを取得する
        /// </summary>
        protected SerializationInfo SeInfo { get; private set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        protected DrawingAdditionaryInfoBase(int mode, string name)
        {
            Mode = mode >= 0 ? mode : throw new ArgumentOutOfRangeException();
            Name = name ?? throw new ArgumentNullException();
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
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected DrawingAdditionaryInfoBase(SerializationInfo info, StreamingContext context)
        {
            SeInfo = info;
        }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            info.AddValue(S_Mode, Mode);
            info.AddValue(S_Name, Name);
            info.AddValue(S_Priority, DrawingPriority);
            info.AddValue(S_AlphaBlend, (int)AlphaBlend);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public virtual void OnDeserialization(object sender)
        {
            if (SeInfo == null) return;
            Mode = SeInfo.GetInt32(S_Mode);
            Name = SeInfo.GetString(S_Name);
            DrawingPriority = SeInfo.GetInt32(S_Priority);
            AlphaBlend = EnumHelper.FromNumber<AlphaBlendMode>(SeInfo.GetInt32(S_AlphaBlend));
            SeInfo = null;
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
