using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawTriangleAdditionally(Vector2DF, Vector2DF, Vector2DF, Color, Vector2DF, Vector2DF, Vector2DF, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingTriangleInfo : DrawingAdditionaryInfoBase
    {
        /// <summary>
        /// 頂点の座標の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Position1 { get; set; }
        /// <summary>
        /// 頂点の座標の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Position2 { get; set; }
        /// <summary>
        /// 頂点の座標の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Position3 { get; set; }
        /// <summary>
        /// <see cref="Position1"/>のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UV1 { get; set; }
        /// <summary>
        /// <see cref="Position2"/>のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UV2 { get; set; }
        /// <summary>
        /// <see cref="Position3"/>のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UV3 { get; set; }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; }
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
        public DrawingTriangleInfo(int mode, string name) : base(mode, name, DrawingAdditionalMode.Triangle) { }
    }
}
