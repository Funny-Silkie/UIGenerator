using System;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// 2種類のキーと値を格納する構造体
    /// </summary>
    /// <typeparam name="TKey1">キー1</typeparam>
    /// <typeparam name="TKey2">キー2</typeparam>
    /// <typeparam name="TValue">値</typeparam>
    [Serializable]
    public readonly struct DoubleKeyValuePair<TKey1, TKey2, TValue> : IEquatable<DoubleKeyValuePair<TKey1, TKey2, TValue>>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key1">格納する<typeparamref name="TKey1"/></param>
        /// <param name="key2">格納する<typeparamref name="TKey2"/></param>
        /// <param name="value">格納する<typeparamref name="TValue"/></param>
        public DoubleKeyValuePair(TKey1 key1, TKey2 key2, TValue value)
        {
            Key1 = key1;
            Key2 = key2;
            Value = value;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="doubleKey">格納する<see cref="DoubleKey{TKey1, TKey2}"/></param>
        /// <param name="value">格納する<typeparamref name="TValue"/></param>
        internal DoubleKeyValuePair(DoubleKey<TKey1, TKey2> doubleKey, TValue value) : this(doubleKey.Key1, doubleKey.Key2, value) { }
        /// <summary>
        /// 1つ目の<typeparamref name="TKey1"/>の値を取得する。
        /// </summary>
        public TKey1 Key1 { get; }
        /// <summary>
        /// 2つ目の<typeparamref name="TKey2"/>の値を取得する。
        /// </summary>
        public TKey2 Key2 { get; }
        /// <summary>
        /// <typeparamref name="TKey1"/>と<typeparamref name="TKey2"/>に紐づけられた<typeparamref name="TValue"/>を取得する。
        /// </summary>
        public TValue Value { get; }
        internal DoubleKey<TKey1, TKey2> DoubleKey => new DoubleKey<TKey1, TKey2>(Key1, Key2);
        /// <summary>
        /// <see cref="KeyValuePair{TKey, TValue}"/>に変換する
        /// </summary>
        public KeyValuePair<DoubleKey<TKey1, TKey2>, TValue> GetKeyValuePair() => new KeyValuePair<DoubleKey<TKey1, TKey2>, TValue>(new DoubleKey<TKey1, TKey2>(Key1, Key2), Value);
        public override string ToString()
        {
            var s = new System.Text.StringBuilder("");
            s.Append('[');
            if (Key1 != null)
                s.Append(Key1.ToString());
            s.Append(", ");
            if (Key2 != null)
                s.Append(Key2.ToString());
            s.Append(", ");
            if (Value != null)
                s.Append(Value.ToString());
            s.Append(']');
            return s.ToString();
        }
        public override bool Equals(object obj) => obj is DoubleKeyValuePair<TKey1, TKey2, TValue> p ? Equals(p) : false;
        /// <summary>
        /// 2つの<see cref="DoubleKeyValuePair{TKey1, TKey2, TValue}"/>のインスタンスの同値性を確かめる
        /// </summary>
        /// <param name="other">同値性を確かめるもう一つの<see cref="DoubleKeyValuePair{TKey1, TKey2, TValue}"/>のインスタンス</param>
        /// <returns>同値であったらtrue，それ以外でfalse</returns>
        public bool Equals(DoubleKeyValuePair<TKey1, TKey2, TValue> other)
        {
            var key1Equal = EqualityComparer<TKey1>.Default.Equals(Key1, other.Key1);
            var key2Equal = EqualityComparer<TKey2>.Default.Equals(Key2, other.Key2);
            var valueEqual = EqualityComparer<TValue>.Default.Equals(Value, other.Value);
            return key1Equal && key2Equal && valueEqual;
        }
        public override int GetHashCode()
        {
            var hashCode = 840212235;
            hashCode = hashCode * -1521134295 + EqualityComparer<TKey1>.Default.GetHashCode(Key1);
            hashCode = hashCode * -1521134295 + EqualityComparer<TKey2>.Default.GetHashCode(Key2);
            hashCode = hashCode * -1521134295 + EqualityComparer<TValue>.Default.GetHashCode(Value);
            return hashCode;
        }
        public static bool operator ==(DoubleKeyValuePair<TKey1, TKey2, TValue> p1, DoubleKeyValuePair<TKey1, TKey2, TValue> p2) => p1.Equals(p2);
        public static bool operator !=(DoubleKeyValuePair<TKey1, TKey2, TValue> p1, DoubleKeyValuePair<TKey1, TKey2, TValue> p2) => !p1.Equals(p2);
    }
}