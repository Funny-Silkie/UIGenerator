using System;
using System.Windows.Forms;
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
        public static bool Instanced => SingleInstance != null;
        /// <summary>
        /// 唯一のインスタンスを取得する
        /// </summary>
        public static FilePackageLoader SingleInstance { get; private set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private FilePackageLoader()
        {
            SingleInstance = this;
            InitializeComponent();
            UpdateStyles();
        }
        /// <summary>
        /// フォームが閉じられたときに実行
        /// </summary>
        private void FilePackageLoader_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingleInstance = null;
            DataBase.Forms.Remove(this);
        }
        /// <summary>
        /// 読み込むファイルパッケージの参照を持つ
        /// </summary>
        private void Button_Ref_Click(object sender, EventArgs e)
        {
            var name = TextBox_Path.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the File Package",
                Filter = FilePathHelper.GetFilter("File Package", ".pack")
            };
            var state = o.ShowDialog();
            if (state == DialogResult.OK) name = o.FileName;
            o.Dispose();
            TextBox_Path.Text = name;
        }
        /// <summary>
        /// パスワードの有無を変更
        /// </summary>
        private void CheckBox_PassWord_CheckedChanged(object sender, EventArgs e) => TextBox_PassWord.Enabled = CheckBox_PassWord.Checked;
        /// <summary>
        /// ファイルパッケージの読み込み
        /// </summary>
        private void Button_Register_Click(object sender, EventArgs e)
        {
            var path = TextBox_Path.Text;
            var passWord = TextBox_PassWord.Text;
            var check = CheckBox_PassWord.Checked;
            var s = check ? DataBase.FllePackages.Add(path, passWord) : DataBase.FllePackages.Add(path);
            Console.WriteLine(s ? "Succeeded to register filepackage" : "Failed to register filepackage");
            if (!s) return;
            ClearForm();
        }
        /// <summary>
        /// ファイルパッケージの削除
        /// </summary>
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            var path = TextBox_Path.Text;
            var passWord = TextBox_PassWord.Text;
            var check = CheckBox_PassWord.Checked;
            var index = check ? DataBase.FllePackages.IndexOf(path, passWord) : DataBase.FllePackages.IndexOf(path);
            var s = check ? DataBase.FllePackages.Remove(path, passWord) : DataBase.FllePackages.Remove(path);
            Console.WriteLine(s ? "Succeeded to remove filepackage" : "Failed to remove filepackage");
            if (!s) return;
            ListView_Packages.Items.RemoveAt(index);
            ClearForm();
        }
        /// <summary>
        /// フォームのリセット
        /// </summary>
        private void ClearForm()
        {
            TextBox_Path.Text = "";
            TextBox_PassWord.Text = "";
            UpdateListView();
        }
        /// <summary>
        /// <see cref="ListView_Packages"/>を更新する
        /// </summary>
        private void UpdateListView()
        {
            ListView_Packages.Items.Clear();
            var names = DataBase.FllePackages.GetNames();
            for (int i = 0; i < names.Length; i++) ListView_Packages.Items.Add(names[i]);
        }
        /// <summary>
        /// インスタンスを生成して表示する
        /// </summary>
        public static bool CreateAndShow()
        {
            if (!Instanced)
            {
                var form = new FilePackageLoader();
                DataBase.Forms.Add(form);
                form.Show();
                return true;
            }
            return false;
        }
    }
}
