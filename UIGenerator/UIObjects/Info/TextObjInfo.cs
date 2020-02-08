using System;
using System.Runtime.Serialization;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="UIText"/>を参照に持つ<see cref="UIInfo{T}"/>の実装
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed partial class TextObjInfo : UIInfo<UIText>, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_FontIndex = "S_FontIndex";
        #endregion
        /// <summary>
        /// オブジェクトのタイプを取得する
        /// </summary>
        public override UITypes Type => UITypes.Text;
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
        /// 中心座標を取得または設定する
        /// </summary>
        public Vector2DF CenterPosition
        {
            get => UIObject.CenterPosition;
            set => UIObject.CenterPosition = value;
        }
        /// <summary>
        /// 大きさを取得または設定する
        /// </summary>
        public Vector2DF Size
        {
            get => UIObject.Size;
            set
            {
                var size = UIObject.Font.CalcTextureSize(UIObject.Text, UIObject.WritingDirection).To2DF();
                UIObject.Scale = new Vector2DF(value.X / size.X, value.Y / size.Y);
            }
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
        /// 文字列の表示方向を取得または設定する
        /// </summary>
        public WritingDirection WritingDirection
        {
            get => UIObject.WritingDirection;
            set => UIObject.WritingDirection = value;
        }
        /// <summary>
        /// 表示する文字列を取得または設定する
        /// </summary>
        public string Text
        {
            get => UIObject.Text;
            set => UIObject.Text = value;
        }
        /// <summary>
        /// 使用するフォントの情報を格納するインスタンスを取得または設定する
        /// </summary>
        public FontInfoBase FontInfo
        {
            get => _fontInfo;
            set
            {
                if (value == null) value = DataBase.DefaultFont;
                _fontInfo = value;
                UIObject.Font = value.Font;
            }
        }
        private FontInfoBase _fontInfo = DataBase.DefaultFont;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public TextObjInfo(int mode, string name) : base(UITypes.Text, mode, name)
        {

        }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private TextObjInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            var fontIndex = DataBase.Fonts.IndexOf(FontInfo);
            if (fontIndex == -1) fontIndex = 0;
            info.AddValue(S_FontIndex, fontIndex);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected override void OnDeserialization()
        {
            if (SeInfo == null) return;
            var index = SeInfo.GetInt32(S_FontIndex);
            base.OnDeserialization();
            FontInfo = DataBase.Fonts[index];
        }
    }
}
