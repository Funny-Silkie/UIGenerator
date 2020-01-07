using System;

namespace UIGenerator
{
    /// <summary>
    /// UIのタイプを表す
    /// </summary>
    [Serializable]
    public enum UITypes
    {
        /// <summary>
        /// テキスト
        /// </summary>
        Text,
        /// <summary>
        /// テクスチャ
        /// </summary>
        Texture,
        /// <summary>
        /// ウィンドウ
        /// </summary>
        Window
    }
}
