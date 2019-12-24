using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Color"/>と互換性がありシリアル化可能な構造体
    /// </summary>
    [Serializable]
    public struct S_Color
    {
        /// <summary>
        /// 赤の値を取得する
        /// </summary>
        public byte R { get; }
        /// <summary>
        /// 緑の値を取得する
        /// </summary>
        public byte G { get; }
        /// <summary>
        /// 青の値を取得する
        /// </summary>
        public byte B { get; }
        /// <summary>
        /// 透明度を取得する
        /// </summary>  
        public byte A { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r">赤</param>
        /// <param name="g">緑</param>
        /// <param name="b">青</param>
        /// <param name="a">透明度</param>
        public S_Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public static implicit operator Color(S_Color c) => new Color(c.R, c.G, c.B, c.A);
        public static implicit operator S_Color(Color c) => new S_Color(c.R, c.G, c.B, c.A);
    }
}
