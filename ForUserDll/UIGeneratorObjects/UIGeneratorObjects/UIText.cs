using System;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// テキストを表すクラス
    /// 継承不可
    /// </summary>
    public sealed class UIText : ClickableText
    {
        /// <summary>
        /// 表示モードを取得する
        /// </summary>
        public int Mode { get; }
        /// <summary>
        /// 名前を取得する
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public UIText(int mode, string name) : base()
        {
            Mode = mode < 0 ? throw new ArgumentOutOfRangeException() : mode;
            Name = name ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// マウス左ボタンでクリックされたときのイベント
        /// </summary>
        public event EventHandler LeftPushed;
        /// <summary>
        /// マウス右ボタンでクリックされたときのイベント
        /// </summary>
        public event EventHandler RightPushed;
        /// <summary>
        /// マウス中央ボタンでクリックされたときのイベント
        /// </summary>
        public event EventHandler MiddlePushed;
        /// <summary>
        /// マウス左ボタンでクリックが終わったときのイベント
        /// </summary>
        public event EventHandler LeftReleased;
        /// <summary>
        /// マウス右ボタンでクリックが終わったときのイベント
        /// </summary>
        public event EventHandler RightReleased;
        /// <summary>
        /// マウス中央ボタンでクリックが終わったときのイベント
        /// </summary>
        public event EventHandler MiddleReleased;
        /// <summary>
        /// マウス左ボタンでクリックされているときのイベント
        /// </summary>
        public event EventHandler LeftHolded;
        /// <summary>
        /// マウス右ボタンでクリックされているときのイベント
        /// </summary>
        public event EventHandler RightHolded;
        /// <summary>
        /// マウス中央ボタンでクリックされているときのイベント
        /// </summary>
        public event EventHandler MiddleHolded;
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
        protected override void OnCursorEnter() => MouseEnter?.Invoke(this, EventArgs.Empty);
        protected override void OnCursorExit() => MouseExit?.Invoke(this, EventArgs.Empty);
        protected override void OnCursorStay() => MouseStay?.Invoke(this, EventArgs.Empty);
        protected override void OnLeftPushed() => LeftPushed?.Invoke(this, EventArgs.Empty);
        protected override void OnLeftHolded() => LeftHolded?.Invoke(this, EventArgs.Empty);
        protected override void OnLeftReleased() => LeftReleased?.Invoke(this, EventArgs.Empty);
        protected override void OnRightPushed() => RightPushed?.Invoke(this, EventArgs.Empty);
        protected override void OnRightHolded() => RightHolded?.Invoke(this, EventArgs.Empty);
        protected override void OnRightReleased() => RightReleased?.Invoke(this, EventArgs.Empty);
        protected override void OnMiddlePushed() => MiddlePushed?.Invoke(this, EventArgs.Empty);
        protected override void OnMiddleHolded() => MiddleHolded?.Invoke(this, EventArgs.Empty);
        protected override void OnMiddleReleased() => MiddleReleased?.Invoke(this, EventArgs.Empty);
    }
}
