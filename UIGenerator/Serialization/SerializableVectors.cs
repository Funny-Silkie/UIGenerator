using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// �V���A�����\��<see cref="Vector2DF"/>�ƌ݊���������\����
    /// </summary>
    [Serializable]
    public readonly struct SerializableVector2DF : IEquatable<SerializableVector2DF>
    {
        /// <summary>
        /// X�̒l���擾����
        /// </summary>
        public float X { get; }
        /// <summary>
        /// Y�̒l���擾����
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="x">X�̒l</param>
        /// <param name="y">Y�̒l</param>
        public SerializableVector2DF(float x, float y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 2��<see cref="SerializableVector2DF"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="other">���l���𒲂ׂ�������<see cref="SerializableVector2DF"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public bool Equals(SerializableVector2DF other) => (X == other.X) && (Y == other.Y);
        /// <summary>
        /// <see cref="SerializableVector2DF"/>��<see cref="Vector2DF"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="serializable">���l���𒲂ׂ�<see cref="SerializableVector2DF"/>�̃C���X�^���X</param>
        /// <param name="normal">���l���𒲂ׂ�������<see cref="Vector2DF"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableVector2DF serializable, Vector2DF normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y);
        /// <summary>
        /// 2��<see cref="SerializableVector2DF"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="vector1">���l���𒲂ׂ�<see cref="SerializableVector2DF"/>�̃C���X�^���X</param>
        /// <param name="vector2">���l���𒲂ׂ�������<see cref="SerializableVector2DF"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableVector2DF vector1, SerializableVector2DF vector2) => vector1.Equals(vector2);
        /// <summary>
        /// ���̃C���X�^���X�Ǝw�肵���I�u�W�F�N�g�����������ǂ������肷��
        /// </summary>
        /// <param name="obj">���肷��<see cref="object"/>�̃C���X�^���X</param>
        /// <returns>������������true�C����ȊO��false</returns>
        public override bool Equals(object obj) => obj is SerializableVector2DF v ? Equals(v) : false;
        /// <summary>
        /// ���̃C���X�^���X�̃n�b�V���R�[�h��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�̃n�b�V���R�[�h</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// <see cref="SerializableVector2DI"/>�Ɍ^�ϊ�����
        /// </summary>
        /// <returns>���̃C���X�^���X�Ɠ����l������<see cref="SerializableVector2DI"/>�̃C���X�^���X</returns>
        public SerializableVector2DI To2DI() => new SerializableVector2DI((int)X, (int)Y);
        /// <summary>
        /// ���̃C���X�^���X��\���������Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X��\��������</returns>
        public override string ToString() => $"({X}, {Y})";
        public static implicit operator SerializableVector2DF(Vector2DF v) => new SerializableVector2DF(v.X, v.Y);
        public static explicit operator SerializableVector2DI(SerializableVector2DF v) => v.To2DI();
        public static implicit operator Vector2DF(SerializableVector2DF v) => new Vector2DF(v.X, v.Y);
        public static bool operator ==(SerializableVector2DF v1, SerializableVector2DF v2) => Equals(v1, v2);
        public static bool operator ==(SerializableVector2DF v1, Vector2DF v2) => Equals(v1, v2);
        public static bool operator ==(Vector2DF v1, SerializableVector2DF v2) => Equals(v2, v1);
        public static bool operator !=(SerializableVector2DF v1, SerializableVector2DF v2) => !Equals(v1, v2);
        public static bool operator !=(SerializableVector2DF v1, Vector2DF v2) => !Equals(v1, v2);
        public static bool operator !=(Vector2DF v1, SerializableVector2DF v2) => !Equals(v2, v1);
    }
    /// <summary>
    /// �V���A�����\��<see cref="Vector2DI"/>�ƌ݊���������\����
    /// </summary>
    [Serializable]
    public readonly struct SerializableVector2DI : IEquatable<SerializableVector2DI>
    {
        /// <summary>
        /// X�̒l���擾����
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Y�̒l���擾����
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="x">X�̒l</param>
        /// <param name="y">Y�̒l</param>
        public SerializableVector2DI(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 2��<see cref="SerializableVector2DI"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="other">���l���𒲂ׂ�������<see cref="SerializableVector2DI"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public bool Equals(SerializableVector2DI other) => (X == other.X) && (Y == other.Y);
        /// <summary>
        /// <see cref="SerializableVector2DI"/>��<see cref="Vector2DI"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="serializable">���l���𒲂ׂ�<see cref="SerializableVector2DI"/>�̃C���X�^���X</param>
        /// <param name="normal">���l���𒲂ׂ�������<see cref="Vector2DI"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableVector2DI serializable, Vector2DI normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y);
        /// <summary>
        /// 2��<see cref="SerializableVector2DI"/>�Ԃɓ��l�������邩�ǂ�����Ԃ�
        /// </summary>
        /// <param name="vector1">���l���𒲂ׂ�<see cref="SerializableVector2DI"/>�̃C���X�^���X</param>
        /// <param name="vector2">���l���𒲂ׂ�������<see cref="SerializableVector2DI"/>�̃C���X�^���X</param>
        /// <returns>���l��������true�C����ȊO��false</returns>
        public static bool Equals(SerializableVector2DI vector1, SerializableVector2DI vector2) => vector1.Equals(vector2);
        /// <summary>
        /// ���̃C���X�^���X�Ǝw�肵���I�u�W�F�N�g�����������ǂ������肷��
        /// </summary>
        /// <param name="obj">���肷��<see cref="object"/>�̃C���X�^���X</param>
        /// <returns>������������true�C����ȊO��false</returns>
        public override bool Equals(object obj) => obj is SerializableVector2DI v ? Equals(v) : false;
        /// <summary>
        /// ���̃C���X�^���X�̃n�b�V���R�[�h��Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X�̃n�b�V���R�[�h</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// <see cref="SerializableVector2DF"/>�Ɍ^�ϊ�����
        /// </summary>
        /// <returns>���̃C���X�^���X�Ɠ����l������<see cref="SerializableVector2DF"/>�̃C���X�^���X</returns>
        public SerializableVector2DF To2DF() => new SerializableVector2DF(X, Y);
        /// <summary>
        /// ���̃C���X�^���X��\���������Ԃ�
        /// </summary>
        /// <returns>���̃C���X�^���X��\��������</returns>
        public override string ToString() => $"({X}, {Y})";
        public static implicit operator SerializableVector2DI(Vector2DI v) => new SerializableVector2DI(v.X, v.Y);
        public static implicit operator SerializableVector2DF(SerializableVector2DI v) => v.To2DF();
        public static implicit operator Vector2DI(SerializableVector2DI v) => new Vector2DI(v.X, v.Y);
        public static bool operator ==(SerializableVector2DI v1, SerializableVector2DI v2) => Equals(v1, v2);
        public static bool operator ==(SerializableVector2DI v1, Vector2DI v2) => Equals(v1, v2);
        public static bool operator ==(Vector2DI v1, SerializableVector2DI v2) => Equals(v2, v1);
        public static bool operator !=(SerializableVector2DI v1, SerializableVector2DI v2) => !Equals(v1, v2);
        public static bool operator !=(SerializableVector2DI v1, Vector2DI v2) => !Equals(v1, v2);
        public static bool operator !=(Vector2DI v1, SerializableVector2DI v2) => !Equals(v2, v1);
    }
}