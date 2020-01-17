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
            $"    IsClickable = {CSharpCodeProvider.FromBoolean(IsClickable)},\n" +
            $"    Color = {CSharpCodeProvider.FromColor(Color)},\n" +
            $"    Position = {CSharpCodeProvider.FromVector2DF(Position)},\n" +
            $"    CenterPosition = {CSharpCodeProvider.FromVector2DF(CenterPosition)},\n" +
            $"    Scale = {CSharpCodeProvider.FromVector2DF(UIObject.Scale)},\n" +
            $"    DrawingPriority = {DrawingPriority},\n" +
            $"    WritingDirection = WritingDirection.{WritingDirection.ToString()},\n" +
            $"    Text = {Text},\n" +
            $"    Font = {CSharpCodeProvider.FromFont(FontInfo)}\n" +
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
        public override string ToCSharp_Set() =>
            $"text_{Mode}_{Name} = new UITexture({Mode}, {Name})\n" +
             "{\n" +
            $"    IsClickable = {CSharpCodeProvider.FromBoolean(IsClickable)},\n" +
            $"    Color = {CSharpCodeProvider.FromColor(Color)},\n" +
            $"    Position = {CSharpCodeProvider.FromVector2DF(Position)},\n" +
            $"    CenterPosition = {CSharpCodeProvider.FromVector2DF(CenterPosition)},\n" +
            $"    Scale = {CSharpCodeProvider.FromVector2DF(UIObject.Scale)},\n" +
            $"    DrawingPriority = {DrawingPriority},\n" +
            $"    Texture = {CSharpCodeProvider.FromTexture(TextureInfo)}\n" +
             "}";
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
            $"    IsClickable = {CSharpCodeProvider.FromBoolean(IsClickable)},\n" +
            $"    Color = {CSharpCodeProvider.FromColor(Color)},\n" +
            $"    Position = {CSharpCodeProvider.FromVector2DF(Position)},\n" +
            $"    Scale = {CSharpCodeProvider.FromVector2DF(UIObject.Scale)},\n" +
            $"    DrawingPriority = {DrawingPriority},\n" +
            $"    LineColor = {CSharpCodeProvider.FromColor(LineColor)},\n" +
            $"    Thickness = {LineThickness},\n" +
            $"    GeneratingFlame = {CSharpCodeProvider.FromBoolean(GeneratingFlame)}\n" +
             "}";
    }
}
