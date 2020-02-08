using System;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// インデックス検索とキー検索両方が出来る読み取り専用のジェネリックコレクションの基底インターフェイス
    /// </summary>
    /// <typeparam name="TKey1">キーの型1</typeparam>
    /// <typeparam name="TKey2">キーの型2</typeparam>
    /// <typeparam name="TValue">値の型</typeparam>
    public interface IReadOnlyNumericDoubleKeyDictionary<TKey1, TKey2, TValue> : IReadOnlyList<DoubleKeyValuePair<TKey1, TKey2, TValue>>, IReadOnlyDoubleKeyDictionary<TKey1, TKey2, TValue>
    {
        /// <summary>
        /// 格納されているキーのコレクションを取得する
        /// </summary>
        new IReadOnlyList<TKey1> Key1Collection { get; }
        /// <summary>
        /// 格納されているキーのコレクションを取得する
        /// </summary>
        new IReadOnlyList<TKey2> Key2Collection { get; }
        /// <summary>
        /// 格納されている値のコレクションを取得する
        /// </summary>
        new IReadOnlyList<TValue> Values { get; }
        /// <summary>
        /// 指定したキーが存在するかどうかを返す
        /// </summary>
        /// <param name="key1">検索するキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>がnull</exception>
        /// <returns>キーが存在していたらtrue，それ以外でfalse</returns>
        bool ContainsKey1(TKey1 key1);
        /// <summary>
        /// 指定したキーが存在するかどうかを返す
        /// </summary>
        /// <param name="key">検索するキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns>キーが存在していたらtrue，それ以外でfalse</returns>
        bool ContainsKey2(TKey2 key);
        /// <summary>
        /// 指定した値が存在するかどうかを返す
        /// </summary>
        /// <param name="value">検索するキー</param>
        /// <returns>キーが存在していたらtrue，それ以外でfalse</returns>
        bool ContainsValue(TValue value);
    }
}