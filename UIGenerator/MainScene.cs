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
        public Layer2DPlus MainLayer { get; } = new Layer2DPlus();
        protected override void OnRegistered()
        {
            AddLayer(MainLayer);
        }
        public void ChangeMode(int mode)
        {
            foreach (var o in DataBase.UIInfos)
            {
                if (o.Mode == DataBase.ShowMode) RemoveObject(o);
                if (o.Mode == mode) AddObject(o);
            }
        }
        public void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            if (info.UIObj is Object2D obj && obj.Layer == null) MainLayer.AddObject(obj);
            else throw new ArgumentException();
        }
        public void RemoveObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            if (info.UIObj is Object2D obj && obj.Layer != null) MainLayer.RemoveObject(obj);
            else throw new ArgumentException();
        }
    }
}
