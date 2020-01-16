using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using asd;
using fslib;
using fslib.Collections;
using fslib.Exception;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="DrawingAdditionaryInfoBase"/>を管理するコレクション
    /// </summary>
    [Serializable]
    public sealed class DrawingAdditionaryInfoCollection : UICollectionBase<DrawingAdditionaryInfoBase>
    {
        /// <summary>
        /// 既定の容量を備えた空の<see cref="DrawingAdditionaryInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        public DrawingAdditionaryInfoCollection() : base() { }
        /// <summary>
        /// 指定した容量を持つ空の<see cref="DrawingAdditionaryInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="capacity">設定する容量</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/>が0未満</exception>
        public DrawingAdditionaryInfoCollection(int capacity) : base(capacity) { }
        /// <summary>
        /// 指定したコレクションの要素をコピーした<see cref="DrawingAdditionaryInfoCollection"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="collection">コピーする要素を格納するコレクション</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        /// <exception cref="KeyDuplicateException"><paramref name="collection"/>内のキーに重複がある</exception>
        public DrawingAdditionaryInfoCollection(IEnumerable<DrawingAdditionaryInfoBase> collection) : base(collection) { }
        private DrawingAdditionaryInfoCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// 指定したモードと名前のペアが格納されているかどうかを返す
        /// </summary>
        /// <param name="mode">検索する表示モード</param>
        /// <param name="name">検索する名前</param>
        /// <returns><paramref name="mode"/>と<paramref name="name"/>を持つ値が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(int mode, string name) => IndexOf(mode, name) != -1;
        /// <summary>
        /// 指定した追加描画の情報が格納されているかどうかを返す
        /// </summary>
        /// <param name="info">検索する追加描画の情報</param>
        /// <returns><paramref name="info"/>が格納されていたらtrue，それ以外でfalse</returns>
        public bool Contains(DrawingAdditionaryInfoBase info) => IndexOf(info) != -1;
        /// <summary>
        /// 2つの値の同一性を判定する
        /// </summary>
        /// <param name="t1">同一性を判定する値</param>
        /// <param name="t2">同一性を判定するもう一つの<値</param>
        /// <returns><paramref name="t1"/>と<paramref name="t2"/>が同じならばtrue，それ以外でfalse</returns>
        protected override bool Equals(DrawingAdditionaryInfoBase t1, DrawingAdditionaryInfoBase t2) => t1 == t2;
        /// <summary>
        /// 全ての描画を実行する
        /// </summary>
        /// <param name="layer">描画を行うレイヤー</param>
        /// <exception cref="ArgumentNullException"><paramref name="layer"/>がnull</exception>
        public void OperateAll(Layer2D layer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, layer);
            for (int i = 0; i < Count; i++)
                if (InnerArray[i].Key1 == DataBase.ShowMode)
                    InnerArray[i].Value.Operate(layer);
        }
    }
}
