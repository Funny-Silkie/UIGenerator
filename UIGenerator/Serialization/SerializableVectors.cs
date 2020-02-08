using System;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// シリアル化可能で<see cref="Vector2DF"/>と互換性がある構造体
    /// </summary>
    [Serializable]
    public readonly struct SerializableVector2DF : IEquatable<SerializableVector2DF>
    {
        /// <summary>
        /// Xの値を取得する
        /// </summary>
        public float X { get; }
        /// <summary>
        /// Yの値を取得する
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">Xの値</param>
        /// <param name="y">Yの値</param>
        public SerializableVector2DF(float x, float y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 2つの<see cref="SerializableVector2DF"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="other">同値性を調べるもう一つの<see cref="SerializableVector2DF"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(SerializableVector2DF other) => (X == other.X) && (Y == other.Y);
        /// <summary>
        /// <see cref="SerializableVector2DF"/>と<see cref="Vector2DF"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="serializable">同値性を調べる<see cref="SerializableVector2DF"/>のインスタンス</param>
        /// <param name="normal">同値性を調べるもう一つの<see cref="Vector2DF"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableVector2DF serializable, Vector2DF normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y);
        /// <summary>
        /// 2つの<see cref="SerializableVector2DF"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="vector1">同値性を調べる<see cref="SerializableVector2DF"/>のインスタンス</param>
        /// <param name="vector2">同値性を調べるもう一つの<see cref="SerializableVector2DF"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableVector2DF vector1, SerializableVector2DF vector2) => vector1.Equals(vector2);
        /// <summary>
        /// このインスタンスと指定したオブジェクトが等しいかどうか判定する
        /// </summary>
        /// <param name="obj">判定する<see cref="object"/>のインスタンス</param>
        /// <returns>等しかったらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is SerializableVector2DF v ? Equals(v) : false;
        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// <see cref="SerializableVector2DI"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと同じ値を持つ<see cref="SerializableVector2DI"/>のインスタンス</returns>
        public SerializableVector2DI To2DI() => new SerializableVector2DI((int)X, (int)Y);
        /// <summary>
        /// このインスタンスを表す文字列を返す
        /// </summary>
        /// <returns>このインスタンスを表す文字列</returns>
        public override string ToString() => $"({X}, {Y})";
        public static implicit operator SerializableVector2DF(Vector2DF v) => new SerializableVector2DF(v.X, v.Y);
        public static explicit operator SerializableVector2DI(SerializableVector2DF v) => v.To2DI();
        public static implicit operator Vector2DF(SerializableVector2DF v) => new Vector2DF(v.X, v.Y);
        public static bool operator ==(SerializableVector2DF v1, SerializableVector2DF v2) => Equals(v1, v2);
        public static bool operator ==(SerializableVector2DF v1, Vector2DF v2) => Equals(v1, v2);
        public static bool operator ==(Vector2DF v1, SerializableVector2DF v2) => Equals(v2, v1);
        public static bool operator !=(SerializableVector2DF v1, SerializableVector2DF v2) => !Equals(v1, v2);
        public static bool operator !=(SerializableVector2DF v1, Vector2DF v2) => !Equals(v1, v2);
        public static bool operator !=(Vector2DF v1, SerializableVector2DF v2) => !Equals(v2, v1);
    }
    /// <summary>
    /// シリアル化可能で<see cref="Vector2DI"/>と互換性がある構造体
    /// </summary>
    [Serializable]
    public readonly struct SerializableVector2DI : IEquatable<SerializableVector2DI>
    {
        /// <summary>
        /// Xの値を取得する
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Yの値を取得する
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">Xの値</param>
        /// <param name="y">Yの値</param>
        public SerializableVector2DI(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 2つの<see cref="SerializableVector2DI"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="other">同値性を調べるもう一つの<see cref="SerializableVector2DI"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public bool Equals(SerializableVector2DI other) => (X == other.X) && (Y == other.Y);
        /// <summary>
        /// <see cref="SerializableVector2DI"/>と<see cref="Vector2DI"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="serializable">同値性を調べる<see cref="SerializableVector2DI"/>のインスタンス</param>
        /// <param name="normal">同値性を調べるもう一つの<see cref="Vector2DI"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableVector2DI serializable, Vector2DI normal) => (serializable.X == normal.X) && (serializable.Y == normal.Y);
        /// <summary>
        /// 2つの<see cref="SerializableVector2DI"/>間に同値性があるかどうかを返す
        /// </summary>
        /// <param name="vector1">同値性を調べる<see cref="SerializableVector2DI"/>のインスタンス</param>
        /// <param name="vector2">同値性を調べるもう一つの<see cref="SerializableVector2DI"/>のインスタンス</param>
        /// <returns>同値だったらtrue，それ以外でfalse</returns>
        public static bool Equals(SerializableVector2DI vector1, SerializableVector2DI vector2) => vector1.Equals(vector2);
        /// <summary>
        /// このインスタンスと指定したオブジェクトが等しいかどうか判定する
        /// </summary>
        /// <param name="obj">判定する<see cref="object"/>のインスタンス</param>
        /// <returns>等しかったらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is SerializableVector2DI v ? Equals(v) : false;
        /// <summary>
        /// このインスタンスのハッシュコードを返す
        /// </summary>
        /// <returns>このインスタンスのハッシュコード</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// <see cref="SerializableVector2DF"/>に型変換する
        /// </summary>
        /// <returns>このインスタンスと同じ値を持つ<see cref="SerializableVector2DF"/>のインスタンス</returns>
        public SerializableVector2DF To2DF() => new SerializableVector2DF(X, Y);
        /// <summary>
        /// このインスタンスを表す文字列を返す
        /// </summary>
        /// <returns>このインスタンスを表す文字列</returns>
        public override string ToString() => $"({X}, {Y})";
        public static implicit operator SerializableVector2DI(Vector2DI v) => new SerializableVector2DI(v.X, v.Y);
        public static implicit operator SerializableVector2DF(SerializableVector2DI v) => v.To2DF();
        public static implicit operator Vector2DI(SerializableVector2DI v) => new Vector2DI(v.X, v.Y);
        public static bool operator ==(SerializableVector2DI v1, SerializableVector2DI v2) => Equals(v1, v2);
        public static bool operator ==(SerializableVector2DI v1, Vector2DI v2) => Equals(v1, v2);
        public static bool operator ==(Vector2DI v1, SerializableVector2DI v2) => Equals(v2, v1);
        public static bool operator !=(SerializableVector2DI v1, SerializableVector2DI v2) => !Equals(v1, v2);
        public static bool operator !=(SerializableVector2DI v1, Vector2DI v2) => !Equals(v1, v2);
        public static bool operator !=(Vector2DI v1, SerializableVector2DI v2) => !Equals(v2, v1);
    }
}