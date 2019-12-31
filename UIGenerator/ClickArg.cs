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
        /// コンストラクタ
        /// </summary>
        /// <param name="mouseButton">押されたマウスのボタン</param>
        public ClickArg(MouseButtons mouseButton)
        {
            MouseButton = mouseButton;
        }
    }
}
