using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// 追加描画を扱うクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class DrawingAdditionaryInfoBase : IUIGeneratorInfo
    {
        [NonSerialized]
        private System.Windows.Forms.Form _handleForm = null;
        /// <summary>
        /// このインスタンスを操作するフォームを取得または設定する
        /// </summary>
        public System.Windows.Forms.Form HandleForm { get => _handleForm; set => _handleForm = value; }
        /// <summary>
        /// 表示モードを取得または設定する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満</exception>
        public int Mode
        {
            get => _mode;
            set => _mode = value >= 0 ? value : throw new ArgumentOutOfRangeException();
        }
        private int _mode;
        /// <summary>
        /// 名前を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public string Name
        {
            get => _name; 
            set => _name = value ?? throw new ArgumentNullException();
        }
        private string _name;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        protected DrawingAdditionaryInfoBase(int mode, string name)
        {
            Mode = mode >= 0 ? mode : throw new ArgumentOutOfRangeException();
            Name = name ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public abstract string ToCSharp();
    }
    /// <summary>
    /// <see cref="Layer2D.DrawArcAdditionally(Vector2DF, float, float, Color, int, int, int, float, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed class DrawingArcInfo : DrawingAdditionaryInfoBase
    {

    }
}
