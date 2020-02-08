using System;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// 2�̃L�[���i�[����\����
    /// </summary>
    /// <typeparam name="TKey1">1�ڂ̃L�[</typeparam>
    /// <typeparam name="TKey2">2�ڂ̃L�[</typeparam>
    [Serializable]
    public readonly struct DoubleKey<TKey1, TKey2> : IEquatable<DoubleKey<TKey1, TKey2>>
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="key1">�i�[����<typeparamref name="TKey1"/></param>
        /// <param name="key2">�i�[����<typeparamref name="TKey2"/></param>
        public DoubleKey(TKey1 key1, TKey2 key2)
        {
            Key1 = key1;
            Key2 = key2;
        }
        /// <summary>
        /// 1�ڂ�<typeparamref name="TKey1"/>�̒l���擾����B
        /// </summary>
        public TKey1 Key1 { get; }
        /// <summary>
        /// 2�ڂ�<typeparamref name="TKey2"/>�̒l���擾����B
        /// </summary>
        public TKey2 Key2 { get; }
        public override string ToString()
        {
            var s = new System.Text.StringBuilder("");
            s.Append('[');
            if (Key1 != null)
            {
                s.Append(Key1.ToString());
            }
            s.Append(", ");
            if (Key2 != null)
            {
                s.Append(Key2.ToString());
            }
            s.Append(']');
            return s.ToString();
        }
        public override bool Equals(object obj) => obj is DoubleKey<TKey1, TKey2> d ? Equals(d) : false;
        /// <summary>
        /// 2��<see cref="DoubleKey{TKey1, TKey2}"/>�̃C���X�^���X�̓��l�����m���߂�
        /// </summary>
        /// <param name="other">���l�����m���߂�������<see cref="DoubleKey{TKey1, TKey2}"/>�̃C���X�^���X</param>
        /// <returns>���l�ł�������true�C����ȊO��false</returns>
        public bool Equals(DoubleKey<TKey1, TKey2> other)
        {
            var key1Equal = EqualityComparer<TKey1>.Default.Equals(Key1, other.Key1);
            var key2Equal = EqualityComparer<TKey2>.Default.Equals(Key2, other.Key2);
            return key1Equal && key2Equal;
        }
        public override int GetHashCode()
        {
            var hashCode = 365011897;
            hashCode = hashCode * -1521134295 + EqualityComparer<TKey1>.Default.GetHashCode(Key1);
            hashCode = hashCode * -1521134295 + EqualityComparer<TKey2>.Default.GetHashCode(Key2);
            return hashCode;
        }
        public static bool operator ==(DoubleKey<TKey1, TKey2> d1, DoubleKey<TKey1, TKey2> d2) => d1.Equals(d2);
        public static bool operator !=(DoubleKey<TKey1, TKey2> d1, DoubleKey<TKey1, TKey2> d2) => !d1.Equals(d2);
    }
}