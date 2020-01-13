using System;

namespace UIGenerator
{
    public sealed partial class TextObjInfo
    {
        /// <summary>
        /// 最初のフィールド宣言を行う
        /// </summary>
        /// <returns>C#による最初のフィールド宣言</returns>
        public override string ToCSharp_Define() => $"{CSharpCodeProvider.FromAccesibility(Accesibility)} UIText text_{Mode}_{Name};";
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp_Set() =>
            $"text_{Mode}_{Name} = new UIText({Mode}, {Name})\n" +
             "{\n" +
            $"    Position = new Vector2DF{Position},\n" +
            $"    CenterPosition = new Vector2DF{CenterPosition},\n" +
            $"    Color = new Color({Color.R}, {Color.G}, {Color.B}, {Color.A}),\n" +
            $"    WritingDirection = {WritingDirection},\n" +
            $"    Text = {Text},\n" +
            $"    IsClickable = {IsClickable},\n" +
            $"    Size = new Vector2DF{Size},\n" +
            $"    DrawingPriority = {DrawingPriority}\n" +
             "}";
    }
    public sealed partial class TextureObjInfo
    {
        /// <summary>
        /// 最初のフィールド宣言を行う
        /// </summary>
        /// <returns>C#による最初のフィールド宣言</returns>
        public override string ToCSharp_Define() => $"{CSharpCodeProvider.FromAccesibility(Accesibility)} UITexture texture_{Mode}_{Name};";
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp_Set() => throw new NotImplementedException();
    }
    public sealed partial class WindowInfo
    {
        /// <summary>
        /// 最初のフィールド宣言を行う
        /// </summary>
        /// <returns>C#による最初のフィールド宣言</returns>
        public override string ToCSharp_Define() => $"{CSharpCodeProvider.FromAccesibility(Accesibility)} UIWindow window_{Mode}_{Name};";
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp_Set() =>
            $"window_{Mode}_{Name} = new UIWindow({Mode}, {Name})\n" +
             "{\n" +
            $"    Position = new Vector2DF{Position},\n" +
            $"    Color = new Color({Color.R}, {Color.G}, {Color.B}, {Color.A}),\n" +
            $"    IsClickable = {IsClickable},\n" +
            $"    Size = new Vector2DF{Size},\n" +
            $"    DrawingPriority = {DrawingPriority},\n" +
            $"    LineColor = new Color({LineColor.R}, {LineColor.G}, {LineColor.B}, {LineColor.A}),\n" +
            $"    Thickness = {LineThickness},\n" +
            $"    GeneratingFlame = {GeneratingFlame}\n" +
             "}";
    }
}
