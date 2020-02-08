using System;
using System.Collections;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// 2つのキーと値の読み取り専用コレクションを表す。
    /// </summary>
    /// <typeparam name="TKey1">読み取り専用ディクショナリの1つ目のキー</typeparam>
    /// <typeparam name="TKey2">読み取り専用ディクショナリの2つ目のキー</typeparam>
    /// <typeparam name="TValue">読み取り専用ディクショナリの値</typeparam>
    public interface IReadOnlyDoubleKeyDictionary<TKey1, TKey2, TValue> : IReadOnlyCollection<DoubleKeyValuePair<TKey1, TKey2, TValue>>, IEnumerable<DoubleKeyValuePair<TKey1, TKey2, TValue>>, IEnumerable
    {
        /// <summary>
        /// インデクサ
        /// <typeparamref name="TKey1"/>，<typeparamref name="TKey2"/>のペアと一致する<typeparamref name="TValue"/>を取得する
        /// </summary>
        /// <param name="key1">1つ目の<typeparamref name="TKey1"/></param>
        /// <param name="key2">2つ目の<typeparamref name="TKey2"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>または<paramref name="key2"/>がnull</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="key1"/>と<paramref name="key2"/>の組み合わせが<see cref="IReadOnlyDoubleKeyDictionary{TKey1, TKey2, TValue}"/>内に存在しない</exception>
        TValue this[TKey1 key1, TKey2 key2] { get; }
        /// <summary>
        /// 読み取り専用のディクショナリに含まれる列挙可能な<typeparamref name="TKey1"/>のコレクションを返す。
        /// </summary>
        IEnumerable<TKey1> Key1Collection { get; }
        /// <summary>
        /// 読み取り専用のディクショナリに含まれる列挙可能な<typeparamref name="TKey2"/>のコレクションを返す。
        /// </summary>
        IEnumerable<TKey2> Key2Collection { get; }
        /// <summary>
        /// 読み取り専用のディクショナリに含まれる列挙可能な<typeparamref name="TValue"/>のコレクションを返す。
        /// </summary>
        IEnumerable<TValue> Values { get; }
        /// <summary>
        /// 指定した2つのキーが読み取り専用ディクショナリに存在するかどうかを返す。
        /// </summary>
        /// <param name="key1">検索するキー1</param>
        /// <param name="key2">検索するキー2</param>
        /// <returns>存在する場合はtrue, それ以外はfalse</returns>
        /// <exception cref="ArgumentNullException">keyがnull</exception>
        bool ContainsKeyPair(TKey1 key1, TKey2 key2);
        /// <summary>
        /// 指定しキー1を持つ要素のコレクションを取得する
        /// </summary>
        /// <param name="key">検索するキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を持つ値のコレクション</returns>
        IDictionary<TKey2, KeyValuePair<TKey1, TValue>> SelectFromKey1(TKey1 key);
        /// <summary>
        /// 指定しキー2を持つ要素のコレクションを取得する
        /// </summary>
        /// <param name="key">検索するキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns><paramref name="key"/>を持つ値のコレクション</returns>
        IDictionary<TKey1, KeyValuePair<TKey2, TValue>> SelectFromKey2(TKey2 key);
        /// <summary>
        /// 指定した<typeparamref name="TKey1"/>と<typeparamref name="TKey2"/>のペアに結び付けられている値を返す。
        /// </summary>
        /// <param name="key1"><typeparamref name="TValue"/>を検索するための<typeparamref name="TKey1"/></param>
        /// <param name="key2"><typeparamref name="TValue"/>を検索するための<typeparamref name="TKey2"/></param>
        /// <param name="value"><typeparamref name="TValue"/>が存在した場合はその値が，存在しなかったら規定値が返される。</param>
        /// <returns>指定した要素が含まれている場合true，それ以外はfalse</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>又は<paramref name="key2"/>がnull</exception>
        bool TryGetValue(TKey1 key1, TKey2 key2, out TValue value);
    }
}