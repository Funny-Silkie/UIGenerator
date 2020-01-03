using System;

namespace UIGenerator
{
    /// <summary>
    /// アクセシビリティを表す列挙体
    /// </summary>
    [Serializable]
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
}
