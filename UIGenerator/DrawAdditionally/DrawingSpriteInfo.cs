using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawSpriteAdditionally(Vector2DF, Vector2DF, Vector2DF, Vector2DF, Color, Color, Color, Color, Vector2DF, Vector2DF, Vector2DF, Vector2DF, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingSpriteInfo : DrawingAdditionaryInfoBase
    {
        /// <summary>
        /// 左上の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperLeftPos { get; set; }
        /// <summary>
        /// 右上の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperRightPos { get; set; }
        /// <summary>
        /// 右下の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerRightPos { get; set; }
        /// <summary>
        /// 左下の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerLeftPos { get; set; }
        /// <summary>
        /// 左上の色を取得または設定する
        /// </summary>
        public ColorPlus UpperLeftColor { get; set; }
        /// <summary>
        /// 右上の色を取得または設定する
        /// </summary>
        public ColorPlus UpperRightColor { get; set; }
        /// <summary>
        /// 右下の色を取得または設定する
        /// </summary>
        public ColorPlus LowerRightColor { get; set; }
        /// <summary>
        /// 左下の色を取得または設定する
        /// </summary>
        public ColorPlus LowerLeftColor { get; set; }
        /// <summary>
        /// 左上のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperLeftUV { get; set; }
        /// <summary>
        /// 右上のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperRightUV { get; set; }
        /// <summary>
        /// 右下のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerRightUV { get; set; }
        /// <summary>
        /// 左下のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerLeftUV { get; set; }
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
        public DrawingSpriteInfo(int mode, string name) : base(mode, name, DrawingAdditionalMode.Sprite) { }
    }
}
