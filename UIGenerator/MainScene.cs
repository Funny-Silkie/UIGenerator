using System;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// UIオブジェクトを表示するためのシーン
    /// </summary>
    public sealed class MainScene : Scene
    {
        /// <summary>
        /// UIオブジェクトを表示するレイヤーを取得する
        /// </summary>
        public Layer2DPlus MainLayer { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainScene()
        {
            MainLayer = new Layer2DPlus();
        }
        protected override void OnRegistered()
        {
            AddLayer(MainLayer);
        }
        protected override void OnUpdated()
        {
            DataBase.DrawingCollection.OperateAll(MainLayer);
        }
        /// <summary>
        /// 表示するアイテムを変更する
        /// </summary>
        /// <param name="mode"></param>
        public void ChangeMode(int mode)
        {
            foreach (var o in DataBase.UIInfos)
            {
                if (o.Key1 == DataBase.ShowMode) RemoveObject(o.Value);
                if (o.Key1 == mode) AddObject(o.Value);
            }
            DataBase.ShowMode = mode;
        }
        /// <summary>
        /// 表示する要素を追加する
        /// </summary>
        /// <param name="info">表示する<see cref="UIInfoBase"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            if (info.UIObj.Layer == null) Engine.AddObject2D(info.UIObj);
        }
        /// <summary>
        /// 表示する要素を削除する
        /// </summary>
        /// <param name="info">表示をやめる<see cref="UIInfoBase"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public void RemoveObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            if (info.UIObj.Layer != null) Engine.RemoveObject2D(info.UIObj);
        }
    }
}
