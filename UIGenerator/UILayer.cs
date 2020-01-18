using System;
using System.Collections.Generic;
using System.Linq;
using asd;
using fslib;
using UIGeneratorObjects;

namespace UIProject
{
    public class UILayerTest : UIGeneratorObjects.UILayer
    {
        public UILayerTest()
        {
            InitObjects();
        }
        private void InitObjects()
        {
            AddUIObject(new UIText(0, "Text")
            {
                IsClickable = true,
                Color = new Color(99, 255, 255, 255),
                Position = new Vector2DF(105, 87),
                CenterPosition = new Vector2DF(0, 0),
                Scale = new Vector2DF(1, 1),
                DrawingPriority = 0,
                WritingDirection = WritingDirection.Horizontal,
                Text = "Hello",
                Font = Engine.Graphics.CreateDynamicFont("Resource/NotoSerifCJKjp-Medium.otf", 30, new Color(255, 255, 255, 255), 1, new Color(0, 0, 0, 255))
            });
        }
        protected override void OnDrawAdditionally()
        {
            switch (Mode)
            {
                case 0:
                    DrawLineAdditionally(new Vector2DF(200, 360), new Vector2DF(530, 360), 3, new Color(255, 0, 0, 255), AlphaBlendMode.Opacity, 0); // Line1
                break
            }
        }
    }
}
