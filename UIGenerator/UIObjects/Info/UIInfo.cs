using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// UIとして操作するオブジェクトの基底クラス
    /// </summary>
    [Serializable]
    public abstract class UIInfoBase : IUIGeneratorInfo, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Accesibility = "S_Accesibility";
        #endregion
        /// <summary>
        /// 使用するアクセシビリティを取得または設定する
        /// </summary>
        public AccesibilityType Accesibility { get; set; } = AccesibilityType.Private;
        /// <summary>
        /// このインスタンスを管理するフォームを取得または設定する
        /// </summary>
        public System.Windows.Forms.Form HandleForm { get; set; } = null;
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
        /// シリアライズされたデータを格納するオブジェクトを取得する
        /// </summary>
        protected SerializationInfo SeInfo { get; private set; }
        /// <summary>
        /// 表示するオブジェクト
        /// </summary>
        public abstract Object2D __UIObj { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected UIInfoBase() { }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected UIInfoBase(SerializationInfo info, StreamingContext context)
        {
            SeInfo = info;
        }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            info.AddValue(S_Accesibility, Accesibility);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public virtual void OnDeserialization(object sender)
        {
            if (SeInfo == null) return;
            Accesibility = SeInfo.GetValue<AccesibilityType>(S_Accesibility);
            SeInfo = null;
        }
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
        /// <summary>
        /// 最初のフィールド宣言を行う
        /// </summary>
        /// <returns>C#による最初のフィールド宣言</returns>
        public abstract string ToCSharp_Define();
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public abstract string ToCSharp_Set();
    }
    /// <summary>
    /// UIオブジェクトを管理する基底クラス
    /// </summary>
    /// <typeparam name="T">UIオブジェクトの型</typeparam>
    [Serializable]
    public abstract class UIInfo<T> : UIInfoBase, ISerializable, IDeserializationCallback where T : Object2D, IUIElements
    {
        #region SerializeName
        private const string S_Name = "S_Name";
        private const string S_Mode = "S_Mode";
        private const string S_Object = "S_Object";
        #endregion
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public sealed override string Name
        {
            get => UIObject.Name;
            set => UIObject.Name = value ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満</exception>
        public sealed override int Mode
        {
            get => UIObject.Mode;
            set => UIObject.Mode = value >= 0 ? value : throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// 管理している<see cref="IUIElements"/>のインスタンスを取得する
        /// </summary>
        public T UIObject { get; private set; }
        /// <summary>
        /// <see cref="Object2D"/>として<see cref="UIObject"/>を繋ぐ
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override Object2D __UIObj => UIObject;
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
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected UIInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(S_Mode, Mode);
            info.AddValue(S_Name, Name);
            info.AddValue(S_Object, UIObject, typeof(T));
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public override void OnDeserialization(object sender)
        {
            if (SeInfo == null) return;
            Mode = SeInfo.GetInt32(S_Mode);
            Name = SeInfo.GetString(S_Name);
            UIObject = SeInfo.GetValue<T>(S_Object);
            base.OnDeserialization(sender);
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
}
