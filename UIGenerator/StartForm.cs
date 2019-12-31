using System;
using System.Windows.Forms;

namespace UIGenerator
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
        private void Button_init_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TextBox_length.Text, out int length) && int.TryParse(TextBox_wide.Text, out int wide) && length > 0 && wide > 0)
            {
                asd.Engine.Initialize(TextBox_Name.Text, wide, length, new asd.EngineOption());
                DataBase.ProjectName = TextBox_Name.Text;
                DataBase.WindowSize = new fslib.Serialization.SerializableVector2DI(wide, length);
                Close();
            }
            TextBox_length.Text = "";
            TextBox_wide.Text = "";
        }
    }
}
