using System;
using System.Collections.Generic;
using System.Linq;
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
                case DynamicFontInfo f: return $"Engine.Graphics.CreateDynamicFont({FromString(f.Font.Path)}, {f.Size}, {FromColor(f.Color)}, {f.OutLineSize}, {FromColor(f.OutLineColor)})";
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
        /// <see cref="string"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="text">文字列化したい<see cref="string"/>の値</param>
        /// <returns><paramref name="text"/>に相当する文字列</returns>
        public static string FromString(string text) => '"' + text.Replace("\n", "\\n") + '"';
        /// <summary>
        /// <see cref="TextureInfo"/>の値からその文字列を取得する
        /// </summary>
        /// <param name="texture">文字列化したい<see cref="TextureInfo"/>の値</param>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/>がnull</exception>
         /// <returns><paramref name="texture"/>に相当する文字列</returns>
        public static string FromTexture(TextureInfo texture)
        {
            if (texture == null) throw new ArgumentNullException();
            return $"Engine.Graphics.CreateTexture2D({FromString(texture.Path)})";
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
            "using System;\n" +
            "using System.Collections.Generic;\n" +
            "using System.Linq;\n" +
            "using System.Text;\n" +
            "using System.Threading.Tasks;\n" +
            "using asd;\n" +
            "using UIGeneratorObjects;";
        /// <summary>
        /// 全ての文字列の先頭に<see cref="GetSpaces(byte)"/>の空白を追加する
        /// </summary>
        /// <param name="code">空白を先頭に追加したいコード</param>
        /// <param name="amount">追加する空白の量</param>
        /// <exception cref="ArgumentNullException"><paramref name="code"/>がnull</exception>
        /// <returns><paramref name="code"/>の各行の先頭に空白が足されたコレクション</returns>
        public static IEnumerable<string> InsertSpaces(IEnumerable<string> code, byte amount)
        {
            if (code == null) throw new ArgumentNullException();
            var list = new List<string>(code.Count());
            var space = GetSpaces(amount);
            foreach (var c in code) list.Add(space + c);
            return list;
        }
        /// <summary>
        /// C#のコードを取得する
        /// </summary>
        /// <param name="nameSpace">名前空間</param>
        /// <param name="layerName">レイヤーの名前</param>
        /// <exception cref="ArgumentException"><paramref name="nameSpace"/>または<paramref name="layerName"/>がnullまたは空白文字からなっている</exception>
        /// <returns>.csに出力するC#のコード</returns>
        public static IEnumerable<string> ProvideCode(string nameSpace, string layerName)
        {
            if (string.IsNullOrWhiteSpace(nameSpace)) throw new ArgumentException();
            nameSpace = nameSpace.Trim();
            var code = new List<string>(30)
            {
                GetUsingStatement() + Indention,
                Indention,
                "namespace " + nameSpace + Indention,
                "{\n"
            };
            var layer = ProvideCode_Layer(layerName);
            code.AddRange(InsertSpaces(layer, 1));
            code.Add("}\n");
            return code;
        }
        /// <summary>
        /// レイヤーのC#コードを取得する
        /// </summary>
        /// <param name="layerName">レイヤーの型名</param>
        /// <exception cref="ArgumentException"><paramref name="layerName"/>がnullまたは空白文字からなっている</exception>
        /// <returns>レイヤーを定義するC#のコード</returns>
        private static IEnumerable<string> ProvideCode_Layer(string layerName)
        {
            if (string.IsNullOrWhiteSpace(layerName)) throw new ArgumentException();
            layerName = layerName.Trim();
            var code = new List<string>(20)
            {
                $"public class {layerName} : {(layerName == "UILayer" ? "UIGeneratorObjects." : "")}UILayer\n",
                "{\n"
            };
            code.AddRange(InsertSpaces(ProvideCode_Layer_Constructor(layerName), 1));
            code.AddRange(InsertSpaces(ProvideCode_Layer_InitObj(), 1));
            code.AddRange(InsertSpaces(ProvideCode_Layer_OnDrawAdditional(), 1));
            code.Add("}\n");
            return code;
        }
        /// <summary>
        /// レイヤーのコンストラクタのC#コードを取得する
        /// </summary>
        /// <param name="layerName">レイヤーの型名</param>
        /// <exception cref="ArgumentException"><paramref name="layerName"/>がnullまたは空白文字からなっている</exception>
        /// <returns>レイヤーのコンストラクタを定義するC#のコード</returns>
        private static IEnumerable<string> ProvideCode_Layer_Constructor(string layerName)
        {
            if (string.IsNullOrWhiteSpace(layerName)) throw new ArgumentException();
            var code = new string[8];
            code[0] = $"public {layerName}()\n";
            code[1] = "{\n";
            code[2] = "    InitObjects();\n";
            code[3] = "}\n";
            code[4] = $"static {layerName}()\n";
            code[5] = "{\n";
            code[6] = $"    Engine.File.AddRootPackage({FromString("DefaultResource.pack")});\n";
            code[7] = "}\n";
            return code;
        }
        /// <summary>
        /// オブジェクトの設定を行う
        /// </summary>
        /// <returns>オブジェクトの設定を行うC#のコード</returns>
        private static IEnumerable<string> ProvideCode_Layer_InitObj()
        {
            var code = new List<string>(4);
            code.Add("private void InitObjects()\n");
            code.Add("{\n");
            foreach (var obj in DataBase.UIInfos)
            {
                var c = obj.Value.ToCSharp().Split('\n');
                c[0] = $"AddUIObject({c[0]}";
                c[c.Length - 1] += ");";
                for (int i = 0; i < c.Length; i++) c[i] += "\n";
                code.AddRange(c);
            }
            code.Add("}\n");
            for (int i = 2; i < code.Count - 1; i++) code[i] = "    " + code[i];
            return code;
        }
        /// <summary>
        /// 追加描画の設定を行う
        /// </summary>
        /// <returns>追加描画の設定を行うC#のコード</returns>
        private static IEnumerable<string> ProvideCode_Layer_OnDrawAdditional()
        {
            var code = new List<string>(4)
            {
                "protected override void OnDrawAdditionally()\n",
                "{\n"
            };
            var adds = DataBase.DrawingCollection;
            var modes = adds.Modes.ToHashSet();
            if (modes.Count > 0)
            {
                code.Add("switch (Mode)\n");
                code.Add("{\n");
                foreach (var m in modes)
                {
                    code.Add($"    case {m}:\n");
                    foreach (var d in adds.SearchFromMode(m)) code.Add($"        {d.ToCSharp()}\n");
                    code.Add("    break;\n");
                }
                code.Add("}\n");
            }
            code.Add("}\n");
            for (int i = 2; i < code.Count - 1; i++) code[i] = "    " + code[i];
            return code;
        }
    }
}
