using System;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawTriangleAdditionally(Vector2DF, Vector2DF, Vector2DF, Color, Vector2DF, Vector2DF, Vector2DF, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingTriangleInfo : DrawingAdditionaryInfoBase, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Color = "S_Color";
        private const string S_Pos1 = "S_Pos1";
        private const string S_Pos2 = "S_Pos2";
        private const string S_Pos3 = "S_Pos3";
        private const string S_UV1 = "S_UV1";
        private const string S_UV2 = "S_UV2";
        private const string S_UV3 = "S_UV3";
        private const string S_TextureIndex = "S_TextureIndex";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public override DrawingAdditionalMode DrawingAdditionalMode => DrawingAdditionalMode.Triangle;
        /// <summary>
        /// 頂点の座標の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Position1 { get; set; } = DataBase.CenterPosition - new Vector2DF(0, 25);
        /// <summary>
        /// 頂点の座標の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Position2 { get; set; } = DataBase.CenterPosition - new Vector2DF(25, 0);
        /// <summary>
        /// 頂点の座標の一つを取得または設定する
        /// </summary>
        public SerializableVector2DF Position3 { get; set; } = DataBase.CenterPosition + new Vector2DF(25, 0);
        /// <summary>
        /// <see cref="Position1"/>のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UV1 { get; set; }
        /// <summary>
        /// <see cref="Position2"/>のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UV2 { get; set; }
        /// <summary>
        /// <see cref="Position3"/>のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UV3 { get; set; }
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; } = new ColorPlus(ColorSet.White);
        /// <summary>
        /// 使用するテクスチャの情報を取得または設定する
        /// </summary>
        public TextureInfo Texture
        {
            get => _texture;
            set => _texture = value ?? DataBase.DefaultTexture;
        }
        private TextureInfo _texture = DataBase.DefaultTexture;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">表示モード</param>
        /// <param name="name">設定する名前</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="mode"/>が0未満</exception>
        public DrawingTriangleInfo(int mode, string name) : base(mode, name) { }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private DrawingTriangleInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected override void GetObjectData(SerializationInfo info)
        {
            base.GetObjectData(info);
            info.AddValue(S_Color, Color);
            info.AddValue(S_Pos1, Position1);
            info.AddValue(S_Pos2, Position2);
            info.AddValue(S_Pos3, Position3);
            info.AddValue(S_UV1, UV1);
            info.AddValue(S_UV2, UV2);
            info.AddValue(S_UV3, UV3);
            var textureindex = DataBase.Textures.IndexOf(Texture);
            if (textureindex == -1) textureindex = 0;
            info.AddValue(S_TextureIndex, textureindex);
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected override void OnDeserialization()
        {
            if (SeInfo == null) return;
            Texture = DataBase.Textures[SeInfo.GetInt32(S_TextureIndex)];
            Position1 = SeInfo.GetValue<SerializableVector2DF>(S_Pos1);
            Position2 = SeInfo.GetValue<SerializableVector2DF>(S_Pos2);
            Position3 = SeInfo.GetValue<SerializableVector2DF>(S_Pos3);
            UV1 = SeInfo.GetValue<SerializableVector2DF>(S_UV1);
            UV2 = SeInfo.GetValue<SerializableVector2DF>(S_UV2);
            UV3 = SeInfo.GetValue<SerializableVector2DF>(S_UV3);
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            base.OnDeserialization();
        }
    }
}
