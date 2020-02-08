﻿using System;
using System.Runtime.Serialization;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="Layer2D.DrawRotatedRectangleAdditionally(RectF, Color, Vector2DF, float, RectF, Texture2D, AlphaBlendMode, int)"/>の実装を仲介するクラス
    /// </summary>
    [Serializable]
    public sealed partial class DrawingRotatedRectangleInfo : DrawingAdditionaryInfoBase, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Angle = "S_Angle";
        private const string S_Center = "S_Center";
        private const string S_Color = "S_Color";
        private const string S_DrawingArea = "S_DrawingArea";
        private const string S_TextureIndex = "S_TextureIndex";
        private const string S_UV = "S_UV";
        #endregion
        /// <summary>
        /// 追加描画のタイプを取得する
        /// </summary>
        public override DrawingAdditionalMode DrawingAdditionalMode => DrawingAdditionalMode.RotatedRectangle;
        /// <summary>
        /// 描画エリアを取得または設定する
        /// </summary>
        public SerializableRectF DrawingArea { get; set; } = new SerializableRectF(DataBase.CenterPosition, new Vector2DF(100, 100));
        /// <summary>
        /// 色を取得または設定する
        /// </summary>
        public ColorPlus Color { get; set; } = new ColorPlus(ColorSet.White);
        public SerializableRectF UV { get; set; }
        public SerializableVector2DF RotationCenter { get; set; } = new Vector2DF(50, 50);
        /// <summary>
        /// 回転角度を取得または設定する
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
        public DrawingRotatedRectangleInfo(int mode, string name) : base(mode, name) { }
        /// <summary>
        /// シリアライズするデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアル化するデータを持つオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        private DrawingRotatedRectangleInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// シリアル化するデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected override void GetObjectData(SerializationInfo info)
        {
            base.GetObjectData(info);
            info.AddValue(S_Angle, Angle);
            info.AddValue(S_Center, RotationCenter);
            info.AddValue(S_Color, Color);
            info.AddValue(S_DrawingArea, DrawingArea);
            info.AddValue(S_UV, UV);
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
            DrawingArea = SeInfo.GetValue<SerializableRectF>(S_DrawingArea);
            UV = SeInfo.GetValue<SerializableRectF>(S_UV);
            Angle = SeInfo.GetSingle(S_Angle);
            RotationCenter = SeInfo.GetValue<SerializableVector2DF>(S_Center);
            Color = SeInfo.GetValue<ColorPlus>(S_Color);
            base.OnDeserialization();
        }
    }
}
