using System;
using System.Runtime.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// キーが重複していた時にスローされる例外を表す
    /// </summary>
    public class KeyDuplicateException : SystemException, ISerializable
    {
        /// <summary>
        /// <see cref="KeyDuplicateException"/>の新しいインスタンスを生成する
        /// </summary>
        public KeyDuplicateException() : base() { }
        /// <summary>
        /// 指定したエラーメッセージを使用して<see cref="KeyDuplicateException"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="message">表示するエラーメッセージ</param>
        public KeyDuplicateException(string message) : base(message) { }
        /// <summary>
        /// 指定したエラーメッセージとこの例外の原因になった内部例外への参照を用いて<see cref="KeyDuplicateException"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="message">表示するエラーメッセージ</param>
        /// <param name="innerException">現在の例外の原因となった例外</param>
        public KeyDuplicateException(string message, System.Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// シリアル化したデータを用いて<see cref="KeyDuplicateException"/>の新しいインスタンスを生成する
        /// </summary>
        /// <param name="info">シリアル化された<see cref="KeyDuplicateException"/>のインスタンスのデータ</param>
        /// <param name="context">シリアル化先に関する情報</param>
        protected KeyDuplicateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}