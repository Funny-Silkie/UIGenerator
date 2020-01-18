using System;

namespace UIGenerator
{
    public sealed partial class TextObjInfo
    {
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp() =>
            $"new UIText({(Mode)}, {CSharpCodeProvider.FromString(Name)})\n" +
             "{\n" +
            $"    IsClickable = {CSharpCodeProvider.FromBoolean(IsClickable)},\n" +
            $"    Color = {CSharpCodeProvider.FromColor(Color)},\n" +
            $"    Position = {CSharpCodeProvider.FromVector2DF(Position)},\n" +
            $"    CenterPosition = {CSharpCodeProvider.FromVector2DF(CenterPosition)},\n" +
            $"    Scale = {CSharpCodeProvider.FromVector2DF(UIObject.Scale)},\n" +
            $"    DrawingPriority = {DrawingPriority},\n" +
            $"    WritingDirection = WritingDirection.{WritingDirection.ToString()},\n" +
            $"    Text = {CSharpCodeProvider.FromString(Text)},\n" +
            $"    Font = {CSharpCodeProvider.FromFont(FontInfo)}\n" +
             "}";
    }
    public sealed partial class TextureObjInfo
    {
        /// <summary>
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp() =>
            $"new UITexture({Mode}, {CSharpCodeProvider.FromString(Name)})\n" +
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
        /// 各要素の設定を行う
        /// </summary>
        /// <returns>C#による各要素の設定</returns>
        public override string ToCSharp() =>
            $"new UIWindow({Mode}, {CSharpCodeProvider.FromString(Name)})\n" +
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
