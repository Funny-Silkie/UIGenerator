using System;
using System.ComponentModel;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Color"/>と互換性がある色の構造体
    /// </summary>
    [Serializable]
    public readonly struct ColorPlus : IEquatable<ColorPlus>
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
        /// <see cref="ColorSet.WindowDefault"/>のRGBA
        /// </summary>
        public static ColorPlus WindowDefaultColor { get; set; }
        /// <summary>
        /// <see cref="ColorSet.CursorDefault"/>のRGBA
        /// </summary>
        public static ColorPlus CursorDefaultColor { get; set; }
        static ColorPlus()
        {
            WindowDefaultColor = new ColorPlus(0, 0, 70, 200);
            CursorDefaultColor = new ColorPlus(0, 0, 45, 200);
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r">赤</param>
        /// <param name="g">緑</param>
        /// <param name="b">青</param>
        public ColorPlus(byte r, byte g, byte b) : this(r, g, b, (byte)255) { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r">赤</param>
        /// <param name="g">緑</param>
        /// <param name="b">青</param>
        /// <param name="a">透明度</param>
        public ColorPlus(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r">赤</param>
        /// <param name="g">緑</param>
        /// <param name="b">青</param>
        public ColorPlus(int r, int g, int b) : this(r, g, b, 255) { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r">赤</param>
        /// <param name="g">緑</param>
        /// <param name="b">青</param>
        /// <param name="a">透明度</param>
        public ColorPlus(int r, int g, int b, int a)
        {
            R = (byte)MathHelper.Clamp(r, 255, 0);
            G = (byte)MathHelper.Clamp(g, 255, 0);
            B = (byte)MathHelper.Clamp(b, 255, 0);
            A = (byte)MathHelper.Clamp(a, 255, 0);
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="color">変換元の<see cref="Color"/></param>
        public ColorPlus(Color color) : this(color.R, color.G, color.B, color.A) { }
        /// <summary>
        /// <see cref="ColorSet"/>から<see cref="ColorPlus"/>のインスタンスを生成する
        /// </summary>
        /// <param name="colorSet">生成したい色を表す<see cref="ColorSet"/>のインスタンス</param>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="colorSet"/>が<see cref="ColorSet"/>における定義外</exception>
        /// <returns><paramref name="colorSet"/>で指定された色を持つ<see cref="ColorPlus"/>のインスタンス</returns>
        public ColorPlus(ColorSet colorSet)
        {
            var c = ColorDetermination(colorSet);
            R = c.R;
            G = c.G;
            B = c.B;
            A = c.A;
        }
        /// <summary>
        /// 2つの<see cref="ColorPlus"/>を加算する
        /// </summary>
        /// <param name="c1">もととなる色</param>
        /// <param name="c2">足す色</param>
        /// <returns>加算された色</returns>
        public static ColorPlus Add(ColorPlus c1, ColorPlus c2) => new ColorPlus(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);
        /// <summary>
        /// <see cref="ColorPlus"/>に変換する
        /// </summary>
        /// <param name="colorSet">色の種類</param>
        /// <exception cref="InvalidEnumArgumentException">不正な値が指定された</exception>
        public static ColorPlus ColorDetermination(ColorSet colorSet) => colorSet switch
        {
            ColorSet.Black => new ColorPlus(0, 0, 0),
            ColorSet.Blue => new ColorPlus(0, 0, 255),
            ColorSet.CursorDefault => CursorDefaultColor,
            ColorSet.Green => new ColorPlus(0, 255, 0),
            ColorSet.Grey => new ColorPlus(217, 217, 217),
            ColorSet.Orange => new ColorPlus(255, 174, 38),
            ColorSet.Purple => new ColorPlus(255, 0, 255),
            ColorSet.Random => GetRandomColor(),
            ColorSet.Red => new ColorPlus(255, 0, 0),
            ColorSet.Transparent => new ColorPlus(0, 0, 0, 0),
            ColorSet.White => new ColorPlus(255, 255, 255),
            ColorSet.WindowDefault => WindowDefaultColor,
            ColorSet.Yellow => new ColorPlus(255, 255, 0),
            ColorSet.Copper => new ColorPlus(174, 105, 56),
            ColorSet.Silver => new ColorPlus(201, 202, 202),
            ColorSet.Gold => new ColorPlus(218, 179, 0),
            ColorSet.Platinum => new ColorPlus(229, 228, 226),
            ColorSet.Pink => new ColorPlus(255, 180, 180),
            ColorSet.YellowGreen => new ColorPlus(150, 255, 100),
            ColorSet.AquaBlue => new ColorPlus(115, 210, 240),
            ColorSet.Sepia => new ColorPlus(107, 74, 43),
            ColorSet.Magenta => new ColorPlus(236, 0, 140),
            ColorSet.Cyan => new ColorPlus(0, 174, 239),
            _ => throw new InvalidEnumArgumentException(),
        };
        /// <summary>
        /// <see cref="ColorPlus"/>と8ビット符号なし整数で除算する
        /// </summary>
        /// <param name="c">もととなる色</param>
        /// <param name="scalar">割る値</param>
        /// <returns>除算された色</returns>
        public static ColorPlus Divide(ColorPlus c, byte scalar) => new ColorPlus(c.R / scalar, c.G / scalar, c.B / scalar, c.A / scalar);
        /// <summary>
        /// もう一つの<see cref="ColorPlus"/>のインスタンスとの同値性を検証する
        /// </summary>
        /// <param name="other">比較するもう一つの<see cref="ColorPlus"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(ColorPlus other) => (R == other.R) && (G == other.G) && (B == other.B) && (A == other.A);
        /// <summary>
        /// 二つの<see cref="ColorPlus"/>のインスタンスの同値性を検証する
        /// </summary>
        /// <param name="color1">比較する<see cref="ColorPlus"/>のインスタンス</param>
        /// <param name="color2">比較するもう一つの<see cref="ColorPlus"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(ColorPlus color1, ColorPlus color2) => color1.Equals(color2);
        /// <summary>
        /// <see cref="ColorPlus"/>のインスタンスと<see cref="Color"/>の同値性を検証する
        /// </summary>
        /// <param name="fscolor">比較する<see cref="ColorPlus"/>のインスタンス</param>
        /// <param name="asdcolor">比較する<see cref="Color"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(ColorPlus fscolor, Color asdcolor) => (fscolor.R == asdcolor.R) && (fscolor.G == asdcolor.G) && (fscolor.B == asdcolor.B) && (fscolor.A == asdcolor.A);
        /// <summary>
        /// このインスタンスと指定したオブジェクトが等しいかどうか判定する
        /// </summary>
        /// <param name="obj">判定する<see cref="object"/>のインスタンス</param>
        /// <returns>等しかったらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is ColorPlus c ? Equals(c) : false;
        /// <summary>
        /// <see cref="System.Drawing.Color"/>から<see cref="ColorPlus"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="systemcolor">もととなる<see cref="System.Drawing.Color"/>のインスタンス</param>
        /// <returns><paramref name="systemcolor"/>と等価な<see cref="ColorPlus"/>のインスタンス</returns>
        public static ColorPlus FromSystemColor(System.Drawing.Color systemcolor) => new ColorPlus(systemcolor.R, systemcolor.G, systemcolor.B, systemcolor.A);
        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 1960784236;
            hashCode = hashCode * -1521134295 + R.GetHashCode();
            hashCode = hashCode * -1521134295 + G.GetHashCode();
            hashCode = hashCode * -1521134295 + B.GetHashCode();
            hashCode = hashCode * -1521134295 + A.GetHashCode();
            return hashCode;
        }
        private static ColorPlus GetRandomColor()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            return new ColorPlus(rand.Next(256), rand.Next(256), rand.Next(256));
        }
        /// <summary>
        /// <see cref="ColorPlus"/>と8ビット符号なし整数で乗算する
        /// </summary>
        /// <param name="c">もととなる色</param>
        /// <param name="scalar">掛ける値</param>
        /// <returns>乗算された色</returns>
        public static ColorPlus Multiply(ColorPlus c, byte scalar) => new ColorPlus(c.R * scalar, c.G * scalar, c.B * scalar, c.A * scalar);
        /// <summary>
        /// 2つの<see cref="ColorPlus"/>を減算する
        /// </summary>
        /// <param name="c1">もととなる色</param>
        /// <param name="c2">引く色</param>
        /// <returns>減算された色</returns>
        public static ColorPlus Substract(ColorPlus c1, ColorPlus c2) => new ColorPlus(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B, c1.A - c2.A);
        /// <summary>
        /// <see cref="Color"/>に変換する
        /// </summary>
        /// <returns><see cref="Color"/>のインスタンス</returns>
        public Color ToAsdColor() => new Color(R, G, B, A);
        /// <summary>
        /// このインスタンスと等価な<see cref="System.Drawing.Color"/>のインスタンスを生成する
        /// </summary>
        /// <returns>このインスタンスと等価な<see cref="System.Drawing.Color"/>のインスタンス</returns>
        public System.Drawing.Color ToSystemColor() => System.Drawing.Color.FromArgb(A, R, G, B);
        /// <summary>
        /// <see cref="Color"/>が<see cref="ColorSet"/>のセットに存在するか返す
        /// </summary>
        /// <param name="color">調べたい<see cref="Color"/></param>
        /// <param name="default">存在していたらその値を，存在していなかったら既定値を返す</param>
        /// <returns>存在していたらtrue，それ以外でfalse</returns>
        public static bool TryGetColorSet(Color color, out ColorPlus @default)
        {
            var array = Enum.GetNames(typeof(ColorSet));
            for (int i = 0; i < array.Length; i++)
                if (color == new ColorPlus(EnumHelper.FromNumber<ColorSet>(i)))
                {
                    @default = new ColorPlus(EnumHelper.FromNumber<ColorSet>(i));
                    return true;
                }
            @default = default;
            return false;
        }
        /// <summary>
        /// このインスタンスを表す文字列を返す
        /// </summary>
        /// <returns>このインスタンスを表す文字列</returns>
        public override string ToString() => $"({R}, {G}, {B}, {A})";
        public static ColorPlus operator +(ColorPlus c1, ColorPlus c2) => Add(c1, c2);
        public static ColorPlus operator -(ColorPlus c1, ColorPlus c2) => Substract(c1, c2);
        public static ColorPlus operator *(ColorPlus c, byte scalar) => Multiply(c, scalar);
        public static ColorPlus operator *(byte scalar, ColorPlus c) => Multiply(c, scalar);
        public static ColorPlus operator /(ColorPlus c, byte scalar) => Divide(c, scalar);
        public static bool operator ==(ColorPlus c1, ColorPlus c2) => Equals(c1, c2);
        public static bool operator ==(ColorPlus f, Color a) => Equals(f, a);
        public static bool operator ==(Color a, ColorPlus f) => Equals(f, a);
        public static bool operator !=(ColorPlus c1, ColorPlus c2) => !Equals(c1, c2);
        public static bool operator !=(ColorPlus f, Color a) => !Equals(f, a);
        public static bool operator !=(Color a, ColorPlus f) => !Equals(f, a);
        public static implicit operator Color(ColorPlus c) => c.ToAsdColor();
        public static implicit operator ColorPlus(Color c) => new ColorPlus(c);
    }
}