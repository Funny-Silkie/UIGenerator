using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// UIとして操作するオブジェクトの基底クラス
    /// </summary>
    [Serializable]
    public abstract class UIInfoBase
    {
        [NonSerialized]
        private System.Windows.Forms.Form handleForm = null;
        /// <summary>
        /// このインスタンスを管理するフォームを取得または設定する
        /// </summary>
        public System.Windows.Forms.Form HandleForm { get => handleForm; set => handleForm = value; }
        /// <summary>
                                                                                                              /// このインスタンスの管理するオブジェクトのタイプを取得する
                                                                                                              /// </summary>
        public abstract UITypes Type { get; }
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        public abstract string Name { get; set; }
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        public abstract int Mode { get; set; }
        /// <summary>
        /// 表示するオブジェクト
        /// </summary>
        internal abstract Object2D UIObj { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected private UIInfoBase() { }
        /// <summary>
        /// インスタンスを取得する
        /// </summary>
        /// <param name="type">取得するUIオブジェクトのタイプ</param>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="type"/>が無効な値</exception>
        /// <returns><see cref="UIInfoBase"/>から派生したインスタンス</returns>
        public static UIInfoBase GetInstance(UITypes type, int mode, string name)
        {
            switch (type)
            {
                case UITypes.Text: return new TextObjInfo(mode, name);
                case UITypes.Texture: return new TextureObjInfo(mode, name);
                case UITypes.Window: return new WindowInfo(mode, name);
                default: throw new InvalidEnumArgumentException();
            }
        }
    }
    /// <summary>
    /// UIオブジェクトを管理する基底クラス
    /// </summary>
    /// <typeparam name="T">UIオブジェクトの型</typeparam>
    [Serializable]
    public abstract class UIInfo<T> : UIInfoBase where T : Object2D, IUIElements
    {
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        public sealed override string Name
        {
            get => UIObject.Name;
            set => UIObject.Name = value;
        }
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        public sealed override int Mode
        {
            get => UIObject.Mode;
            set => UIObject.Mode = value;
        }
        /// <summary>
        /// 管理している<see cref="IUIElements"/>のインスタンスを取得する
        /// </summary>
        public T UIObject { get; }
        /// <summary>
        /// <see cref="Object2D"/>として<see cref="UIObject"/>を繋ぐ
        /// </summary>
        internal sealed override Object2D UIObj => UIObject;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="type">管理するUIオブジェクトのタイプ</param>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="type"/>の値が無効</exception>
        protected UIInfo(UITypes type, int mode, string name) : base()
        {
            UIObject = (T)GetUIElement(type, mode, name);
            Mode = mode >= 0 ? mode : throw new ArgumentOutOfRangeException();
            Name = name ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// 指定したタイプの<see cref="IUIElements"/>を返す
        /// </summary>
        private IUIElements GetUIElement(UITypes type, int mode, string name)
        {
            switch (type)
            {
                case UITypes.Window: return new UIWindow(mode, name);
                case UITypes.Text: return new UIText(mode, name);
                case UITypes.Texture: return new UITexture(mode, name);
                default: throw new InvalidEnumArgumentException();
            }
        }
    }
    /// <summary>
    /// <see cref="UIWindow"/>を参照に持つ<see cref="UIInfo{T}"/>の実装
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed class WindowInfo : UIInfo<UIWindow>
    {
        /// <summary>
        /// オブジェクトのタイプを取得する
        /// </summary>
        public override UITypes Type => UITypes.Window;
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
        /// 大きさを取得または設定する
        /// </summary>
        public Vector2DF Size
        {
            get => UIObject.Size;
            set => UIObject.Size = value;
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
        /// 枠線の色を取得または設定する
        /// </summary>
        public Color LineColor
        {
            get => UIObject.LineColor;
            set => UIObject.LineColor = value;
        }
        /// <summary>
        /// 枠線の大きさを取得または設定する
        /// </summary>
        public int LineThickness
        {
            get => UIObject.Thickness;
            set => UIObject.Thickness = value;
        }
        /// <summary>
        /// 枠線の有無を取得または設定する
        /// </summary>
        public bool GeneratingFlame
        {
            get => UIObject.GeneratingFlame;
            set => UIObject.GeneratingFlame = value;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public WindowInfo(int mode, string name) : base(UITypes.Window, mode, name)
        {

        }
    }
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
        /// 使用するフォントを取得または設定する
        /// </summary>
        public Font Font
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
    }
    /// <summary>
    /// <see cref="UITexture"/>を参照に持つ<see cref="UIInfo{T}"/>の実装
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed class TextureObjInfo : UIInfo<UITexture>
    {
        /// <summary>
        /// オブジェクトのタイプを取得する
        /// </summary>
        public override UITypes Type => UITypes.Texture;
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
            set => UIObject.Size = value;
        }
        /// <summary>
        /// 使用するテクスチャを取得または設定する
        /// </summary>
        public Texture2D Texture
        {
            get => UIObject.Texture;
            set => UIObject.Texture = value;
        }
        /// <summary>
        /// 使用するテクスチャの情報を格納するインスタンスを取得または設定する
        /// </summary>
        internal TextureInfo TextureInfo
        {
            get => _textureInfo;
            set
            {
                if (value == null) value = DataBase.DefaultTexture;
                _textureInfo = value;
                Texture = value.Texture;
            }
        }
        private TextureInfo _textureInfo;
        /// <summary>
        /// 描画優先度を取得または設定する
        /// </summary>
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public TextureObjInfo(int mode, string name) : base(UITypes.Texture, mode, name)
        {

        }
    }
}
