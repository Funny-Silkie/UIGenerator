using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawCircleAdditionally(Vector2DF, float, float, Color, int, float, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed class DrawingCircleInfo : DrawingAdditionaryInfoBase
    {
        /// <summary>
        /// 中心の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF Center { get; set; }
        /// <summary>
        /// 外側の半径を取得または設定する
        /// </summary>
        public float OuterDiameter { get; set; }
        /// <summary>
        /// 内側の半径を取得または設定する
        /// </summary>
        public float InnerDiameter { get; set; }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; }
        public int VertNum { get; set; }
        /// <summary>
        /// 描画角度を取得または設定する
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
        private TextureInfo _texture;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingCircleInfo(int mode, string name) : base(mode, name, DrawingAdditionalMode.Circle) { }
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => throw new NotImplementedException();
    }
}
