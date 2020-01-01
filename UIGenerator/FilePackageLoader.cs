using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using asd;
using fslib;
using fslib.IO;

namespace UIGenerator
{
    /// <summary>
    /// ファイルパッケージを読み込むクラス
    /// </summary>
    public partial class FilePackageLoader : Form
    {
        /// <summary>
        /// インスタンスが存在するかどうかを取得する
        /// </summary>
        public static bool Instanced { get; private set; } = false;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FilePackageLoader()
        {
            Instanced = true;
            InitializeComponent();
        }
        private void FilePackageLoader_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instanced = false;
            DataBase.Forms.Remove(this);
        }
        private void Button_Ref_Click(object sender, EventArgs e)
        {
            var name = TextBox_Path.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the File Package",
                Filter = FilePathHelper.GetFilter("File Package", ".pack")
            };
            var thread = new Thread(new ParameterizedThreadStart(x =>
            {
                var state = o.ShowDialog();
                if (state == DialogResult.OK)
                {
                    name = o.FileName;
                }
            }));
            o.Dispose();
            TextBox_Path.Text = name;
        }
        private void CheckBox_PassWord_CheckedChanged(object sender, EventArgs e) => TextBox_PassWord.Enabled = CheckBox_PassWord.Checked;
        private void Button_Register_Click(object sender, EventArgs e)
        {
            if (!Engine.File.Exists(TextBox_Path.Text)) return;
            if (CheckBox_PassWord.Checked) Engine.File.AddRootPackageWithPassword(TextBox_Path.Text, TextBox_PassWord.Text);
            else Engine.File.AddRootPackage(TextBox_Path.Text);
            DataBase.FllePackages.Add(TextBox_Path.Text);
        }
    }
}
