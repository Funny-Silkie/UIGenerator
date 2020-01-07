using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIGenerator
{
    /// <summary>
    /// C#のコードを提供するクラス
    /// </summary>
    public static class CSharpCodeProvider
    {
        /// <summary>
        /// 改行を表す文字列を取得する
        /// </summary>
        public const string Indention = "\n";
        /// <summary>
        /// <see cref="AccesibilityType"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="accesibility">文字列化したい<see cref="AccesibilityType"/>の値</param>
        /// <exception cref="ArgumentException"><paramref name="accesibility"/>の値が不正</exception>
        /// <returns><paramref name="accesibility"/>に相当する文字列</returns>
        public static string FromAccesibility(AccesibilityType accesibility)
        {
            switch (accesibility)
            {
                case AccesibilityType.Private: return "private";
                case AccesibilityType.ProtectedPrivate: return "protected private";
                case AccesibilityType.Internal: return "internal";
                case AccesibilityType.Protected: return "protected";
                case AccesibilityType.ProtectedInternal: return "protected internal";
                case AccesibilityType.Public: return "public";
                default: throw new ArgumentException();
            }
        }
        /// <summary>
        /// usingステートメントを表す文字列を返す
        /// </summary>
        /// <returns>usingステートメントを表す文字列</returns>
        public static string GetUsingStatement() =>
            "using System\n;" +
            "using System.Collections.Generic;\n" +
            "using System.Linq;\n" +
            "using asd;\n" +
            "using fslib;\n" +
            "using fslib.Serializable;";
    }
}
