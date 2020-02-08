using System;

namespace UIGenerator
{
    /// <summary>
    /// テキストファイルの作成に対してどのような操作を行うか判定する
    /// </summary>
    [Serializable]
    public enum WriteTextMode
    {
        /// <summary>
        /// 前に書き込まれた内容を無視して上書きする
        /// </summary>
        Overwrite,
        /// <summary>
        /// 前に書き込まれた内容の文頭に書き込む(改行付き)
        /// </summary>
        AddBeggining,
        /// <summary>
        /// 前に書き込まれた内容の文末に書き込む(改行付き)
        /// </summary>
        AddEnd
    }
}