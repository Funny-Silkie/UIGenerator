using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// マウスクリックされた時のイベント変数
    /// </summary>
    public class ClickArg : EventArgs
    {
        /// <summary>
        /// 押されたマウスのボタンを取得する
        /// </summary>
        public MouseButtons MouseButton { get; }
        /// <summary>
        /// 押されているボタンの状態を取得する
        /// </summary>
        public ButtonState ButtonState { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mouseButton">押されたマウスのボタン</param>
        /// <param name="buttonState">ボタンの状態</param>
        public ClickArg(MouseButtons mouseButton, ButtonState buttonState)
        {
            MouseButton = mouseButton;
            ButtonState = buttonState;
        }
    }
}
