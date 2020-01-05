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
        Private,
        /// <summary>
        /// protected private
        /// </summary>
        ProtectedPrivate,
        /// <summary>
        /// internal
        /// </summary>
        Internal,
        /// <summary>
        /// protected private
        /// </summary>
        Protected,
        /// <summary>
        /// protected internal
        /// </summary>
        ProtectedInternal,
        /// <summary>
        /// public
        /// </summary>
        Public
    }
}
