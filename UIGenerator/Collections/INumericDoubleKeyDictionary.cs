using System;
using System.Collections.Generic;

namespace UIGenerator
{
    /// <summary>
    /// インデックス検索とキー検索両方が出来るジェネリックコレクションの基底インターフェイス
    /// </summary>
    /// <typeparam name="TKey1">キーの型1</typeparam>
    /// <typeparam name="TKey2">キーの型2</typeparam>
    /// <typeparam name="TValue">値の型</typeparam>
    public interface INumericDoubleKeyDictionary<TKey1, TKey2, TValue> : IList<DoubleKeyValuePair<TKey1, TKey2, TValue>>, IDoubleKeyDictionary<TKey1, TKey2, TValue>
    {
        /// <summary>
        /// 格納されているキーのコレクションを取得する
        /// </summary>
        new IList<TKey1> Key1Collection { get; }
        /// <summary>
        /// 格納されているキーのコレクションを取得する
        /// </summary>
        new IList<TKey2> Key2Collection { get; }
        /// <summary>
        /// 格納されている値のコレクションを取得する
        /// </summary>
        new IList<TValue> Values { get; }
        /// <summary>
        /// 指定したキーが存在するかどうかを返す
        /// </summary>
        /// <param name="key">検索するキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/>がnull</exception>
        /// <returns>キーが存在していたらtrue，それ以外でfalse</returns>
        bool ContainsKey1(TKey1 key);
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
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="arrayIndex"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        void CopyTo(TValue[] array, int arrayIndex);
        /// <summary>
        /// 指定したキーの組み合わせを持つ値のインデックスを返す
        /// </summary>
        /// <param name="key1">検索するキー1</param>
        /// <param name="key2">検索するキー2</param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>または<paramref name="key2"/>がnull</exception>
        /// <returns>見つかったらそのインデックス，見つからなかったら見つからなかったら-1</returns>
        int IndexOf(TKey1 key1, TKey2 key2);
        /// <summary>
        /// 指定した値のインデックスのうち先頭の物を返す
        /// </summary>
        /// <param name="value">検索する値</param>
        /// <returns>見つかったらそのインデックス，見つからなかったら見つからなかったら-1</returns>
        int IndexOf(TValue value);
        /// <summary>
        /// 指定したインデックスにキーと値のペアを挿入する
        /// </summary>
        /// <param name="index">挿入する位置</param>
        /// <param name="key1">挿入する値のキー1</param>
        /// <param name="key2">挿入する値のキー2</param>
        /// <param name="value">挿入する値</param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>または<paramref name="key2"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="ICollection{T}.Count"/>より大きい</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="key1"/>と<paramref name="key2"/>の組み合わせが既に存在している</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        void Insert(int index, TKey1 key1, TKey2 key2, TValue value);
        /// <summary>
        /// 指定したキーを持つ値のキーを変更する
        /// キーが変更された要素のインデックスは変わらない
        /// </summary>
        /// <param name="oldKey1">検索する値のキー1</param>
        /// <param name="key2">検索する値のキー2</param>
        /// <param name="newKey1">変更後のキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="oldKey1"/>または<paramref name="key2"/>，<paramref name="newKey1"/>がnull</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="newKey1"/>と<paramref name="key2"/>の組み合わせが既に使用されている</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="oldKey1"/>と<paramref name="key2"/>の組み合わせが存在していない</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        /// <returns>変更された要素のインデックス</returns>
        int OverWrite(TKey1 oldKey1, TKey2 key2, TKey1 newKey1);
        /// <summary>
        /// 指定したキーを持つ値のキーを変更する
        /// キーが変更された要素のインデックスは変わらない
        /// </summary>
        /// <param name="key1">検索する値のキー1</param>
        /// <param name="oldKey2">検索する値のキー2</param>
        /// <param name="newKey2">変更後のキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="key1"/>または<paramref name="oldKey2"/>，<paramref name="newKey2"/>がnull</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="key1"/>と<paramref name="newKey2"/>の組み合わせが既に使用されている</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="key1"/>と<paramref name="oldKey2"/>の組み合わせが存在していない</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        /// <returns>変更された要素のインデックス</returns>
        int OverWrite(TKey1 key1, TKey2 oldKey2, TKey2 newKey2);
        /// <summary>
        /// 指定したキーを持つ値のキーを変更する
        /// キーが変更された要素のインデックスは変わらない
        /// </summary>
        /// <param name="oldKey1">検索する値のキー1</param>
        /// <param name="oldKey2">検索する値のキー2</param>
        /// <param name="newKey1">変更後のキー1</param>
        /// <param name="newKey2">変更後のキー2</param>
        /// <exception cref="ArgumentNullException"><paramref name="oldKey1"/>または<paramref name="oldKey2"/>，<paramref name="newKey1"/>，<paramref name="newKey2"/>がnull</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="newKey1"/>と<paramref name="newKey2"/>の組み合わせが既に使用されている</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="oldKey1"/>と<paramref name="oldKey2"/>の組み合わせが存在していない</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        /// <returns>変更された要素のインデックス</returns>
        int OverWrite(TKey1 oldKey1, TKey2 oldKey2, TKey1 newKey1, TKey2 newKey2);
        /// <summary>
        /// 指定したインデックスの要素のキーを変更する キーが変更された要素のインデックスは変わらない
        /// </summary>
        /// <param name="index">キーを変更する要素のインデックス</param>
        /// <param name="newKey1">変更後のキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="newKey1"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="ICollection{T}.Count"/>以上</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="newKey1"/>が既に使用されている</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        void OverWrite(int index, TKey1 newKey1);
        /// <summary>
        /// 指定したインデックスの要素のキーを変更する キーが変更された要素のインデックスは変わらない
        /// </summary>
        /// <param name="index">キーを変更する要素のインデックス</param>
        /// <param name="newKey2">変更後のキー</param>
        /// <exception cref="ArgumentNullException"><paramref name="newKey2"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="ICollection{T}.Count"/>以上</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="newKey2"/>が既に使用されている</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        void OverWrite(int index, TKey2 newKey2);
        /// <summary>
        /// 指定したインデックスの要素のキーを変更する キーが変更された要素のインデックスは変わらない
        /// </summary>
        /// <param name="index">キーを変更する要素のインデックス</param>
        /// <param name="newKey1">変更後のキー1</param>
        /// <param name="newKey2">変更後のキー2</param>
        /// <exception cref="ArgumentNullException"><paramref name="newKey1"/>または<paramref name="newKey2"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="ICollection{T}.Count"/>以上</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="newKey1"/>と<paramref name="newKey2"/>の組み合わせが既に使用されている</exception>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        void OverWrite(int index, TKey1 newKey1, TKey2 newKey2);
        /// <summary>
        /// 指定した値のうち先頭の物を削除する
        /// </summary>
        /// <param name="value">削除する値</param>
        /// <exception cref="NotSupportedException">コレクションが読み取り専用</exception>
        /// <returns>削除出来たらtrue，それ以外でfalse</returns>
        bool Remove(TValue value);
    }
}