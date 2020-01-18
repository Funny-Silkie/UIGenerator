using System;
using System.Collections;
using System.Collections.Generic;
using asd;
using System.Threading;
using fslib.Collections;
using fslib.Collections.BasicModel;
using fslib.Exception;

namespace UIGeneratorObjects
{
    /// <summary>
    /// <see cref="IUIElements"/>を格納するコレクション
    /// </summary>
    internal sealed class UIInfoCollection : IDoubleKeyDictionary<int, string, IUIElements>, IReadOnlyDoubleKeyDictionary<int, string, IUIElements>, IDictionary
    {
        private DoubleKeyValuePair<int, string, IUIElements>[] _array;
        private readonly static DoubleKeyValuePair<int, string, IUIElements>[] emptyArray = new DoubleKeyValuePair<int, string, IUIElements>[0];
        private int version = 0;
        private int Capacity => _array.Length;
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// UI情報を格納するコレクションを取得する
        /// </summary>
        public InfoCollection Infos => _infos ?? (_infos = new InfoCollection(this));
        private InfoCollection _infos;
        bool IDictionary.IsFixedSize => false;
        bool ICollection<DoubleKeyValuePair<int, string, IUIElements>>.IsReadOnly => false;
        bool IDictionary.IsReadOnly => false;
        bool ICollection.IsSynchronized => false;
        ICollection IDictionary.Keys
        {
            get
            {
                var array = new DoubleKey<int, string>[Count];
                for (int i = 0; i < Count; i++) array[i] = new DoubleKey<int, string>(_array[i].Key1, _array[i].Key2);
                return Array.AsReadOnly(array);
            }
        }
        ICollection<int> IDoubleKeyDictionary<int, string, IUIElements>.Key1Collection => Modes;
        IEnumerable<int> IReadOnlyDoubleKeyDictionary<int, string, IUIElements>.Key1Collection => Modes;
        ICollection<string> IDoubleKeyDictionary<int, string, IUIElements>.Key2Collection => Names;
        IEnumerable<string> IReadOnlyDoubleKeyDictionary<int, string, IUIElements>.Key2Collection => Names;
        /// <summary>
        /// 表示モードを格納するコレクションを取得する
        /// </summary>
        public ModeCollection Modes => _modes ?? (_modes = new ModeCollection(this));
        private ModeCollection _modes;
        /// <summary>
        /// 名前を格納するコレクションを取得する
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
        ICollection IDictionary.Values => Infos;
        ICollection<IUIElements> IDoubleKeyDictionary<int, string, IUIElements>.Values => Infos;
        IEnumerable<IUIElements> IReadOnlyDoubleKeyDictionary<int, string, IUIElements>.Values => Infos;
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
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            _array = capacity == 0 ? emptyArray : new DoubleKeyValuePair<int, string, IUIElements>[capacity];
        }
        /// <summary>
        /// 指定した表示モードと名前を持つUI情報を取得する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが存在しない</exception>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ要素</returns>
        public IUIElements this[int mode, string name]
        {
            get
            {
                var index = IndexOfKeyPair(mode, name);
                return index == -1 ? throw new KeyNotFoundException() : _array[index].Value;
            }
        }
        IUIElements IDoubleKeyDictionary<int, string, IUIElements>.this[int key1, string key2]
        {
            get => this[key1, key2];
            set => throw new NotSupportedException();
        }
        object IDictionary.this[object key]
        {
            get => key is DoubleKey<int, string> pair ? this[pair.Key1, pair.Key2] : throw new ArgumentException();
            set => throw new NotSupportedException();
        }
        /// <summary>
        /// 指定したUI情報を追加する
        /// </summary>
        /// <param name="item">追加するUI情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>またはその名前がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="item"/>の表示モードが0未満</exception>
        /// <exception cref="KeyDuplicateException">キーに重複がある</exception>
        public void Add(IUIElements item)
        {
            if (item == null || item.Name == null) throw new ArgumentNullException();
            if (ContainsKeyPair(item.Mode, item.Name)) throw new KeyDuplicateException();
            if (Capacity < Count + 1) ReSize(Count + 1);
            _array[Count++] = new DoubleKeyValuePair<int, string, IUIElements>(item.Mode, item.Name, item);
            version++;
        }
        /// <summary>
        /// 指定した要素を追加する
        /// </summary>
        /// <param name="mode">追加する要素の表示モード</param>
        /// <param name="name">追加する要素の名前</param>
        /// <param name="value">追加する要素</param>
        /// <exception cref="ArgumentException"><paramref name="value"/>における表示モードや名前と<paramref name="mode"/>及び<paramref name="name"/>との不一致が見られた</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>またはその名前がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>の表示モードが0未満</exception>
        /// <exception cref="KeyDuplicateException">キーに重複がある</exception>
        private void Add(int mode, string name, IUIElements value)
        {
            if (value == null) throw new ArgumentNullException();
            if (value.Mode != mode || value.Name != name) throw new ArgumentException();
            Add(value);
        }
        void ICollection<DoubleKeyValuePair<int, string, IUIElements>>.Add(DoubleKeyValuePair<int, string, IUIElements> item) => Add(item.Key1, item.Key2, item.Value);
        void IDictionary.Add(object key, object value)
        {
            if (key == null || value == null) throw new ArgumentNullException();
            if (key is DoubleKey<int, string> pair && value is IUIElements v) Add(pair.Key1, pair.Key2, v);
            else throw new ArgumentException();
        }
        void IDoubleKeyDictionary<int, string, IUIElements>.Add(int key1, string key2, IUIElements value) => Add(key1, key2, value);
        /// <summary>
        /// UI情報の読み取り専用コレクションを返す
        /// </summary>
        /// <returns>UI情報が格納された読み取り専用コレクション</returns>
        public BasicReadOnlyCollection<IUIElements> AsReadOnly()
        {
            var array = new IUIElements[Count];
            for (int i = 0; i < Count; i++) array[i] = _array[i].Value;
            return new BasicReadOnlyCollection<IUIElements>(array);
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
        /// 指定したUI情報が格納されているかどうかを取得する
        /// </summary>
        /// <param name="info">検索するUI情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        /// <returns><paramref name="info"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(IUIElements info) => IndexOfValue(info) != -1;
        /// <summary>
        /// 指定した要素が含まれているかどうかを検索する
        /// </summary>
        /// <param name="item">検索する要素</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>の名前またはUI情報がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="item"/>の表示モードが0未満</exception>
        /// <returns><paramref name="item"/>が格納されていたらtrue，それ以外でfalse</returns>
        private bool Contains(DoubleKeyValuePair<int, string, IUIElements> item) => IndexOfPair(item) != -1;
        bool ICollection<DoubleKeyValuePair<int, string, IUIElements>>.Contains(DoubleKeyValuePair<int, string, IUIElements> item) => Contains(item);
        bool IDictionary.Contains(object key)
        {
            switch (key)
            {
                case DoubleKey<int, string> pair: return ContainsKeyPair(pair.Key1, pair.Key2);
                case null: throw new ArgumentNullException();
                default: throw new ArgumentException();
            }
        }
        /// <summary>
        /// 指定した表示モードと名前を持つ要素が格納されているかどうかを取得する
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ要素が格納されていたらtrue，それ以外でfalse</returns>
        public bool ContainsKeyPair(int mode, string name) => IndexOfKeyPair(mode, name) != -1;
        bool IDoubleKeyDictionary<int, string, IUIElements>.ContainsKey1(int key1) => IndexOfMode(key1) != -1;
        bool IReadOnlyDoubleKeyDictionary<int, string, IUIElements>.ContainsKey1(int key1) => IndexOfMode(key1) != -1;
        bool IDoubleKeyDictionary<int, string, IUIElements>.ContainsKey2(string key2) => IndexOfName(key2) != -1;
        bool IReadOnlyDoubleKeyDictionary<int, string, IUIElements>.ContainsKey2(string key2) => IndexOfName(key2) != -1;
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="arrayIndex"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        private void CopyTo(DoubleKeyValuePair<int, string, IUIElements>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
            if (array.Length < Count + arrayIndex) throw new ArgumentException();
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Rank != 1) throw new RankException();
            if (index < 0) throw new ArgumentOutOfRangeException();
            if (array.Length < Count + index || array.GetLowerBound(0) != 0) throw new ArgumentException();
            switch (array)
            {
                case DoubleKeyValuePair<int, string, IUIElements>[] pairs: CopyTo(pairs, index); return;
                case DictionaryEntry[] entries:
                    for (int i = 0; i < Count; i++) entries[index++] = new DictionaryEntry(new DoubleKey<int, string>(_array[i].Key1, _array[i].Key2), _array[i].Value);
                    return;
                case object[] o:
                    try
                    {
                        for (int i = 0; i < Count; i++) o[index++] = _array[i];
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentNullException();
                    }
                    return;
                default: throw new ArgumentNullException();
            }
        }
        void ICollection<DoubleKeyValuePair<int, string, IUIElements>>.CopyTo(DoubleKeyValuePair<int, string, IUIElements>[] array, int arrayIndex) => CopyTo(array, arrayIndex);
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IDictionaryEnumerator IDictionary.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<DoubleKeyValuePair<int, string, IUIElements>> IEnumerable<DoubleKeyValuePair<int, string, IUIElements>>.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// 指定した表示モードと名前を持つ要素のインデックスを検索する
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ要素のインデックス 無かったら-1</returns>
        private int IndexOfKeyPair(int mode, string name)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException();
            if (name == null) throw new ArgumentNullException();
            for (int i = 0; i < Count; i++)
                if (mode == _array[i].Key1 && name == _array[i].Key2)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した表示モードを持つ要素のうち最初の物のインデックスを検索する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns><paramref name="mode"/>を持つ要素のうち最初の物のインデックス 無かったら-1</returns>
        private int IndexOfMode(int mode)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException();
            for (int i = 0; i < Count; i++)
                if (mode == _array[i].Key1)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した名前を持つ要素のうち最初の物のインデックスを検索する
        /// </summary>
        /// <param name="name">検索する要素の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <returns><paramref name="name"/>を持つ要素のうち最初の物のインデックス 無かったら-1</returns>
        private int IndexOfName(string name)
        {
            if (name == null) throw new ArgumentNullException();
            for (int i = 0; i < Count; i++)
                if (name == _array[i].Key2)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定したペアのインデックスを検索する
        /// </summary>
        /// <param name="item">インデックスを検索する要素</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>の名前またはUI情報がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="item"/>の表示モードが0未満</exception>
        /// <returns><paramref name="item"/>の持つインデックス 無かったら-1</returns>
        private int IndexOfPair(DoubleKeyValuePair<int, string, IUIElements> item)
        {
            if (item.Value == null) throw new ArgumentNullException();
            var ind = IndexOfKeyPair(item.Key1, item.Key2);
            if (ind == -1) return -1;
            return _array[ind].Value == item.Value ? ind : -1;
        }
        /// <summary>
        /// 指定した要素のインデックスを検索する
        /// </summary>
        /// <param name="value">検索するUI情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>がnull</exception>
        /// <returns><paramref name="value"/>の持つインデックス 無かったら-1</returns>
        private int IndexOfValue(IUIElements value)
        {
            if (value == null) throw new ArgumentNullException();
            for (int i = 0; i < Count; i++)
                if (value == _array[i].Value)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した表示モードと名前を持つUI情報を削除する
        /// </summary>
        /// <param name="mode">削除する要素の表示モード</param>
        /// <param name="name">削除する要素の名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns>要素を削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(int mode, string name)
        {
            var index = IndexOfKeyPair(mode, name);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定したUI情報を削除する
        /// </summary>
        /// <param name="value">削除する要素</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>がnull</exception>
        /// <returns><paramref name="value"/>を削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(IUIElements value)
        {
            var index = IndexOfValue(value);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        bool ICollection<DoubleKeyValuePair<int, string, IUIElements>>.Remove(DoubleKeyValuePair<int, string, IUIElements> item)
        {
            var index = IndexOfPair(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        void IDictionary.Remove(object key)
        {
            switch (key)
            {
                case DoubleKey<int, string> pair: Remove(pair.Key1, pair.Key2); return;
                case null: throw new ArgumentNullException();
                default: throw new ArgumentException();
            }
        }
        /// <summary>
        /// 指定した位置の要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        private void RemoveAt(int index)
        {
            if (index < 0 || Count - 1 < index) throw new ArgumentOutOfRangeException();
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            _array[Count - 1] = default;
            Count--;
            version++;
        }
        /// <summary>
        /// <see cref="_array"/>の容量を変更する
        /// </summary>
        /// <param name="min">変更後の容量の最小値</param>
        private void ReSize(int min)
        {
            if (min < Count) return;
            var size = Capacity == 0 ? 4 : Capacity * 2;
            if ((uint)size > int.MaxValue) size = int.MaxValue;
            if (min > size) size = min;
            if (size == Count) return;
            var array = new DoubleKeyValuePair<int, string, IUIElements>[size];
            for (int i = 0; i < Count; i++) array[i] = _array[i];
            _array = array;
        }
        /// <summary>
        /// 指定した表示モードと名前を持つ値を検索する
        /// </summary>
        /// <param name="mode">検索する要素の表示モード</param>
        /// <param name="name">検索する要素の名前</param>
        /// <param name="value"><paramref name="mode"/>と<paramref name="name"/>を持つ要素 無かったら既定値</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns><paramref name="value"/>が見つかったらtrue，それ以外でfalse</returns>
        public bool TryGetValue(int mode, string name, out IUIElements value)
        {
            var index = IndexOfKeyPair(mode, name);
            if (index == -1)
            {
                value = default;
                return false;
            }
            value = _array[index].Value;
            return false;
        }
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        internal struct Enumerator : IEnumerator<DoubleKeyValuePair<int, string, IUIElements>>, IDictionaryEnumerator
        {
            private readonly UIInfoCollection dictionary;
            private int index;
            private readonly int version;
            /// <summary>
            /// 現在列挙されている要素を取得する
            /// </summary>
            public DoubleKeyValuePair<int, string, IUIElements> Current { get; private set; }
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
            internal Enumerator(UIInfoCollection dictionary)
            {
                this.dictionary = dictionary ?? throw new ArgumentNullException();
                version = dictionary.version;
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
                ThrowIfInvalidVersion();
                if (index < dictionary.Count)
                {
                    Current = dictionary._array[index++];
                    return true;
                }
                index = dictionary.Count + 1;
                Current = default;
                return false;
            }
            void IEnumerator.Reset()
            {
                ThrowIfInvalidVersion();
                index = 0;
                Current = default;
            }
            /// <summary>
            /// <see cref="index"/>の値が不正だったら<see cref="InvalidOperationException"/>をスローする
            /// </summary>
            private void ThrowIfInvalidIndex()
            {
                if (index < 0 || dictionary.Count < index) throw new InvalidOperationException();
            }
            /// <summary>
            /// <see cref="version"/>の値が不正だったら，<see cref="InvalidOperationException"/>をスローする
            /// </summary>
            private void ThrowIfInvalidVersion()
            {
                if (version != dictionary.version) throw new InvalidOperationException();
            }
        }
        /// <summary>
        /// <see cref="UIInfoCollection"/>内の特定の値を格納するコレクション
        /// </summary>
        /// <typeparam name="T">格納する値の型</typeparam>
        [Serializable]
        internal abstract class InnerCollectionBase<T> : ICollection<T>, IReadOnlyCollection<T>, ICollection
        {
            /// <summary>
            /// 要素を変換する変換子を取得する
            /// </summary>
            protected private abstract Converter<DoubleKeyValuePair<int, string, IUIElements>, T> Converter { get; }
            /// <summary>
            /// 格納されている要素数を取得する
            /// </summary>
            public int Count => Dictionary.Count;
            /// <summary>
            /// <see cref="UIInfoCollection"/>への参照を取得する
            /// </summary>
            protected private UIInfoCollection Dictionary { get; }
            bool ICollection<T>.IsReadOnly => true;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => ((ICollection)Dictionary).SyncRoot;
            protected private InnerCollectionBase(UIInfoCollection dictionary)
            {
                this.Dictionary = dictionary ?? throw new ArgumentNullException();
            }
            void ICollection<T>.Add(T item) => throw new NotSupportedException();
            void ICollection<T>.Clear() => throw new NotSupportedException();
            bool ICollection<T>.Contains(T item) => IndexOfItem(item) != -1;
            /// <summary>
            /// 指定した配列に要素をコピーする
            /// </summary>
            /// <param name="array">コピー先の配列</param>
            /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
            /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
            /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
            /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
            public void CopyTo(T[] array, int arrayIndex)
            {
                if (array == null) throw new ArgumentNullException();
                if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
                if (array.Length < Count + arrayIndex) throw new ArgumentException();
                for (int i = 0; i < Count; i++) array[arrayIndex++] = Converter.Invoke(Dictionary._array[i]);
            }
            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null) throw new ArgumentNullException();
                if (array.Rank != 1) throw new RankException();
                if (index < 0) throw new ArgumentOutOfRangeException();
                if (array.Length < Count + index || array.GetLowerBound(0) != 0) throw new ArgumentException();
                switch (array)
                {
                    case T[] t: CopyTo(t, index); return;
                    case object[] o:
                        try
                        {
                            for (int i = 0; i < Count; i++) o[index++] = Converter.Invoke(Dictionary._array[i]);
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
            internal Enumerator GetEnumerator() => new Enumerator(Dictionary, Converter);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
            /// <summary>
            /// 指定した要素の<see cref="Dictionary"/>内でのインデックスを検索する
            /// </summary>
            /// <param name="item">検索する値</param>
            /// <remarks><paramref name="item"/>の持つインデックス 無かったら-1</remarks>
            protected private abstract int IndexOfItem(T item);
            bool ICollection<T>.Remove(T item) => throw new NotSupportedException();
            /// <summary>
            /// 列挙をサポートする構造体
            /// </summary>
            [Serializable]
            internal struct Enumerator : IEnumerator<T>
            {
                private readonly UIInfoCollection dictionary;
                private readonly Converter<DoubleKeyValuePair<int, string, IUIElements>, T> converter;
                private int index;
                private readonly int version;
                /// <summary>
                /// 現在列挙されている要素を取得する
                /// </summary>
                public T Current { get; private set; }
                object IEnumerator.Current
                {
                    get
                    {
                        if (index < 0 || dictionary.Count < index) throw new InvalidOperationException();
                        return Current;
                    }
                }
                internal Enumerator(UIInfoCollection dictionary, Converter<DoubleKeyValuePair<int, string, IUIElements>, T> converter)
                {
                    this.dictionary = dictionary ?? throw new ArgumentNullException();
                    this.converter = converter ?? throw new ArgumentNullException();
                    index = 0;
                    Current = default;
                    version = dictionary.version;
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
                    if (version != dictionary.version) throw new InvalidOperationException();
                    if (index < dictionary.Count)
                    {
                        Current = converter.Invoke(dictionary._array[index++]);
                        return true;
                    }
                    index = dictionary.Count + 1;
                    Current = default;
                    return false;
                }
                void IEnumerator.Reset()
                {
                    if (version != dictionary.version) throw new InvalidOperationException();
                    index = 0;
                    Current = default;
                }
            }
        }
        /// <summary>
        /// <see cref="UIInfoCollection"/>の表示モードを格納するコレクション
        /// </summary>
        [Serializable]
        internal sealed class ModeCollection : InnerCollectionBase<int>
        {
            /// <summary>
            /// 要素を変換する変換子を取得する
            /// </summary>
            protected private override Converter<DoubleKeyValuePair<int, string, IUIElements>, int> Converter => _converter ?? (_converter = x => x.Key1);
            private Converter<DoubleKeyValuePair<int, string, IUIElements>, int> _converter;
            internal ModeCollection(UIInfoCollection dictionary) : base(dictionary) { }
            /// <summary>
            /// 指定した要素の<see cref="InnerCollectionBase{T}.Dictionary"/>内でのインデックスを検索する
            /// </summary>
            /// <param name="item">検索する値</param>
            /// <remarks><paramref name="item"/>の持つインデックス 無かったら-1</remarks>
            protected private override int IndexOfItem(int item) => Dictionary.IndexOfMode(item);
        }
        /// <summary>
        /// <see cref="UIInfoCollection"/>の名前を格納するコレクション
        /// </summary>
        [Serializable]
        internal sealed class NameCollection : InnerCollectionBase<string>
        {
            /// <summary>
            /// 要素を変換する変換子を取得する
            /// </summary>
            protected private override Converter<DoubleKeyValuePair<int, string, IUIElements>, string> Converter => _converter ?? (_converter = x => x.Key2);
            private Converter<DoubleKeyValuePair<int, string, IUIElements>, string> _converter;
            internal NameCollection(UIInfoCollection dictionary) : base(dictionary) { }
            /// <summary>
            /// 指定した要素の<see cref="InnerCollectionBase{T}.Dictionary"/>内でのインデックスを検索する
            /// </summary>
            /// <param name="item">検索する値</param>
            /// <remarks><paramref name="item"/>の持つインデックス 無かったら-1</remarks>
            protected private override int IndexOfItem(string item) => Dictionary.IndexOfName(item);
        }
        /// <summary>
        /// <see cref="UIInfoCollection"/>のUI情報を格納するコレクション
        /// </summary>
        [Serializable]
        internal sealed class InfoCollection : InnerCollectionBase<IUIElements>
        {
            /// <summary>
            /// 要素を変換する変換子を取得する
            /// </summary>
            protected private override Converter<DoubleKeyValuePair<int, string, IUIElements>, IUIElements> Converter => _converter ?? (_converter = x => x.Value);
            private Converter<DoubleKeyValuePair<int, string, IUIElements>, IUIElements> _converter;
            internal InfoCollection(UIInfoCollection dictionary) : base(dictionary) { }
            /// <summary>
            /// 指定した要素の<see cref="InnerCollectionBase{T}.Dictionary"/>内でのインデックスを検索する
            /// </summary>
            /// <param name="item">検索する値</param>
            /// <remarks><paramref name="item"/>の持つインデックス 無かったら-1</remarks>
            protected private override int IndexOfItem(IUIElements item) => Dictionary.IndexOfValue(item);
        }
    }
}
