using System;
using System.Windows.Forms;
using asd;

namespace UIGenerator
{
    public class Program
    {
        /// <summary>
        /// 更新を続けるかどうかを取得または設定する
        /// </summary>
        public static bool ContinueUpdating { get; set; } = true;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            var form = new MainEdittor();
            form.Show();
            Engine.ChangeScene(new MainScene());
            while (ContinueUpdating & Engine.DoEvents())
            {
                Application.DoEvents();
                Engine.Update();
            }
            if (!form.IsDisposed) form.Dispose();
            Engine.Terminate();
        }
    }
}
