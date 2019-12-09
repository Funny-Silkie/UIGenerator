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
    }
}
