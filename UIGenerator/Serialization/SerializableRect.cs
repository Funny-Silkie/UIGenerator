using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="RectF"/>�ƌ݊���������V���A���C�Y�\�ȍ\����
    /// </summary>
    [Serializable]
    public readonly struct SerializableRectF : IEquatable<SerializableRectF>
    {
        /// <summary>
        /// �����X���W���擾����
        /// </summary>
        public float X { get; }
        /// <summary>
        /// �����Y���W���擾����
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// �������擾����
        /// </summary>
        public float Width { get; }
        /// <summary>
        /// �c�����擾����
        /// </summary>
        public float Height { get; }
        /// <summary>
        /// ����̍��W���擾����
        /// </summary>
        public Vector2DF Position => new Vector2DF(X, Y);
        /// <summary>
        /// �c���̑傫�����擾����
        /// </summary>
        public Vector2DF Size => new Vector2DF(Width, Height);
        /// <summary>
        /// �l���̍��W������C�E��C�E���C�����̏��ɔz��Ƃ��Ď擾����B
        /// </summary>
        public Vector2DF[] Vertexes => new Vector2DF[] { new Vector2DF(X, Y), new Vector2DF(X + Width, Y), new Vector2DF(X + Width, Y + Height), new Vector2DF(X, Y + Width) };
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="x">�����X���W</param>
        /// <param name="y">�����Y���W</param>
        /// <param name="width">����</param>
        /// <param name="height">�c��</param>
        public SerializableRectF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="position">����̍��W</param>
        /// <param name="size">�c���̑傫��</param>
        public SerializableRectF(SerializableVector2DF position, SerializableVector2DF size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="position">����̍��W</param>
        /// <param name="size">�c���̑傫��</param>
        public SerializableRectF(Vector2DF position, Vector2DF size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// 2��<see cref="SerializableRectF"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="other">���l���𒲂ׂ�������<see cref="SerializableRectF"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public bool Equals(SerializableRectF other) => (X == other.X) && (Y == other.Y) && (Width == other.Width) && (Height == other.Height);
        /// <summary>
        /// <see cref="SerializableRectF"/>��<see cref="RectF"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="serializable">���l���𒲂ׂ�<see cref="SerializableRectF"/>�̃C���X�^���X</param>
        /// <param name="normal">���l���𒲂ׂ�������<see cref="RectF"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableRectF serializable, RectF normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y) && (serializable.Width == normal.Width) && (serializable.Height == normal.Height);
        /// <summary>
        /// 2��<see cref="SerializableRectF"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="rect1">���l���𒲂ׂ�<see cref="SerializableRectF"/>�̃C���X�^���X</param>
        /// <param name="rect2">���l���𒲂ׂ�������<see cref="SerializableRectF"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableRectF rect1, SerializableRectF rect2) => rect1.Equals(rect2);
        /// <summary>
        /// ���̃C���X�^���X�Ǝw�肵���I�u�W�F�N�g�����������ǂ������肷��
        /// </summary>
        /// <param name="obj">���肷��<see cref="object"/>�̃C���X�^���X</param>
        /// <returns>������������true�C����ȊO��false</returns>
        public override bool Equals(object obj) => obj is SerializableRectF r ? Equals(r) : false;
        /// <summary>
        /// ���̃C���X�^���X�̃n�b�V���R�[�h��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�̃n�b�V���R�[�h</returns>
        public override int GetHashCode()
        {
            var hashCode = 466501756;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// ���̃C���X�^���X�Ɠ����l������<see cref="SerializableRectI"/>��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�Ɠ����l������<see cref="SerializableRectI"/>�̐V�����C���X�^���X</returns>
        public SerializableRectI ToI() => new SerializableRectI((int)X, (int)Y, (int)Width, (int)Height);
        public static implicit operator RectF(SerializableRectF r) => new RectF(r.X, r.Y, r.Width, r.Height);
        public static implicit operator SerializableRectF(RectF r) => new SerializableRectF(r.X, r.Y, r.Width, r.Height);
        public static explicit operator SerializableRectI(SerializableRectF f) => f.ToI();
        public static bool operator ==(SerializableRectF r1, SerializableRectF r2) => Equals(r1, r2);
        public static bool operator ==(SerializableRectF r1, RectF r2) => Equals(r1, r2);
        public static bool operator ==(RectF r1, SerializableRectF r2) => Equals(r2, r1);
        public static bool operator !=(SerializableRectF r1, SerializableRectF r2) => !Equals(r1, r2);
        public static bool operator !=(SerializableRectF r1, RectF r2) => !Equals(r1, r2);
        public static bool operator !=(RectF r1, SerializableRectF r2) => !Equals(r2, r1);
    }
    /// <summary>
    /// <see cref="RectI"/>�ƌ݊���������V���A���C�Y�\�ȍ\����
    /// </summary>
    [Serializable]
    public readonly struct SerializableRectI : IEquatable<SerializableRectI>
    {
        /// <summary>
        /// �����X���W���擾����
        /// </summary>
        public int X { get; }
        /// <summary>
        /// �����Y���W���擾����
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// �������擾����
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// �c�����擾����
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// ����̍��W���擾����
        /// </summary>
        public Vector2DI Position => new Vector2DI(X, Y);
        /// <summary>
        /// �c���̑傫�����擾����
        /// </summary>
        public Vector2DI Size => new Vector2DI(Width, Height);
        /// <summary>
        /// �l���̍��W������C�E��C�E���C�����̏��ɔz��Ƃ��Ď擾����B
        /// </summary>
        public Vector2DI[] Vertexes => new Vector2DI[] { new Vector2DI(X, Y), new Vector2DI(X + Width, Y), new Vector2DI(X + Width, Y + Height), new Vector2DI(X, Y + Width) };
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="x">�����X���W</param>
        /// <param name="y">�����Y���W</param>
        /// <param name="width">����</param>
        /// <param name="height">�c��</param>
        public SerializableRectI(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="position">����̍��W</param>
        /// <param name="size">�c���̑傫��</param>
        public SerializableRectI(SerializableVector2DI position, SerializableVector2DI size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="position">����̍��W</param>
        /// <param name="size">�c���̑傫��</param>
        public SerializableRectI(Vector2DI position, Vector2DI size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// 2��<see cref="SerializableRectI"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="other">���l���𒲂ׂ�������<see cref="SerializableRectI"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public bool Equals(SerializableRectI other) => (X == other.X) && (Y == other.Y) && (Width == other.Width) && (Height == other.Height);
        /// <summary>
        /// <see cref="SerializableRectI"/>��<see cref="RectI"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="serializable">���l���𒲂ׂ�<see cref="SerializableRectI"/>�̃C���X�^���X</param>
        /// <param name="normal">���l���𒲂ׂ�������<see cref="RectI"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableRectI serializable, RectI normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y) && (serializable.Width == normal.Width) && (serializable.Height == normal.Height);
        /// <summary>
        /// 2��<see cref="SerializableRectI"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="rect1">���l���𒲂ׂ�<see cref="SerializableRectI"/>�̃C���X�^���X</param>
        /// <param name="rect2">���l���𒲂ׂ�������<see cref="SerializableRectI"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableRectI rect1, SerializableRectI rect2) => rect1.Equals(rect2);
        /// <summary>
        /// ���̃C���X�^���X�Ǝw�肵���I�u�W�F�N�g�����������ǂ������肷��
        /// </summary>
        /// <param name="obj">���肷��<see cref="object"/>�̃C���X�^���X</param>
        /// <returns>������������true�C����ȊO��false</returns>
        public override bool Equals(object obj) => obj is SerializableRectI r ? Equals(r) : false;
        /// <summary>
        /// ���̃C���X�^���X�̃n�b�V���R�[�h��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�̃n�b�V���R�[�h</returns>
        public override int GetHashCode()
        {
            var hashCode = 466501756;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// ���̃C���X�^���X�Ɠ����l������<see cref="SerializableRectF"/>��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�Ɠ����l������<see cref="SerializableRectF"/>�̐V�����C���X�^���X</returns>
        public SerializableRectF ToF() => new SerializableRectF(X, Y, Width, Height);
        public static implicit operator RectI(SerializableRectI r) => new RectI(r.X, r.Y, r.Width, r.Height);
        public static implicit operator SerializableRectI(RectI r) => new SerializableRectI(r.X, r.Y, r.Width, r.Height);
        public static implicit operator SerializableRectF(SerializableRectI i) => i.ToF();
        public static bool operator ==(SerializableRectI r1, SerializableRectI r2) => Equals(r1, r2);
        public static bool operator ==(SerializableRectI r1, RectI r2) => Equals(r1, r2);
        public static bool operator ==(RectI r1, SerializableRectI r2) => Equals(r2, r1);
        public static bool operator !=(SerializableRectI r1, SerializableRectI r2) => !Equals(r1, r2);
        public static bool operator !=(SerializableRectI r1, RectI r2) => !Equals(r1, r2);
        public static bool operator !=(RectI r1, SerializableRectI r2) => !Equals(r2, r1);
    }
}