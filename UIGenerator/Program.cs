using System;
using System.Threading;
using System.Windows.Forms;
using asd;

namespace UIGenerator
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            SynchronizationContext.SetSynchronizationContext(DataBase.SynchronizationContext);
            var form = new MainEdittor();
            form.Show();
            Engine.ChangeScene(new MainScene());
            while (Engine.DoEvents())
            {
                Application.DoEvents();
                Engine.Update();
                DataBase.SynchronizationContext.Update();
            }
            if (!form.IsDisposed) form.Dispose();
            Engine.Terminate();
        }
    }
}
