﻿using System;

namespace UIGenerator
{
    /// <summary>
    /// UIとして使用されるオブジェクトの基底のインターフェイス
    /// </summary>
    public interface IUIElements
    {
        /// <summary>
        /// 使用されるモードを取得または設定する
        /// </summary>
        int Mode { get; set; }
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 自身のタイプを取得する
        /// </summary>
        UITypes Type { get; }
        /// <summary>
        /// マウスでクリックされたときのイベント
        /// </summary>
        event EventHandler<ClickArg> MouseClicked;
        /// <summary>
        /// マウスカーソルと重なったときのイベント
        /// </summary>
        event EventHandler MouseEnter;
        /// <summary>
        /// マウスカーソルとの重なりが解除されたときのイベント
        /// </summary>
        event EventHandler MouseExit;
    }
}