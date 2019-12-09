using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

namespace UIGenerator
{
    public class DataBase
    {
        public static string[] Types { get; } = new string[] { "Text", "Texture", "Window" };
        public static MainScene MainScene { get; } = new MainScene();
    }
}
