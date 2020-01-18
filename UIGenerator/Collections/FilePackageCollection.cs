using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// ファイルパッケージの情報を格納する
    /// </summary>
    [Serializable]
    public struct FilePackageEntry : IEquatable<FilePackageEntry>
    {
        /// <summary>
        /// パッケージファイルのパスを取得する
        /// </summary>
        public string FilePath { get; }
        /// <summary>
        /// パスワードを取得する
        /// </summary>
        public string PassWord { get; }
        /// <summary>
        /// パスワードでロックされているかどうかを取得する
        /// </summary>
        public bool IsLocked { get; }
        /// <summary>
        /// パスワード無しのファイルパッケージの情報をもとに<see cref="FilePackageEntry"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="path">パッケージファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public FilePackageEntry(string path)
        {
            FilePath = path ?? throw new ArgumentNullException();
            PassWord = string.Empty;
            IsLocked = false;
        }
        /// <summary>
        /// パスワード有りのファイルパッケージの情報をもとに<see cref="FilePackageEntry"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="path">ファイルのパスパッケージファイルのパス</param>
        /// <param name="passWord">パスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="passWord"/>がnull</exception>
        public FilePackageEntry(string path, string passWord)
        {
            FilePath = path ?? throw new ArgumentNullException();
            PassWord = passWord ?? throw new ArgumentNullException();
            IsLocked = true;
        }
        /// <summary>
        /// 2つの<see cref="FilePackageEntry"/>間の同値性を評価する
        /// </summary>
        /// <param name="f1">同値性を評価する<see cref="FilePackageEntry"/>のインスタンス</param>
        /// <param name="f2">同値性を評価するもう一つの<see cref="FilePackageEntry"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(FilePackageEntry f1, FilePackageEntry f2) => f1.Equals(f2);
        /// <summary>
        /// 2つの<see cref="FilePackageEntry"/>インスタンス間の同値性を調査する
        /// </summary>
        /// <param name="other">同値性を調査するもう一つの<see cref="FilePackageEntry"/>のインスタンス</param>
        /// <returns>このインスタンスと<paramref name="other"/>が同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(FilePackageEntry other) => (IsLocked == other.IsLocked) && (FilePath == other.FilePath) && (PassWord == other.PassWord);
        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を評価するオブジェクト</param>
        /// <returns>等価だったらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is FilePackageEntry f ? Equals(f) : false;
        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(FilePackageEntry f1, FilePackageEntry f2) => Equals(f1, f2);
        public static bool operator !=(FilePackageEntry f1, FilePackageEntry f2) => !Equals(f1, f2);
    }
    /// <summary>
    /// ファイルパッケージのパスを保管するコレクション
    /// </summary>
    [Serializable]
    public class FilePackageCollection : IList<FilePackageEntry>, IReadOnlyList<FilePackageEntry>, IList
    {
        private FilePackageEntry[] _array;
        private readonly static FilePackageEntry[] emptyArray = new FilePackageEntry[0];
        private int version = 0;
        private int Capacity => _array.Length;
        /// <summary>
        /// 格納されている要素数を取得する
        /// </summary>
        public int Count { get; private set; }
        bool IList.IsFixedSize => false;
        bool ICollection<FilePackageEntry>.IsReadOnly => false;
        bool IList.IsReadOnly => false;
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
        /// 既定の容量を持つ空の<see cref="FilePackageCollection"/>の新しいインスタンスを生成する
        /// </summary>
        public FilePackageCollection() : this(0) { }
        /// <summary>
        /// 指定した容量を持つ空の<see cref="FilePackageCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="capacity">設定する容量</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        public FilePackageCollection(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            _array = capacity == 0 ? emptyArray : new FilePackageEntry[capacity];
        }
        /// <summary>
        /// 指定したコレクションのコピーを持つ<see cref="FilePackageCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collection">コピーされる要素が格納されているコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        public FilePackageCollection(IEnumerable<FilePackageEntry> collection)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, collection);
            if (collection is ICollection<FilePackageEntry> c)
            {
                Count = c.Count;
                _array = c.Count == 0 ? emptyArray : new FilePackageEntry[c.Count];
                if (Count != 0) CopyTo(_array, 0);
            }
            else
            {
                _array = emptyArray;
                using (var e = collection.GetEnumerator())
                    while (e.MoveNext())
                        Add(e.Current);
            }
        }
        /// <summary>
        /// 指定したインデックスを持つ要素を取得する
        /// </summary>
        /// <param name="index">検索する要素</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0未満または<see cref="Count"/>以上</exception>
        /// <returns><paramref name="index"/>を持つ要素</returns>
        public FilePackageEntry this[int index]
        {
            get
            {
                Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
                return _array[index];
            }
        }
        /// <summary>
        /// 指定したファイルパスを持つパスワード無しの要素を取得する
        /// </summary>
        /// <param name="path">検索するパスワード無しの要素のファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="path"/>を持つパスワード無しの要素が存在しない</exception>
        /// <returns><paramref name="path"/>を持つパスワード無しの要素</returns>
        public FilePackageEntry this[string path]
        {
            get
            {
                var index = IndexOf(path);
                return _array[index == -1 ? throw new KeyNotFoundException() : index];
            }
        }
        /// <summary>
        /// 指定したファイルパスとパスワードを持つ要素を取得する
        /// </summary>
        /// <param name="path">検索する要素のファイルパス</param>
        /// <param name="passWord">検索する要素のパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="passWord"/>がnull</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="path"/>と<paramref name="passWord"/>を持つ要素が存在しない</exception>
        /// <returns><paramref name="path"/>と<paramref name="passWord"/>を持つ要素</returns>
        public FilePackageEntry this[string path, string passWord]
        {
            get
            {
                var index = IndexOf(path, passWord);
                return _array[index == -1 ? throw new KeyNotFoundException() : index];
            }
        }
        object IList.this[int index]
        {
            get => this[index];
            set => throw new NotSupportedException();
        }
        FilePackageEntry IList<FilePackageEntry>.this[int index]
        {
            get => this[index];
            set => throw new NotSupportedException();
        }
        /// <summary>
        /// 指定したファイルパスを持つパスワード無しの要素を末尾に追加する
        /// </summary>
        /// <param name="path">追加するパスワード無しの要素のファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>追加に成功したらtrue，それ以外でfalse</returns>
        public bool Add(string path)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: path);
            if (!Engine.File.Exists(path) || Contains(path)) return false;
            try
            {
                AddEvent(new FilePackageEntry(path));
            }
            catch
            {
                return false;
            }
            if (Capacity < Count + 1) ReSize(Count + 1);
            _array[Count++] = new FilePackageEntry(path);
            version++;
            return true;
        }
        /// <summary>
        /// 指定したファイルパスとパスワードを持つ要素を末尾に追加する
        /// </summary>
        /// <param name="path">追加する要素のファイルパス</param>
        /// <param name="passWord">追加する要素のパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="passWord"/>がnull</exception>
        /// <returns>追加に成功したらtrue，それ以外でfalse</returns>
        public bool Add(string path, string passWord)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, path, passWord);
            if (!Engine.File.Exists(path) || Contains(path, passWord)) return false;
            try
            {
                AddEvent(new FilePackageEntry(path, passWord));
            }
            catch
            {
                return false;
            }
            if (Capacity < Count + 1) ReSize(Count + 1);
            _array[Count++] = new FilePackageEntry(path, passWord);
            version++;
            return true;
        }
        private bool Add(FilePackageEntry entry) => entry.IsLocked ? Add(entry.FilePath, entry.PassWord) : Add(entry.FilePath);
        void ICollection<FilePackageEntry>.Add(FilePackageEntry item) => Add(item);
        int IList.Add(object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case string path: return Add(path) ? Count - 1 : -1;
                case FilePackageEntry f: return Add(f) ? Count - 1 : -1;
                default: throw new ArgumentException();
            }
        }
        private void AddEvent(FilePackageEntry entry)
        {
            if (entry.IsLocked) Engine.File.AddRootPackageWithPassword(entry.FilePath, entry.PassWord);
            else Engine.File.AddRootPackage(entry.FilePath);
        }
        /// <summary>
        /// 格納されているすべての要素を削除する
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++) _array[i] = default;
            Count = 0;
            version++;
            Engine.File.ClearRootDirectories();
            Engine.File.AddRootPackage("DefaultResource.pack");
        }
        /// <summary>
        /// 指定したファイルパスを持つパスワード無しの要素が存在するかどうかを返す
        /// </summary>
        /// <param name="path">検索するパスワード無しの要素のファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>存在していたらtrue，それ以外でfalse</returns>
        public bool Contains(string path) => IndexOf(path) != -1;
        /// <summary>
        /// 指定したファイルパスとパスワードを持つ要素が存在するかどうかを返す
        /// </summary>
        /// <param name="path">検索する要素のファイルパス</param>
        /// <param name="passWord">検索する要素のパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="passWord"/>がnull</exception>
        /// <returns>存在していたらtrue，それ以外でfalse</returns>
        public bool Contains(string path, string passWord) => IndexOf(path, passWord) != -1;
        private bool Contains(FilePackageEntry entry) => entry.IsLocked ? Contains(entry.FilePath, entry.PassWord) : Contains(entry.FilePath);
        bool ICollection<FilePackageEntry>.Contains(FilePackageEntry item) => Contains(item);
        bool IList.Contains(object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case string path: return Contains(path);
                case FilePackageEntry f: return Contains(f);
                default: throw new ArgumentException();
            }
        }
        private void CopyTo(FilePackageEntry[] array, int arrayIndex)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(arrayIndex, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentException(array.Length < Count + arrayIndex, null);
            for (int i = 0; i < Count; i++) array[arrayIndex++] = _array[i];
        }
        void ICollection.CopyTo(Array array, int index)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, array);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, int.MaxValue, null);
            Central.ThrowHelper.ThrowExceptionWithMessage(new RankException(), array.Rank != 1, null);
            Central.ThrowHelper.ThrowArgumentException(array.Length < Count + index || array.GetLowerBound(0) != 0, null);
            switch (array)
            {
                case FilePackageEntry[] f: CopyTo(f, index); break;
                case object[] o:
                    try
                    {
                        for (int i = 0; i < Count; i++) o[index++] = _array[i];
                    }
                    catch (ArrayTypeMismatchException)
                    {
                        throw new ArgumentException();
                    }
                    break;
                default: throw new ArgumentException();
            }
        }
        void ICollection<FilePackageEntry>.CopyTo(FilePackageEntry[] array, int arrayIndex) => CopyTo(array, arrayIndex);
        /// <summary>
        /// 列挙をサポートする構造体を返す
        /// </summary>
        /// <returns><see cref="Enumerator"/>の新しいインスタンス</returns>
        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<FilePackageEntry> IEnumerable<FilePackageEntry>.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// コレクションの要素の文字列情報を返す
        /// </summary>
        /// <returns>コレクションの要素の文字列情報</returns>
        public string[] GetNames()
        {
            var array = new string[Count];
            for (int i = 0; i < Count; i++) array[i] = _array[i].FilePath + (_array[i].IsLocked ? "(Locked)" : "");
            return array;
        }
        /// <summary>
        /// 指定したファイルパスをもつパスワード無し要素のインデックスを返す
        /// </summary>
        /// <param name="path">検索するパスワード無し要素のファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>見つかったらそのインデックス，それ以外で-1</returns>
        public int IndexOf(string path)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, values: path);
            for (int i = 0; i < Count; i++)
                if (!_array[i].IsLocked && _array[i].FilePath == path)
                    return i;
            return -1;
        }
        /// <summary>
        /// 指定したファイルパスとパスワードを持つ要素のインデックスを返す
        /// </summary>
        /// <param name="path">検索する要素のファイルパス</param>
        /// <param name="passWord">検索する要素のパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="passWord"/>がnull</exception>
        /// <returns>インデックスがあったらその値，それ以外で-1</returns>
        public int IndexOf(string path, string passWord)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, path, passWord);
            for (int i = 0; i < Count; i++)
                if (_array[i].IsLocked && _array[i].FilePath == path && _array[i].PassWord == passWord)
                    return i;
            return -1;
        }
        private int IndexOf(FilePackageEntry entry)
        {
            for (int i = 0; i < Count; i++)
                if (_array[i] == entry)
                    return i;
            return -1;
        }
        int IList.IndexOf(object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case string path: return IndexOf(path);
                case FilePackageEntry f: return IndexOf(f);
                default: throw new ArgumentException();
            }
        }
        int IList<FilePackageEntry>.IndexOf(FilePackageEntry item) => IndexOf(item);
        /// <summary>
        /// 指定した位置にパスワード無しの要素を挿入する
        /// </summary>
        /// <param name="index">挿入位置</param>
        /// <param name="path">挿入されるパスワード無しの要素のファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0以上<see cref="Count"/>より大きい</exception>
        /// <returns>挿入出来たらtrue，それ以外でfalse</returns>
        public bool Insert(int index, string path)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count, null);
            Central.ThrowHelper.ThrowArgumentNullException(null, values: path);
            if (!Engine.File.Exists(path) || Contains(path)) return false;
            try
            {
                AddEvent(new FilePackageEntry(path));
            }
            catch
            {
                return false;
            }
            if (Capacity < Count + 1) ReSize(Count + 1);
            if (index < Count) Array.Copy(_array, index, _array, index + 1, Count - index);
            _array[index] = new FilePackageEntry(path);
            Count++;
            version++;
            return true;
        }
        /// <summary>
        /// 指定した位置にパスワード有りの要素を挿入する
        /// </summary>
        /// <param name="index">挿入位置</param>
        /// <param name="path">挿入される要素のファイルパス</param>
        /// <param name="passWord">挿入される要素のパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="passWord"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/>が0以上<see cref="Count"/>より大きい</exception>
        /// <returns>挿入出来たらtrue，それ以外でfalse</returns>
        public bool Insert(int index, string path, string passWord)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count, null);
            Central.ThrowHelper.ThrowArgumentNullException(null, path, passWord);
            if (!Engine.File.Exists(path) || Contains(path, passWord)) return false;
            try
            {
                AddEvent(new FilePackageEntry(path, passWord));
            }
            catch
            {
                return false;
            }
            if (Capacity < Count + 1) ReSize(Count + 1);
            if (index < Count) Array.Copy(_array, index, _array, index + 1, Count - index);
            _array[index] = new FilePackageEntry(path, passWord);
            Count++;
            version++;
            return true;
        }
        private bool Insert(int index, FilePackageEntry entry) => entry.IsLocked ? Insert(index, entry.FilePath, entry.PassWord) : Insert(index, entry.FilePath);
        void IList.Insert(int index, object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case string path: Insert(index, path); return;
                case FilePackageEntry f: Insert(index, f); return;
                default: throw new ArgumentException();
            }
        }
        void IList<FilePackageEntry>.Insert(int index, FilePackageEntry item) => Insert(index, item);
        /// <summary>
        /// 指定したファイルパスを持つパスワード無しの要素を削除する
        /// </summary>
        /// <param name="path">削除するパスワード無しの要素のファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(string path)
        {
            var index = IndexOf(path);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        /// <summary>
        /// 指定したファイルパスとパスワードを持つ要素を削除する
        /// </summary>
        /// <param name="path">削除する要素のファイルパス</param>
        /// <param name="passWord">削除する要素のパスワード</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>削除出来たらtrue，それ以外でfalse</returns>
        public bool Remove(string path, string passWord)
        {
            var index = IndexOf(path, passWord);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        private bool Remove(FilePackageEntry entry) => entry.IsLocked ? Remove(entry.FilePath, entry.PassWord) : Remove(entry.FilePath);
        bool ICollection<FilePackageEntry>.Remove(FilePackageEntry item) => Remove(item);
        void IList.Remove(object value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException();
                case string path: Remove(path); return;
                case FilePackageEntry f: Remove(f); return;
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
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(index, 0, Count - 1, null);
            if (index < Count - 1) Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            _array[Count - 1] = default;
            Count--;
            version++;
            RemoveEvent();
        }
        private void RemoveEvent()
        {
            Engine.File.ClearRootDirectories();
            Engine.File.AddRootPackage("DefaultResource.pack");
            for (int i = 0; i < Count; i++) AddEvent(_array[i]);
        }
        private void ReSize(int min)
        {
            if (Capacity >= min) return;
            var size = Capacity == 0 ? 4 : Capacity + 4;
            if ((uint)size > int.MaxValue) size = int.MaxValue;
            if (size < min) size = min;
            var array = new FilePackageEntry[size];
            for (int i = 0; i < Count; i++) array[i] = _array[i];
            _array = array;
        }
        /// <summary>
        /// 列挙をサポートする構造体
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<FilePackageEntry>
        {
            private readonly FilePackageCollection collection;
            private int index;
            private readonly int version;
            /// <summary>
            /// 現在列挙されている要素を取得する
            /// </summary>
            public FilePackageEntry Current { get; private set; }
            object IEnumerator.Current
            {
                get
                {
                    if (index < 0 || collection.Count < index) throw new InvalidOperationException();
                    return Current;
                }
            }
            internal Enumerator(FilePackageCollection collection)
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
    }
}
