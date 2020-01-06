using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="UIText"/>を参照に持つ<see cref="UIInfo{T}"/>の実装
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed class TextObjInfo : UIInfo<UIText>
    {
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
        public ColorPlus Color
        {
            get => UIObject.Color;
            set => UIObject.Color = value;
        }
        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public SerializableVector2DF Position
        {
            get => UIObject.Position;
            set => UIObject.Position = value;
        }
        /// <summary>
        /// 中心座標を取得または設定する
        /// </summary>
        public SerializableVector2DF CenterPosition
        {
            get => UIObject.CenterPosition;
            set => UIObject.CenterPosition = value;
        }
        /// <summary>
        /// 大きさを取得または設定する
        /// </summary>
        public SerializableVector2DF Size
        {
            get => UIObject.Size;
            set
            {
                var size = UIObject.Font.Font.CalcTextureSize(UIObject.Text, UIObject.WritingDirection).To2DF();
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
        /// 使用するフォントを取得または設定する
        /// </summary>
        public SerializableFont Font
        {
            get => UIObject.Font;
            set => UIObject.Font = value;
        }
        /// <summary>
        /// 使用するフォントの情報を格納するインスタンスを取得または設定する
        /// </summary>
        internal FontInfoBase FontInfo
        {
            get => _fontInfo;
            set
            {
                if (value == null) value = DataBase.DefaultFont;
                _fontInfo = value;
                Font = value.Font;
            }
        }
        private FontInfoBase _fontInfo;
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
        /// 最初のフィールド宣言を行う
        /// </summary>
        /// <returns>C#による最初のフィールド宣言</returns>
        public override string ToCSharp_Define() => $"{CSharpCodeProvider.FromAccesibility(Accesibility)} UIText text_{Mode}_{Name};";
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp_Set() =>
            $"text_{Mode}_{Name} = new UIText({Mode}, {Name})\n" +
             "{\n" +
            $"    Position = new Vector2DF{Position},\n" +
            $"    CenterPosition = new Vector2DF{CenterPosition},\n" +
            $"    Color = new Color({Color.R}, {Color.G}, {Color.B}, {Color.A}),\n" +
            $"    WritingDirection = {WritingDirection},\n" +
            $"    Text = {Text},\n" +
            $"    IsClickable = {IsClickable},\n" +
            $"    Size = new Vector2DF{Size},\n" +
            $"    DrawingPriority = {DrawingPriority}\n" +
             "}";
    }
}
