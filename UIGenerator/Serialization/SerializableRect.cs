using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="RectF"/>と互換性があるシリアライズ可能な構造体
    /// </summary>
    [Serializable]
    public readonly struct SerializableRectF : IEquatable<SerializableRectF>
    {
        /// <summary>
        /// 左上のX座標を取得する
        /// </summary>
        public float X { get; }
        /// <summary>
        /// 左上のY座標を取得する
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// 横幅を取得する
        /// </summary>
        public float Width { get; }
        /// <summary>
        /// 縦幅を取得する
        /// </summary>
        public float Height { get; }
        /// <summary>
        /// 左上の座標を取得する
        /// </summary>
        public Vector2DF Position => new Vector2DF(X, Y);
        /// <summary>
        /// 縦横の大きさを取得する
        /// </summary>
        public Vector2DF Size => new Vector2DF(Width, Height);
        /// <summary>
        /// 四隅の座標を左上，右上，右下，左下の順に配列として取得する。
        /// </summary>
        public Vector2DF[] Vertexes => new Vector2DF[] { new Vector2DF(X, Y), new Vector2DF(X + Width, Y), new Vector2DF(X + Width, Y + Height), new Vector2DF(X, Y + Width) };
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">左上のX座標</param>
        /// <param name="y">左上のY座標</param>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        public SerializableRectF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">左上の座標</param>
        /// <param name="size">縦横の大きさ</param>
        public SerializableRectF(SerializableVector2DF position, SerializableVector2DF size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">左上の座標</param>
        /// <param name="size">縦横の大きさ</param>
        public SerializableRectF(Vector2DF position, Vector2DF size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// 2つの<see cref="SerializableRectF"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="other">同値性を調べるもう一つの<see cref="SerializableRectF"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(SerializableRectF other) => (X == other.X) && (Y == other.Y) && (Width == other.Width) && (Height == other.Height);
        /// <summary>
        /// <see cref="SerializableRectF"/>と<see cref="RectF"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="serializable">同値性を調べる<see cref="SerializableRectF"/>のインスタンス</param>
        /// <param name="normal">同値性を調べるもう一つの<see cref="RectF"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableRectF serializable, RectF normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y) && (serializable.Width == normal.Width) && (serializable.Height == normal.Height);
        /// <summary>
        /// 2つの<see cref="SerializableRectF"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="rect1">同値性を調べる<see cref="SerializableRectF"/>のインスタンス</param>
        /// <param name="rect2">同値性を調べるもう一つの<see cref="SerializableRectF"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableRectF rect1, SerializableRectF rect2) => rect1.Equals(rect2);
        /// <summary>
        /// このインスタンスと指定したオブジェクトが等しいかどうか判定する
        /// </summary>
        /// <param name="obj">判定する<see cref="object"/>のインスタンス</param>
        /// <returns>等しかったらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is SerializableRectF r ? Equals(r) : false;
        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 466501756;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// このインスタンスと同じ値を持つ<see cref="SerializableRectI"/>を返す
        /// </summary>
        /// <returns>このインスタンスと同じ値を持つ<see cref="SerializableRectI"/>の新しいインスタンス</returns>
        public SerializableRectI ToI() => new SerializableRectI((int)X, (int)Y, (int)Width, (int)Height);
        public static implicit operator RectF(SerializableRectF r) => new RectF(r.X, r.Y, r.Width, r.Height);
        public static implicit operator SerializableRectF(RectF r) => new SerializableRectF(r.X, r.Y, r.Width, r.Height);
        public static explicit operator SerializableRectI(SerializableRectF f) => f.ToI();
        public static bool operator ==(SerializableRectF r1, SerializableRectF r2) => Equals(r1, r2);
        public static bool operator ==(SerializableRectF r1, RectF r2) => Equals(r1, r2);
        public static bool operator ==(RectF r1, SerializableRectF r2) => Equals(r2, r1);
        public static bool operator !=(SerializableRectF r1, SerializableRectF r2) => !Equals(r1, r2);
        public static bool operator !=(SerializableRectF r1, RectF r2) => !Equals(r1, r2);
        public static bool operator !=(RectF r1, SerializableRectF r2) => !Equals(r2, r1);
    }
    /// <summary>
    /// <see cref="RectI"/>と互換性があるシリアライズ可能な構造体
    /// </summary>
    [Serializable]
    public readonly struct SerializableRectI : IEquatable<SerializableRectI>
    {
        /// <summary>
        /// 左上のX座標を取得する
        /// </summary>
        public int X { get; }
        /// <summary>
        /// 左上のY座標を取得する
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// 横幅を取得する
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// 縦幅を取得する
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// 左上の座標を取得する
        /// </summary>
        public Vector2DI Position => new Vector2DI(X, Y);
        /// <summary>
        /// 縦横の大きさを取得する
        /// </summary>
        public Vector2DI Size => new Vector2DI(Width, Height);
        /// <summary>
        /// 四隅の座標を左上，右上，右下，左下の順に配列として取得する。
        /// </summary>
        public Vector2DI[] Vertexes => new Vector2DI[] { new Vector2DI(X, Y), new Vector2DI(X + Width, Y), new Vector2DI(X + Width, Y + Height), new Vector2DI(X, Y + Width) };
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">左上のX座標</param>
        /// <param name="y">左上のY座標</param>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        public SerializableRectI(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">左上の座標</param>
        /// <param name="size">縦横の大きさ</param>
        public SerializableRectI(SerializableVector2DI position, SerializableVector2DI size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">左上の座標</param>
        /// <param name="size">縦横の大きさ</param>
        public SerializableRectI(Vector2DI position, Vector2DI size) : this(position.X, position.Y, size.X, size.Y) { }
        /// <summary>
        /// 2つの<see cref="SerializableRectI"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="other">同値性を調べるもう一つの<see cref="SerializableRectI"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(SerializableRectI other) => (X == other.X) && (Y == other.Y) && (Width == other.Width) && (Height == other.Height);
        /// <summary>
        /// <see cref="SerializableRectI"/>と<see cref="RectI"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="serializable">同値性を調べる<see cref="SerializableRectI"/>のインスタンス</param>
        /// <param name="normal">同値性を調べるもう一つの<see cref="RectI"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableRectI serializable, RectI normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y) && (serializable.Width == normal.Width) && (serializable.Height == normal.Height);
        /// <summary>
        /// 2つの<see cref="SerializableRectI"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="rect1">同値性を調べる<see cref="SerializableRectI"/>のインスタンス</param>
        /// <param name="rect2">同値性を調べるもう一つの<see cref="SerializableRectI"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableRectI rect1, SerializableRectI rect2) => rect1.Equals(rect2);
        /// <summary>
        /// このインスタンスと指定したオブジェクトが等しいかどうか判定する
        /// </summary>
        /// <param name="obj">判定する<see cref="object"/>のインスタンス</param>
        /// <returns>等しかったらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is SerializableRectI r ? Equals(r) : false;
        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 466501756;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// このインスタンスと同じ値を持つ<see cref="SerializableRectF"/>を返す
        /// </summary>
        /// <returns>このインスタンスと同じ値を持つ<see cref="SerializableRectF"/>の新しいインスタンス</returns>
        public SerializableRectF ToF() => new SerializableRectF(X, Y, Width, Height);
        public static implicit operator RectI(SerializableRectI r) => new RectI(r.X, r.Y, r.Width, r.Height);
        public static implicit operator SerializableRectI(RectI r) => new SerializableRectI(r.X, r.Y, r.Width, r.Height);
        public static implicit operator SerializableRectF(SerializableRectI i) => i.ToF();
        public static bool operator ==(SerializableRectI r1, SerializableRectI r2) => Equals(r1, r2);
        public static bool operator ==(SerializableRectI r1, RectI r2) => Equals(r1, r2);
        public static bool operator ==(RectI r1, SerializableRectI r2) => Equals(r2, r1);
        public static bool operator !=(SerializableRectI r1, SerializableRectI r2) => !Equals(r1, r2);
        public static bool operator !=(SerializableRectI r1, RectI r2) => !Equals(r1, r2);
        public static bool operator !=(RectI r1, SerializableRectI r2) => !Equals(r2, r1);
    }
}