using System;
using System.Collections.Generic;
using System.Linq;
using fslib.Collections.BasicModel;

namespace UIGenerator
{
    /// <summary>
    /// 列挙体の処理を補助するクラス
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 指定された列挙体のうち定義されているものの個数を取得する
        /// </summary>
        /// <typeparam name="TEnum">要素数を取得する列挙体の型</typeparam>
        /// <returns><typeparamref name="TEnum"/>で定義されている値の個数</returns>
        public static int Count<TEnum>() where TEnum : struct, Enum => InnerEnums<TEnum>.Count;
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(sbyte value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(byte value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(short value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(ushort value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(int value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(uint value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(long value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 数値から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換元の数値</param>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromNumber<TEnum>(ulong value) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), value);
        /// <summary>
        /// 文字列から列挙体に変換する
        /// </summary>
        /// <typeparam name="TEnum">変換先の列挙体</typeparam>
        /// <param name="value">変換する文字列</param>
        /// <exception cref="ArgumentException"><paramref name="value"/>が空白文字からなる又は<typeparamref name="TEnum"/>で定義されている文字列ではない</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>がnull</exception>
        /// <exception cref="OverflowException"><paramref name="value"/>が<typeparamref name="TEnum"/>の範囲外を示す</exception>
        /// <returns><paramref name="value"/>に対応する<typeparamref name="TEnum"/>の値</returns>
        public static TEnum FromString<TEnum>(string value) where TEnum : struct, Enum => (TEnum)Enum.Parse(typeof(TEnum), value);
        /// <summary>
        /// 指定した値を持つ<typeparamref name="TEnum"/>の文字列を返す
        /// </summary>
        /// <typeparam name="TEnum">文字列を獲得したい列挙体の型</typeparam>
        /// <param name="value"><typeparamref name="TEnum"/>に変換したい値</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>がnull</exception>
        /// <returns><paramref name="value"/>を持つ<typeparamref name="TEnum"/>の文字列</returns>
        public static string GetName<TEnum>(object value) where TEnum : struct, Enum => Enum.GetName(typeof(TEnum), value);
        /// <summary>
        /// 列挙体の文字列を全て取得する
        /// </summary>
        /// <typeparam name="TEnum">文字列を得る列挙体の種類</typeparam>
        /// <returns><typeparamref name="TEnum"/>で定義された全ての文字列</returns>
        public static string[] GetNames<TEnum>() where TEnum : struct, Enum => InnerEnums<TEnum>.Names;
        /// <summary>
        /// 指定した列挙体の型が持つ値のタイプを返す
        /// </summary>
        /// <typeparam name="TEnum">値のタイプを調べたい列挙体の型</typeparam>
        /// <returns>指定した列挙体の型が持つ値のタイプ</returns>
        public static Type GetUnderlyingType<TEnum>() where TEnum : struct, Enum => Enum.GetUnderlyingType(typeof(TEnum));
        /// <summary>
        /// 列挙体の値をすべて取得する
        /// </summary>
        /// <typeparam name="TEnum">値を取得する列挙体の値</typeparam>
        /// <returns><typeparamref name="TEnum"/>で定義されたすべての要素</returns>
        public static TEnum[] GetValues<TEnum>() where TEnum : struct, Enum => InnerEnums<TEnum>.Values;
        /// <summary>
        /// 指定した列挙体の型が<see cref="FlagsAttribute"/>を持つかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum"><see cref="FlagsAttribute"/>の存在を調査する列挙体の型</typeparam>
        /// <returns><see cref="FlagsAttribute"/>を持っていたらtrue，それ以外でfalse</returns>
        public static bool HaveFlagAttribute<TEnum>() where TEnum : struct, Enum => Attribute.IsDefined(typeof(TEnum), typeof(FlagsAttribute));
        /// <summary>
        /// 指定した列挙体の中で定義されているもののうち割り当てられた値が最大の物を返す
        /// </summary>
        /// <typeparam name="TEnum">最大値を検索する列挙体の型</typeparam>
        /// <returns><typeparamref name="TEnum"/>で定義されている値のうち最大値を持つ者のインスタンス</returns>
        public static TEnum Max<TEnum>() where TEnum : struct, Enum => Max(GetValues<TEnum>());
        /// <summary>
        /// 指定した列挙体の配列内の値のうち割り当てられた値が最大の物を返す
        /// </summary>
        /// <typeparam name="TEnum">処理する列挙体の型</typeparam>
        /// <param name="array">最大値を検索する<typeparamref name="TEnum"/>の配列</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>の容量が0</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <returns><paramref name="array"/>内の列挙体の値のうち最大値を持つもの</returns>
        public static TEnum Max<TEnum>(TEnum[] array) where TEnum : struct, Enum
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Length == 0) throw new ArgumentException();
            var comparison = array[0];
            for (int i = 1; i < array.Length; i++)
                if (comparison.CompareTo(array[i]) == -1)
                    comparison = array[i];
            return comparison;
        }
        /// <summary>
        /// 指定した列挙体のコレクション内の値のうち割り当てられた値が最大の物を返す
        /// </summary>
        /// <typeparam name="TEnum">処理する列挙体の型</typeparam>
        /// <param name="collection">最大値を検索する<typeparamref name="TEnum"/>の配列</param>
        /// <exception cref="ArgumentException"><paramref name="collection"/>の容量が0</exception>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        /// <returns><paramref name="collection"/>内の列挙体の値のうち最大値を持つもの</returns>
        public static TEnum Max<TEnum>(IEnumerable<TEnum> collection) where TEnum : struct, Enum
        {
            if (collection == null) throw new ArgumentNullException();
            if (collection is TEnum[] array) return Max(array);
            else if (collection is IList<TEnum> list)
            {
                if (list.Count == 0) throw new ArgumentException();
                var comparison = list[0];
                for (int i = 1; i < list.Count; i++)
                    if (comparison.CompareTo(list[i]) == -1)
                        comparison = list[i];
                return comparison;
            }
            else
            {
                var count = 0;
                TEnum comparison = default;
                using (var en = collection.GetEnumerator())
                {
                    if (count == 0)
                    {
                        if (!en.MoveNext()) throw new ArgumentException();
                        comparison = en.Current;
                        count++;
                    }
                    while (en.MoveNext())
                    {
                        if (comparison.CompareTo(en.Current) == -1) comparison = en.Current;
                        count++;
                    }
                }
                return comparison;
            }
        }
        /// <summary>
        /// 指定した列挙体の中で定義されているもののうち割り当てられた値が最小の物を返す
        /// </summary>
        /// <typeparam name="TEnum">最小値を検索する列挙体の型</typeparam>
        /// <returns><typeparamref name="TEnum"/>で定義されている値のうち最小値を持つ者のインスタンス</returns>
        public static TEnum Min<TEnum>() where TEnum : struct, Enum => Min(GetValues<TEnum>());
        /// <summary>
        /// 指定した列挙体の配列内の値のうち割り当てられた値が最小の物を返す
        /// </summary>
        /// <typeparam name="TEnum">処理する列挙体の型</typeparam>
        /// <param name="array">最小値を検索する<typeparamref name="TEnum"/>の配列</param>
        /// <exception cref="ArgumentException"><paramref name="array"/>の容量が0</exception>
        /// <exception cref="ArgumentNullException"><paramref name="array"/>がnull</exception>
        /// <returns><paramref name="array"/>内の列挙体の値のうち最小値を持つもの</returns>
        public static TEnum Min<TEnum>(TEnum[] array) where TEnum : struct, Enum
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Length == 0) throw new ArgumentException();
            var comparison = array[0];
            for (int i = 1; i < array.Length; i++)
                if (comparison.CompareTo(array[i]) == 1)
                    comparison = array[i];
            return comparison;
        }
        /// <summary>
        /// 指定した列挙体のコレクション内の値のうち割り当てられた値が最小の物を返す
        /// </summary>
        /// <typeparam name="TEnum">処理する列挙体の型</typeparam>
        /// <param name="collection">最小値を検索する<typeparamref name="TEnum"/>の配列</param>
        /// <exception cref="ArgumentException"><paramref name="collection"/>の容量が0</exception>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>がnull</exception>
        /// <returns><paramref name="collection"/>内の列挙体の値のうち最小値を持つもの</returns>
        public static TEnum Min<TEnum>(IEnumerable<TEnum> collection) where TEnum : struct, Enum
        {
            if (collection == null) throw new ArgumentNullException();
            if (collection is TEnum[] array) return Min(array);
            else if (collection is IList<TEnum> list)
            {
                if (list.Count == 0) throw new ArgumentException();
                var comparison = list[0];
                for (int i = 1; i < list.Count; i++)
                    if (comparison.CompareTo(list[i]) == 1)
                        comparison = list[i];
                return comparison;
            }
            else
            {
                var count = 0;
                TEnum comparison = default;
                using (var en = collection.GetEnumerator())
                {
                    if (count == 0)
                    {
                        if (!en.MoveNext()) throw new ArgumentException();
                        comparison = en.Current;
                        count++;
                    }
                    while (en.MoveNext())
                    {
                        if (comparison.CompareTo(en.Current) == 1) comparison = en.Current;
                        count++;
                    }
                }
                return comparison;
            }
        }
        /// <summary>
        /// 列挙体の値を定義された値で分割していく
        /// </summary>
        /// <typeparam name="TEnum">分割する列挙体の型</typeparam>
        /// <param name="value">分割する列挙体の値</param>
        /// <exception cref="ArgumentException"><paramref name="value"/>に<see cref="FlagsAttribute"/>が適用されていない</exception>
        /// <returns>分割されて生じた<typeparamref name="TEnum"/>のすべての値</returns>
        public static TEnum[] Split<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            if (!HaveFlagAttribute<TEnum>()) throw new ArgumentException();
            var enums = new HashSet<TEnum>();
            var values = new Queue<TEnum>(GetValues<TEnum>());
            var count = values.Count;
            for (int i = 0; i < count; i++)
            {
                var comparison = values.Dequeue();
                if (value.HasFlag(comparison)) enums.Add(comparison);
            }
            return enums.ToArray();
        }
        /// <summary>
        /// 指定した列挙体の配列を，小さい値順に整列していく
        /// </summary>
        /// <typeparam name="TEnum">ソートする列挙体の型</typeparam>
        /// <param name="enums">ソートしたい列挙体が格納される配列</param>
        /// <exception cref="ArgumentNullException"><paramref name="enums"/>がnull</exception>
        /// <returns>ソートされた配列</returns>
        public static TEnum[] Sort<TEnum>(TEnum[] enums) where TEnum : struct, Enum
        {
            if (enums == null) throw new ArgumentNullException();
            var count = enums.Length;
            var array = new TEnum[count];
            var set = new BasicCollection<TEnum>(enums);
            for (int i = 0; i < count; i++)
            {
                var min = Min(set);
                array[i] = min;
                set.Remove(min);
            }
            return array;
        }
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this TEnum value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this sbyte value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this byte value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this short value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this ushort value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this int value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this uint value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this long value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this ulong value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        /// <summary>
        /// 指定した値が列挙体として列挙されているかどうかを返す
        /// </summary>
        /// <typeparam name="TEnum">定義されているかどうかを調査する型</typeparam>
        /// <param name="value">定義されているか調べる値</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>がnull</exception>
        /// <returns>定義されていたらtrue，それ以外でfalse</returns>
        public static bool IsDefined<TEnum>(this string value) where TEnum : struct, Enum => Enum.IsDefined(typeof(TEnum), value);
        private static class InnerEnums<TEnum> where TEnum : struct, Enum
        {
            internal static string[] Names { get; } = Enum.GetNames(typeof(TEnum));
            internal static int Count => Names.Length;
            internal static TEnum[] Values { get; } = CreateValues();
            private static TEnum[] CreateValues()
            {
                var array = new TEnum[Count];
                for (int i = 0; i < Count; i++) array[i] = FromString<TEnum>(Names[i]);
                return array;
            }
        }
    }
}