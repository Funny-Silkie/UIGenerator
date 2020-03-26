using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="TextureInfo"/>を格納するコレクションクラス
    /// </summary>
    [Serializable]
    public class TextureCollection : ICollection<TextureInfo>, ICollection, IReadOnlyCollection<TextureInfo>
    {
        private int version = 0;
        private TextureInfo[] _array;
        private readonly static TextureInfo[] emptyArray = new TextureInfo[0];
        /// <summary>
        /// 格納されている用をの数を取得する
        /// </summary>
        public int Count { get; private set; }
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
        bool ICollection<TextureInfo>.IsReadOnly => false;
        /// <summary>
        /// 既定の容量を持つ空の<see cref="TextureCollection"/>のインスタンスを生成する
        /// </summary>
        public TextureCollection() : this(0) { }
        /// <summary>
        /// 指定した容量を備えた空の<see cref="TextureCollection"/>のインスタンスを生成する
        /// </summary>
        /// <param name="capacity">設定する容量</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        public TextureCollection(int capacity)
        {
            Central.ThrowHelper.ThrowIfLower(capacity, 0);
            _array = capacity == 0 ? emptyArray : new TextureInfo[capacity];
            Add(DataBase.DefaultTexture);
        }
        /// <summary>
        /// 指定したコレクション内の要素のコピーを持つ<see cref="TextureCollection"/>のインスタンスを生成する
        /// </summary>
        /// <param name="collection">要素をコピーするコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        public TextureCollection(IEnumerable<TextureInfo> collection)
        {
            Central.ThrowHelper.ThrowIfNull(collection);
            _array = new TextureInfo[collection.Count() + 1];
            Add(DataBase.DefaultTexture);
            using var e = collection.GetEnumerator();
            while (e.MoveNext())
                Add(e.Current);
        }
        /// <summary>
        /// 指定したインデックスに対応した要素を取得または設定する
        /// </summary>
        /// <param name="index">検索するインデックス</param>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        /// <returns>インデックスに対応する要素</returns>
        public TextureInfo this[int index]
        {
            get
            {
                Central.ThrowHelper.ThrowIfLower(index, 0);
                Central.ThrowHelper.ThrowIfBiggerOrEqual(index, Count);
                return _array[index];
            }
            set
            {
                Central.ThrowHelper.ThrowIfLower(index, 0);
                Central.ThrowHelper.ThrowIfBiggerOrEqual(index, Count);
                _array[index] = value ?? throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// 末尾に指定した要素を追加する
        /// </summary>
        /// <param name="item">追加する要素</param>
        /// <exception cref="ArgumentException"><paramref name="item"/>が既に存在している</exception>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>がnull</exception>
        public void Add(TextureInfo item)
        {
            Central.ThrowHelper.ThrowIfNull(item);
            Central.ThrowHelper.Throw(new ArgumentException(), Contains(item));
            if (_array.Length < Count + 1) ReSize();
            _array[Count++] = item;
            version++;
            ChangeComboBox();
        }
        private void ReSize()
        {
            var size = _array.Length == 0 ? 4 : _array.Length * 2;
            var array = new TextureInfo[size];
            for (int i = 0; i < Count; i++) array[i] = _array[i];
            _array = array;
        }
        /// <summary>
        /// コンボボックスの内容を更新する
        /// </summary>
        public void ChangeComboBox()
        {
            var names = GetNames();
            foreach (var u in DataBase.UIInfos)
                if (u.Value.Type == UITypes.Texture)
                {
                    var form = (TextureEdittor)((TextureObjInfo)u.Value).HandleForm;
                    if (form == null) continue;
                    else form.ComboBox_Texture.DataSource = names;
                }
            foreach (var a in DataBase.DrawingCollection)
                switch (a.Value.HandleForm)
                {
                    case DrawingArcForm f: f.ComboBox_Texture.DataSource = names; continue;
                    case DrawingCircleForm f: f.ComboBox_Texture.DataSource = names; continue;
                    case DrawingRectangleForm f: f.ComboBox_Texture.DataSource = names; continue;
                    case DrawingRotatedRectangleForm f: f.ComboBox_Texture.DataSource = names; continue;
                    case DrawingSpriteForm f: f.ComboBox_Texture.DataSource = names; continue;
                    case DrawingTriangleForm f: f.ComboBox_Texture.DataSource = names; continue;
                    default: continue;
                }
        }
        /// <summary>
        /// コレクション内の要素をすべて削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) _array[i] = default;
            version++;
            Count = 0;
            ChangeComboBox();
            Add(DataBase.DefaultTexture);
        }
        /// <summary>
        /// 指定した要素が格納されているかどうかを返す
        /// </summary>
        /// <param name="item">検索する要素</param>
        /// <returns>格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(TextureInfo item) => IndexOf(item) != -1;
        /// <summary>
        /// 指定した配列に要素をコピーする
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex"><paramref name="array"/>におけるコピー開始地点</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>のサイズ不足</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/>が0未満</exception>
        public void CopyTo(TextureInfo[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowIfNull(array);
            Central.ThrowHelper.ThrowIfLower(arrayIndex, 0);
            Central.ThrowHelper.Throw(new ArgumentException(), array.Length < arrayIndex + Count);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            Central.ThrowHelper.ThrowIfNull(array);
            Central.ThrowHelper.ThrowIfLower(index, 0);
            Central.ThrowHelper.Throw(new ArgumentException(), array.Length < Count + index || array.GetLowerBound(0) != 0);
            Central.ThrowHelper.Throw(new RankException(), array.Rank != 1);
            if (array is TextureInfo[] t) CopyTo(t, index);
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
        /// 指定した要素のインデックスを返す
        /// </summary>
        /// <param name="item">インデックスを検索する要素</param>
        /// <returns>該当インデックス 無かった場合は-1</returns>
        public int IndexOf(TextureInfo item)
        {
            if (item == null) return -1;
            for (int i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定した要素を削除する
        /// </summary>
        /// <param name="item">削除する要素</param>
        /// <returns>削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(TextureInfo item)
        {
            if (item == null) return false;
            var index = IndexOf(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定したインデックスの要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        public void RemoveAt(int index)
        {
            Central.ThrowHelper.ThrowIfLower(index, 0);
            Central.ThrowHelper.ThrowIfBiggerOrEqual(index, Count);
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            _array[Count - 1] = default;
            Count--;
            version++;
            ChangeComboBox();
        }
        /// <summary>
        /// 文字列情報を格納した配列を取得する
        /// </summary>
        /// <returns>文字列情報を格納した配列</returns>
        public string[] GetNames()
        {
            var names = new string[Count];
            for (int i = 0; i < Count; i++) names[i] = _array[i].ToString();
            return names;
        }
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<TextureInfo> IEnumerable<TextureInfo>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// テクスチャの配列を返す
        /// </summary>
        /// <returns>登録されているテクスチャの配列</returns>
        public UIGeneratorTexture2D[] ToTextureArray()
        {
            var array = new UIGeneratorTexture2D[Count];
            for (int i = 0; i < Count; i++) array[i] = _array[i].Texture;
            return array;
        }
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<TextureInfo>
        {
            private int index;
            private readonly int version;
            private readonly TextureCollection collection;
            /// <summary>
            /// 現在列挙されている<see cref="TextureInfo"/>を取得する
            /// </summary>
            public TextureInfo Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    Central.ThrowHelper.ThrowIfInvalidOperation(index < 0 || collection.Count < index, null); ;
                    return Current;
                }
            }
            internal Enumerator(TextureCollection collection)
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
            /// 列挙を次の要素に進める
            /// </summary>
            /// <exception cref="InvalidOperationException">列挙中にコレクションが変更された</exception>
            /// <returns>次の要素に進めたらtrue，それ以外でfalse</returns>
            public bool MoveNext()
            {
                Central.ThrowHelper.ThrowIfInvalidOperation(version != collection.version, null);
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
                Central.ThrowHelper.ThrowIfInvalidOperation(version != collection.version, null);
                Current = default;
                index = 0;
            }
        }
    }
}
