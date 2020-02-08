using System;
using System.Collections;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// 2つのキーと値のジェネリックコレクションを表す
    /// </summary>
    /// <typeparam name="TKey1">キー1</typeparam>
    /// <typeparam name="TKey2">キー2</typeparam>
    /// <typeparam name="TValue">値</typeparam>
    public interface IDoubleKeyDictionary<TKey1, TKey2, TValue> : ICollection<DoubleKeyValuePair<TKey1, TKey2, TValue>>, IEnumerable<DoubleKeyValuePair<TKey1, TKey2, TValue>>, IEnumerable
    {
        /// <summary>
        /// インデクサ
        /// <typeparamref name="TKey1"/>と<typeparamref name="TKey2"/>のペアと一致する<typeparamref name="TValue"/>を設定または取得する
        /// </summary>
        /// <param name="key1">1つ目の<typeparamref name="TKey1"/></param>
        /// <param name="key2">2つ目の<typeparamref name="TKey2"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>がnull</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="key2"/>がコレクションに存在しない</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        TValue this[TKey1 key1, TKey2 key2] { get; set; }
        /// <summary>
        /// <see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>の持っている<typeparamref name="TKey1"/>の<see cref="ICollection{T}"/>を取得する
        /// </summary>
        ICollection<TKey1> Key1Collection { get; }
        /// <summary>
        /// <see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>の持っている<typeparamref name="TKey2"/>の<see cref="ICollection{T}"/>を取得する
        /// </summary>
        ICollection<TKey2> Key2Collection { get; }
        /// <summary>
        /// <see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>内の<typeparamref name="TValue"/>を格納している<see cref="ICollection{T}"/>を取得する
        /// </summary>
        ICollection<TValue> Values { get; }
        /// <summary>
        /// 指定した<typeparamref name="TKey1"/>，<typeparamref name="TKey2"/>のペアと<typeparamref name="TValue"/>を<see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>に追加する
        /// </summary>
        /// <param name="key1">追加する<typeparamref name="TKey1"/></param>
        /// <param name="key2">追加する<typeparamref name="TKey2"/></param>
        /// <param name="value">追加する<paramref name="value"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>又は<paramref name="key2"/>がnull</exception>
        /// <exception cref="KeyDuplicateException">同じ値の組み合わせの<typeparamref name="TKey1"/>と<typeparamref name="TKey2"/>が既に存在する</exception>
        /// <exception cref="NotSupportedException"><see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>が読み取り専用</exception>
        void Add(TKey1 key1, TKey2 key2, TValue value);
        /// <summary>
        /// 指定した2つのキーがディクショナリに存在するかどうかを返す。
        /// </summary>
        /// <param name="key1">検索するキー1</param>
        /// <param name="key2">検索するキー2</param>
        /// <returns>存在する場合はtrue, それ以外はfalse</returns>
        /// <exception cref="ArgumentNullException">keyがnull</exception>
        bool ContainsKeyPair(TKey1 key1, TKey2 key2);
        /// <summary>
        /// 指定する組合せの<typeparamref name="TKey1"/>と<typeparamref name="TKey2"/>を持つ<typeparamref name="TValue"/>を<see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>から削除する
        /// </summary>
        /// <param name="key1">削除される<typeparamref name="TValue"/>の<typeparamref name="TKey1"/></param>
        /// <param name="key2">削除される<typeparamref name="TValue"/>の<typeparamref name="TKey2"/></param>
        /// <returns>正常に削除された場合はtrue，<paramref name="key1"/>と<paramref name="key2"/>の組み合わせが存在しないまたはそれ以外の場合はfalse</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>又は<paramref name="key2"/>がnull</exception>
        /// <exception cref="NotSupportedException"><see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>が読み取り専用</exception>
        bool Remove(TKey1 key1, TKey2 key2);
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
        /// 指定された組合せの<typeparamref name="TKey1"/>と<typeparamref name="TKey2"/>に関連付けられている<typeparamref name="TValue"/>を取得する
        /// </summary>
        /// <param name="key1"><typeparamref name="TValue"/>を取得する<typeparamref name="TKey1"/></param>
        /// <param name="key2"><typeparamref name="TValue"/>を取得する<typeparamref name="TKey2"/></param>
        /// <param name="value"><typeparamref name="TValue"/>が存在していたらその値，それ以外の場合は規定値を返す。</param>
        /// <returns><see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>に値が含まれる場合はtrue，それ以外にfalse</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>又は<paramref name="key2"/>がnull</exception>
        bool TryGetValue(TKey1 key1, TKey2 key2, out TValue value);
    }
}