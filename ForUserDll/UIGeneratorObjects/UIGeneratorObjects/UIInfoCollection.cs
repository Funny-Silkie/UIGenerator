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
    internal sealed class UIInfoCollection<T> : IDoubleKeyDictionary<int, string, T>, IReadOnlyDoubleKeyDictionary<int, string, T>, IDictionary where T : Object2D, IUIElements
    {
        private DoubleKeyValuePair<int, string, T>[] _array;
        private readonly static DoubleKeyValuePair<int, string, T>[] emptyArray = new DoubleKeyValuePair<int, string, T>[0];
        private int version;
        public int Count { get; private set; }
        bool IDictionary.IsFixedSize => false;
        bool ICollection<DoubleKeyValuePair<int, string, T>>.IsReadOnly => true;
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null) Interlocked.CompareExchange(_syncRoot, new object(), null);
                return _syncRoot;
            }
        }
        private object _syncRoot;
    }
}
