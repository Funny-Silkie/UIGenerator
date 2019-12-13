﻿using System;
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
                case UITypes.Text: return new TextObjInfo(mode, name);
                case UITypes.Texture: return new TextureObjInfo(mode, name);
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
    public class TextObjInfo : UIInfo<UIText>
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
            set => UIObject.Font = value;
        }
        internal FontInfoBase FontInfo
        {
            get => _fontInfo;
            set
            {
                if (value == null) value = DataBase.DefaultFont;
                _fontInfo = value;
                Font = value.Font;
            }
        }
        private FontInfoBase _fontInfo;
        public TextObjInfo(int mode, string name) : base(UITypes.Text, mode, name)
        {

        }
    }
    public class TextureObjInfo : UIInfo<UITexture>
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
            set => UIObject.Texture = value;
        }
        internal TextureInfo TextureInfo
        {
            get => _textureInfo;
            set
            {
                if (value == null) value = DataBase.DefaultTexture;
                _textureInfo = value;
                Texture = value.Texture;
            }
        }
        private TextureInfo _textureInfo;
        public int DrawingPriority
        {
            get => UIObject.DrawingPriority;
            set => UIObject.DrawingPriority = value;
        }
        public TextureObjInfo(int mode, string name) : base(UITypes.Texture, mode, name)
        {

        }
    }
}
