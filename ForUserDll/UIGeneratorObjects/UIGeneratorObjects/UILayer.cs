using System;
using System.Linq;
using asd;
using fslib;
using fslib.Collections;

namespace UIGeneratorObjects
{
    /// <summary>
    /// UIGeneratorで生成したオブジェクトを表示するレイヤー
    /// </summary>
    public class UILayer : Layer2DPlus
    {
        private readonly UIInfoCollection infos = new UIInfoCollection();
        /// <summary>
        /// 現在表示しているオブジェクトのモードを取得する
        /// </summary>
        public int Mode { get; private set; }
        /// <summary>
        /// UIのオブジェクトを追加する
        /// </summary>
        /// <param name="ui">追加するUIのオブジェクト</param>
        /// <exception cref="ArgumentException"><paramref name="ui"/>が既に登録されているまたは何かのレイヤーに所属している</exception>
        /// <exception cref="ArgumentNullException"><paramref name="ui"/>がnull</exception>
        public void AddUIObject<T>(T ui) where T : Object2D, IUIElements
        {
            if (ui == null) throw new ArgumentNullException("追加しようとしたインスタンスがnullです", nameof(ui));
            if (ui.Layer != null || infos.Contains(ui)) throw new ArgumentException();
            if (ui.Mode == Mode) AddObject(ui);
            infos.Add(ui);
        }
        /// <summary>
        /// 表示モードを変更する
        /// </summary>
        /// <param name="mode">変更先の値</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public void ChangeMode(int mode)
        {
            if (mode < 0) throw new ArgumentOutOfRangeException("設定する値が0未満です", nameof(mode));
            if (Mode == mode) return;
            foreach (var o in infos)
            {
                var obj = o.Value.AsObject2D();
                if (o.Key1 == Mode && obj.Layer == this) RemoveObject(obj);
                else if (o.Key1 == mode && obj.Layer == null) AddObject(obj);
            }
            Mode = mode;
        }
        /// <summary>
        /// UIオブジェクトが登録されているかどうかを検索する
        /// </summary>
        /// <param name="ui">検索するUIオブジェクト</param>
        /// <returns><paramref name="ui"/>が登録されていたらtrue，それ以外でfalse</returns>
        public bool ContainsUIObject<T>(T ui) where T : Object2D, IUIElements => ui == null ? false : infos.Contains(ui);
        /// <summary>
        /// UIのオブジェクトを削除する
        /// </summary>
        /// <param name="ui">削除するUIのオブジェクト</param>
        /// <exception cref="ArgumentException"><paramref name="ui"/>が登録されていない</exception>
        /// <exception cref="ArgumentNullException"><paramref name="ui"/>がnull</exception>
        public void RemoveUIObject<T>(T ui) where T : Object2D, IUIElements
        {
            if (ui == null) throw new ArgumentNullException();
            if (!infos.Contains(ui) || !Objects.Contains(ui)) throw new ArgumentException();
            if(ui.Layer == this) RemoveObject(ui);
            infos.Remove(ui);
        }
    }
}
