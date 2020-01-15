using System;
using System.Runtime.Serialization;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawTextAdditionally(Vector2DF, Color, Font, string, WritingDirection, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingTextInfo : DrawingAdditionaryInfoBase, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Color = "S_Color";
        private const string S_Direction = "S_Direction";
        private const string S_FontIndex = "S_FontIndex";
        private const string S_Position = "S_Position";
        private const string S_Text = "S_Text";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public override DrawingAdditionalMode DrawingAdditionalMode => DrawingAdditionalMode.Text;
        /// <summary>
        /// 表示する座標を取得または設定する
        /// </summary>
        public SerializableVector2DF Position { get; set; } = DataBase.CenterPosition;
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; } = new ColorPlus(ColorSet.White);
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
        private string _text = "AdditionalText";
        /// <summary>
        /// 文字列の方向を取得または設定する
        /// </summary>
        public WritingDirection WritingDirection { get; set; } = WritingDirection.Horizontal;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingTextInfo(int mode, string name) : base(mode, name) { }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private DrawingTextInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Direction, (int)WritingDirection);
            info.AddValue(S_Position, Position);
            info.AddValue(S_Text, Text);
            var fontindex = DataBase.Fonts.IndexOf(FontInfo);
            if (fontindex == -1) fontindex = 0;
            info.AddValue(S_FontIndex, fontindex);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public override void OnDeserialization(object sender)
        {
            if (SeInfo == null) return;
            FontInfo = DataBase.Fonts[SeInfo.GetInt32(S_FontIndex)];
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            Text = SeInfo.GetString(S_Text);
            Position = SeInfo.GetValue<SerializableVector2DF>(S_Position);
            WritingDirection = EnumHelper.FromNumber<WritingDirection>(SeInfo.GetInt32(S_Direction));
            base.OnDeserialization(sender);
        }
    }
}
