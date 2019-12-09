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
        public static bool IsShown { get; set; } = false;
        public AddWindow()
        {
            IsShown = true;
            InitializeComponent();
            var types = new List<string>() { "All" };
            types.AddRange(DataBase.Types);
            ComboBox_Type.DataSource = types.ToArray();
        }
        private void AddWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShown = false;
        }
    }
}
