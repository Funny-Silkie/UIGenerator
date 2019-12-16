using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using asd;
using fslib;
using fslib.Collections;

namespace UIGenerator
{
    /// <summary>
    /// UIに関する情報を格納するコレクションのクラス
    /// </summary>
    [Serializable]
    public class UIInfoCollection : IList<DoubleKeyValuePair<int, string, UIInfoBase>>, IReadOnlyList<DoubleKeyValuePair<int, string, UIInfoBase>>, IDoubleKeyDictionary<int, string, UIInfoBase>, IReadOnlyDoubleKeyDictionary<int, string, UIInfoBase>, IList, IDictionary
    {
        private int version = 0;
        private DoubleKeyValuePair<int, string, UIInfoBase>[] _array;
        private readonly static DoubleKeyValuePair<int, string, UIInfoBase>[] emptyArray = new DoubleKeyValuePair<int, string, UIInfoBase>[0];
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        internal int Capacity => _array.Length;
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
        bool IDictionary.IsFixedSize => false;
        bool IDictionary.IsReadOnly => false;
        bool ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.IsReadOnly => false;
        bool IList.IsFixedSize => false;
        bool IList.IsReadOnly => false;
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
        /// 指定した要素を末尾に追加する
        /// </summary>
        /// <param name="mode">追加する要素の表示モード</param>
        /// <param name="name">追加する要素の名前</param>
        /// <param name="info">追加する要素</param>
        /// <exception cref="ArgumentException"><paramref name="mode"/>と<paramref name="name"/>の組み合わせが既に存在している</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>又は<paramref name="info"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public void Add(int mode, string name, UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(name, null);
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            if (Capacity > Count + 1) ReSize();
            _array[Count - 1] = new DoubleKeyValuePair<int, string, UIInfoBase>(mode, name, info);
            Count++;
            version++;
        }
        void ICollection<DoubleKeyValuePair<int, string, UIInfoBase>>.Add(DoubleKeyValuePair<int, string, UIInfoBase> item) => Add(item.Key1, item.Key2, item.Value);
        int IList.Add(object value)
        {
            Central.ThrowHelper.ThrowArgumentNullException(value, null);
            switch (value)
            {
                case DoubleKeyValuePair<int, string, UIInfoBase> p: Add(p.Key1, p.Key2, p.Value); break;
                case ValueTuple<int, string, UIInfoBase> v: Add(v.Item1, v.Item2, v.Item3); break;
                case ValueTuple<string, int, UIInfoBase> v: Add(v.Item2, v.Item1, v.Item3); break;
                case KeyValuePair<DoubleKey<int, string>, UIInfoBase> d: Add(d.Key.Key1, d.Key.Key2, d.Value); break;
                case KeyValuePair<DoubleKey<string, int>, UIInfoBase> d: Add(d.Key.Key2, d.Key.Key1, d.Value); break;
                default: return -1;
            }
            return Count - 1;
        }
        void IDictionary.Add(object key, object value)
        {
            Central.ThrowHelper.ThrowArgumentNullException(key, null);
            Central.ThrowHelper.ThrowArgumentNullException(value, null);
            if (value is UIInfoBase u)
            {
                switch (key)
                {
                    case ValueTuple<int, string> v: Add(v.Item1, v.Item2, u); return;
                    case ValueTuple<string, int> v: Add(v.Item2, v.Item1, u); return;
                    case DoubleKey<int, string> p: Add(p.Key1, p.Key2, u); return;
                    case DoubleKey<string, int> p: Add(p.Key2, p.Key1, u); return;
                    default: throw new ArgumentException();
                }
            }
            else throw new ArgumentException();
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
        bool IDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey1(int mode) => ContainsMode(mode);
        bool IDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey2(string name) => ContainsName(name);
        bool IDictionary.Contains(object key)
        {
            if (key == null) return false;
            switch (key)
            {
                case ValueTuple<int, string> t: return Contains(t.Item1, t.Item2);
                case ValueTuple<string, int> t: return Contains(t.Item2, t.Item1);
                case DoubleKey<int, string> p: return Contains(p.Key1, p.Key2);
                case DoubleKey<string, int> p: return Contains(p.Key2, p.Key1);
                default: return false;
            }
        }
        bool IList.Contains(object value)
        {
            if (value == null) return false;
            switch (value)
            {
                case DoubleKeyValuePair<int, string, UIInfoBase> p: return IndexOf(p) != -1;
                case UIInfoBase ui: return Contains(ui);
                case ValueTuple<int, string> t: return Contains(t.Item1, t.Item2);
                case ValueTuple<string, int> t: return Contains(t.Item2, t.Item1);
                case DoubleKey<int, string> p: return Contains(p.Key1, p.Key2);
                case DoubleKey<string, int> p: return Contains(p.Key2, p.Key1);
                default: return false;
            }
        }
        bool IReadOnlyDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey1(int mode) => ContainsMode(mode);
        bool IReadOnlyDoubleKeyDictionary<int, string, UIInfoBase>.ContainsKey2(string name) => ContainsName(name);
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
        int IList.IndexOf(object value)
        {
            if (value == null) return -1;
            switch (value)
            {
                case DoubleKeyValuePair<int, string, UIInfoBase> pair: return IndexOf(pair);
                case UIInfoBase ui: return IndexOf(ui);
                case ValueTuple<int, string> t: return IndexOf(t.Item1, t.Item2);
                case ValueTuple<string, int> t: return IndexOf(t.Item2, t.Item1);
                case DoubleKey<int, string> p: return IndexOf(p.Key1, p.Key2);
                default: return -1;
            }
        }
        int IList<DoubleKeyValuePair<int, string, UIInfoBase>>.IndexOf(DoubleKeyValuePair<int, string, UIInfoBase> item) => IndexOf(item);
        void IList.Insert(int index, object value) => throw new NotSupportedException();
        void IList<DoubleKeyValuePair<int, string, UIInfoBase>>.Insert(int index, DoubleKeyValuePair<int, string, UIInfoBase> item) => throw new NotSupportedException();
        private void ReSize()
        {
            var size = Capacity == 0 ? 4 : Capacity * 2;
            var array = new DoubleKeyValuePair<int, string, UIInfoBase>[size];
            Array.Copy(_array, array, Count);
            _array = array;
        }
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns>新しい<see cref="Enumerator"/>のインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<DoubleKeyValuePair<int, string, UIInfoBase>> IEnumerable<DoubleKeyValuePair<int, string, UIInfoBase>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IDictionaryEnumerator IDictionary.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<DoubleKeyValuePair<int, string, UIInfoBase>>, IDictionaryEnumerator
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
            object IDictionaryEnumerator.Key
            {
                get
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                    return Current.GetKeyValuePair().Key;
                }
            }
            object IDictionaryEnumerator.Value
            {
                get
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                    return Current.Value;
                }
            }
            DictionaryEntry IDictionaryEnumerator.Entry
            {
                get
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                    return new DictionaryEntry(Current.GetKeyValuePair().Key, Current.Value);
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
    }
}
