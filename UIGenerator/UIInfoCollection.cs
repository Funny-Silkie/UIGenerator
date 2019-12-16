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
    public class UIInfoCollection : IList<UIInfoBase>, IReadOnlyList<UIInfoBase>, IList
    {
        private int version = 0;
        private UIInfoBase[] _array;
        private readonly static UIInfoBase[] emptyArray = new UIInfoBase[0];
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
        bool ICollection<UIInfoBase>.IsReadOnly => false;
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
            _array = capacity == 0 ? emptyArray : new UIInfoBase[capacity];
        }
        /// <summary>
        /// 指定した要素を末尾に加える
        /// </summary>
        /// <param name="mode"><paramref name="info"/>の描画モード</param>
        /// <param name="name"><paramref name="info"/>の名前</param>
        /// <param name="info">追加する<see cref="UIInfoBase"/>のアイテム</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>又は<paramref name="info"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns>追加出来たらtrue，それ以外でfalse</returns>
        public bool Add(int mode, string name, UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(name, null);
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            if (ContainsModeNamePair(mode, name)) return false;
            if (Capacity < Count + 1) ReSize();
            _array[Count - 1] = info;
            version++;
            Count++;
            return true;
        }
        int IList.Add(object value)
        {
            if (value is UIInfoBase ui)
            {
                Central.ThrowHelper.ThrowArgumentNullException(ui, null);
                Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), ContainsModeNamePair(ui.Mode, ui.Name), null);
                Add(ui.Mode, ui.Name, ui);
                return Count - 1;
            }
            else throw new ArgumentException();
        }
        void ICollection<UIInfoBase>.Add(UIInfoBase item)
        {
            Central.ThrowHelper.ThrowArgumentNullException(item, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), ContainsModeNamePair(item.Mode, item.Name), null);
            Add(item.Mode, item.Name, item);
        }
        /// <summary>
        /// コレクションの要素をすべて削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) _array[i] = default;
            Count = 0;
            version++;
        }
        /// <summary>
        /// 指定した要素が含まれているかどうかを返す
        /// </summary>
        /// <param name="item">検索する要素</param>
        /// <returns>含まれていたらtrue，それ以外でfalse</returns>
        public bool Contains(UIInfoBase item) => IndexOf(item) != -1;
        bool IList.Contains(object value)
        {
            if (value == null) return false;
            if (value is UIInfoBase ui) return Contains(ui);
            return false;
        }
        /// <summary>
        /// 指定された表示モードと名前のペアが存在するかどうかを返す
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns>存在したらtrue，それ以外でfalse</returns>
        public bool ContainsModeNamePair(int mode, string name) => IndexOf(mode, name) != -1;
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
            Central.ThrowHelper.ThrowArgumentNullException(array, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < arrayIndex + Count, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            Central.ThrowHelper.ThrowArgumentNullException(array, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < index + Count || array.GetLowerBound(0) != 0, null);
            if (array is UIInfoBase[] uis)
            {
                CopyTo(uis, index);
                return;
            }
            else if (array is object[] o)
            {
                try
                {
                    for (int i = 0; i < Count; i++) o[index++] = _array[i];
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException();
                }
            }
        }
        /// <summary>
        /// 指定した要素のインデックスを検索する
        /// </summary>
        /// <param name="info">検索する要素</param>
        /// <returns>インデックスが見つかったらその値，見つからなかったら-1</returns>
        public int IndexOf(UIInfoBase info)
        {
            if (info == null) return -1;
            for (int i = 0; i < Count; i++)
                if (_array[i] == info)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した表示モードと名前に一致する要素のインデックスを取得する
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        /// <returns>見つかったらそのインデックス，見つからなかったら-1</returns>
        public int IndexOf(int mode, string name)
        {
            Central.ThrowHelper.ThrowArgumentNullException(name, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(mode, 0, int.MaxValue, null);
            for (int i = 0; i < Count; i++)
                if ((_array[i].Mode == mode) && (_array[i].Name == name))
                    return i;
            return -1;
        }
        int IList.IndexOf(object value)
        {
            Central.ThrowHelper.ThrowArgumentNullException(value, null);
            switch (value)
            {
                case UIInfoBase ui: return IndexOf(ui);
                case ValueTuple<int, string> t: return IndexOf(t.Item1, t.Item2);
                case ValueTuple<string, int> t: return IndexOf(t.Item2, t.Item1);
                default: return -1;
            }
        }
        /// <summary>
        /// 指定した要素を削除する
        /// </summary>
        /// <param name="info">削除する要素</param>
        /// <returns>含まれていたらtrue，それ以外でfalse</returns>
        public bool Remove(UIInfoBase info)
        {
            if (info == null) return false;

        }
        /// <summary>
        /// 指定インデックスの要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満<see cref="Count"/>以上</exception>
        public void RemoveAt(int index)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
        }
        private void ReSize()
        {
            var length = Capacity == 0 ? 4 : Capacity * 2;
            var array = new UIInfoBase[length];
            Array.Copy(_array, array, Count);
            _array = array;
        }
        /// <summary>
        /// 列挙をサポートする構造体を取得する
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<UIInfoBase> IEnumerable<UIInfoBase>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<UIInfoBase>
        {
            private int index;
            private readonly int version;
            private readonly UIInfoCollection collection;
            /// <summary>
            /// 現在列挙されている要素を崇徳する
            /// </summary>
            public UIInfoBase Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || index > collection.Count, null);
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
            /// 列挙を次の要素に移す
            /// </summary>
            /// <exception cref="InvalidOperationException">コレクションが列挙中に変更された</exception>
            /// <returns>次の要素を列挙出来たらtrue，それ以外でfalse</returns>
            public bool MoveNext()
            {
                Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                if ((uint)index < (uint)collection.Count)
                {
                    Current =
                    return true;
                }
                index = collection.Count + 1;
                Current = default;
                return false;
            }
            void IEnumerator.Reset()
            {
                Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                index = 0;
                Current = default;
            }
        }
    }
}
