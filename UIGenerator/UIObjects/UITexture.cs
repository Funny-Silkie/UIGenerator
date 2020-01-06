﻿using System;
using asd;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// テクスチャを表すクラス
    /// 継承不可
    /// </summary>
    [Serializable]
    public class UITexture : SerializableClickableTexture, IUIElements
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
        public UITypes Type => UITypes.Texture;
        public event EventHandler<ClickArg> MouseClicked;
        public event EventHandler MouseEnter;
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
        Object2D IUIElements.AsObject2D() => this;
        protected override void OnCursorEnter()
        {
            MouseEnter?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnCursorExit()
        {
            MouseExit?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnLeftPushed()
        {
            MouseClicked?.Invoke(this, new ClickArg(MouseButtons.ButtonLeft));
        }
        protected override void OnRightPushed()
        {
            MouseClicked?.Invoke(this, new ClickArg(MouseButtons.ButtonRight));
        }
    }
}
