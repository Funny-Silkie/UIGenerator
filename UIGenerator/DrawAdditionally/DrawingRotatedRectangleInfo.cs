using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawRotatedRectangleAdditionally(RectF, Color, Vector2DF, float, RectF, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingRotatedRectangleInfo : DrawingAdditionaryInfoBase
    {
        /// <summary>
        /// 描画エリアを取得または設定する
        /// </summary>
        public SerializableRectF DrawingArea { get; set; } = new SerializableRectF(DataBase.CenterPosition, new Vector2DF(100, 100));
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; } = new ColorPlus(ColorSet.White);
        public SerializableRectF UV { get; set; }
        public SerializableVector2DF RotationCenter { get; set; } = new Vector2DF(50, 50);
        /// <summary>
        /// 回転角度を取得または設定する
        /// </summary>
        public float Angle { get; set; }
        /// <summary>
        /// 使用するテクスチャの情報を取得または設定する
        /// </summary>
        public TextureInfo Texture
        {
            get => _texture;
            set => _texture = value ?? DataBase.DefaultTexture;
        }
        private TextureInfo _texture = DataBase.DefaultTexture;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingRotatedRectangleInfo(int mode, string name) : base(mode, name, DrawingAdditionalMode.RotatedRectangle) { }
    }
}
