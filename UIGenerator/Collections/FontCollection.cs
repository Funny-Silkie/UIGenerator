using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="FontInfoBase"/>を格納するコレクションのクラス
    /// </summary>
    [Serializable]
    public class FontCollection : ICollection<FontInfoBase>, IReadOnlyCollection<FontInfoBase>, ICollection
    {
        private FontInfoBase[] _array;
        private static readonly FontInfoBase[] emptyArray = new FontInfoBase[0];
        private int version = 0;
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        bool ICollection<FontInfoBase>.IsReadOnly => false;
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null) Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                return _syncRoot;
            }
        }
        private object _syncRoot;
        /// <summary>
        /// 既定の容量を持った空の<see cref="FontCollection"/>のインスタンスを生成する
        /// </summary>
        public FontCollection() : this(0) { }
        /// <summary>
        /// 指定した容量を備えた空の<see cref="FontCollection"/>のインスタンスを生成する
        /// </summary>
        /// <param name="capacity">設定する容量</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        public FontCollection(int capacity)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(capacity, 0, int.MaxValue, null);
            _array = capacity == 0 ? emptyArray : new FontInfoBase[capacity];
            Add(DataBase.DefaultFont);
        }
        /// <summary>
        /// 指定したコレクションのコピーを持った<see cref="FontCollection"/>のインスタンスを生成する
        /// </summary>
        /// <param name="collection">要素をコピーするコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        public FontCollection(IEnumerable<FontInfoBase> collection)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, collection);
            _array = new FontInfoBase[collection.Count() + 1];
            Add(DataBase.DefaultFont);
            using (var e = collection.GetEnumerator())
                while (e.MoveNext())
                    Add(e.Current);
        }
        /// <summary>
        /// 指定したインデックスに対応する要素を取得または設定する
        /// </summary>
        /// <param name="index">検索する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        public FontInfoBase this[int index]
        {
            get
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                return _array[index];
            }
            set
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                _array[index] = value ?? throw new ArgumentNullException(nameof(value));
                version++;
            }
        }
        internal FontInfoBase this[string tostring]
        {
            get
            {
                var index = IndexOf(tostring);
                if (index == -1) throw new KeyNotFoundException();
                return _array[index];
            }
        }
        /// <summary>
        /// 指定した要素を末尾に追加する
        /// </summary>
        /// <param name="item">追加する<see cref="FontCollection"/>のインスタンス</param>
        /// <exception cref="ArgumentException"><see cref="FontInfoBase"/>が重複している</exception>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>がnull</exception>
        public void Add(FontInfoBase item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Contains(item)) throw new ArgumentException("Status duplicated");
            if (_array.Length < Count + 1) ReSize();
            _array[Count++] = item;
            version++;
            ChangeFontComboBox();
        }
        /// <summary>
        /// コンボボックスの内容を更新する
        /// </summary>
        public void ChangeFontComboBox()
        {
            var names = GetNames();
            foreach (var u in DataBase.UIInfos)
                if (u.Value.Type == UITypes.Text)
                {
                    var form = (TextEdittor)((TextObjInfo)u.Value).HandleForm;
                    if (form == null) continue;
                    else form.ComboBox_Font.DataSource = names;
                }
            foreach (var form in DataBase.Forms)
                if (form is DrawingTextForm f)
                    f.ComboBox_Font.DataSource = names;
        }
        /// <summary>
        /// 要素をすべて削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) _array[i] = default;
            Count = 0;
            version++;
            ChangeFontComboBox();
            Add(DataBase.DefaultFont);
        }
        /// <summary>
        /// 指定した要素が含まれているかどうかを返す
        /// </summary>
        /// <param name="item">検索する要素</param>
        /// <returns>含まれていたらtrue，それ以外でfalse</returns>
        public bool Contains(FontInfoBase item) => IndexOf(item) != -1;
        /// <summary>
        /// 文字列情報に一致する要素のうち先頭の物のインデックスを返す
        /// </summary>
        /// <param name="tostring">検索する要素の文字列情報</param>
        /// <returns>見つかったらそのインデックス，見つからなかったら-1</returns>
        public int IndexOf(string tostring)
        {
            for (int i = 0; i < Count; i++)
                if (tostring == _array[i].ToString())
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した要素のインデックスを返す
        /// </summary>
        /// <param name="item">インデックスを検索する要素</param>
        /// <returns>インデックス 含まれていない場合は-1</returns>
        public int IndexOf(FontInfoBase item)
        {
            if (item == null) return -1;
            for (int i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した要素と一致する要素を削除する
        /// </summary>
        /// <param name="item">削除する要素</param>
        /// <returns>削除されたらtrue，できなかったらfalse</returns>
        public bool Remove(FontInfoBase item)
        {
            if (item == null) return false;
            var index = IndexOf(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 文字列情報に一致する要素のうち先頭の物を削除する
        /// </summary>
        /// <param name="tostring">削除される要素の文字列情報</param>
        /// <returns>削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(string tostring)
        {
            if (tostring == null) return false;
            var index = IndexOf(tostring);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定したインデックスにある要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || Count <= index) throw new ArgumentOutOfRangeException();
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            _array[Count - 1] = default;
            Count--;
            version++;
            ChangeFontComboBox();
        }
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        public void CopyTo(FontInfoBase[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < arrayIndex + Count, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        /// <summary>
        /// このコレクションを文字列化した情報が格納された配列を返す
        /// </summary>
        /// <returns>このコレクションを文字列化した情報が格納された配列</returns>
        public string[] GetNames()
        {
            var names = new string[Count];
            for (int i = 0; i < Count; i++) names[i] = _array[i].ToString();
            return names;
        }
        /// <summary>
        /// <see cref="_array"/>のサイズを拡張する
        /// </summary>
        private void ReSize()
        {
            var newSize = _array.Length == 0 ? 4 : _array.Length * 2;
            var array = new FontInfoBase[newSize];
            for (int i = 0; i < Count; i++)
                array[i] = _array[i];
            _array = array;
        }
        /// <summary>
        /// 格納されているフォントからなる配列を返す
        /// </summary>
        /// <returns>格納されているフォントからなる配列</returns>
        public UIGeneratorFontBase[] ToFontArray()
        {
            var array = new UIGeneratorFontBase[Count];
            for (int i = 0; i < Count; i++) array[i] = _array[i].Font;
            return array;
        }
        void ICollection.CopyTo(Array array, int index)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.Length < index + Count, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new ArgumentException(), array.GetLowerBound(0) != 0, null);
            if (array is FontInfoBase[] f) CopyTo(f, index);
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
            else throw new ArgumentException();
        }
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<FontInfoBase> IEnumerable<FontInfoBase>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<FontInfoBase>
        {
            private int index;
            private readonly int version;
            private readonly FontCollection collection;
            /// <summary>
            /// 現在列挙されている要素
            /// </summary>
            public FontInfoBase Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    Central.ThrowHelper.ThrowInvalidOperationException(index < 0 || collection.Count < index, null);
                    return Current;
                }
            }
            internal Enumerator(FontCollection collection)
            {
                this.collection = collection;
                index = 0;
                version = collection.version;
                Current = default;
            }
            /// <summary>
            /// 列挙を次に進める
            /// </summary>
            /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
            /// <returns>列挙出来たらtrue，出来なかったらfalse</returns>
            public bool MoveNext()
            {
                Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                if (index < collection.Count)
                {
                    Current = collection._array[index];
                    index++;
                    return true;
                }
                index = collection.Count + 1;
                Current = default;
                return false;
            }
            /// <summary>
            /// このインスタンスを破棄する
            /// </summary>
            public void Dispose() { }
            void IEnumerator.Reset()
            {
                Central.ThrowHelper.ThrowInvalidOperationException(version != collection.version, null);
                index = 0;
                Current = default;
            }
        }
    }
}
