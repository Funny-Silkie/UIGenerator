using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using asd;
using fslib;
using fslib.Collections;
using fslib.Exception;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="DrawingAdditionaryInfoBase"/>を管理するコレクション
    /// </summary>
    [Serializable]
    public sealed class DrawingAdditionaryInfoCollection : INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>, IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>, ICollection, ISerializable
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        #endregion
        private DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[] _array;
        private readonly static DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[] emptyArray = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[0];
        private int version = 0;
        private int Capacity => _array.Length;
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// 格納されている<see cref="DrawingAdditionaryInfoBase"/>のコレクションを取得する
        /// </summary>
        public InfoCollection Infos => _infos ?? (_infos = new InfoCollection(this));
        private InfoCollection _infos;
        bool ICollection<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>.IsReadOnly => false;
        bool ICollection.IsSynchronized => false;
        IList<int> INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.KeysCollection1 => Modes;
        IEnumerable<int> IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.KeyCollection1 => Modes;
        IList<string> INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.KeysCollection2 => Names;
        IEnumerable<string> IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.KeyCollection2 => Names;
        public IList<int> Modes => GetModeCollection();
        /// <summary>
        /// 格納されている名前のコレクションを取得する
        /// </summary>
        public NameCollection Names => _names ?? (_names = new NameCollection(this));
        private NameCollection _names;
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null) Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                return _syncRoot;
            }
        }
        private object _syncRoot;
        IList<DrawingAdditionaryInfoBase> INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.Values => Infos;
        IEnumerable<DrawingAdditionaryInfoBase> IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.Values => Infos;
        /// <summary>
        /// 既定の容量を備えた空の<see cref="DrawingAdditionaryInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        public DrawingAdditionaryInfoCollection() : this(0) { }
        /// <summary>
        /// 指定した容量を持つ空の<see cref="DrawingAdditionaryInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="capacity">設定する容量</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        public DrawingAdditionaryInfoCollection(int capacity)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(capacity, 0, int.MaxValue, null);
            _array = capacity == 0 ? emptyArray : new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[capacity];
        }
        /// <summary>
        /// 指定したコレクションの要素をコピーした<see cref="DrawingAdditionaryInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collection">コピーする要素を格納するコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="collection"/>内のキーに重複がある</exception>
        public DrawingAdditionaryInfoCollection(IEnumerable<DrawingAdditionaryInfoBase> collection)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, collection);
            _array = emptyArray;
            using (var en = collection.GetEnumerator())
                while (en.MoveNext())
                    Add(en.Current.Mode, en.Current.Name, en.Current);
        }
        private DrawingAdditionaryInfoCollection(SerializationInfo info, StreamingContext context)
        {
            _array = info.GetValue<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[]>(S_Array);
            Count = _array.Length;
        }
        /// <summary>
        /// 指定したインデックスに対応する要素を取得する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        /// <returns><paramref name="index"/>に対応する値</returns>
        public DrawingAdditionaryInfoBase this[int index]
        {
            get
            {
                if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
                return _array[index].Value;
            }
        }
        /// <summary>
        /// 指定した表示モードと名前を持つ要素を取得する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ要素</returns>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが存在していない</exception>
        public DrawingAdditionaryInfoBase this[int mode, string name]
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
        DrawingAdditionaryInfoBase INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.this[int index]
        {
            get => this[index];
            set
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                Central.ThrowHelper.ThrowArgumentNullException(null, value);
                var i = IndexOf(value);
                Central.ThrowHelper.ThrowExceptionWithMessage(new KeyDuplicateException(), i != -1 && i != index, null);
                _array[index] = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>(_array[index].Key1, _array[index].Key2, value);
            }
        }
        DrawingAdditionaryInfoBase INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.this[int mode, string name]
        {
            get => this[mode, name];
            set
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, values: name);
                Central.ThrowHelper.ThrowArgumentNullException(null, value);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
                var index = IndexOf(mode, name);
                if (index == -1) throw new KeyNotFoundException();
                _array[index] = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>(_array[index].Key1, _array[index].Key2, value);
            }
        }
        /// <summary>
        /// 指定した追加描画の情報を末尾に追加する
        /// </summary>
        /// <param name="mode">追加するオブジェクトの描画モード</param>
        /// <param name="name">追加するオブジェクトの名前</param>
        /// <param name="info">追加する追加描画の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>または<paramref name="info"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが既に存在している</exception>
        public void Add(int mode, string name, DrawingAdditionaryInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, name, info);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new KeyDuplicateException(), Contains(mode, name), null);
            if (Capacity < Count + 1) ReSize(Count + 1);
            _array[Count++] = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>(mode, name, info);
            version++;
        }
        void ICollection<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>.Add(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase> item) => Add(item.Key1, item.Key2, item.Value);
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
            _array[index] = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>(pair.Key1, newname, pair.Value);
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
            _array[index] = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>(newmode, pair.Key2, pair.Value);
            return index;
        }
        /// <summary>
        /// 格納されているすべての要素を削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) _array[i] = default;
            Count = 0;
            version++;
        }
        /// <summary>
        /// 指定したモードと名前のペアが格納されているかどうかを返す
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ値が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(int mode, string name) => IndexOf(mode, name) != -1;
        /// <summary>
        /// 指定した追加描画の情報が格納されているかどうかを返す
        /// </summary>
        /// <param name="info">検索する追加描画の情報</param>
        /// <returns><paramref name="info"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(DrawingAdditionaryInfoBase info) => IndexOf(info) != -1;
        bool ICollection<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>.Contains(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase> item) => IndexOf(item) != -1;
        bool INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsKeyPair(int key1, string key2) => Contains(key1, key2);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsKeyPair(int key1, string key2) => Contains(key1, key2);
        bool INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsKey1(int key) => ContainsMode(key);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsKey1(int key1) => ContainsMode(key1);
        bool INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsKey2(string key) => ContainsName(key);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsKey2(string key) => ContainsName(key);
        /// <summary>
        /// 指定した描画モードを持つ要素が格納されているかどうかを返す
        /// </summary>
        /// <param name="mode">検索する描画モード</param>
        /// <returns><paramref name="mode"/>を持つ要素が格納されていたらtrue，それ以外でfalse</returns>
        public bool ContainsMode(int mode) => IndexOfMode(mode) != -1;
        /// <summary>
        /// 指定した名前を持つ要素が格納されているかどうかを返す
        /// </summary>
        /// <param name="name">検索する名前</param>
        /// <returns><paramref name="name"/>を持つ要素が格納されていたらtrue，それ以外でfalse</returns>
        public bool ContainsName(string name) => IndexOfName(name) != -1;
        bool INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsValue(DrawingAdditionaryInfoBase value) => Contains(value);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.ContainsValue(DrawingAdditionaryInfoBase value) => Contains(value);
        /// <summary>
        /// 指定したコレクションの要素を配列にコピー
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        public void CopyTo(DrawingAdditionaryInfoBase[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentException(array.Length < Count + arrayIndex, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i].Value;
        }
        private void CopyTo(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentException(array.Length < Count + arrayIndex, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentException(array.Length < Count + index || array.GetLowerBound(0) != 0, null);
            switch (array)
            {
                case DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[] p: CopyTo(p, index); return;
                case DrawingAdditionaryInfoBase[] i: CopyTo(i, index); return;
                case object[] o:
                    try
                    {
                        for (int i = 0; i < Count; i++) o[index++] = _array[i].Value;
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentException();
                    }
                    return;
                default: throw new ArgumentException();
            }
        }
        void ICollection<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>.CopyTo(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[] array, int arrayIndex) => CopyTo(array, arrayIndex);
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>> IEnumerable<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>.GetEnumerator() => GetEnumerator();
        private IList<int> GetModeCollection()
        {
            var array = new int[Count];
            for (int i = 0; i < Count; i++) array[i] = _array[i].Key1;
            return array;
        }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアル化するデータを格納する<see cref="SerializationInfo"/>のインスタンス</param>
        /// <param name="context">送信先を表す<see cref="StreamingContext"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            var array = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[Count];
            CopyTo(array, 0);
            info.AddValue(S_Array, _array);
        }
        /// <summary>
        /// 指定したモードと名前の組み合わせを持つ値のインデックスを取得する
        /// </summary>
        /// <param name="mode"><検索する値の表示モード/param>
        /// <param name="name">検索する値の名前</param>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ値のインデックス 見つからなかった場合は-1</returns>
        public int IndexOf(int mode, string name)
        {
            if (mode < 0 || name == null) return -1;
            for (int i = 0; i < Count; i++)
            {
                var pair = _array[i];
                if (pair.Key1 == mode && pair.Key2 == name) return i;
            }
            return -1;
        }
        /// <summary>
        /// 指定した追加描画の情報のインデックスを取得する
        /// </summary>
        /// <param name="info">検索する追加描画の情報</param>
        /// <returns><paramref name="info"/>の持つインデックス 見つからなかった場合は-1</returns>
        public int IndexOf(DrawingAdditionaryInfoBase info)
        {
            if (info == null) return -1;
            for (int i = 0; i < Count; i++)
                if (info == _array[i].Value)
                    return i;
            return -1;
        }
        private int IndexOf(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase> item)
        {
            if (item.Key1 < 0 || item.Key2 == null || item.Value == null) return -1;
            for (int i = 0; i < Count; i++)
                if ((_array[i].Key1 == item.Key1) && (_array[i].Key2 == item.Key2) && (_array[i].Value == item.Value))
                    return i;
            return -1;
        }
        private int IndexOfMode(int mode)
        {
            if (mode < 0) return -1;
            for (int i = 0; i < Count; i++)
                if (mode == _array[i].Key1)
                    return i;
            return -1;
        }
        private int IndexOfName(string name)
        {
            if (name == null) return -1;
            for (int i = 0; i < Count; i++)
                if (name == _array[i].Key2)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した追加描画の情報を指定箇所に挿入する
        /// </summary>
        /// <param name="index">挿入するインデックス</param>
        /// <param name="mode">追加するオブジェクトの描画モード</param>
        /// <param name="name">追加するオブジェクトの名前</param>
        /// <param name="info">追加する追加描画の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>または<paramref name="info"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>より大きい 若しくは<paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが既に存在している</exception>
        public void Insert(int index, int mode, string name, DrawingAdditionaryInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, name, info);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new KeyDuplicateException(), Contains(mode, name), null);
            if (Capacity < Count + 1) ReSize(Count + 1);
            if (index < Count) Array.Copy(_array, index, _array, index + 1, Count - index);
            _array[index] = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>(mode, name, info);
            Count++;
            version++;
        }
        /// <summary>
        /// 全ての描画を実行する
        /// </summary>
        /// <param name="layer">描画を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public void OperateAll(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            for (int i = 0; i < Count; i++)
                if (_array[i].Key1 == DataBase.ShowMode)
                    _array[i].Value.Operate(layer);
        }
        void INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.OverWrite(int index, int newKey1) => throw new NotImplementedException();
        void INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.OverWrite(int index, int newKey1, string newKey2) => throw new NotImplementedException();
        void INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.OverWrite(int index, string newKey2) => throw new NotImplementedException();
        int INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.OverWrite(int key1, string oldKey2, string newKey2) => ChangeName(key1, oldKey2, newKey2);
        int INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.OverWrite(int oldKey1, string key2, int newKey1) => ChangeMode(oldKey1, key2, newKey1);
        int INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.OverWrite(int oldKey1, string oldKey2, int newKey1, string newKey2) => throw new NotImplementedException();
        private void ReSize(int min)
        {
            if (Count > min) return;
            var size = Capacity + 4;
            if (size > int.MaxValue) size = int.MaxValue;
            if (size < min) size = min;
            var array = new DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>[size];
            for (int i = 0; i < Count; i++) array[i] = _array[i];
            _array = array;
        }
        /// <summary>
        /// 指定した表示モーと名前を持つ要素を削除する
        /// </summary>
        /// <param name="mode">削除する要素の表示モード</param>
        /// <param name="name">削除する要素の名前</param>
        /// <returns>削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(int mode, string name)
        {
            var index = IndexOf(mode, name);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        private bool Remove(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase> item)
        {
            var index = IndexOf(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        bool ICollection<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>.Remove(DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase> item) => Remove(item);
        bool INumericDoubleKeyDictionary<int, string, DrawingAdditionaryInfoBase>.Remove(DrawingAdditionaryInfoBase value)
        {
            var index = IndexOf(value);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定インデックスの要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        public void RemoveAt(int index)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            _array[Count - 1] = default;
            Count--;
            version++;
        }
        /// <summary>
        /// 指定した表示モードと名前を持つ要素を取得する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <param name="info"><paramref name="mode"/>が先<paramref name="name"/>を持つ値 無かったら既定値</param>
        /// <returns><paramref name="info"/>を取得出来たらtrue，それ以外でfalse</returns>
        public bool TryGetValue(int mode, string name, out DrawingAdditionaryInfoBase info)
        {
            var index = IndexOf(mode, name);
            if (index == -1)
            {
                info = null;
                return false;
            }
            info = _array[index].Value;
            return true;
        }
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase>>
        {
            private readonly DrawingAdditionaryInfoCollection collection;
            private int index;
            private readonly int version;
            /// <summary>
            /// 現在列挙されている要素を取得する
            /// </summary>
            public DoubleKeyValuePair<int, string, DrawingAdditionaryInfoBase> Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    if (index < 0 || collection.Count < index) throw new InvalidOperationException();
                    return Current;
                }
            }
            internal Enumerator(DrawingAdditionaryInfoCollection collection)
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
            /// <returns>次に進められたらtrue，それ以外でfalse</returns>
            public bool MoveNext()
            {
                if (version != collection.version) throw new InvalidOperationException();
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
                if (version != collection.version) throw new InvalidOperationException();
                index = 0;
                Current = default;
            }
        }
        /// <summary>
        /// 名前を格納するコレクション
        /// </summary>
        [Serializable]
        public sealed class NameCollection : IList<string>, IReadOnlyList<string>, IList
        {
            private readonly DrawingAdditionaryInfoCollection collection;
            /// <summary>
            /// 格納されている要素数を取得する
            /// </summary>
            public int Count => collection.Count;
            bool IList.IsFixedSize => false;
            bool ICollection<string>.IsReadOnly => true;
            bool IList.IsReadOnly => true;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => ((ICollection)collection).SyncRoot;
            internal NameCollection(DrawingAdditionaryInfoCollection collection)
            {
                this.collection = collection ?? throw new ArgumentNullException();
            }
            /// <summary>
            /// 指定したインデックスにある名前を取得する
            /// </summary>
            /// <param name="index">検索する名前のインデックス</param>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
            /// <returns><paramref name="index"/>を持つ名前</returns>
            public string this[int index]
            {
                get
                {
                    if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
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
            bool IList.Contains(object value) => CompareHelper.IsCompatibleValue<string>(value, out var name) ? collection.ContainsName(name) : false;
            bool ICollection<string>.Contains(string item) => collection.ContainsName(item);
            /// <summary>
            /// 指定したコレクションの要素を配列にコピー
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
                Central.ThrowHelper.ThrowArgumentException(array.Length < arrayIndex + Count, null);
                for (int i = 0; i < Count; i++) array[arrayIndex++] = collection._array[i].Key2;
            }
            void ICollection.CopyTo(Array array, int index)
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, array);
                Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
                Central.ThrowHelper.ThrowArgumentException(array.Length < Count + index || array.GetLowerBound(0) != 0, null);
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
            /// <summary>
            /// 列挙をサポートする構造体を返す
            /// </summary>
            /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
            public Enumerator GetEnumerator() => new Enumerator(collection);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();
            int IList.IndexOf(object value) => CompareHelper.IsCompatibleValue<string>(value, out var name) ? collection.IndexOfName(name) : -1;
            int IList<string>.IndexOf(string item) => collection.IndexOfName(item);
            void IList.Insert(int index, object value) => throw new NotSupportedException();
            void IList<string>.Insert(int index, string item) => throw new NotSupportedException();
            bool ICollection<string>.Remove(string item) => throw new NotSupportedException();
            void IList.Remove(object value) => throw new NotSupportedException();
            void IList.RemoveAt(int index) => throw new NotSupportedException();
            void IList<string>.RemoveAt(int index) => throw new NotSupportedException();
            /// <summary>
            /// 列挙をサポートする構造体
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<string>
            {
                private readonly DrawingAdditionaryInfoCollection collection;
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
                        if (index < 0 || collection.Count < index) throw new InvalidOperationException();
                        return Current;
                    }
                }
                internal Enumerator(DrawingAdditionaryInfoCollection collection)
                {
                    this.collection = collection ?? throw new ArgumentNullException();
                    index = 0;
                    version = collection.version;
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
                    if (version != collection.version) throw new InvalidOperationException();
                    if (index < collection.Count)
                    {
                        Current = collection._array[index].Key2;
                        return true;
                    }
                    index = collection.Count + 1;
                    Current = default;
                    return false;
                }
                void IEnumerator.Reset()
                {
                    if (version != collection.version) throw new InvalidOperationException();
                    index = 0;
                    Current = default;
                }
            }
        }
        /// <summary>
        /// 追加描画情報を格納するコレクション
        /// </summary>
        [Serializable]
        public sealed class InfoCollection : IList<DrawingAdditionaryInfoBase>, IReadOnlyList<DrawingAdditionaryInfoBase>, IList
        {
            private readonly DrawingAdditionaryInfoCollection collection;
            /// <summary>
            /// 格納されている要素数を取得する
            /// </summary>
            public int Count => collection.Count;
            bool IList.IsFixedSize => false;
            bool ICollection<DrawingAdditionaryInfoBase>.IsReadOnly => true;
            bool IList.IsReadOnly => true;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => ((ICollection)collection).SyncRoot;
            internal InfoCollection(DrawingAdditionaryInfoCollection collection)
            {
                this.collection = collection ?? throw new ArgumentNullException();
            }
            /// <summary>
            /// 指定したインデックスにある追加描画情報を取得する
            /// </summary>
            /// <param name="index">検索するインデックス</param>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
            /// <returns><paramref name="index"/>を持つ追加描画情報</returns>
            public DrawingAdditionaryInfoBase this[int index]
            {
                get
                {
                    if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
                    return collection._array[index].Value;
                }
            }
            object IList.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            DrawingAdditionaryInfoBase IList<DrawingAdditionaryInfoBase>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            void ICollection<DrawingAdditionaryInfoBase>.Add(DrawingAdditionaryInfoBase item) => throw new NotSupportedException();
            int IList.Add(object value) => throw new NotSupportedException();
            void ICollection<DrawingAdditionaryInfoBase>.Clear() => throw new NotSupportedException();
            void IList.Clear() => throw new NotSupportedException();
            bool ICollection<DrawingAdditionaryInfoBase>.Contains(DrawingAdditionaryInfoBase item) => collection.Contains(item);
            bool IList.Contains(object value) => CompareHelper.IsCompatibleValue<DrawingAdditionaryInfoBase>(value, out var info) ? collection.Contains(info) : false;
            /// <summary>
            /// 指定したコレクションの要素を配列にコピー
            /// </summary>
            /// <param name="array">コピー先の配列</param>
            /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
            /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
            public void CopyTo(DrawingAdditionaryInfoBase[] array, int arrayIndex) => collection.CopyTo(array, arrayIndex);
            void ICollection.CopyTo(Array array, int index)
            {
                Central.ThrowHelper.ThrowArgumentNullException(null, array);
                Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
                Central.ThrowHelper.ThrowArgumentException(array.Length < Count + index || array.GetLowerBound(0) != 0, null);
                switch (array)
                {
                    case DrawingAdditionaryInfoBase[] d: CopyTo(d, index); return;
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
            /// <summary>
            /// 列挙をサポートする構造体を返す
            /// </summary>
            /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
            public Enumerator GetEnumerator() => new Enumerator(collection);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            IEnumerator<DrawingAdditionaryInfoBase> IEnumerable<DrawingAdditionaryInfoBase>.GetEnumerator() => GetEnumerator();
            int IList.IndexOf(object value) => CompareHelper.IsCompatibleValue<DrawingAdditionaryInfoBase>(value, out var result) ? collection.IndexOf(result) : -1;
            int IList<DrawingAdditionaryInfoBase>.IndexOf(DrawingAdditionaryInfoBase item) => collection.IndexOf(item);
            void IList.Insert(int index, object value) => throw new NotSupportedException();
            void IList<DrawingAdditionaryInfoBase>.Insert(int index, DrawingAdditionaryInfoBase item) => throw new NotSupportedException();
            bool ICollection<DrawingAdditionaryInfoBase>.Remove(DrawingAdditionaryInfoBase item) => throw new NotSupportedException();
            void IList.Remove(object value) => throw new NotSupportedException();
            void IList.RemoveAt(int index) => throw new NotSupportedException();
            void IList<DrawingAdditionaryInfoBase>.RemoveAt(int index) => throw new NotSupportedException();
            /// <summary>
            /// 列挙をサポートする構造体
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<DrawingAdditionaryInfoBase>
            {
                private readonly DrawingAdditionaryInfoCollection collection;
                private int index;
                private readonly int version;
                /// <summary>
                /// 現在列挙されている要素を取得する
                /// </summary>
                public DrawingAdditionaryInfoBase Current { get; private set; }
                object IEnumerator.Current
                {
                    get
                    {
                        if (index < 0 || collection.Count < index) throw new InvalidOperationException();
                        return Current;
                    }
                }
                internal Enumerator(DrawingAdditionaryInfoCollection collection)
                {
                    this.collection = collection ?? throw new ArgumentNullException();
                    index = 0;
                    version = collection.version;
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
                    if (version != collection.version) throw new InvalidOperationException();
                    if (index < collection.Count)
                    {
                        Current = collection._array[index].Value;
                        return true;
                    }
                    index = collection.Count + 1;
                    Current = default;
                    return false;
                }
                void IEnumerator.Reset()
                {
                    if (version != collection.version) throw new InvalidOperationException();
                    index = 0;
                    Current = default;
                }
            }
        }
    }
}
