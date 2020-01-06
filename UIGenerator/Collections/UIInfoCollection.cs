﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using fslib;
using fslib.Collections;
using fslib.Exception;

namespace UIGenerator
{
    /// <summary>
    /// UIに関する情報を格納するコレクションのクラス
    /// </summary>
    [Serializable]
    public sealed class UIInfoCollection : INumericDoubleKeyDictionary<int, string, UIInfoBase>, IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>, ICollection, ISerializable
    {
        private int version = 0;
        private DoubleKeyValuePair<int, string, UIInfoBase>[] _array;
        private readonly static DoubleKeyValuePair<int, string, UIInfoBase>[] emptyArray = new DoubleKeyValuePair<int, string, UIInfoBase>[0];
        private const string Name_Array = "S_Array";
        private const string Name_Version = "S_Version";
        private const string Name_Count = "S_Count";
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        internal int Capacity => _array.Length;
        /// <summary>
        /// 登録されている要素の表示モードの最大値を取得する
        /// </summary>
        public int MaxMode
        {
            get
            {
                var max = -1;
                for (int i = 0; i < Count; i++)
                    if (_array[i].Key1 > max)
                        max = _array[i].Key1;
                return max;
            }
        }
        /// <summary>
        /// 登録されている要素の表示モードの最小値を取得する
        /// </summary>
        public int MinMode
        {
            get
            {
                var min = int.MaxValue;
                for (int i = 0; i < Count; i++)
                    if (min > _array[i].Key1)
                        min = _array[i].Key1;
                return Count == 0 ? -1 : min;
            }
        }
        private IList<int> Modes
        {
            get
            {
                var list = new List<int>(Count);
                for (int i = 0; i < Count; i++) list.Add(_array[i].Key1);
                return list;
            }
        }
        IList<int> INumericDoubleKeyDictionary<int, string, UIInfoBase>.KeysCollection1 => Modes;
        IEnumerable<int> IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.KeyCollection1 => Modes;
        /// <summary>
        /// 名前を格納しているコレクションを取得する
        /// </summary>
        public NameCollection Names => _names ?? (_names = new NameCollection(this));
        private NameCollection _names;
        IList<string> INumericDoubleKeyDictionary<int, string, UIInfoBase>.KeysCollection2 => Names;
        IEnumerable<string> IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.KeyCollection2 => Names;
        /// <summary>
        /// <see cref="UIInfoBase"/>を格納しているコレクションを取得する
        /// </summary>
        public InfoCollection Infos => _infos ?? (_infos = new InfoCollection(this));
        private InfoCollection _infos;
        IList<UIInfoBase> INumericDoubleKeyDictionary<int, string, UIInfoBase>.Values => Infos;
        IEnumerable<UIInfoBase> IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.Values => Infos;
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot
        {
            get
            {
                Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                return _syncRoot;
            }
        }
        private object _syncRoot;
        bool ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.IsReadOnly => false;
        /// <summary>
        /// 既定の容量を備えた空の<see cref="UIInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        public UIInfoCollection() : this(0) { }
        /// <summary>
        /// 指定した容量を備えた空の<see cref="UIInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        /// <param name="capacity">設定する容量</param>
        public UIInfoCollection(int capacity)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(capacity, 0, int.MaxValue, null);
            _array = capacity == 0 ? emptyArray : new DoubleKeyValuePair<int, string, UIInfoBase>[capacity];
        }
        /// <summary>
        /// 指定したコレクションの要素のコピーを持った<see cref="UIInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        /// <param name="collection">要素をコピーする<see cref="IEnumerable{T}"/>のインスタンス</param>
        public UIInfoCollection(IEnumerable<UIInfoBase> collection)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, collection);
            _array = new DoubleKeyValuePair<int, string, UIInfoBase>[collection.Count()];
            using (var e = collection.GetEnumerator())
                while (e.MoveNext())
                    Add(e.Current.Mode, e.Current.Name, e.Current);
        }
        /// <summary>
        /// 指定したコレクションの要素のコピーを持った<see cref="UIInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="ddictionary"/>がnull</exception>
        /// <param name="ddictionary">要素をコピーする<see cref="IDoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンス</param>
        public UIInfoCollection(IEnumerable<DoubleKeyValuePair<int, string, UIInfoBase>> ddictionary)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, ddictionary);
            _array = new DoubleKeyValuePair<int, string, UIInfoBase>[ddictionary.Count()];
            using (var e = ddictionary.GetEnumerator())
                while (e.MoveNext())
                    Add(e.Current.Key1, e.Current.Key2, e.Current.Value);
        }
        private UIInfoCollection(SerializationInfo info, StreamingContext context)
        {
            _array = (DoubleKeyValuePair<int, string, UIInfoBase>[])info.GetValue(Name_Array, typeof(DoubleKeyValuePair<int, string, UIInfoBase>[]));
            Count = info.GetInt32(Name_Count);
            version = info.GetInt32(Name_Version);
        }
        /// <summary>
        /// 指定したインデックスに対応する要素を取得する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        /// <returns><paramref name="index"/>に対応する要素</returns>
        public UIInfoBase this[int index]
        {
            get
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                return _array[index].Value;
            }
        }
        /// <summary>
        /// 指定した表示モードと名前を持つ要素を取得する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyNotFoundException">指定した<paramref name="mode"/>と<paramref name="name"/>の組み合わせが存在しない</exception>
        /// <returns>指定した表示モードと名前を持つ<see cref="UIInfoBase"/>のインスタンス</returns>
        public UIInfoBase this[int mode, string name]
        {
            get
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
                var index = IndexOf(mode, name);
                Central.ThrowHelper.ThrowExceptionWithMessage(new KeyNotFoundException(), index == -1, null);
                return _array[index].Value;
            }
        }
        UIInfoBase INumericDoubleKeyDictionary<int, string, UIInfoBase>.this[int mode, string name]
        {
            get
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
                var index = IndexOf(mode, name);
                return index != -1 ? _array[index].Value : throw new KeyNotFoundException();
            }
            set
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
                Central.ThrowHelper.ThrowArgumentNullException(null, value);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
                var index = IndexOf(mode, name);
                if (index == -1) throw new KeyNotFoundException();
                _array[index] = new DoubleKeyValuePair<int, string, UIInfoBase>(_array[index].Key1, _array[index].Key2, value);
            }
        }
        UIInfoBase INumericDoubleKeyDictionary<int, string, UIInfoBase>.this[int index]
        {
            get
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                return _array[index].Value;
            }
            set
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                Central.ThrowHelper.ThrowArgumentNullException(null, value);
                var i = IndexOf(value);
                Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), i != -1 && i != index, null);
                _array[index] = new DoubleKeyValuePair<int, string, UIInfoBase>(_array[index].Key1, _array[index].Key2, value);
            }
        }
        /// <summary>
        /// 指定した要素を末尾に追加する
        /// </summary>
        /// <param name="mode">追加する要素の表示モード</param>
        /// <param name="name">追加する要素の名前</param>
        /// <param name="info">追加する要素</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>又は<paramref name="info"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが既に存在している</exception>
        public void Add(int mode, string name, UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new KeyDuplicateException(), Contains(mode, name), null);
            if (Capacity < Count + 1) ReSize();
            _array[Count++] = new DoubleKeyValuePair<int, string, UIInfoBase>(mode, name, info);
            version++;
        }
        void ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.Add(DoubleKeyValuePair<int, string, UIInfoBase> item) => Add(item.Key1, item.Key2, item.Value);
        /// <summary>
        /// 要素の名前を変更する
        /// </summary>
        /// <param name="mode">変更する要素の表示モード</param>
        /// <param name="oldname">変更前の名前</param>
        /// <param name="newname">変更後の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="oldname"/>又は<paramref name="newname"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="mode"/>と<paramref name="newname"/>の組み合わせが既に存在している</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="mode"/>と<paramref name="oldname"/>の組み合わせが存在しない</exception>
        /// <returns>変更した要素のインデックス</returns>
        public int ChangeName(int mode, string oldname, string newname)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: oldname);
            Central.ThrowHelper.ThrowArgumentNullException(null, values: newname);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            var index = IndexOf(mode, oldname);
            if (index == -1) throw new KeyNotFoundException();
            var ind = IndexOf(mode, newname);
            if (ind != -1 && index != ind) throw new KeyDuplicateException();
            var pair = _array[index];
            pair.Value.Name = newname;
            _array[index] = new DoubleKeyValuePair<int, string, UIInfoBase>(pair.Key1, newname, pair.Value);
            return index;
        }
        /// <summary>
        /// 要素の表示モードを変更する
        /// </summary>
        /// <param name="oldmode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <param name="newmode">変更後の表示モード</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="oldmode"/>または<paramref name="newmode"/>が0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="newmode"/>と<paramref name="name"/>の組み合わせが既に存在している</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="oldmode"/>と<paramref name="name"/>の組み合わせが存在しない</exception>
        /// <returns>変更した要素のインデックス</returns>
        public int ChangeMode(int oldmode, string name, int newmode)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(oldmode, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(newmode, 0, int.MaxValue, null);
            var index = IndexOf(oldmode, name);
            if (index == -1) throw new KeyNotFoundException();
            var ind = IndexOf(newmode, name);
            if (ind != -1 && index != ind) throw new KeyDuplicateException();
            var pair = _array[index];
            pair.Value.Mode = newmode;
            _array[index] = new DoubleKeyValuePair<int, string, UIInfoBase>(newmode, pair.Key2, pair.Value);
            return index;
        }
        /// <summary>
        /// 格納されている要素をすべて削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) _array[i] = default;
            Count = 0;
            version++;
        }
        /// <summary>
        /// 指定した<see cref="UIInfoBase"/>が値として格納されているかどうかを返す
        /// </summary>
        /// <param name="info">検索する要素</param>
        /// <returns>含まれていたらtrue，それ以外でfalse</returns>
        public bool Contains(UIInfoBase info) => IndexOf(info) != -1;
        /// <summary>
        /// 指定された表示モードと名前の組み合わせが存在するかどうかを返す
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <returns>含まれていたらtrue，それ以外でfalse</returns>
        public bool Contains(int mode, string name) => IndexOf(mode, name) != -1;
        private bool ContainsMode(int mode)
        {
            if (mode < 0) return false;
            for (int i = 0; i < Count; i++)
                if (mode == _array[i].Key1)
                    return true;
            return false;
        }
        private bool ContainsName(string name)
        {
            if (name == null) return false;
            for (int i = 0; i < Count; i++)
                if (name == _array[i].Key2)
                    return true;
            return false;
        }
        bool ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.Contains(DoubleKeyValuePair<int, string, UIInfoBase> item) => IndexOf(item) != -1;
        bool INumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey1(int mode) => ContainsMode(mode);
        bool INumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey2(string name) => ContainsName(name);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey1(int mode) => ContainsMode(mode);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey2(string name) => ContainsName(name);
        bool INumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKeyPair(int key1, string key2) => Contains(key1, key2);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKeyPair(int key1, string key2) => Contains(key1, key2);
        bool INumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsValue(UIInfoBase value) => Contains(value);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, UIInfoBase>.ContainsValue(UIInfoBase value) => Contains(value);
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        public void CopyTo(UIInfoBase[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < arrayIndex + Count, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i].Value;
        }
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        internal void CopyTo(DoubleKeyValuePair<int, string, UIInfoBase>[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < arrayIndex + Count, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < Count + index || array.GetLowerBound(0) != 0, null);
            switch (array)
            {
                case DoubleKeyValuePair<int, string, UIInfoBase>[] p: CopyTo(p, index); return;
                case UIInfoBase[] u: CopyTo(u, index); return;
                case int[] it:
                    for (int i = 0; i < Count; i++)
                        it[index++] = _array[i].Key1;
                    return;
                case string[] s:
                    for (int i = 0; i < Count; i++)
                        s[index++] = _array[i].Key2;
                    return;
                case DoubleKey<int, string>[] p:
                    for (int i = 0; i < Count; i++)
                        p[index++] = _array[i].GetKeyValuePair().Key;
                    return;
                case object[] o:
                    try
                    {
                        for (int i = 0; i < Count; i++) o[index++] = _array[i];
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentException();
                    }
                    return;
                default: throw new ArgumentException();
            }
        }
        void ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.CopyTo(DoubleKeyValuePair<int, string, UIInfoBase>[] array, int arrayIndex) => CopyTo(array, arrayIndex);
        /// <summary>
        /// シリアル化するデータを保存する
        /// </summary>
        /// <param name="info">シリアル化するデータを設定する<see cref="SerializationInfo"/>のインスタンス</param>
        /// <param name="context">出力先の情報を持つ<see cref="StreamingContext"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            info.AddValue(Name_Array, _array);
            info.AddValue(Name_Count, Count);
            info.AddValue(Name_Version, version);
        }
        /// <summary>
        /// 指定された要素と一致する物のインデックスを検索する
        /// </summary>
        /// <param name="info">検索する<see cref="UIInfoBase"/>のインスタンス</param>
        /// <returns>そのインデックス 無かったら-1</returns>
        public int IndexOf(UIInfoBase info)
        {
            if (info == null) return -1;
            for (int i = 0; i < Count; i++)
                if (_array[i].Value == info)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定された表示モードと名前を持つ要素のインデックスを検索する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <returns>そのインデックス 無かったら-1</returns>
        public int IndexOf(int mode, string name)
        {
            if (mode < 0 || name == null) return -1;
            for (int i = 0; i < Count; i++)
                if ((_array[i].Key1 == mode) && (_array[i].Key2 == name))
                    return i;
            return -1;
        }
        private int IndexOf(DoubleKeyValuePair<int, string, UIInfoBase> item)
        {
            if (item.Key1 < 0 || item.Key2 == null || item.Value == null) return -1;
            for (int i = 0; i < Count; i++)
                if ((_array[i].Key1 == item.Key1) && (_array[i].Key2 == item.Key2) && (_array[i].Value == item.Value))
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定したインデックスに要素を挿入する
        /// </summary>
        /// <param name="index">挿入するインデックス</param>
        /// <param name="mode">挿入する値の表示モード</param>
        /// <param name="name">挿入する値の名前</param>
        /// <param name="info">挿入する<see cref="UIInfoBase"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>又は<paramref name="info"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>よりも大きい，もしくは<paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが既に存在している</exception>
        public void Insert(int index, int mode, string name, UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, Count, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new KeyDuplicateException(), Contains(mode, name), null);
            if (Capacity < Count + 1) ReSize();
            if (index < Count) Array.Copy(_array, index, _array, index + 1, Count - index);
            _array[index] = new DoubleKeyValuePair<int, string, UIInfoBase>(mode, name, info);
            Count++;
            version++;
        }
        int INumericDoubleKeyDictionary<int, string, UIInfoBase>.OverWrite(int key1, string oldKey2, string newKey2) => ChangeName(key1, oldKey2, newKey2);
        int INumericDoubleKeyDictionary<int, string, UIInfoBase>.OverWrite(int oldKey1, string key2, int newKey1) => ChangeMode(oldKey1, key2, newKey1);
        int INumericDoubleKeyDictionary<int, string, UIInfoBase>.OverWrite(int oldKey1, string oldKey2, int newKey1, string newKey2) => throw new NotImplementedException();
        void INumericDoubleKeyDictionary<int, string, UIInfoBase>.OverWrite(int index, int newKey1) => throw new NotImplementedException();
        void INumericDoubleKeyDictionary<int, string, UIInfoBase>.OverWrite(int index, string newKey2) => throw new NotImplementedException();
        void INumericDoubleKeyDictionary<int, string, UIInfoBase>.OverWrite(int index, int newKey1, string newKey2) => throw new NotImplementedException();
        /// <summary>
        /// 指定した表示モードと名前を持つ要素を削除する
        /// </summary>
        /// <param name="mode">削除する要素の表示モード</param>
        /// <param name="name">削除する要素の名前</param>
        /// <returns>削除出来たらtrue，削除できなかったらfalse</returns>
        public bool Remove(int mode, string name)
        {
            if (mode < 0 || name == null) return false;
            var index = IndexOf(mode, name);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        private bool Remove(DoubleKeyValuePair<int, string, UIInfoBase> item)
        {
            if (item.Key1 < 0 || item.Key2 == null || item.Value == null) return false;
            var index = IndexOf(item.Key1, item.Key2);
            if (index == -1 || _array[index].Value != item.Value) return false;
            RemoveAt(index);
            return true;
        }
        bool ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.Remove(DoubleKeyValuePair<int, string, UIInfoBase> item) => Remove(item);
        bool INumericDoubleKeyDictionary<int, string, UIInfoBase>.Remove(UIInfoBase value)
        {
            var index = IndexOf(value);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定したインデックスの要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        ///<exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        public void RemoveAt(int index)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            _array[Count - 1] = default;
            Count--;
            version++;
        }
        private void ReSize()
        {
            var size = Capacity == 0 ? 4 : Capacity * 2;
            var array = new DoubleKeyValuePair<int, string, UIInfoBase>[size];
            for (int i = 0; i < Count; i++) array[i] = _array[i];
            _array = array;
        }
        /// <summary>
        /// このインスタンスの要素を格納する<see cref="DoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンスを返す
        /// </summary>
        /// <returns>要素がコピーされた<see cref="DoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンス</returns>
        public DoubleKeyDictionary<int, string, UIInfoBase> ToDoubleKeyDictionary()
        {
            var dic = new DoubleKeyDictionary<int, string, UIInfoBase>(Count);
            for (int i = 0; i < Count; i++) dic.Add(_array[i].Key1, _array[i].Key2, _array[i].Value);
            return dic;
        }
        /// <summary>
        /// 指定した表示モードと名前を持つ要素を検索する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <param name="info">検索結果 見つからなかったら既定値</param>
        /// <returns>指定した表示モードと名前を持つ要素が見つかったらtrue，それ以外でfalse</returns>
        public bool TryGetValue(int mode, string name, out UIInfoBase info)
        {
            if (mode < 0 || name == null)
            {
                info = default;
                return false;
            }
            var index = IndexOf(mode, name);
            if (index == -1)
            {
                info = default;
                return false;
            }
            info = _array[index].Value;
            return true;
        }
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns>新しい<see cref="Enumerator"/>のインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<DoubleKeyValuePair<int, string, UIInfoBase>> IEnumerable<DoubleKeyValuePair<int, string, UIInfoBase>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<DoubleKeyValuePair<int, string, UIInfoBase>>
        {
            private int index;
            private readonly int version;
            private readonly UIInfoCollection collection;
            /// <summary>
            /// 現在列挙されている要素を取得する
            /// </summary>
            public DoubleKeyValuePair<int, string, UIInfoBase> Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                    return Current;
                }
            }
            internal Enumerator(UIInfoCollection collection)
            {
                this.collection = collection;
                version = collection.version;
                index = 0;
                Current = default;
            }
            /// <summary>
            /// このインスタンスを破棄する
            /// </summary>
            public void Dispose() { }
            /// <summary>
            /// 列挙を次に進める
            /// </summary>
            /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
            /// <returns>次に進められたらtrue，それ以外でfalse</returns>
            public bool MoveNext()
            {
                Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                if (index < collection.Count)
                {
                    Current = collection._array[index++];
                    return true;
                }
                index = collection.Count + 1;
                Current = default;
                return false;
            }
            void IEnumerator.Reset()
            {
                index = 0;
                Current = default;
            }
        }
        /// <summary>
        /// <see cref="UIInfoCollection"/>に格納されている名前のコレクション
        /// </summary>
        [Serializable]
        public sealed class NameCollection : IList<string>, IReadOnlyList<string>, IList
        {
            /// <summary>
            /// 格納されている要素数を取得する
            /// </summary>
            public int Count => collection.Count;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => ((ICollection)collection).SyncRoot;
            bool IList.IsFixedSize => false;
            bool IList.IsReadOnly => true;
            bool ICollection<string>.IsReadOnly => true;
            private readonly UIInfoCollection collection;
            internal NameCollection(UIInfoCollection collection)
            {
                this.collection = collection ?? throw new ArgumentNullException();
            }
            /// <summary>
            /// 指定したインデックスの要素を取得する
            /// </summary>
            /// <param name="index">取得する要素のインデックス</param>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
            /// <returns>指定したインデックスに対応する要素</returns>
            public string this[int index]
            {
                get
                {
                    Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
                    return collection._array[index].Key2;
                }
            }
            object IList.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            string IList<string>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            void ICollection<string>.Add(string item) => throw new NotSupportedException();
            int IList.Add(object value) => throw new NotSupportedException();
            void ICollection<string>.Clear() => throw new NotSupportedException();
            void IList.Clear() => throw new NotSupportedException();
            /// <summary>
            /// 指定した要素が含まれているかどうかを返す
            /// </summary>
            /// <param name="name">検索する要素</param>
            /// <returns>格納されていたらtrue，それ以外でfalse</returns>
            public bool Contains(string name) => collection.ContainsName(name);
            bool IList.Contains(object value) => value is string s ? Contains(s) : false;
            /// <summary>
            /// 指定した配列に要素をコピーする
            /// </summary>
            /// <param name="array">コピー先の配列</param>
            /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
            /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
            public void CopyTo(string[] array, int arrayIndex)
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, array);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < Count + arrayIndex, null);
                for (int i = 0; i < Count; i++) array[arrayIndex++] = collection._array[i].Key2;
            }
            void ICollection.CopyTo(Array array, int index)
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, array);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < Count + index || array.GetLowerBound(0) != 0, null);
                switch (array)
                {
                    case string[] s: CopyTo(s, index); return;
                    case object[] o:
                        try
                        {
                            for (int i = 0; i < Count; i++) o[index++] = collection._array[i].Key2;
                        }
                        catch (ArrayTypeMismatchException)
                        {
                            throw new ArgumentException();
                        }
                        return;
                    default: throw new ArgumentException();
                }
            }
            private int IndexOf(string name)
            {
                if (name == null) return -1;
                for (int i = 0; i < Count; i++)
                    if (collection._array[i].Key2 == name)
                        return i;
                return -1;
            }
            int IList.IndexOf(object value) => value is string s ? IndexOf(s) : -1;
            int IList<string>.IndexOf(string item) => IndexOf(item);
            void IList.Insert(int index, object value) => throw new NotSupportedException();
            void IList<string>.Insert(int index, string item) => throw new NotSupportedException();
            bool ICollection<string>.Remove(string item) => throw new NotSupportedException();
            void IList.Remove(object value) => throw new NotSupportedException();
            void IList.RemoveAt(int index) => throw new NotSupportedException();
            void IList<string>.RemoveAt(int index) => throw new NotSupportedException();
            /// <summary>
            /// 列挙をサポートする構造体を返す
            /// </summary>
            /// <returns><see cref="Enumerator"/>のインスタンス</returns>
            public Enumerator GetEnumerator() => new Enumerator(collection);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();
            /// <summary>
            /// 列挙をサポートする構造体
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<string>
            {
                private readonly UIInfoCollection collection;
                private int index;
                private readonly int version;
                /// <summary>
                /// 現在列挙されている要素を取得する
                /// </summary>
                public string Current { get; private set; }
                object IEnumerator.Current
                {
                    get
                    {
                        Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                        return Current;
                    }
                }
                internal Enumerator(UIInfoCollection collection)
                {
                    this.collection = collection ?? throw new ArgumentNullException();
                    index = 0;
                    Current = default;
                    version = collection.version;
                }
                /// <summary>
                /// このインスタンスを破棄する
                /// </summary>
                public void Dispose() { }
                /// <summary>
                /// 列挙を次に進める
                /// </summary>
                /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
                /// <returns>次の要素に進められたらtrue，それ以外でfalse</returns>
                public bool MoveNext()
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                    if (index < collection.Count)
                    {
                        Current = collection._array[index++].Key2;
                        return true;
                    }
                    Current = default;
                    index = collection.Count + 1;
                    return false;
                }
                void IEnumerator.Reset()
                {
                    index = 0;
                    Current = default;
                }
            }
        }
        /// <summary>
        /// <see cref="UIInfoCollection"/>に格納されている<see cref="UIInfoBase"/>のコレクション
        /// </summary>
        [Serializable]
        public sealed class InfoCollection : IList<UIInfoBase>, IReadOnlyList<UIInfoBase>, IList
        {
            /// <summary>
            /// 格納されている要素数を取得する
            /// </summary>
            public int Count => collection.Count;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => ((ICollection)collection).SyncRoot;
            bool IList.IsFixedSize => false;
            bool IList.IsReadOnly => true;
            bool ICollection<UIInfoBase>.IsReadOnly => true;
            private readonly UIInfoCollection collection;
            internal InfoCollection(UIInfoCollection collection)
            {
                this.collection = collection ?? throw new ArgumentNullException();
            }
            /// <summary>
            /// 指定したインデックスの要素を取得する
            /// </summary>
            /// <param name="index">取得する要素のインデックス</param>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
            /// <returns>指定したインデックスに対応する要素</returns>
            public UIInfoBase this[int index]
            {
                get
                {
                    Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
                    return collection._array[index].Value;
                }
            }
            object IList.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            UIInfoBase IList<UIInfoBase>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            void ICollection<UIInfoBase>.Add(UIInfoBase item) => throw new NotSupportedException();
            int IList.Add(object value) => throw new NotSupportedException();
            void ICollection<UIInfoBase>.Clear() => throw new NotSupportedException();
            void IList.Clear() => throw new NotSupportedException();
            /// <summary>
            /// 指定した要素が含まれているかどうかを返す
            /// </summary>
            /// <param name="name">検索する要素</param>
            /// <returns>格納されていたらtrue，それ以外でfalse</returns>
            public bool Contains(UIInfoBase info) => collection.Contains(info);
            bool IList.Contains(object value) => value is UIInfoBase s ? Contains(s) : false;
            /// <summary>
            /// 指定した配列に要素をコピーする
            /// </summary>
            /// <param name="array">コピー先の配列</param>
            /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
            /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
            public void CopyTo(UIInfoBase[] array, int arrayIndex)
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, array);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < Count + arrayIndex, null);
                for (int i = 0; i < Count; i++) array[arrayIndex++] = collection._array[i].Value;
            }
            void ICollection.CopyTo(Array array, int index)
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, array);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < Count + index || array.GetLowerBound(0) != 0, null);
                switch (array)
                {
                    case UIInfoBase[] s: CopyTo(s, index); return;
                    case object[] o:
                        try
                        {
                            for (int i = 0; i < Count; i++) o[index++] = collection._array[i].Value;
                        }
                        catch (ArrayTypeMismatchException)
                        {
                            throw new ArgumentException();
                        }
                        return;
                    default: throw new ArgumentException();
                }
            }
            private int IndexOf(UIInfoBase info)
            {
                if (info == null) return -1;
                for (int i = 0; i < Count; i++)
                    if (collection._array[i].Value == info)
                        return i;
                return -1;
            }
            int IList.IndexOf(object value) => value is UIInfoBase s ? IndexOf(s) : -1;
            int IList<UIInfoBase>.IndexOf(UIInfoBase item) => IndexOf(item);
            void IList.Insert(int index, object value) => throw new NotSupportedException();
            void IList<UIInfoBase>.Insert(int index, UIInfoBase item) => throw new NotSupportedException();
            bool ICollection<UIInfoBase>.Remove(UIInfoBase item) => throw new NotSupportedException();
            void IList.Remove(object value) => throw new NotSupportedException();
            void IList.RemoveAt(int index) => throw new NotSupportedException();
            void IList<UIInfoBase>.RemoveAt(int index) => throw new NotSupportedException();
            /// <summary>
            /// このインスタンスのコピーを持つ配列を返す
            /// </summary>
            /// <returns>コピーされた要素を持つ配列のインスタンス</returns>
            public UIInfoBase[] ToArray()
            {
                var array = new UIInfoBase[Count];
                for (int i = 0; i < Count; i++) array[i] = collection._array[i].Value;
                return array;
            }
            /// <summary>
            /// 列挙をサポートする構造体を返す
            /// </summary>
            /// <returns><see cref="Enumerator"/>のインスタンス</returns>
            public Enumerator GetEnumerator() => new Enumerator(collection);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            IEnumerator<UIInfoBase> IEnumerable<UIInfoBase>.GetEnumerator() => GetEnumerator();
            /// <summary>
            /// 列挙をサポートする構造体
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<UIInfoBase>
            {
                private readonly UIInfoCollection collection;
                private int index;
                private readonly int version;
                /// <summary>
                /// 現在列挙されている要素を取得する
                /// </summary>
                public UIInfoBase Current { get; private set; }
                object IEnumerator.Current
                {
                    get
                    {
                        Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                        return Current;
                    }
                }
                internal Enumerator(UIInfoCollection collection)
                {
                    this.collection = collection ?? throw new ArgumentNullException();
                    index = 0;
                    Current = default;
                    version = collection.version;
                }
                /// <summary>
                /// このインスタンスを破棄する
                /// </summary>
                public void Dispose() { }
                /// <summary>
                /// 列挙を次に進める
                /// </summary>
                /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
                /// <returns>次の要素に進められたらtrue，それ以外でfalse</returns>
                public bool MoveNext()
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                    if (index < collection.Count)
                    {
                        Current = collection._array[index++].Value;
                        return true;
                    }
                    Current = default;
                    index = collection.Count + 1;
                    return false;
                }
                void IEnumerator.Reset()
                {
                    index = 0;
                    Current = default;
                }
            }
        }
    }
}
