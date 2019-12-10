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
    public class UIText : ClickableText, IUIElements
    {
        public int Mode { get; set; }
        public string Name { get; set; }
        public UIText(int mode, string name) : base()
        {
            Mode = mode;
            Name = name;
        }
        public event EventHandler MouseClicked;
        public event EventHandler MouseEnter;
        public event EventHandler MouseExit;
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnCursorEnter()
        {
            MouseEnter.Invoke(this, EventArgs.Empty);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnCursorExit()
        {
            MouseExit.Invoke(this, EventArgs.Empty);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnLeftPushed()
        {
            MouseClicked.Invoke(this, new ClickArg(MouseButtons.ButtonLeft));
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override void OnRightPushed()
        {
            MouseClicked.Invoke(this, new ClickArg(MouseButtons.ButtonRight));
        }
    }
}
