using System;

namespace UIGenerator
{
    public partial class DrawingArcInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawArcAdditionally({CSharpCodeProvider.FromVector2DF(Center)}, {OuterDiameter}, {InnerDiameter}, {CSharpCodeProvider.FromColor(Color)}, {VertNum}, {StartingVerticalAngle}, {EndingVerticalAngle}, {Angle}, {CSharpCodeProvider.FromTexture(Texture)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); //{Name}";
    }
    public partial class DrawingCircleInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawCircleAdditionally({CSharpCodeProvider.FromVector2DF(Center)}, {OuterDiameter}, {InnerDiameter}, {CSharpCodeProvider.FromColor(Color)}, {VertNum}, {Angle}, {CSharpCodeProvider.FromTexture(Texture)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
    public partial class DrawingLineInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawLineAdditionally({CSharpCodeProvider.FromVector2DF(Point1)}, {CSharpCodeProvider.FromVector2DF(Point2)}, {Thickness}, {CSharpCodeProvider.FromColor(Color)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
    public partial class DrawingRectangleInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawRectangleAdditionally({CSharpCodeProvider.FromRectF(DrawingArea)}, {CSharpCodeProvider.FromColor(Color)}, {CSharpCodeProvider.FromRectF(UV)}, {CSharpCodeProvider.FromTexture(Texture)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
    public partial class DrawingRotatedRectangleInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawRotatedRectangleAdditionally({CSharpCodeProvider.FromRectF(DrawingArea)}, {CSharpCodeProvider.FromColor(Color)}, {CSharpCodeProvider.FromVector2DF(RotationCenter)}, {Angle}, {CSharpCodeProvider.FromRectF(UV)}, {CSharpCodeProvider.FromTexture(Texture)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
    public partial class DrawingSpriteInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawSpriteAdditionally({CSharpCodeProvider.FromVector2DF(UpperLeftPos)}, {CSharpCodeProvider.FromVector2DF(UpperRightPos)}, {CSharpCodeProvider.FromVector2DF(LowerRightPos)}, {CSharpCodeProvider.FromVector2DF(LowerLeftPos)}, {CSharpCodeProvider.FromColor(UpperLeftColor)}, {CSharpCodeProvider.FromColor(UpperRightColor)}, {CSharpCodeProvider.FromColor(LowerRightColor)}, {CSharpCodeProvider.FromColor(LowerLeftColor)}, {CSharpCodeProvider.FromVector2DF(UpperLeftUV)}, {CSharpCodeProvider.FromVector2DF(UpperRightUV)}, {CSharpCodeProvider.FromVector2DF(LowerRightUV)}, {CSharpCodeProvider.FromVector2DF(LowerLeftUV)}, {CSharpCodeProvider.FromTexture(Texture)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
    public partial class DrawingTextInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawTextAdditionally({CSharpCodeProvider.FromVector2DF(Position)}, {CSharpCodeProvider.FromColor(Color)}, {CSharpCodeProvider.FromFont(FontInfo)}, {Text}, WritingDirection.{WritingDirection.ToString()}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
    public partial class DrawingTriangleInfo
    {
        /// <summary>
        /// C#のコードを返す
        /// </summary>
        /// <returns>この追加描画を実装するC#のコード</returns>
        public override string ToCSharp() => $"DrawTriangleAdditionally({CSharpCodeProvider.FromVector2DF(Position1)}, {CSharpCodeProvider.FromVector2DF(Position2)}, {CSharpCodeProvider.FromVector2DF(Position3)}, {CSharpCodeProvider.FromColor(Color)}, {CSharpCodeProvider.FromVector2DF(UV1)}, {CSharpCodeProvider.FromVector2DF(UV2)}, {CSharpCodeProvider.FromVector2DF(UV3)}, {CSharpCodeProvider.FromTexture(Texture)}, AlphaBlendMode.{AlphaBlend.ToString()}, {DrawingPriority}); // {Name}";
    }
}
