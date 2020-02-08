using System;
using System.Windows.Forms;

namespace UIGenerator
{
    /// <summary>
    /// オプションを操作するフォーム
    /// </summary>
    public partial class OptionForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OptionForm()
        {
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// フォームを初期化する
        /// </summary>
        private void Init()
        {
            NumericUpDown_Window_X.Value = DataBase.WindowSize.X;
            NumericUpDown_Window_Y.Value = DataBase.WindowSize.Y;
            TextBox_ProjectName.Text = DataBase.ProjectName;
        }
        /// <summary>
        /// 設定を保存
        /// </summary>
        private void Button_Save_Click(object sender, EventArgs e)
        {
            DataBase.ProjectName = TextBox_ProjectName.Text;
            DataBase.WindowSize = new SerializableVector2DI((int)NumericUpDown_Window_X.Value, (int)NumericUpDown_Window_Y.Value);
            Close();
        }
        /// <summary>
        /// 設定を保存せずに閉じる
        /// </summary>
        private void Button_Cancel_Click(object sender, EventArgs e) => Close();
    }
}
