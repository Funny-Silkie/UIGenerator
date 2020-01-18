using System;
using asd;

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
        /// <see cref="bool"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="value">文字化したい<see cref="bool"/>の値</param>
        /// <returns><paramref name="value"/>に相当する文字列</returns>
        public static string FromBoolean(bool value) => value ? "true" : "false";
        /// <summary>
        /// <see cref="Color"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="color">文字列化したい<see cref="Color"/>の値</param>
        /// <returns><paramref name="color"/>に相当する文字列</returns>
        public static string FromColor(Color color) => $"new Color({color.R}, {color.G}, {color.B}, {color.A})";
        /// <summary>
        /// <see cref="FontInfoBase"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="font">文字列化したい<see cref="FontInfoBase"/>の値</param>
        /// <exception cref="ArgumentNullException"><paramref name="font"/>がnull</exception>
        /// <exception cref="NotSupportedException"><paramref name="font"/>が想定されていない型だった</exception>
        /// <returns><paramref name="font"/>に相当する文字列</returns>
        public static string FromFont(FontInfoBase font)
        {
            if (font == null) throw new ArgumentNullException();
            switch (font)
            {
                case DynamicFontInfo f: return $"Engine.Graphics.CreateDynamicFont({f.Font.Path}, {f.Size}, {FromColor(f.Color)}, {f.OutLineSize}, {FromColor(f.OutLineColor)})";
                case StaticFontInfo f: return $"Engine.Graphics.CreateFont({f.Font.Path})";
                default: throw new NotSupportedException();
            }
        }
        /// <summary>
        /// <see cref="RectF"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="rect">文字列化したい<see cref="RectF"/>の値</param>
        /// <returns><paramref name="rect"/>に相当する文字列</returns>
        public static string FromRectF(RectF rect) => $"new RectF({rect.X}, {rect.Y}, {rect.Width}, {rect.Height})";
        /// <summary>
        /// <see cref="TextureInfo"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="texture">文字列化したい<see cref="TextureInfo"/>の値</param>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/>がnull</exception>
         /// <returns><paramref name="texture"/>に相当する文字列</returns>
        public static string FromTexture(TextureInfo texture)
        {
            if (texture == null) throw new ArgumentNullException();
            return $"Engine.Graphics.CreateTexture2D({texture.Path})";
        }
        /// <summary>
        /// <see cref="Vector2DF"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="vector">文字列化したい<see cref="Vector2DF"/>の値</param>
        /// <returns><paramref name="vector"/>に相当する文字列</returns>
        public static string FromVector2DF(Vector2DF vector) => $"new Vector2DF({vector.X}, {vector.Y})";
        /// <summary>
        /// 指定した回数空白を4つ返す
        /// </summary>
        /// <param name="amount">空白文字のセット個数</param>
        /// <returns>指定した回数 * 4個の空白文字</returns>
        public static string GetSpaces(byte amount)
        {
            var result = "";
            for (byte i = 0; i < amount; i++) result += "    ";
            return result;
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
            "using fslib.Serializable;\n" +
            "using UIGeneratorObjects;";
    }
}
