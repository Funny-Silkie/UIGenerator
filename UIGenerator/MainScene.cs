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
            MainLayer = new Layer2DPlus() { Name = "Main" };
        }
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
            DataBase.ShowMode = mode;
        }
        public void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            if (info.UIObj.Layer == null) MainLayer.AddObject(info.UIObj);
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
