using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using asd;
using fslib;

namespace UIGenerator
{
    public partial class WindowEditter : Form
    {
        private readonly WindowInfo info;
        public WindowEditter(WindowInfo info)
        {
            this.info = info;
            InitializeComponent();
        }
        private void NumericUpDown_Mode_ValueChanged(object sender, EventArgs e) => info.Mode = (int)NumericUpDown_Mode.Value;

    }
}
