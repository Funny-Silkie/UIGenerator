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
        public abstract string Name { get; set; }
        public abstract int Mode { get; set; }
        public abstract IUIElements UIObj { get; }
        protected private UIInfoBase()
        {

        }
        public static UIInfoBase GetInstance(UITypes type, int mode, string name)
        {
            switch (type)
            {
                case UITypes.Window: return new WindowInfo(mode, name);
                default: throw new ArgumentException();
            }
        }
    }
    public abstract class UIInfo<T> : UIInfoBase where T : IUIElements
    {
        public override string Name
        {
            get => UIObject.Name;
            set => UIObject.Name = value;
        }
        public override int Mode
        {
            get => UIObject.Mode;
            set => UIObject.Mode = value;
        }
        public T UIObject { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override IUIElements UIObj => UIObject;
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
                default: throw new ArgumentException();
            }
        }
    }
    public class WindowInfo : UIInfo<UIWindow>
    {
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
}
