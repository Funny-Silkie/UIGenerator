using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using fslib;
using fslib.Collections;
using fslib.Exception;

namespace UIGenerator
{
    /// <summary>
    /// モードと値をキーとするコレクション
    /// </summary>
    /// <typeparam name="T">格納される情報</typeparam>
    [Serializable]
    public abstract class UICollectionBase<T> : INumericDoubleKeyDictionary<int, string, T>, IReadOnlyNumericDoubleKeyDictionary<int, string, T>, IDictionary, IList, ISerializable, IDeserializationCallback where T : IUIGeneratorInfo
    {
        #region SerializeName
        private const string S_Array = "S_Array";
        private const string S_Version = "S_Version";
        #endregion
        private readonly static DoubleKeyValuePair<int, string, T>[] emptyArray = new DoubleKeyValuePair<int, string, T>[0];
        private SerializationInfo seInfo;
        private int version = 0;
        private int Capacity => InnerArray.Length;
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// UI情報を格納するコレクションを取得する
        /// </summary>
        public InfoCollection Infos => _infos ??= new InfoCollection(this);
        private InfoCollection _infos;
        /// <summary>
        /// 内部配列を取得する
        /// </summary>
        protected DoubleKeyValuePair<int, string, T>[] InnerArray { get; private set; }
        bool IDictionary.IsFixedSize => false;
        bool IList.IsFixedSize => false;
        bool ICollection<DoubleKeyValuePair<int, string, T>>.IsReadOnly => false;
        bool IDictionary.IsReadOnly => false;
        bool IList.IsReadOnly => false;
        bool ICollection.IsSynchronized => false;
        ICollection IDictionary.Keys
        {
            get
            {
                var array = new DoubleKey<int, string>[Count];
                for (int i = 0; i < Count; i++) array[i] = new DoubleKey<int, string>(InnerArray[i].Key1, InnerArray[i].Key2);
                return Array.AsReadOnly(array);
            }
        }
        ICollection<int> IDoubleKeyDictionary<int, string, T>.Key1Collection => Modes;
        IList<int> INumericDoubleKeyDictionary<int, string, T>.Key1Collection => Modes;
        IEnumerable<int> IReadOnlyDoubleKeyDictionary<int, string, T>.Key1Collection => Modes;
        IReadOnlyList<int> IReadOnlyNumericDoubleKeyDictionary<int, string, T>.Key1Collection => Modes;
        ICollection<string> IDoubleKeyDictionary<int, string, T>.Key2Collection => Names;
        IList<string> INumericDoubleKeyDictionary<int, string, T>.Key2Collection => Names;
        IEnumerable<string> IReadOnlyDoubleKeyDictionary<int, string, T>.Key2Collection => Names;
        IReadOnlyList<string> IReadOnlyNumericDoubleKeyDictionary<int, string, T>.Key2Collection => Names;
        /// <summary>
        /// 表示モードを格納するコレクションを取得する
        /// </summary>
        public ModeCollection Modes => _modes ??= new ModeCollection(this);
        private ModeCollection _modes;
        /// <summary>
        /// 名前を格納するコレクションを取得する
        /// </summary>
        public NameCollection Names => _names ??= new NameCollection(this);
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
        ICollection IDictionary.Values => Infos;
        ICollection<T> IDoubleKeyDictionary<int, string, T>.Values => Infos;
        IList<T> INumericDoubleKeyDictionary<int, string, T>.Values => Infos;
        IEnumerable<T> IReadOnlyDoubleKeyDictionary<int, string, T>.Values => Infos;
        IReadOnlyList<T> IReadOnlyNumericDoubleKeyDictionary<int, string, T>.Values => Infos;
        /// <summary>
        /// 既定の容量を備えた空の<see cref="UICollectionBase{T}"/>の新しいインスタンスを生成する
        /// </summary>
        protected UICollectionBase() : this(0) { }
        /// <summary>
        /// 指定した容量を備えた空の<see cref="UICollectionBase{T}"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="capacity">設定する容量</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>がnull</exception>
        protected UICollectionBase(int capacity)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(capacity, 0, int.MaxValue, null);
            InnerArray = capacity == 0 ? emptyArray : new DoubleKeyValuePair<int, string, T>[capacity];
        }
        protected UICollectionBase(IEnumerable<DoubleKeyValuePair<int, string, T>> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            InnerArray = collection is ICollection<DoubleKeyValuePair<int, string, T>> c && c.Count != 0 ? new DoubleKeyValuePair<int, string, T>[c.Count] : emptyArray;
            using var en = collection.GetEnumerator();
            while (en.MoveNext())
                Add(en.Current);
        }
        /// <summary>
        /// 指定したコレクションのコピーを格納する<see cref="UICollectionBase{T}"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collection">要素のコピー元のコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        protected UICollectionBase(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            using var en = collection.GetEnumerator();
            while (en.MoveNext())
                Add(en.Current);
        }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected UICollectionBase(SerializationInfo info, StreamingContext context)
        {
            seInfo = info;
        }
        /// <summary>
        /// 指定したインデックスのUI情報を取得する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        /// <returns><paramref name="index"/>に対応した要素</returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
                return InnerArray[index].Value;
            }
        }
        /// <summary>
        /// 指定した表示モードと名前を持つUI情報を取得する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="mode"/>と<paramref name="name"/>のペアが存在しない</exception>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ値</returns>
        public T this[int mode, string name]
        {
            get
            {
                if (mode < 0) throw new ArgumentOutOfRangeException();
                if (name == null) throw new ArgumentNullException();
                var index = IndexOf(mode, name);
                if (index == -1) throw new KeyNotFoundException();
                return InnerArray[index].Value;
            }
        }
        object IDictionary.this[object key]
        {
            get => key switch
                {
                    null => throw new ArgumentNullException(),
                    DoubleKey<int, string> p => this[p.Key1, p.Key2],
                    _ => throw new ArgumentException(),
                };
            set => throw new NotSupportedException();
        }
        object IList.this[int index]
        {
            get => this[index];
            set => throw new NotSupportedException();
        }
        DoubleKeyValuePair<int, string, T> IList<DoubleKeyValuePair<int, string, T>>.this[int index]
        {
            get
            {
                if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
                return InnerArray[index];
            }
            set => throw new NotSupportedException();
        }
        DoubleKeyValuePair<int, string, T> IReadOnlyList<DoubleKeyValuePair<int, string, T>>.this[int index]
        {
            get
            {
                if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
                return InnerArray[index];
            }
        }
        T IDoubleKeyDictionary<int, string, T>.this[int key1, string key2]
        {
            get => this[key1, key2];
            set => throw new NotSupportedException();
        }
        T IReadOnlyDoubleKeyDictionary<int, string, T>.this[int key1, string key2] => this[key1, key2];
        /// <summary>
        /// 指定したUI情報を末尾に追加する
        /// </summary>
        /// <param name="value">追加するUI情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>またはその名前がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>の表示モードが0未満</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="value"/>内のキーの組み合わせが既に存在している</exception>
        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException();
            Add(value.Mode, value.Name, value);
        }
        private void Add(int mode, string name, T value)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException();
            if (name == null || value == null) throw new ArgumentNullException();
            if (Contains(mode, name)) throw new KeyDuplicateException();
            if (Capacity < Count + 1) ReSize(Count + 1);
            var item = new DoubleKeyValuePair<int, string, T>(mode, name, value);
            InnerArray[Count++] = item;
            version++;
            OnAdded(item, Count - 1);
        }
        private void Add(DoubleKeyValuePair<int, string, T> item)
        {
            if (item.Key1 != item.Value.Mode || item.Key2 != item.Value.Name) throw new ArgumentException();
            Add(item.Value);
        }
        void ICollection<DoubleKeyValuePair<int, string, T>>.Add(DoubleKeyValuePair<int, string, T> item) => Add(item);
        void IDictionary.Add(object key, object value)
        {
            if (CompareHelper.IsCompatibleValue<DoubleKey<int, string>>(key, out var keys) && CompareHelper.IsCompatibleValue<T>(value, out var v)) Add(keys.Key1, keys.Key2, v);
            else throw new ArgumentException();
        }
        int IList.Add(object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case DoubleKeyValuePair<int, string, T> p: Add(p);  return Count - 1;
                case T t: Add(t); return Count - 1;
                default: throw new ArgumentException();
            }
        }
        void IDoubleKeyDictionary<int, string, T>.Add(int key1, string key2, T value) => Add(key1, key2, value);
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
            if (oldname == null || newname == null) throw new ArgumentNullException();
            if (mode < 0) throw new ArgumentOutOfRangeException();
            var index = IndexOf(mode, oldname);
            if (index == -1) throw new KeyNotFoundException();
            var ind = IndexOf(mode, newname);
            if (ind != -1 && index != ind) throw new KeyDuplicateException();
            var pair = InnerArray[index];
            pair.Value.Name = newname;
            InnerArray[index] = new DoubleKeyValuePair<int, string, T>(pair.Key1, newname, pair.Value);
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
            if (name == null) throw new ArgumentNullException();
            if (oldmode < 0 || newmode < 0) throw new ArgumentOutOfRangeException();
            var index = IndexOf(oldmode, name);
            if (index == -1) throw new KeyNotFoundException();
            var ind = IndexOf(newmode, name);
            if (ind != -1 && index != ind) throw new KeyDuplicateException();
            var pair = InnerArray[index];
            pair.Value.Mode = newmode;
            InnerArray[index] = new DoubleKeyValuePair<int, string, T>(newmode, pair.Key2, pair.Value);
            return index;
        }
        /// <summary>
        /// 全ての要素を削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) InnerArray[i] = default;
            Count = 0;
            version++;
            OnCleared();
        }
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="arrayIndex"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
            if (array.Length < arrayIndex + Count) throw new ArgumentException();
            for (int i = 0; i < Count; i++) array[arrayIndex++] = InnerArray[i].Value;
        }
        private void CopyTo(DoubleKeyValuePair<int, string, T>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
            if (array.Length < arrayIndex + Count) throw new ArgumentException();
            for (int i = 0; i < Count; i++) array[arrayIndex++] = InnerArray[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Rank != 1) throw new RankException();
            if (index < 0) throw new ArgumentOutOfRangeException();
            if (array.Length < index + Count || array.GetLowerBound(0) != 0) throw new ArgumentException();
            switch (array)
            {
                case DoubleKeyValuePair<int, string, T>[] pairs: CopyTo(pairs, index); return;
                case T[] t: CopyTo(t, index); return;
                case DictionaryEntry[] entries:
                    for (int i = 0; i < Count; i++) entries[index++] = new DictionaryEntry(new DoubleKey<int, string>(InnerArray[i].Key1, InnerArray[i].Key2), InnerArray[i].Value);
                    return;
                case object[] o:
                    try
                    {
                        for (int i = 0; i < Count; i++) o[index++] = InnerArray[i];
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentException();
                    }
                    return;
                default: throw new ArgumentException();
            }
        }
        void ICollection<DoubleKeyValuePair<int, string, T>>.CopyTo(DoubleKeyValuePair<int, string, T>[] array, int arrayIndex) => CopyTo(array, arrayIndex);
        private bool Contains(DoubleKeyValuePair<int, string, T> item) => IndexOf(item) != -1;
        bool ICollection<DoubleKeyValuePair<int, string, T>>.Contains(DoubleKeyValuePair<int, string, T> item) => Contains(item);
        bool IDictionary.Contains(object key) => key switch
        {
            int mode => ContainsMode(mode),
            string name => ContainsName(name),
            DoubleKey<int, string> pair => Contains(pair.Key1, pair.Key2),
            null => throw new ArgumentNullException(),
            _ => throw new ArgumentException(),
        };
        bool IList.Contains(object value) => value switch
        {
            T t => Contains(t),
            DoubleKeyValuePair<int, string, T> pair => Contains(pair),
            null => false,
            _ => throw new ArgumentException(),
        };
        /// <summary>
        /// 指定した表示モードと名前の組み合わせが存在するかどうかを検索する
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>のペアが格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(int mode, string name) => IndexOf(mode, name) != -1;
        /// <summary>
        /// 指定したUI情報が格納されているかどうかを検索する
        /// </summary>
        /// <param name="value">検索するUI情報</param>
        /// <returns><paramref name="value"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(T value) => IndexOf(value) != -1;
        bool IDoubleKeyDictionary<int, string, T>.ContainsKeyPair(int key1, string key2) => Contains(key1, key2);
        bool IReadOnlyDoubleKeyDictionary<int, string, T>.ContainsKeyPair(int key1, string key2) => Contains(key1, key2);
        bool INumericDoubleKeyDictionary<int, string, T>.ContainsKey1(int key) => ContainsMode(key);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, T>.ContainsKey1(int key) => ContainsMode(key);
        bool INumericDoubleKeyDictionary<int, string, T>.ContainsKey2(string key) => ContainsName(key);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, T>.ContainsKey2(string key) => ContainsName(key);
        private bool ContainsMode(int mode) => IndexOfMode(mode) != -1;
        private bool ContainsName(string name) => IndexOfName(name) != -1;
        bool INumericDoubleKeyDictionary<int, string, T>.ContainsValue(T value) => Contains(value);
        bool IReadOnlyNumericDoubleKeyDictionary<int, string, T>.ContainsValue(T value) => Contains(value);
        /// <summary>
        /// 2つの<typeparamref name="T"/>の値の同一性を判定する
        /// </summary>
        /// <param name="t1">同一性を判定する<typeparamref name="T"/>の値</param>
        /// <param name="t2">同一性を判定するもう一つの<typeparamref name="T"/>の値</param>
        /// <returns><paramref name="t1"/>と<paramref name="t2"/>が同じならばtrue，それ以外でfalse</returns>
        protected abstract bool Equals(T t1, T t2);
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IDictionaryEnumerator IDictionary.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<DoubleKeyValuePair<int, string, T>> IEnumerable<DoubleKeyValuePair<int, string, T>>.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            var array = new DoubleKeyValuePair<int, string, T>[Count];
            CopyTo(array, 0);
            info.AddValue(S_Array, array);
            info.AddValue(S_Version, version);
        }
        /// <summary>
        /// 指定したキーの組み合わせのインデックスを取得する
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>のペアが存在していたらそのインデックス，無かったら-1</returns>
        public int IndexOf(int mode, string name)
        {
            if (mode < 0 || name == null) return -1;
            for (int i = 0; i < Count; i++)
                if (InnerArray[i].Key1 == mode && InnerArray[i].Key2 == name)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定したUI情報のインデックスを取得する
        /// </summary>
        /// <param name="value">検索するUI情報</param>
        /// <returns><paramref name="value"/>のインデックス，無かったら-1</returns>
        public int IndexOf(T value) => value == null ? -1 : IndexOf(value.Mode, value.Name);
        private int IndexOf(DoubleKeyValuePair<int, string, T> item)
        {
            var index = IndexOf(item.Key1, item.Key2);
            if (index == -1) return -1;
            return Equals(item.Value, InnerArray[index].Value) ? index : -1;
        }
        int IList.IndexOf(object value) => value switch
        {
            DoubleKeyValuePair<int, string, T> pair => IndexOf(pair),
            T t => IndexOf(t),
            DoubleKey<int, string> keys => IndexOf(keys.Key1, keys.Key2),
            null => -1,
            _ => throw new ArgumentException(),
        };
        int IList<DoubleKeyValuePair<int, string, T>>.IndexOf(DoubleKeyValuePair<int, string, T> item) => IndexOf(item);
        private int IndexOfMode(int mode)
        {
            if (mode < 0) return -1;
            for (int i = 0; i < Count; i++)
                if (mode == InnerArray[i].Key1)
                    return i;
            return -1;
        }
        private int IndexOfName(string name)
        {
            if (name == null) return -1;
            for (int i = 0; i < Count; i++)
                if (name == InnerArray[i].Key2)
                    return i;
            return -1;
        }
        void IList.Insert(int index, object value) => throw new NotSupportedException();
        void IList<DoubleKeyValuePair<int, string, T>>.Insert(int index, DoubleKeyValuePair<int, string, T> item) => throw new NotSupportedException();
        void INumericDoubleKeyDictionary<int, string, T>.Insert(int index, int key1, string key2, T value) => throw new NotSupportedException();
        /// <summary>
        /// 指定したインデックスがコレクションの管理インデックスかどうかを返す
        /// </summary>
        /// <param name="index">検証するインデックス</param>
        /// <returns><paramref name="index"/>が管理インデックスであったらtrue，それ以外でfalse</returns>
        public bool IsCompatibleIndex(int index) => index >= 0 && index < Count;
        /// <summary>
        /// 要素が追加されたときに実行
        /// </summary>
        /// <param name="element">追加された要素</param>
        /// <param name="index"><paramref name="element"/>が追加されたインデックス</param>
        protected virtual void OnAdded(in DoubleKeyValuePair<int, string, T> element, int index) { }
        /// <summary>
        /// 全ての要素が削除されたときに実行
        /// </summary>
        protected virtual void OnCleared() { }
        /// <summary>
        /// 要素が削除されたときに実行
        /// </summary>
        /// <param name="element">削除された要素</param>
        /// <param name="index"><paramref name="element"/>に割り当てられていたインデックス</param>
        protected virtual void OnRemoved(in DoubleKeyValuePair<int, string, T> element, int index) { }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        public virtual void OnDeserialization(object sender)
        {
            if (seInfo == null) return;
            InnerArray = seInfo.GetValue<DoubleKeyValuePair<int, string, T>[]>(S_Array);
            Count = InnerArray.Length;
            version = seInfo.GetInt32(S_Version);
            seInfo = null;
        }
        void INumericDoubleKeyDictionary<int, string, T>.OverWrite(int index, int newKey1) => throw new NotSupportedException();
        void INumericDoubleKeyDictionary<int, string, T>.OverWrite(int index, int newKey1, string newKey2) => throw new NotSupportedException();
        void INumericDoubleKeyDictionary<int, string, T>.OverWrite(int index, string newKey2) => throw new NotSupportedException();
        int INumericDoubleKeyDictionary<int, string, T>.OverWrite(int key1, string oldKey2, string newKey2) => ChangeName(key1, oldKey2, newKey2);
        int INumericDoubleKeyDictionary<int, string, T>.OverWrite(int oldKey1, string key2, int newKey1) => ChangeMode(oldKey1, key2, newKey1);
        int INumericDoubleKeyDictionary<int, string, T>.OverWrite(int oldKey1, string oldKey2, int newKey1, string newKey2) => throw new NotSupportedException();
        /// <summary>
        /// 指定した表示モードと名前を持つ要素を削除する
        /// </summary>
        /// <param name="mode">削除する要素の表示モード</param>
        /// <param name="name">削除する要素の名前</param>
        /// <returns>要素を削除出来たらture，それ以外でfalse</returns>
        public bool Remove(int mode, string name)
        {
            var index = IndexOf(mode, name);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定したUI情報を削除する
        /// </summary>
        /// <param name="value">削除するUI情報</param>
        /// <returns><paramref name="value"/>を削除できたらtrue，それ以外でfalse</returns>
        public bool Remove(T value) => value == null ? false : Remove(value.Mode, value.Name);
        private bool Remove(DoubleKeyValuePair<int, string, T> item)
        {
            var index = IndexOf(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        bool ICollection<DoubleKeyValuePair<int, string, T>>.Remove(DoubleKeyValuePair<int, string, T> item) => Remove(item);
        void IDictionary.Remove(object key) => _ = CompareHelper.IsCompatibleValue<DoubleKey<int, string>>(key, out var keys) ? Remove(keys.Key1, keys.Key2) : throw new ArgumentException();
        void IList.Remove(object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case T t: Remove(t); return;
                case DoubleKeyValuePair<int, string, T> pair: Remove(pair); return;
                default: throw new ArgumentException();
            }
        }
        /// <summary>
        /// 指定したインデックスの要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
            var item = InnerArray[index];
            if (index < Count) Array.Copy(InnerArray, index + 1, InnerArray, index, Count - index - 1);
            InnerArray[Count - 1] = default;
            Count--;
            version++;
            OnRemoved(item, index);
        }
        /// <summary>
        /// 内部配列の容量を変更する
        /// </summary>
        /// <param name="min">変更後の要素の最小値</param>
        protected void ReSize(int min)
        {
            if (min < Count) return;
            var size = Capacity == 0 ? 4 : Capacity + 5;
            if ((uint)size > int.MaxValue) size = int.MaxValue;
            if (size < min) size = min;
            var array = new DoubleKeyValuePair<int, string, T>[size];
            for (int i = 0; i < Count; i++) array[i] = InnerArray[i];
            InnerArray = array;
        }
        /// <summary>
        /// 指定した表示モードを持つ要素をすべて取得する
        /// </summary>
        /// <param name="name">取得する要素の表示モード</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="name"/>が0未満</exception>
        /// <returns><paramref name="name"/>を持つ全ての要素が格納されたコレクション</returns>
        public List<T> SearchFromMode(int mode)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException();
            var collection = new List<T>(Count);
            for (int i = 0; i < Count; i++)
                if (mode == InnerArray[i].Key1)
                    collection.Add(InnerArray[i].Value);
            return collection;
        }
        /// <summary>
        /// 指定した名前を持つ要素をすべて取得する
        /// </summary>
        /// <param name="name">取得する要素の表示モード</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <returns><paramref name="name"/>を持つ全ての要素が格納されたコレクション</returns>
        public List<T> SearchFromName(string name)
        {
            if (name == null) throw new ArgumentNullException();
            var collection = new List<T>(Count);
            for (int i = 0; i < Count; i++)
                if (name == InnerArray[i].Key2)
                    collection.Add(InnerArray[i].Value);
            return collection;
        }
        /// <summary>
        /// 指定し表示モードを持つ要素のコレクションを取得する
        /// </summary>
        /// <param name="mode">検索する表示モード</par
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns><paramref name="mode"/>を持つ値のコレクション</returns>
        private Dictionary<string, KeyValuePair<int, T>> SelectFromMode(int mode)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException();
            var dictionary = new Dictionary<string, KeyValuePair<int, T>>(Count);
            for (int i = 0; i < Count; i++)
                if (InnerArray[i].Key1 == mode)
                    dictionary.Add(InnerArray[i].Key2, new KeyValuePair<int, T>(InnerArray[i].Key1, InnerArray[i].Value));
            return dictionary;
        }
        IDictionary<string, KeyValuePair<int, T>> IDoubleKeyDictionary<int, string, T>.SelectFromKey1(int key) => SelectFromMode(key);
        IDictionary<string, KeyValuePair<int, T>> IReadOnlyDoubleKeyDictionary<int, string, T>.SelectFromKey1(int key) => SelectFromMode(key);
        /// <summary>
        /// 指定し名前を持つ要素のコレクションを取得する
        /// </summary>
        /// <param name="name">検索する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <returns><paramref name="name"/>を持つ値のコレクション</returns>
        private Dictionary<int, KeyValuePair<string, T>> SelectFromName(string name)
        {
            if (name == null) throw new ArgumentNullException();
            var dictionary = new Dictionary<int, KeyValuePair<string, T>>(Count);
            for (int i = 0; i < Count; i++)
                if (name == InnerArray[i].Key2)
                    dictionary.Add(InnerArray[i].Key1, new KeyValuePair<string, T>(InnerArray[i].Key2, InnerArray[i].Value));
            return dictionary;
        }
        IDictionary<int, KeyValuePair<string, T>> IDoubleKeyDictionary<int, string, T>.SelectFromKey2(string key) => SelectFromName(key);
        IDictionary<int, KeyValuePair<string, T>> IReadOnlyDoubleKeyDictionary<int, string, T>.SelectFromKey2(string key) => SelectFromName(key);
        /// <summary>
        /// このインスタンスの要素を格納する<see cref="DoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンスを返す
        /// </summary>
        /// <returns>要素がコピーされた<see cref="DoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンス</returns>
        public DoubleKeyDictionary<int, string, T> ToDoubleKeyDictionary()
        {
            var dic = new DoubleKeyDictionary<int, string, T>(Count);
            for (int i = 0; i < Count; i++) dic.Add(InnerArray[i].Key1, InnerArray[i].Key2, InnerArray[i].Value);
            return dic;
        }
        /// <summary>
        /// 指定したキーを持つUI情報を取得する
        /// </summary>
        /// <param name="mode">取得するUI情報の表示モード</param>
        /// <param name="name">取得するUI情報の名前</param>
        /// <param name="value"><paramref name="mode"/>と<paramref name="name"/>を持つUI情報 無かったら既定値</param>
        /// <returns><paramref name="value"/>が見つかったらtrue，それ以外でfalse</returns>
        public bool TryGetValue(int mode, string name, out T value)
        {
            var index = IndexOf(mode, name);
            if (index == -1)
            {
                value = default;
                return false;
            }
            value = InnerArray[index].Value;
            return true;
        }
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<DoubleKeyValuePair<int, string, T>>, IDictionaryEnumerator
        {
            private readonly UICollectionBase<T> collection;
            private int index;
            private readonly int version;
            /// <summary>
            /// 現在列挙されている要素を取得する
            /// </summary>
            public DoubleKeyValuePair<int, string, T> Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    ThrowIfInvalidIndex();
                    return Current;
                }
            }
            DictionaryEntry IDictionaryEnumerator.Entry
            {
                get
                {
                    ThrowIfInvalidIndex();
                    return new DictionaryEntry(new DoubleKey<int, string>(Current.Key1, Current.Key2), Current.Value);
                }
            }
            object IDictionaryEnumerator.Key
            {
                get
                {
                    ThrowIfInvalidIndex();
                    return new DoubleKey<int, string>(Current.Key1, Current.Key2);
                }
            }
            object IDictionaryEnumerator.Value
            {
                get
                {
                    ThrowIfInvalidIndex();
                    return Current.Value;
                }
            }
            internal Enumerator(UICollectionBase<T> collection)
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
                ThrowIfInvalidVersion();
                if (index < collection.Count)
                {
                    Current = collection.InnerArray[index++];
                    return true;
                }
                Current = default;
                index = collection.Count + 1;
                return false;
            }
            void IEnumerator.Reset()
            {
                ThrowIfInvalidVersion();
                index = 0;
                Current = default;
            }
            private void ThrowIfInvalidIndex()
            {
                if (index < 0 || collection.Count < index) throw new InvalidOperationException();
            }
            private void ThrowIfInvalidVersion()
            {
                if (version != collection.version) throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// 内部コレクションの基底のクラス
        /// </summary>
        /// <typeparam name="TAnother">格納される値の型</typeparam>
        [Serializable]
        public abstract class InnerCollectionBase<TAnother> : IList<TAnother>, IReadOnlyList<TAnother>, IList
        {
            /// <summary>
            /// もととなるコレクションへの参照を取得する
            /// </summary>
            protected UICollectionBase<T> Collection { get; }
            /// <summary>
            /// 格納されている要素数を取得する
            /// </summary>
            public int Count => Collection.Count;
            /// <summary>
            /// 与えられた値のペアから<typeparamref name="TAnother"/>に値を変更する関数を取得する
            /// </summary>
            protected abstract Converter<DoubleKeyValuePair<int, string, T>, TAnother> Converter { get; }
            bool IList.IsFixedSize => false;
            bool ICollection<TAnother>.IsReadOnly => true;
            bool IList.IsReadOnly => true;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => ((ICollection)Collection).SyncRoot;
            private protected InnerCollectionBase(UICollectionBase<T> collection)
            {
                this.Collection = collection ?? throw new ArgumentNullException();
            }
            /// <summary>
            /// 指定したインデックスの要素を取得する
            /// </summary>
            /// <param name="index">検索する要素のインデックス</param>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
            /// <returns><paramref name="index"/>に対応する要素</returns>
            public TAnother this[int index] => Converter.Invoke(Collection.InnerArray[index]);
            object IList.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            TAnother IList<TAnother>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            void ICollection<TAnother>.Add(TAnother item) => throw new NotSupportedException();
            int IList.Add(object value) => throw new NotSupportedException();
            void ICollection<TAnother>.Clear() => throw new NotSupportedException();
            void IList.Clear() => throw new NotSupportedException();
            /// <summary>
            /// 指定した要素が格納されているかどうかを検索する
            /// </summary>
            /// <param name="item">検索する要素</param>
            /// <returns><paramref name="item"/>が格納されていたらtrue，それ以外でfalse</returns>
            public bool Contains(TAnother item) => IndexOf(item) != -1;
            bool IList.Contains(object value) => CompareHelper.IsCompatibleValue<TAnother>(value, out var item) ? Contains(item) : throw new ArgumentException();
            /// <summary>
            /// 指定した配列に要素をコピーする
            /// </summary>
            /// <param name="array">コピー先の配列</param>
            /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
            /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
            public void CopyTo(TAnother[] array, int arrayIndex)
            {
                if (array == null) throw new ArgumentNullException();
                if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
                if (array.Length < arrayIndex + Count) throw new ArgumentException();
                for (int i = 0; i < Count; i++) array[arrayIndex++] = Converter.Invoke(Collection.InnerArray[i]);
            }
            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null) throw new ArgumentNullException();
                if (array.Rank != 1) throw new RankException();
                if (index < 0) throw new ArgumentOutOfRangeException();
                if (array.Length < Count + index || array.GetLowerBound(0) != 0) throw new ArgumentException();
                switch (array)
                {
                    case TAnother[] t: CopyTo(t, index); return;
                    case object[] o:
                        try
                        {
                            for (int i = 0; i < Count; i++) o[index++] = Converter.Invoke(Collection.InnerArray[index]);
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
            public Enumerator GetEnumerator() => new Enumerator(Collection, Converter);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            IEnumerator<TAnother> IEnumerable<TAnother>.GetEnumerator() => GetEnumerator();
            /// <summary>
            /// 指定した要素のインデックスを検索する
            /// </summary>
            /// <param name="item">検索する要素のインデックス</param>
            /// <returns><paramref name="item"/>の持つインデックス 無い場合は-1</returns>
            public int IndexOf(TAnother item) => IndexOfItem(item);
            int IList.IndexOf(object value) => CompareHelper.IsCompatibleValue<TAnother>(value, out var item) ? IndexOf(item) : throw new ArgumentException();
            /// <summary>
            /// 指定した要素のインデックスを検索する
            /// </summary>
            /// <param name="item">検索する要素のインデックス</param>
            /// <returns><paramref name="item"/>の持つインデックス 無い場合は-1</returns>
            protected abstract int IndexOfItem(TAnother item);
            void IList.Insert(int index, object value) => throw new NotSupportedException();
            void IList<TAnother>.Insert(int index, TAnother item) => throw new NotSupportedException();
            bool ICollection<TAnother>.Remove(TAnother item) => throw new NotSupportedException();
            void IList.Remove(object value) => throw new NotSupportedException();
            void IList.RemoveAt(int index) => throw new NotSupportedException();
            void IList<TAnother>.RemoveAt(int index) => throw new NotSupportedException();
            /// <summary>
            /// 現在格納されている要素を配列にまとめて返す
            /// </summary>
            /// <returns>現在格納されている要素が格納された配列</returns>
            public TAnother[] ToAttay()
            {
                var array = new TAnother[Count];
                CopyTo(array, 0);
                return array;
            }
            /// <summary>
            /// 列挙をサポートする構造体
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<TAnother>
            {
                private readonly UICollectionBase<T> collection;
                private readonly Converter<DoubleKeyValuePair<int, string, T>, TAnother> converter;
                private int index;
                private readonly int version;
                /// <summary>
                /// 現在列挙されている要素を取得する
                /// </summary>
                public TAnother Current { get; private set; }
                object IEnumerator.Current
                {
                    get
                    {
                        if (index < 0 || collection.Count < index) throw new InvalidOperationException();
                        return Current;
                    }
                }
                internal Enumerator(UICollectionBase<T> collection, Converter<DoubleKeyValuePair<int, string, T>, TAnother> converter)
                {
                    this.collection = collection ?? throw new ArgumentNullException();
                    this.converter = converter ?? throw new ArgumentNullException();
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
                        Current = converter.Invoke(collection.InnerArray[index++]);
                        return true;
                    }
                    Current = default;
                    index = collection.Count + 1;
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
        /// 表示モードを格納するコレクション
        /// </summary>
        [Serializable]
        public sealed class ModeCollection : InnerCollectionBase<int>
        {
            /// <summary>
            /// 格納されている要素の最大値を取得する
            /// </summary>
            public int Max
            {
                get
                {
                    if (Count == 0) return 0;
                    var max = Collection.InnerArray[0].Key1;
                    for (int i = 1; i < Count; i++)
                        if (max < Collection.InnerArray[i].Key1)
                            max = Collection.InnerArray[i].Key1;
                    return max;
                }
            }
            /// <summary>
            /// 格納されている要素の最小値を取得する
            /// </summary>
            public int Min
            {
                get
                {
                    if (Count == 0) return 0;
                    var min = Collection.InnerArray[0].Key1;
                    for (int i = 1; i < Count; i++)
                        if (min > Collection.InnerArray[i].Key1)
                            min = Collection.InnerArray[i].Key1;
                    return min;
                }
            }
            /// <summary>
            /// 与えられた値のペアから値を変換する関数を取得する
            /// </summary>
            protected override Converter<DoubleKeyValuePair<int, string, T>, int> Converter => x => x.Key1;
            internal ModeCollection(UICollectionBase<T> collection) : base(collection) { }
            /// <summary>
            /// 指定した要素のインデックスを検索する
            /// </summary>
            /// <param name="item">検索する要素のインデックス</param>
            /// <returns><paramref name="item"/>の持つインデックス 無い場合は-1</returns>
            protected override int IndexOfItem(int item) => Collection.IndexOfMode(item);
            /// <summary>
            /// <see cref="HashSet{T}"/>として返す
            /// </summary>
            /// <returns>現在格納されている要素を持った<see cref="HashSet{T}"/>の新しいインスタンス</returns>
            public HashSet<int> ToHashSet() => new HashSet<int>(this);
        }
        /// <summary>
        /// 名前を格納するコレクション
        /// </summary>
        [Serializable]
        public sealed class NameCollection : InnerCollectionBase<string>
        {
            /// <summary>
            /// 与えられた値のペアから値を変換する関数を取得する
            /// </summary>
            protected override Converter<DoubleKeyValuePair<int, string, T>, string> Converter => x => x.Key2;
            internal NameCollection(UICollectionBase<T> collection) : base(collection) { }
            /// <summary>
            /// 指定した要素のインデックスを検索する
            /// </summary>
            /// <param name="item">検索する要素のインデックス</param>
            /// <returns><paramref name="item"/>の持つインデックス 無い場合は-1</returns>
            protected override int IndexOfItem(string item) => Collection.IndexOfName(item);
        }
        /// <summary>
        /// UI情報を格納するコレクション
        /// </summary>
        [Serializable]
        public sealed class InfoCollection : InnerCollectionBase<T>
        {
            /// <summary>
            /// 与えられた値のペアから値を変換する関数を取得する
            /// </summary>
            protected override Converter<DoubleKeyValuePair<int, string, T>, T> Converter => x => x.Value;
            internal InfoCollection(UICollectionBase<T> collection) : base(collection) { }
            /// <summary>
            /// 指定した要素のインデックスを検索する
            /// </summary>
            /// <param name="item">検索する要素のインデックス</param>
            /// <returns><paramref name="item"/>の持つインデックス 無い場合は-1</returns>
            protected override int IndexOfItem(T item) => Collection.IndexOf(item);
        }
    }
}
