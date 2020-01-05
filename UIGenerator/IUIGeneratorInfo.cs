using System;

namespace UIGenerator
{
    /// <summary>
    /// UIGenerator内の操作を仲介するクラスの基底
    /// </summary>
    public interface IUIGeneratorInfo
    {
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満</exception>
        int Mode { get; set; }
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        string Name { get; set; }
        /// <summary>
        /// このオブジェクトを操作するフォームを取得または設定する
        /// </summary>
        System.Windows.Forms.Form HandleForm { get; set; }
    }
}
