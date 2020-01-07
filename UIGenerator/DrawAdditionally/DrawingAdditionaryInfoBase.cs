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
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public DrawingAdditionalMode DrawingAdditionalMode { get; }
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
        /// 使用するアルファブレンドの設定を取得または設定する
        /// </summary>
        public AlphaBlendMode AlphaBlend { get; set; }
        /// <summary>
        /// 描画優先度を取得または設定する
        /// </summary>
        public int DrawingPriority { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <param name="drawingAdditionalMode">追加描画のモード</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        protected DrawingAdditionaryInfoBase(int mode, string name, DrawingAdditionalMode drawingAdditionalMode)
        {
            Mode = mode >= 0 ? mode : throw new ArgumentOutOfRangeException();
            Name = name ?? throw new ArgumentNullException();
            DrawingAdditionalMode = drawingAdditionalMode;
        }
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public abstract string ToCSharp();
    }
}
