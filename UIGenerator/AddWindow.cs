using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIGenerator
{
    public partial class AddWindow : Form
    {
        private readonly MainEdittor mainEdittor;
        public static bool IsShown { get; set; } = false;
        public AddWindow(MainEdittor main)
        {
            mainEdittor = main ?? throw new ArgumentNullException();
            IsShown = true;
            InitializeComponent();
            ComboBox_Type.DataSource = DataBase.Types;
            NumericUpDown_Mode.Minimum = DataBase.MinMode;
            NumericUpDown_Mode.Maximum = DataBase.MaxMode;
        }
        private void AddWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShown = false;
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            var mode = (int)NumericUpDown_Mode.Value;
            var type = (UITypes)Enum.Parse(typeof(UITypes), ComboBox_Type.Text);
            if (mode > DataBase.MaxMode) DataBase.MaxMode = mode;
            DataBase.AddObject(UIInfoBase.GetInstance(type, mode, TextBox_Name.Text));
            var item = mainEdittor.ListView_Main.Items.Add(ComboBox_Type.Text);
            item.SubItems.Add(TextBox_Name.Text);
            item.SubItems.Add(mode.ToString());
            Reset();
        }
        private void Reset()
        {
            TextBox_Name.Text = "";
            NumericUpDown_Mode.Value = DataBase.MinMode;
        }
    }
}
