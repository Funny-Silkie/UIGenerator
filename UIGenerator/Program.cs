﻿using System;
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
            Engine.Initialize("NewProject", 640, 480, new EngineOption());
            Engine.File.AddRootPackage("DefaultResource.pack");
            DataBase.Initialize(640, 480, "NewProject");
            using (var form = new MainEdittor())
            {
                form.Show();
                Engine.ChangeScene(DataBase.MainScene);
                while (ContinueUpdating & Engine.DoEvents())
                {
                    Application.DoEvents();
                    Engine.Update();
                }
            }
            Engine.Terminate();
        }
    }
}
