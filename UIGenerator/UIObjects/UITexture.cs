using System;
using System.Runtime.Serialization;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// テクスチャを表すクラス
    /// 継承不可
    /// </summary>
    [Serializable]
    public class UITexture : ClickableTexture, IUIElements, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_CenterPosition = "S_CenterPosition";
        private const string S_Color = "S_Color";
        private const string S_IsClickable = "S_IsClickable";
        private const string S_Mode = "S_Mode";
        private const string S_Name = "S_Name";
        private const string S_Position = "S_Position";
        private const string S_DrawingPriority = "S_DrawingPriority";
        private const string S_Scale = "S_Scale";
        #endregion
        private SerializationInfo seInfo;
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        public int Mode { get; set; }
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// オブジェクトのタイプを取得または設定する
        /// </summary>
        public UITypes Type => UITypes.Texture;
        /// <summary>
        /// マウス左ボタンでクリックされたときのイベント
        /// </summary>
        public event EventHandler<ClickArg> LeftPushed;
        /// <summary>
        /// マウス右ボタンでクリックされたときのイベント
        /// </summary>
        public event EventHandler<ClickArg> RightPushed;
        /// <summary>
        /// マウス中央ボタンでクリックされたときのイベント
        /// </summary>
        public event EventHandler<ClickArg> MiddlePushed;
        /// <summary>
        /// マウス左ボタンでクリックが終わったときのイベント
        /// </summary>
        public event EventHandler<ClickArg> LeftReleased;
        /// <summary>
        /// マウス右ボタンでクリックが終わったときのイベント
        /// </summary>
        public event EventHandler<ClickArg> RightReleased;
        /// <summary>
        /// マウス中央ボタンでクリックが終わったときのイベント
        /// </summary>
        public event EventHandler<ClickArg> MiddleReleased;
        /// <summary>
        /// マウス左ボタンでクリックされているときのイベント
        /// </summary>
        public event EventHandler<ClickArg> LeftHolded;
        /// <summary>
        /// マウス右ボタンでクリックされているときのイベント
        /// </summary>
        public event EventHandler<ClickArg> RightHolded;
        /// <summary>
        /// マウス中央ボタンでクリックされているときのイベント
        /// </summary>
        public event EventHandler<ClickArg> MiddleHolded;
        /// <summary>
        /// マウスカーソルと重なったときのイベント
        /// </summary>
        public event EventHandler MouseEnter;
        /// <summary>
        /// マウスカーソルと重なっているときのイベント
        /// </summary>
        public event EventHandler MouseStay;
        /// <summary>
        /// マウスカーソルとの重なりが解除されたときのイベント
        /// </summary>
        public event EventHandler MouseExit;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public UITexture(int mode, string name) : base(DataBase.DefaultTexture.Texture)
        {
            Mode = mode < 0 ? throw new ArgumentOutOfRangeException() : mode;
            Name = name ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private UITexture(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
        }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            info.AddValue(S_CenterPosition, (SerializableVector2DF)CenterPosition);
            info.AddValue(S_Color, (ColorPlus)Color);
            info.AddValue(S_DrawingPriority, DrawingPriority);
            info.AddValue(S_IsClickable, IsClickable);
            info.AddValue(S_Mode, Mode);
            info.AddValue(S_Name, Name);
            info.AddValue(S_Position, (SerializableVector2DF)Position);
            info.AddValue(S_Scale, (SerializableVector2DF)Scale);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            CenterPosition = seInfo.GetValue<SerializableVector2DF>(S_CenterPosition);
            Color = seInfo.GetValue<ColorPlus>(S_Color);
            DrawingPriority = seInfo.GetInt32(S_DrawingPriority);
            IsClickable = seInfo.GetBoolean(S_IsClickable);
            Mode = seInfo.GetInt32(S_Mode);
            Name = seInfo.GetString(S_Name);
            Position = seInfo.GetValue<SerializableVector2DF>(S_Position);
            Scale = seInfo.GetValue<SerializableVector2DF>(S_Scale);
            seInfo = null;
        }
        Object2D IUIElements.AsObject2D() => this;
        protected override void OnCursorEnter() => MouseEnter?.Invoke(this, EventArgs.Empty);
        protected override void OnCursorExit() => MouseExit?.Invoke(this, EventArgs.Empty);
        protected override void OnCursorStay() => MouseStay?.Invoke(this, EventArgs.Empty);
        protected override void OnLeftPushed() => LeftPushed?.Invoke(this, new ClickArg(MouseButtons.ButtonLeft, ButtonState.Push));
        protected override void OnLeftHolded() => LeftHolded?.Invoke(this, new ClickArg(MouseButtons.ButtonLeft, ButtonState.Hold));
        protected override void OnLeftReleased() => LeftReleased?.Invoke(this, new ClickArg(MouseButtons.ButtonLeft, ButtonState.Release));
        protected override void OnRightPushed() => RightPushed?.Invoke(this, new ClickArg(MouseButtons.ButtonRight, ButtonState.Push));
        protected override void OnRightHolded() => RightHolded?.Invoke(this, new ClickArg(MouseButtons.ButtonRight, ButtonState.Hold));
        protected override void OnRightReleased() => RightReleased?.Invoke(this, new ClickArg(MouseButtons.ButtonRight, ButtonState.Release));
        protected override void OnMiddlePushed() => MiddlePushed?.Invoke(this, new ClickArg(MouseButtons.ButtonMiddle, ButtonState.Push));
        protected override void OnMiddleHolded() => MiddleHolded?.Invoke(this, new ClickArg(MouseButtons.ButtonMiddle, ButtonState.Hold));
        protected override void OnMiddleReleased() => MiddleReleased?.Invoke(this, new ClickArg(MouseButtons.ButtonMiddle, ButtonState.Release));
    }
}
