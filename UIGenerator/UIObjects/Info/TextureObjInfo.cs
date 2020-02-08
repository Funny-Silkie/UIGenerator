using System;
using System.Runtime.Serialization;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="UITexture"/>を参照に持つ<see cref="UIInfo{T}"/>の実装
    /// 継承不可
    /// </summary>
    [Serializable]
    public sealed partial class TextureObjInfo : UIInfo<UITexture>, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_TextureIndex = "S_TextureIndex";
        #endregion
        /// <summary>
        /// オブジェクトのタイプを取得する
        /// </summary>
        public override UITypes Type => UITypes.Texture;
        /// <summary>
        /// クリック可能かどうかを取得または設定する
        /// </summary>
        public bool IsClickable
        {
            get => UIObject.IsClickable;
            set => UIObject.IsClickable = value;
        }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public Color Color
        {
            get => UIObject.Color;
            set => UIObject.Color = value;
        }
        /// <summary>
        /// 座標を取得または設定する
        /// </summary>
        public Vector2DF Position
        {
            get => UIObject.Position;
            set => UIObject.Position = value;
        }
        /// <summary>
        /// 中心座標を取得または設定する
        /// </summary>
        public Vector2DF CenterPosition
        {
            get => UIObject.CenterPosition;
            set => UIObject.CenterPosition = value;
        }
        /// <summary>
        /// 大きさを取得または設定する
        /// </summary>
        public Vector2DF Size
        {
            get => UIObject.Size;
            set => UIObject.Size = value;
        }
        /// <summary>
        /// 使用するテクスチャの情報を格納するインスタンスを取得または設定する
        /// </summary>
        public TextureInfo TextureInfo
        {
            get => _textureInfo;
            set
            {
                if (value == null) value = DataBase.DefaultTexture;
                _textureInfo = value;
                UIObject.Texture = value.Texture;
            }
        }
        private TextureInfo _textureInfo = DataBase.DefaultTexture;
        /// <summary>
        /// 描画優先度を取得または設定する
        /// </summary>
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public TextureObjInfo(int mode, string name) : base(UITypes.Texture, mode, name)
        {

        }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private TextureObjInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            var textureIndex = DataBase.Textures.IndexOf(TextureInfo);
            if (textureIndex == -1) textureIndex = 0;
            info.AddValue(S_TextureIndex, textureIndex);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected override void OnDeserialization()
        {
            if (SeInfo == null) return;
            var index = SeInfo.GetInt32(S_TextureIndex);
            base.OnDeserialization();
            TextureInfo = DataBase.Textures[index];
        }
    }
}
