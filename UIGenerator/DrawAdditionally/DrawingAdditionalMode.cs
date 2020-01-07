using System;

namespace UIGenerator
{
    /// <summary>
    /// 追加描画のモードを表す列挙体
    /// </summary>
    [Serializable]
    public enum DrawingAdditionalMode
    {
        Arc,
        Circle,
        Line,
        Rectangle,
        RotatedRectangle,
        Sprite,
        Text,
        Triangle
    }
}
