using System;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// 2つのキーを格納する構造体
    /// </summary>
    /// <typeparam name="TKey1">1つ目のキー</typeparam>
    /// <typeparam name="TKey2">2つ目のキー</typeparam>
    [Serializable]
    public readonly struct DoubleKey<TKey1, TKey2> : IEquatable<DoubleKey<TKey1, TKey2>>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key1">格納する<typeparamref name="TKey1"/></param>
        /// <param name="key2">格納する<typeparamref name="TKey2"/></param>
        public DoubleKey(TKey1 key1, TKey2 key2)
        {
            Key1 = key1;
            Key2 = key2;
        }
        /// <summary>
        /// 1つ目の<typeparamref name="TKey1"/>の値を取得する。
        /// </summary>
        public TKey1 Key1 { get; }
        /// <summary>
        /// 2つ目の<typeparamref name="TKey2"/>の値を取得する。
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
        /// 2つの<see cref="DoubleKey{TKey1, TKey2}"/>のインスタンスの同値性を確かめる
        /// </summary>
        /// <param name="other">同値性を確かめるもう一つの<see cref="DoubleKey{TKey1, TKey2}"/>のインスタンス</param>
        /// <returns>同値であったらtrue，それ以外でfalse</returns>
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