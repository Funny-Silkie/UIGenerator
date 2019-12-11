using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

namespace UIGenerator
{
    public abstract class UIInfoBase
    {
        public System.Windows.Forms.Form HandleForm { get; set; } = null;
        public abstract UITypes Type { get; }
        public abstract string Name { get; set; }
        public abstract int Mode { get; set; }
        internal abstract Object2D UIObj { get; }
        protected private UIInfoBase()
        {

        }
        public static UIInfoBase GetInstance(UITypes type, int mode, string name)
        {
            switch (type)
            {
                case UITypes.Text: return new TextInfo(mode, name);
                case UITypes.Texture: return new TextureInfo(mode, name);
                case UITypes.Window: return new WindowInfo(mode, name);
                default: throw new InvalidEnumArgumentException();
            }
        }
    }
    public abstract class UIInfo<T> : UIInfoBase where T : Object2D, IUIElements
    {
        public sealed override string Name
        {
            get => UIObject.Name;
            set
            {
                var oldName = UIObject.Name;
                if (value != oldName)
                {
                    DataBase.UIInfos.Remove(UIObject.Mode, oldName);
                    DataBase.UIInfos.Add(UIObject.Mode, value, this);
                    UIObject.Name = value;
                }
            }
        }
        public sealed override int Mode
        {
            get => UIObject.Mode;
            set
            {
                var oldMode = UIObject.Mode;
                if (value != oldMode)
                {
                    if (oldMode == DataBase.ShowMode && UIObject.Layer != null) DataBase.MainScene.MainLayer.RemoveObject(UIObject);
                    if (value == DataBase.ShowMode) DataBase.MainScene.MainLayer.AddObject(UIObject);
                    DataBase.UIInfos.Remove(oldMode, UIObject.Name);
                    DataBase.UIInfos.Add(value, UIObject.Name, this);
                    UIObject.Mode = value;
                }
            }
        }
        public T UIObject { get; }
        internal sealed override Object2D UIObj => UIObject;
        protected UIInfo(UITypes type, int mode, string name) : base()
        {
            UIObject = (T)GetUIElement(type, mode, name);
            Mode = mode;
            Name = name;
        }
        private IUIElements GetUIElement(UITypes type, int mode, string name)
        {
            switch (type)
            {
                case UITypes.Window: return new UIWindow(mode, name);
                case UITypes.Text: return new UIText(mode, name);
                case UITypes.Texture: return new UITexture(mode, name);
                default: throw new ArgumentException();
            }
        }
    }
    public class WindowInfo : UIInfo<UIWindow>
    {
        public override UITypes Type => UITypes.Window;
        public bool IsClickable
        {
            get => UIObject.IsClickable;
            set => UIObject.IsClickable = value;
        }
        public Color Color
        {
            get => UIObject.Color;
            set => UIObject.Color = value;
        }
        public Vector2DF Position
        {
            get => UIObject.Position;
            set => UIObject.Position = value;
        }
        public Vector2DF Size
        {
            get => UIObject.Size;
            set => UIObject.Size = value;
        }
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        public Color LineColor
        {
            get => UIObject.LineColor;
            set => UIObject.LineColor = value;
        }
        public int LineThickness
        {
            get => UIObject.Thickness;
            set => UIObject.Thickness = value;
        }
        public bool GeneratingFlame
        {
            get => UIObject.GeneratingFlame;
            set => UIObject.GeneratingFlame = value;
        }
        public WindowInfo(int mode, string name) : base(UITypes.Window, mode, name)
        {

        }
    }
    public class TextInfo : UIInfo<UIText>
    {
        public override UITypes Type => UITypes.Text;
        public bool IsClickable
        {
            get => UIObject.IsClickable;
            set => UIObject.IsClickable = value;
        }
        public Color Color
        {
            get => UIObject.Color;
            set => UIObject.Color = value;
        }
        public Vector2DF Position
        {
            get => UIObject.Position;
            set => UIObject.Position = value;
        }
        public Vector2DF CenterPosition
        {
            get => UIObject.CenterPosition;
            set => UIObject.CenterPosition = value;
        }
        public Vector2DF Size
        {
            get => UIObject.Size;
            set
            {
                var size = UIObject.Font.CalcTextureSize(UIObject.Text, UIObject.WritingDirection).To2DF();
                UIObject.Scale = new Vector2DF(value.X / size.X, value.Y / size.Y);
            }
        }
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        public WritingDirection WritingDirection
        {
            get => UIObject.WritingDirection;
            set => UIObject.WritingDirection = value;
        }
        public string Text
        {
            get => UIObject.Text;
            set => UIObject.Text = value;
        }
        public Font Font
        {
            get => UIObject.Font;
            set
            {
                if (value == null)
                {
                    //ToDo:ここでフォーム内容変更
                    UIObject.Font = DataBase.DefaultFont;
                    FontColor = new ColorDefault(ColorSet.White);
                    FontPath = "NotoSerifCJKjp-Medium.otf";
                    FontSize = 30;
                    OutLineColor = new ColorDefault(ColorSet.Black);
                    OutLineSize = 1;
                }
                else UIObject.Font = value;
            }
        }
        public int FontSize { get; set; } = 30;
        public Color FontColor { get; set; } = new ColorDefault(ColorSet.White);
        public string FontPath { get; set; } = "NotoSerifCJKjp-Medium.otf";
        public int OutLineSize { get; set; } = 1;
        public Color OutLineColor { get; set; } = new ColorDefault(ColorSet.Black);
        internal void SetFont()
        {
            var extension = System.IO.Path.GetExtension(FontPath);
            switch (extension)
            {
                case ".aff": Font = Engine.Graphics.CreateFont(FontPath); break;
                case ".otf":
                case ".ttf":
                case ".ttc": Font = Engine.Graphics.CreateDynamicFont(FontPath, FontSize, FontColor, OutLineSize, OutLineColor); break;
                default: Font = null; break;
            }
        }
        public TextInfo(int mode, string name) : base(UITypes.Text, mode, name)
        {

        }
    }
    public class TextureInfo : UIInfo<UITexture>
    {
        internal WindowEditter Editter => (WindowEditter)HandleForm;
        public override UITypes Type => UITypes.Texture;
        public bool IsClickable
        {
            get => UIObject.IsClickable;
            set => UIObject.IsClickable = value;
        }
        public Color Color
        {
            get => UIObject.Color;
            set => UIObject.Color = value;
        }
        public Vector2DF Position
        {
            get => UIObject.Position;
            set => UIObject.Position = value;
        }
        public Vector2DF CenterPosition
        {
            get => UIObject.CenterPosition;
            set => UIObject.CenterPosition = value;
        }
        public Vector2DF Size
        {
            get => UIObject.Size;
            set => UIObject.Size = value;
        }
        public Texture2D Texture
        {
            get => UIObject.Texture;
            set
            {
                if (value == null)
                {
                    //ToDo:フォームの内容変更
                    TexturePath = "DefaultPicture.png";
                }
                else UIObject.Texture = value;
                //TDo:フォームのSizeの変更
            }
        }
        public string TexturePath { get; set; } = "DefaultPicture.png";
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        public TextureInfo(int mode, string name) : base(UITypes.Texture, mode, name)
        {

        }
    }
}
