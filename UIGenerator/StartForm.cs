using asd;
using System;
using System.Windows.Forms;

namespace UIGenerator
{
    /// <summary>
    /// 最初に起動するウィンドウ
    /// </summary>
    public partial class StartForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// プロジェクトの初期化を行う
        /// </summary>
        private void Button_init_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TextBox_length.Text, out var length) && int.TryParse(TextBox_wide.Text, out var wide) && length > 0 && wide > 0)
            {
                Engine.Initialize(TextBox_Name.Text, wide, length, new EngineOption());
                DataBase.Initialize(wide, length, TextBox_wide.Text);
                Close();
            }
            TextBox_length.Text = "";
            TextBox_wide.Text = "";
        }
    }
}
