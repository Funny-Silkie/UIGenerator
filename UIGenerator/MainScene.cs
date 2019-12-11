using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

namespace UIGenerator
{
    public class MainScene : Scene
    {
        public Layer2DPlus MainLayer { get; }
        public MainScene()
        {
            MainLayer = new Layer2DPlus();
        }
        protected override void OnRegistered()
        {
            AddLayer(MainLayer);
        }
        public void ChangeMode(int mode)
        {
            foreach (var o in DataBase.UIInfos)
            {
                if (o.Value.Mode == DataBase.ShowMode) RemoveObject(o.Value);
                if (o.Value.Mode == mode) AddObject(o.Value);
            }
            DataBase.ShowMode = mode;
        }
        public void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            if (info.UIObj.Layer == null)
                switch (info)
                {
                    case WindowInfo win: MainLayer.AddObject(win.UIObject); return;
                    case TextInfo tt: MainLayer.AddObject(tt.UIObject); return;
                    case TextureInfo te: MainLayer.AddObject(te.UIObject); return;
                }
            else throw new ArgumentException();
        }
        public void RemoveObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            if (info.UIObj.Layer != null) MainLayer.RemoveObject(info.UIObj);
            else throw new ArgumentException();
        }
    }
}
