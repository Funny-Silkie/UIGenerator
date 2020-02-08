using System;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawSpriteAdditionally(Vector2DF, Vector2DF, Vector2DF, Vector2DF, Color, Color, Color, Color, Vector2DF, Vector2DF, Vector2DF, Vector2DF, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingSpriteInfo : DrawingAdditionaryInfoBase, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Pos1 = "S_Pos1";
        private const string S_Pos2 = "S_Pos2";
        private const string S_Pos3 = "S_Pos3";
        private const string S_Pos4 = "S_Pos4";
        private const string S_Col1 = "S_Col1";
        private const string S_Col2 = "S_Col2";
        private const string S_Col3 = "S_Col3";
        private const string S_Col4 = "S_Col4";
        private const string S_UV1 = "S_UV1";
        private const string S_UV2 = "S_UV2";
        private const string S_UV3 = "S_UV3";
        private const string S_UV4 = "S_UV4";
        private const string S_TextureIndex = "S_TextureIndex";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public override DrawingAdditionalMode DrawingAdditionalMode => DrawingAdditionalMode.Sprite;
        /// <summary>
        /// 左上の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperLeftPos { get; set; } = DataBase.CenterPosition - new Vector2DF(25, 25);
        /// <summary>
        /// 右上の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperRightPos { get; set; } = DataBase.CenterPosition + new Vector2DF(25, -25);
        /// <summary>
        /// 右下の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerRightPos { get; set; } = DataBase.CenterPosition + new Vector2DF(25, 25);
        /// <summary>
        /// 左下の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerLeftPos { get; set; } = DataBase.CenterPosition + new Vector2DF(-25, 25);
        /// <summary>
        /// 左上の色を取得または設定する
        /// </summary>
        public ColorPlus UpperLeftColor { get; set; } = new ColorPlus(ColorSet.White);
        /// <summary>
        /// 右上の色を取得または設定する
        /// </summary>
        public ColorPlus UpperRightColor { get; set; } = new ColorPlus(ColorSet.White);
        /// <summary>
        /// 右下の色を取得または設定する
        /// </summary>
        public ColorPlus LowerRightColor { get; set; } = new ColorPlus(ColorSet.White);
        /// <summary>
        /// 左下の色を取得または設定する
        /// </summary>
        public ColorPlus LowerLeftColor { get; set; } = new ColorPlus(ColorSet.White);
        /// <summary>
        /// 左上のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperLeftUV { get; set; }
        /// <summary>
        /// 右上のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF UpperRightUV { get; set; }
        /// <summary>
        /// 右下のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerRightUV { get; set; }
        /// <summary>
        /// 左下のUV値を取得または設定する
        /// </summary>
        public SerializableVector2DF LowerLeftUV { get; set; }
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
        public DrawingSpriteInfo(int mode, string name) : base(mode, name) { }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private DrawingSpriteInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected override void GetObjectData(SerializationInfo info)
        {
            base.GetObjectData(info);
            info.AddValue(S_Pos1, UpperLeftPos);
            info.AddValue(S_Pos2, UpperRightPos);
            info.AddValue(S_Pos3, LowerRightPos);
            info.AddValue(S_Pos4, LowerLeftPos);
            info.AddValue(S_Col1, UpperLeftColor);
            info.AddValue(S_Col2, UpperRightColor);
            info.AddValue(S_Col3, LowerRightColor);
            info.AddValue(S_Col4, LowerLeftColor);
            info.AddValue(S_UV1, UpperLeftUV);
            info.AddValue(S_UV2, UpperRightUV);
            info.AddValue(S_UV3, LowerRightUV);
            info.AddValue(S_UV4, LowerLeftUV);
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
            UpperLeftPos = SeInfo.GetValue<SerializableVector2DF>(S_Pos1);
            UpperRightPos = SeInfo.GetValue<SerializableVector2DF>(S_Pos2);
            LowerRightPos = SeInfo.GetValue<SerializableVector2DF>(S_Pos3);
            LowerLeftPos = SeInfo.GetValue<SerializableVector2DF>(S_Pos4);
            UpperLeftColor = SeInfo.GetValue<ColorPlus>(S_Col1);
            UpperRightColor = SeInfo.GetValue<ColorPlus>(S_Col2);
            LowerRightColor = SeInfo.GetValue<ColorPlus>(S_Col3);
            LowerLeftColor = SeInfo.GetValue<ColorPlus>(S_Col4);
            UpperLeftUV = SeInfo.GetValue<SerializableVector2DF>(S_UV1);
            UpperRightUV = SeInfo.GetValue<SerializableVector2DF>(S_UV2);
            LowerRightUV = SeInfo.GetValue<SerializableVector2DF>(S_UV3);
            LowerLeftUV = SeInfo.GetValue<SerializableVector2DF>(S_UV4);
            base.OnDeserialization();
        }
    }
}
