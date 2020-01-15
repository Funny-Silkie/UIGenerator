﻿using System;
using System.Runtime.Serialization;
using fslib.Collections;

namespace UIGenerator
{
    /// <summary>
    /// UIに関する情報を格納するコレクションのクラス
    /// </summary>
    [Serializable]
    public sealed class UIInfoCollection : UICollectionBase<UIInfoBase>
    {
        /// <summary>
        /// 既定の容量を備えた空の<see cref="UIInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        public UIInfoCollection() : base() { }
        /// <summary>
        /// 指定した容量を備えた空の<see cref="UIInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        /// <param name="capacity">設定する容量</param>
        public UIInfoCollection(int capacity) : base(capacity) { }
        private UIInfoCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// 指定された表示モードと名前の組み合わせが存在するかどうかを返す
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <returns>含まれていたらtrue，それ以外でfalse</returns>
        public bool Contains(int mode, string name) => IndexOf(mode, name) != -1;
        /// <summary>
        /// 2つの値の同一性を判定する
        /// </summary>
        /// <param name="t1">同一性を判定する値</param>
        /// <param name="t2">同一性を判定するもう一つの<値</param>
        /// <returns><paramref name="t1"/>と<paramref name="t2"/>が同じならばtrue，それ以外でfalse</returns>
        protected override bool Equals(UIInfoBase t1, UIInfoBase t2) => t1 == t2;
        /// <summary>
        /// このインスタンスの要素を格納する<see cref="DoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンスを返す
        /// </summary>
        /// <returns>要素がコピーされた<see cref="DoubleKeyDictionary{TKey1, TKey2, TValue}"/>のインスタンス</returns>
        public DoubleKeyDictionary<int, string, UIInfoBase> ToDoubleKeyDictionary()
        {
            var dic = new DoubleKeyDictionary<int, string, UIInfoBase>(Count);
            for (int i = 0; i < Count; i++) dic.Add(InnerArray[i].Key1, InnerArray[i].Key2, InnerArray[i].Value);
            return dic;
        }
    }
}
