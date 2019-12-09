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
        static MainEdittor MainEdittor;
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            Application.Run(MainEdittor = new MainEdittor());
            Application.LeaveThreadModal += new EventHandler(Update);
            Engine.Terminate();
        }
        static void Update(object sender, EventArgs e)
        {
            if (Engine.DoEvents())
            {
                Console.WriteLine("Updated");
                Engine.Update();
            }
            else MainEdittor.Close();
        }
    }
}
