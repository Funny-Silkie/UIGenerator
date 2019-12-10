using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using asd;
using fslib;

namespace UIGenerator
{
    public class Program
    {
        static bool b = false;
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            UpdateAsync();
            while (Engine.DoEvents() && !b)
            {
                Engine.Update();
            }
            Engine.Terminate();
        }
        private static async void UpdateAsync()
        {
            await Task.Run(() => Update());
        }
        private static void Update()
        {
            Application.Run(new MainEdittor());
            b = true;
        }
    }
}
