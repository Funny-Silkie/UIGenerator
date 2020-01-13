using System;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// ウィンドウを表すクラス
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed class UIWindow : SerializableWindow, IUIElements
    {
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
        public UITypes Type => UITypes.Window;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public UIWindow(int mode, string name) : base(default, new Vector2DI(100, 100))
        {
            Mode = mode < 0 ? throw new ArgumentOutOfRangeException() : mode;
            Name = name ?? throw new ArgumentNullException();
            DrawingPriority = -1;
            GeneratingFlame = true;
            SetColor(ColorSet.WindowDefault);
        }
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
