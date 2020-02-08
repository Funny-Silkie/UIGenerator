using System;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawCircleAdditionally(Vector2DF, float, float, Color, int, float, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingCircleInfo : DrawingAdditionaryInfoBase, ISerializable ,IDeserializationCallback
    {
        #region SerializeName
        private const string S_Center = "S_Center";
        private const string S_OuterD = "S_OuterD";
        private const string S_InnerD = "S_InnerD";
        private const string S_Color = "S_Color";
        private const string S_VertNum = "S_VertNum";
        private const string S_Angle = "S_Angle";
        private const string S_TextureIndex = "S_TextureIndex";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public override DrawingAdditionalMode DrawingAdditionalMode => DrawingAdditionalMode.Circle;
        /// <summary>
        /// 中心の座標を取得または設定する
        /// </summary>
        public SerializableVector2DF Center { get; set; } = DataBase.CenterPosition;
        /// <summary>
        /// 外側の半径を取得または設定する
        /// </summary>
        public float OuterDiameter { get; set; } = 60;
        /// <summary>
        /// 内側の半径を取得または設定する
        /// </summary>
        public float InnerDiameter { get; set; } = 15;
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; } = new ColorPlus(ColorSet.White);
        public int VertNum { get; set; } = 30;
        /// <summary>
        /// 描画角度を取得または設定する
        /// </summary>
        public float Angle { get; set; }
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
        public DrawingCircleInfo(int mode, string name) : base(mode, name) { }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private DrawingCircleInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected override void GetObjectData(SerializationInfo info)
        {
            base.GetObjectData(info);
            info.AddValue(S_Angle, Angle);
            info.AddValue(S_Center, Center);
            info.AddValue(S_Color, Color);
            info.AddValue(S_InnerD, InnerDiameter);
            info.AddValue(S_OuterD, OuterDiameter);
            info.AddValue(S_VertNum, VertNum);
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
            Angle = SeInfo.GetSingle(S_Angle);
            Center = SeInfo.GetValue<SerializableVector2DF>(S_Center);
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            VertNum = SeInfo.GetInt32(S_VertNum);
            InnerDiameter = SeInfo.GetSingle(S_InnerD);
            OuterDiameter = SeInfo.GetSingle(S_OuterD);
            base.OnDeserialization();
        }
    }
}
