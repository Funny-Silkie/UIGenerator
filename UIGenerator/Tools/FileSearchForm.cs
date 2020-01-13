using System;
using System.Windows.Forms;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// ファイル検索フォーム
    /// </summary>
    public partial class FileSearchForm : Form
    {
        /// <summary>
        /// インスタンスとして存在するか廊下を取得する
        /// </summary>
        public static bool Instanced { get; private set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FileSearchForm()
        {
            Instanced = true;
            InitializeComponent();
        }
        /// <summary>
        /// ファイルを検索する
        /// </summary>
        private void Button_Search_Click(object sender, EventArgs e)
        {
            var ex = Engine.File.Exists(TextBox_Path.Text);
            var text = ex ? "ファイルが見つかりました" : "ファイルが見つかりませんでした";
            Console.WriteLine(text);
            RichTextBox_Log.Text = text;
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void FileSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            Instanced = false;
        }
    }
}
