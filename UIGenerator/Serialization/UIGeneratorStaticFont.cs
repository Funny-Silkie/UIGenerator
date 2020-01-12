using System;
using System.IO;
using System.Runtime.Serialization;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// シリアライズ可能な静的なフォントを扱うクラス
    /// </summary>
    [Serializable]
    public sealed class UIGeneratorStaticFont : UIGeneratorFontBase
    {
        /// <summary>
        /// 指定したファイルパスからフォントを読み込みインスタンスを初期化する
        /// </summary>
        /// <param name="path">使用するファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが存在しない</exception>
        /// <exception cref="IOException">フォントを読み込めなかった</exception>
        public UIGeneratorStaticFont(string path) : base(path)
        {
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            Font = GetFont(path) ?? throw new IOException();
        }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private UIGeneratorStaticFont(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// 指定したパスからフォントを読み込む
        /// </summary>
        /// <param name="path">使用するパス</param>
        /// <returns>読み込まれたフォント</returns>
        protected override Font GetFont(string path) => Engine.Graphics.CreateFont(path);
    }
}
