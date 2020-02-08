using System;
using System.Runtime.Serialization;
using System.Text;

namespace UIGenerator
{
    /// <summary>
    /// 文字エンコードのオプションのクラス。
    /// </summary>
    [Serializable]
    public class EncodeOption : ICloneable, ISerializable
    {
        #region SerializeName
        private const string s_type = "Type";
        private const string s_encoding = "Encoding";
        private const string s_enum = "Enum_Type";
        #endregion
        /// <summary>
        /// <see cref="EncodingType.UTF8"/>による<see cref="EncodeOption"/>を取得する。
        /// </summary>
        public static EncodeOption Default => _default ?? (_default = new EncodeOption(EncodingType.Default));
        private static EncodeOption _default;
        /// <summary>
        /// エンコードクラスを取得する。
        /// </summary>
        public Encoding Encoding { get; }
        /// <summary>
        /// バイトシーケンスを文字に変換するデコーダーを取得する
        /// </summary>
        public Decoder Decoder => _decoder ??= Encoding.GetDecoder();
        private Decoder _decoder;
        /// <summary>
        /// 文字のエンコーダーを取得する
        /// </summary>
        public Encoder Encoder => _encoder ??= Encoding.GetEncoder();
        private Encoder _encoder;
        private readonly string type;
        private readonly EncodingType? eType = null;
        /// <summary>
        /// コンストラクタ
        /// <see cref="EncodingType.Default"/>として実行
        /// </summary>
        public EncodeOption() : this(EncodingType.Default) { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">指定するエンコードの名前</param>
        /// <exception cref="ArgumentException">指定したエンコード名が見つからなかった</exception>
        public EncodeOption(string name)
        {
            Encoding = Encoding.GetEncoding(name);
            type = name;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="type">エンコードのタイプ</param>
        public EncodeOption(EncodingType type)
        {
            Encoding = GetEncodingType(type);
        }
        /// <summary>
        /// シリアル化したデータで<see cref="EncodeOption"/>のインスタンスを生成する。
        /// </summary>
        /// <param name="info"><see cref="EncodeOption"/>をシリアル化するために必要な情報を格納している<see cref="SerializationInfo"/>のインスタンス</param>
        /// <param name="context"><see cref="EncodeOption"/>に関連付けられているシリアル化ストリームの送信元及び送信先を格納している<see cref="StreamingContext"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        protected EncodeOption(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            type = (string)info.GetValue(s_type, typeof(string));
            Encoding = (Encoding)info.GetValue(s_encoding, typeof(Encoding));
            eType = (EncodingType?)info.GetValue(s_enum, typeof(EncodingType?));
        }
        /// <summary>
        /// このインスタンスのコピーである新しいオブジェクトを生成する。
        /// </summary>
        public virtual object Clone() => eType.HasValue ? new EncodeOption(eType.Value) : new EncodeOption(type);
        /// <summary>
        /// <see cref="EncodeOption"/>をシリアル化するため必要なデータを返す<see cref="ISerializable"/>の実装。
        /// </summary>
        /// <param name="info"><see cref="EncodeOption"/>の情報を格納するための<see cref="SerializationInfo"/>のインスタンス</param>
        /// <param name="context"><see cref="EncodeOption"/>に関連付けられているシリアル化ストリームの転送元及び転送先を格納する<see cref="StreamingContext"/>構造体</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException();
            info.AddValue(s_type, type);
            info.AddValue(s_encoding, Encoding);
            info.AddValue(s_enum, eType);
        }
        public override string ToString() => "fslib.EncodeOption\n" + "Type:" + type;
        private static Encoding GetEncodingType(EncodingType encoding) => encoding switch
        {
            EncodingType.Default => Encoding.Default,
            EncodingType.ASCII => new ASCIIEncoding(),
            EncodingType.UTF7 => Encoding.UTF7,
            EncodingType.UTF8 => new UTF8Encoding(false),
            EncodingType.UTF8WithBOM => new UTF8Encoding(true),
            EncodingType.UTF16LE => new UnicodeEncoding(false, false),
            EncodingType.UTF16LEWithBOM => new UnicodeEncoding(false, true),
            EncodingType.UTF16BE => new UnicodeEncoding(true, false),
            EncodingType.UTF16BEWithBOM => new UnicodeEncoding(true, true),
            EncodingType.UTF32LE => new UTF32Encoding(false, false),
            EncodingType.UTF32LEWithBOM => new UTF32Encoding(true, true),
            EncodingType.UTF32BE => new UTF32Encoding(true, false),
            EncodingType.UTF32BEWithBOM => new UTF32Encoding(true, true),
            _ => encoding.IsDefined() ? Encoding.GetEncoding((int)encoding) : throw new ArgumentException(),
        };
    }
}