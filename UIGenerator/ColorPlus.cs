using System;
using System.ComponentModel;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Color"/>�ƌ݊���������F�̍\����
    /// </summary>
    [Serializable]
    public readonly struct ColorPlus : IEquatable<ColorPlus>
    {
        /// <summary>
        /// �Ԃ̒l���擾����
        /// </summary>
        public byte R { get; }
        /// <summary>
        /// �΂̒l���擾����
        /// </summary>
        public byte G { get; }
        /// <summary>
        /// �̒l���擾����
        /// </summary>
        public byte B { get; }
        /// <summary>
        /// �����x���擾����
        /// </summary>
        public byte A { get; }
        /// <summary>
        /// <see cref="ColorSet.WindowDefault"/>��RGBA
        /// </summary>
        public static ColorPlus WindowDefaultColor { get; set; }
        /// <summary>
        /// <see cref="ColorSet.CursorDefault"/>��RGBA
        /// </summary>
        public static ColorPlus CursorDefaultColor { get; set; }
        static ColorPlus()
        {
            WindowDefaultColor = new ColorPlus(0, 0, 70, 200);
            CursorDefaultColor = new ColorPlus(0, 0, 45, 200);
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="r">��</param>
        /// <param name="g">��</param>
        /// <param name="b">��</param>
        public ColorPlus(byte r, byte g, byte b) : this(r, g, b, (byte)255) { }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="r">��</param>
        /// <param name="g">��</param>
        /// <param name="b">��</param>
        /// <param name="a">�����x</param>
        public ColorPlus(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="r">��</param>
        /// <param name="g">��</param>
        /// <param name="b">��</param>
        public ColorPlus(int r, int g, int b) : this(r, g, b, 255) { }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="r">��</param>
        /// <param name="g">��</param>
        /// <param name="b">��</param>
        /// <param name="a">�����x</param>
        public ColorPlus(int r, int g, int b, int a)
        {
            R = (byte)MathHelper.Clamp(r, 255, 0);
            G = (byte)MathHelper.Clamp(g, 255, 0);
            B = (byte)MathHelper.Clamp(b, 255, 0);
            A = (byte)MathHelper.Clamp(a, 255, 0);
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="color">�ϊ�����<see cref="Color"/></param>
        public ColorPlus(Color color) : this(color.R, color.G, color.B, color.A) { }
        /// <summary>
        /// <see cref="ColorSet"/>����<see cref="ColorPlus"/>�̃C���X�^���X�𐶐�����
        /// </summary>
        /// <param name="colorSet">�����������F��\��<see cref="ColorSet"/>�̃C���X�^���X</param>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="colorSet"/>��<see cref="ColorSet"/>�ɂ������`�O</exception>
        /// <returns><paramref name="colorSet"/>�Ŏw�肳�ꂽ�F������<see cref="ColorPlus"/>�̃C���X�^���X</returns>
        public ColorPlus(ColorSet colorSet)
        {
            var c = ColorDetermination(colorSet);
            R = c.R;
            G = c.G;
            B = c.B;
            A = c.A;
        }
        /// <summary>
        /// 2��<see cref="ColorPlus"/>�����Z����
        /// </summary>
        /// <param name="c1">���ƂƂȂ�F</param>
        /// <param name="c2">�����F</param>
        /// <returns>���Z���ꂽ�F</returns>
        public static ColorPlus Add(ColorPlus c1, ColorPlus c2) => new ColorPlus(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);
        /// <summary>
        /// <see cref="ColorPlus"/>�ɕϊ�����
        /// </summary>
        /// <param name="colorSet">�F�̎��</param>
        /// <exception cref="InvalidEnumArgumentException">�s���Ȓl���w�肳�ꂽ</exception>
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
        /// <see cref="ColorPlus"/>��8�r�b�g�����Ȃ������ŏ��Z����
        /// </summary>
        /// <param name="c">���ƂƂȂ�F</param>
        /// <param name="scalar">����l</param>
        /// <returns>���Z���ꂽ�F</returns>
        public static ColorPlus Divide(ColorPlus c, byte scalar) => new ColorPlus(c.R / scalar, c.G / scalar, c.B / scalar, c.A / scalar);
        /// <summary>
        /// �������<see cref="ColorPlus"/>�̃C���X�^���X�Ƃ̓��l�������؂���
        /// </summary>
        /// <param name="other">��r����������<see cref="ColorPlus"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public bool Equals(ColorPlus other) => (R == other.R) && (G == other.G) && (B == other.B) && (A == other.A);
        /// <summary>
        /// ���<see cref="ColorPlus"/>�̃C���X�^���X�̓��l�������؂���
        /// </summary>
        /// <param name="color1">��r����<see cref="ColorPlus"/>�̃C���X�^���X</param>
        /// <param name="color2">��r����������<see cref="ColorPlus"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(ColorPlus color1, ColorPlus color2) => color1.Equals(color2);
        /// <summary>
        /// <see cref="ColorPlus"/>�̃C���X�^���X��<see cref="Color"/>�̓��l�������؂���
        /// </summary>
        /// <param name="fscolor">��r����<see cref="ColorPlus"/>�̃C���X�^���X</param>
        /// <param name="asdcolor">��r����<see cref="Color"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(ColorPlus fscolor, Color asdcolor) => (fscolor.R == asdcolor.R) && (fscolor.G == asdcolor.G) && (fscolor.B == asdcolor.B) && (fscolor.A == asdcolor.A);
        /// <summary>
        /// ���̃C���X�^���X�Ǝw�肵���I�u�W�F�N�g�����������ǂ������肷��
        /// </summary>
        /// <param name="obj">���肷��<see cref="object"/>�̃C���X�^���X</param>
        /// <returns>������������true�C����ȊO��false</returns>
        public override bool Equals(object obj) => obj is ColorPlus c ? Equals(c) : false;
        /// <summary>
        /// <see cref="System.Drawing.Color"/>����<see cref="ColorPlus"/>�̐V�����C���X�^���X�𐶐�����
        /// </summary>
        /// <param name="systemcolor">���ƂƂȂ�<see cref="System.Drawing.Color"/>�̃C���X�^���X</param>
        /// <returns><paramref name="systemcolor"/>�Ɠ�����<see cref="ColorPlus"/>�̃C���X�^���X</returns>
        public static ColorPlus FromSystemColor(System.Drawing.Color systemcolor) => new ColorPlus(systemcolor.R, systemcolor.G, systemcolor.B, systemcolor.A);
        /// <summary>
        /// ���̃C���X�^���X�̃n�b�V���R�[�h��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�̃n�b�V���R�[�h</returns>
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
        /// <see cref="ColorPlus"/>��8�r�b�g�����Ȃ������ŏ�Z����
        /// </summary>
        /// <param name="c">���ƂƂȂ�F</param>
        /// <param name="scalar">�|����l</param>
        /// <returns>��Z���ꂽ�F</returns>
        public static ColorPlus Multiply(ColorPlus c, byte scalar) => new ColorPlus(c.R * scalar, c.G * scalar, c.B * scalar, c.A * scalar);
        /// <summary>
        /// 2��<see cref="ColorPlus"/>�����Z����
        /// </summary>
        /// <param name="c1">���ƂƂȂ�F</param>
        /// <param name="c2">�����F</param>
        /// <returns>���Z���ꂽ�F</returns>
        public static ColorPlus Substract(ColorPlus c1, ColorPlus c2) => new ColorPlus(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B, c1.A - c2.A);
        /// <summary>
        /// <see cref="Color"/>�ɕϊ�����
        /// </summary>
        /// <returns><see cref="Color"/>�̃C���X�^���X</returns>
        public Color ToAsdColor() => new Color(R, G, B, A);
        /// <summary>
        /// ���̃C���X�^���X�Ɠ�����<see cref="System.Drawing.Color"/>�̃C���X�^���X�𐶐�����
        /// </summary>
        /// <returns>���̃C���X�^���X�Ɠ�����<see cref="System.Drawing.Color"/>�̃C���X�^���X</returns>
        public System.Drawing.Color ToSystemColor() => System.Drawing.Color.FromArgb(A, R, G, B);
        /// <summary>
        /// <see cref="Color"/>��<see cref="ColorSet"/>�̃Z�b�g�ɑ��݂��邩�Ԃ�
        /// </summary>
        /// <param name="color">���ׂ���<see cref="Color"/></param>
        /// <param name="default">���݂��Ă����炻�̒l���C���݂��Ă��Ȃ����������l��Ԃ�</param>
        /// <returns>���݂��Ă�����true�C����ȊO��false</returns>
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
        /// ���̃C���X�^���X��\���������Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X��\��������</returns>
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