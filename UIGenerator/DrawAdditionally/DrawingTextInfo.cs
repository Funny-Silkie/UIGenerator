using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawTextAdditionally(Vector2DF, Color, Font, string, WritingDirection, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingTextInfo : DrawingAdditionaryInfoBase
    {
        /// <summary>
        /// 表示する座標を取得または設定する
        /// </summary>
        public SerializableVector2DF Position { get; set; }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; }
        /// <summary>
        /// 使用するフォントを取得または設定する
        /// </summary>
        public FontInfoBase FontInfo
        {
            get => _fontInfo;
            set => _fontInfo = value ?? DataBase.DefaultFont;
        }
        private FontInfoBase _fontInfo = DataBase.DefaultFont;
        /// <summary>
        /// 描画するテキストを取得または設定する
        /// </summary>
        public string Text
        {
            get => _text;
            set => _text = value ?? "";
        }
        private string _text = "Texts";
        /// <summary>
        /// 文字列の方向を取得または設定する
        /// </summary>
        public WritingDirection WritingDirection { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingTextInfo(int mode, string name) : base(mode, name, DrawingAdditionalMode.Text) { }
    }
}
