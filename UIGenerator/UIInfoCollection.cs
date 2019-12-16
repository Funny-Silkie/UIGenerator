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
