using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// フォントのタイプを表す
    /// </summary>
    [Serializable]
    public enum FontType
    {
        /// <summary>
        /// <see cref="Graphics.CreateDynamicFont(string, int, Color, int, Color)"/>によって生成されるフォント
        /// </summary>
        Dynamic,
        /// <summary>
        /// <see cref="Graphics.CreateFont(string)"/>によってaffファイルから生成されたフォント
        /// </summary>
        Static
    }
}
