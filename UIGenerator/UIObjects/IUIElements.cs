using System;
using asd;

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
        /// マウス左ボタンでクリックされたときのイベント
        /// </summary>
        event EventHandler<ClickArg> LeftPushed;
        /// <summary>
        /// マウス右ボタンでクリックされたときのイベント
        /// </summary>
        event EventHandler<ClickArg> RightPushed;
        /// <summary>
        /// マウス中央ボタンでクリックされたときのイベント
        /// </summary>
        event EventHandler<ClickArg> MiddlePushed;
        /// <summary>
        /// マウス左ボタンでクリックが終わったときのイベント
        /// </summary>
        event EventHandler<ClickArg> LeftReleased;
        /// <summary>
        /// マウス右ボタンでクリックが終わったときのイベント
        /// </summary>
        event EventHandler<ClickArg> RightReleased;
        /// <summary>
        /// マウス中央ボタンでクリックが終わったときのイベント
        /// </summary>
        event EventHandler<ClickArg> MiddleReleased;
        /// <summary>
        /// マウス左ボタンでクリックされているときのイベント
        /// </summary>
        event EventHandler<ClickArg> LeftHolded;
        /// <summary>
        /// マウス右ボタンでクリックされているときのイベント
        /// </summary>
        event EventHandler<ClickArg> RightHolded;
        /// <summary>
        /// マウス中央ボタンでクリックされているときのイベント
        /// </summary>
        event EventHandler<ClickArg> MiddleHolded;
        /// <summary>
        /// マウスカーソルと重なったときのイベント
        /// </summary>
        event EventHandler MouseEnter;
        /// <summary>
        /// マウスカーソルと重なっているときのイベント
        /// </summary>
        event EventHandler MouseStay;
        /// <summary>
        /// マウスカーソルとの重なりが解除されたときのイベント
        /// </summary>
        event EventHandler MouseExit;
        /// <summary>
        /// <see cref="Object2D"/>としてキャストする
        /// </summary>
        /// <returns>このインスタンスの<see cref="Object2D"/>としてのインスタンス</returns>
        Object2D AsObject2D();
    }
}
