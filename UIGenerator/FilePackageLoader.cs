﻿using System;
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
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            o.Dispose();
            TextBox_Path.Text = name;
        }
        private void CheckBox_PassWord_CheckedChanged(object sender, EventArgs e) => TextBox_PassWord.Enabled = CheckBox_PassWord.Checked;
        private void Button_Register_Click(object sender, EventArgs e)
        {
            var s = CheckBox_PassWord.Checked ? DataBase.FllePackages.Add(TextBox_Path.Text) : DataBase.FllePackages.Add(TextBox_Path.Text, TextBox_PassWord.Text);
            Console.WriteLine(s ? "Succeeded to register filepackage" : "Failed to register file package");
            if (!s) return;
            ListView_Packages.Items.Add(TextBox_Path.Text + (s ? $"PassWord({TextBox_PassWord.Text})" : ""));
            ClearForm();
        }
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            var index = CheckBox_PassWord.Checked ? DataBase.FllePackages.IndexOf(TextBox_Path.Text, TextBox_PassWord.Text) : DataBase.FllePackages.IndexOf(TextBox_Path.Text);
            var s = CheckBox_PassWord.Checked ? DataBase.FllePackages.Remove(TextBox_Path.Text) : DataBase.FllePackages.Remove(TextBox_Path.Text, TextBox_PassWord.Text);
            Console.WriteLine(s ? "Succeeded to register filepackage" : "Failed to register file package");
            if (!s) return;
            ListView_Packages.Items.RemoveAt(index);
            ClearForm();
        }
        private void ClearForm()
        {
            TextBox_Path.Text = "";
            TextBox_PassWord.Text = "";
        }
    }
}
