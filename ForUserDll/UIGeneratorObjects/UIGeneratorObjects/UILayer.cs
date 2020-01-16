using System;
using asd;
using fslib;
using fslib.Collections;

namespace UIGeneratorObjects
{
    /// <summary>
    /// UIGeneratorで生成したオブジェクトを表示するレイヤー
    /// </summary>
    public class UILayer : Layer2DPlus
    {
        /// <summary>
        /// 現在表示しているオブジェクトのモードを取得する
        /// </summary>
        public int Mode { get; private set; }
        /// <summary>
        /// UIのオブジェクトを追加する
        /// </summary>
        /// <typeparam name="T">追加するオブジェクトの</typeparam>
        /// <param name="item">追加するUIのオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>がnull</exception>
        public void AddUIObject<T>(T item) where T : Object2D, IUIElements
        {
            if (item == null) throw new ArgumentNullException("追加しようとしたインスタンスがnullです", nameof(item));
            if (item.Mode == Mode) AddObject(item);
        }
        public void ChangeMode(int mode)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException("設定する値が0未満です", nameof(mode));
            Mode = mode;

        }
    }
}
