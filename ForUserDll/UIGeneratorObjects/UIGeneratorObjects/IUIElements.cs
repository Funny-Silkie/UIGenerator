using System;
using asd;

namespace UIGeneratorObjects
{
    /// <summary>
    /// UIとして使用されるオブジェクトの基底のインターフェイス
    /// </summary>
    public interface IUIElements
    {
        /// <summary>
        /// 使用されるモードを取得する
        /// </summary>
        int Mode { get; }
        /// <summary>
        /// 名前を取得する
        /// </summary>
        string Name { get; }
        /// <summary>
        /// マウス左ボタンでクリックされたときのイベント
        /// </summary>
        event EventHandler LeftPushed;
        /// <summary>
        /// マウス右ボタンでクリックされたときのイベント
        /// </summary>
        event EventHandler RightPushed;
        /// <summary>
        /// マウス中央ボタンでクリックされたときのイベント
        /// </summary>
        event EventHandler MiddlePushed;
        /// <summary>
        /// マウス左ボタンでクリックが終わったときのイベント
        /// </summary>
        event EventHandler LeftReleased;
        /// <summary>
        /// マウス右ボタンでクリックが終わったときのイベント
        /// </summary>
        event EventHandler RightReleased;
        /// <summary>
        /// マウス中央ボタンでクリックが終わったときのイベント
        /// </summary>
        event EventHandler MiddleReleased;
        /// <summary>
        /// マウス左ボタンでクリックされているときのイベント
        /// </summary>
        event EventHandler LeftHolded;
        /// <summary>
        /// マウス右ボタンでクリックされているときのイベント
        /// </summary>
        event EventHandler RightHolded;
        /// <summary>
        /// マウス中央ボタンでクリックされているときのイベント
        /// </summary>
        event EventHandler MiddleHolded;
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
