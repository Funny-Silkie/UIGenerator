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
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            Engine.ChangeScene(new MainScene());
            Run();
            while (Engine.DoEvents() && !b)
            {
                Engine.Update();
            }
            Engine.Terminate();
        }
        private static async void Run()
        {
            await Task.Run(() => 
            {
                Application.Run(new MainEdittor());
                b = true;
            });
        }
    }
}
