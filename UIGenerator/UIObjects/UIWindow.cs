using System;
using System.ComponentModel;
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
            SetColor(ColorSet.WindowDefault);
        }
        public event EventHandler<ClickArg> MouseClicked;
        public event EventHandler MouseEnter;
        public event EventHandler MouseExit;
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnCursorEnter()
        {
            MouseEnter?.Invoke(this, EventArgs.Empty);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnCursorExit()
        {
            MouseExit?.Invoke(this, EventArgs.Empty);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnLeftPushed()
        {
            MouseClicked?.Invoke(this, new ClickArg(MouseButtons.ButtonLeft));
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnRightPushed()
        {
            MouseClicked?.Invoke(this, new ClickArg(MouseButtons.ButtonRight));
        }
    }
}
