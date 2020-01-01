using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fslib;
using fslib.Collections;

namespace UIGenerator
{
    /// <summary>
    /// 要素の定義方法を表す列挙体
    /// </summary>
    [Serializable]
    public enum InstanceDefineType
    {
        /// <summary>
        /// フィールド変数として定義
        /// </summary>
        Field,
        /// <summary>
        /// 自動プロパティとして定義
        /// </summary>
        Property
    }
    /// <summary>
    /// アクセシビリティを表す列挙体
    /// </summary>
    [Serializable, Flags]
    public enum AccesibilityType
    {
        /// <summary>
        /// private
        /// </summary>
        Private = 0b0,
        /// <summary>
        /// protected private
        /// </summary>
        ProtectedPrivate = 0b1,
        /// <summary>
        /// internal
        /// </summary>
        Internal = 0b11,
        /// <summary>
        /// protected private
        /// </summary>
        Protected = 0b101,
        /// <summary>
        /// protected internal
        /// </summary>
        ProtectedInternal = 0b111,
        /// <summary>
        /// public
        /// </summary>
        Public = 0b1111
    }
    /// <summary>
    /// プロパティのアクセッサのタイプを表す列挙体
    /// </summary>
    [Serializable]
    public enum PropertyType
    {
        /// <summary>
        /// getとset可能
        /// </summary>
        GetSet,
        /// <summary>
        /// getのみ可能
        /// </summary>
        GetOnly,
        /// <summary>
        /// setのみ可能
        /// </summary>
        SetOnly
    }
    /// <summary>
    /// 要素のアクセシビリティを制御するクラス
    /// </summary>
    [Serializable]
    public sealed class AccesibilityInfo
    {
        /// <summary>
        /// 定義方法を取得する
        /// </summary>
        public InstanceDefineType DefineType { get; set; }
        /// <summary>
        /// アクセシビリティを取得または設定する
        /// </summary>
        public AccesibilityType Accesibility 
        {
            get => _accesibility;
            set
            {
                _accesibility = value;
                _getterAccesibility = value;
                _setterAccesibility = value;
            }
        }
        private AccesibilityType _accesibility;
        /// <summary>
        /// getterのアクセシビリティを取得または設定する
        /// </summary>
        public AccesibilityType GetterAccesibility
        {
            get => _getterAccesibility;
            set
            {
                var array = ToBits(_accesibility);

                _getterAccesibility = value;
            }
        }
        private AccesibilityType _getterAccesibility;
        /// <summary>
        /// setterのアクセシビリティを取得または設定する
        /// </summary>
        public AccesibilityType SetterAccesibility
        {
            get => _setterAccesibility;
            set
            {
                _setterAccesibility = value;
            }
        }
        private AccesibilityType _setterAccesibility;
        /// <summary>
        /// フィールドとして<see cref="AccesibilityInfo"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="accesibility">アクセシビリティ</param>
        /// <exception cref="ArgumentException"><paramref name="accesibility"/>の値が不正</exception>
        public AccesibilityInfo(AccesibilityType accesibility)
        {
            Central.ThrowHelper.ThrowArgumentException(!Enum.IsDefined(typeof(AccesibilityType), accesibility), null);
            DefineType = InstanceDefineType.Field;
            Accesibility = accesibility;
        }
        /// <summary>
        /// <see cref="AccesibilityType"/>の値をビットの分解し<see cref="bool"/>の配列(サイズ4)を返す
        /// </summary>
        /// <param name="accesibility"><see cref="bool"/>配列に直す<see cref="AccesibilityType"/>の値</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="accesibility"/>の値が不正</exception>
        /// <returns><paramref name="accesibility"/>のビット配列</returns>
        public static bool[] ToBits(AccesibilityType accesibility)
        {
            var value = (byte)accesibility;
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(value, byte.MinValue, (byte)0b1111, null);
            var array = new bool[4];
            if (value >= 0b1000)
            {
                array[3] = true;
                value -= 0b1000;
            }
            if (value >= 0b100)
            {
                array[2] = true;
                value -= 0b100;
            }
            if (value >= 0b10)
            {
                array[1] = true;
                value -= 0b10;
            }
            array[0] = value >= 0b1;
            return array;
        }
        /// <summary>
        /// ビット配列から<see cref="AccesibilityType"/>を返す
        /// </summary>
        /// <param name="bits">使用するビット配列</param>
        /// <exception cref="ArgumentException"><paramref name="bits"/>のサイズが4以外</exception>
        /// <exception cref="ArgumentNullException"><paramref name="bits"/>がnull</exception>
        /// <returns><paramref name="bits"/>の指定する<see cref="AccesibilityType"/>の値</returns>
        public static AccesibilityType ToAccesibility(bool[] bits)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, bits);
            Central.ThrowHelper.ThrowArgumentException(bits.Length != 4, null);
            byte value = 0;
            for (int i = 0; i < 4; i++)
                if (bits[i])
                {
                    byte comparison = 1;
                    for (int j = 0; j < i; j++) comparison *= 2;
                    value += comparison;
                }
            return value.ToEnum<AccesibilityType>();
        }
        /// <summary>
        /// 指定した<see cref="AccesibilityType"/>の値から，選択できるgetter, setter用の選択可能な<see cref="AccesibilityType"/>の値を返す
        /// </summary>
        /// <param name="limit">アクセシビリティの閾となる値</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="limit"/>の値が不正</exception>
        /// <returns>getter, setterとして選択できる<see cref="AccesibilityType"/>の値</returns>
        public static AccesibilityType[] CalcAccesibility(AccesibilityType limit)
        {
            var bits = ToBits(limit);
            var list = new BasicCollection<AccesibilityType>(bits.Length);
            if (bits[0]) list.Add(AccesibilityType.Private);
            if (bits[1] || bits[2]) list.Add(AccesibilityType.ProtectedPrivate);
            if (bits[1] && bits[2])
            {
                list.Add(AccesibilityType.Internal);
                list.Add(AccesibilityType.Protected);
            }
            if (bits[3]) list.Add(AccesibilityType.ProtectedInternal);
            return list.ToArray();
        }
    }
}
