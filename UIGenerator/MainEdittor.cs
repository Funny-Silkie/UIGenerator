﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using asd;

namespace UIGenerator
{
    public partial class MainEdittor : Form
    {
        public const int MinMode = 0;
        public int MaxMode { get; set; } = 0;
        public MainEdittor()
        {
            InitializeComponent();
            ComboBox_Filter_Mode.DataSource = new int[] { 0 };
            var types = new List<string>() { "All" };
            types.AddRange(DataBase.Types);
            ComboBox_Filter_Type.DataSource = types.ToArray();
            ComboBox_Filter_Type.SelectedIndex = 0;
            NumericUpDown_ShowMode.Minimum = MinMode;
            NumericUpDown_ShowMode.Maximum= MaxMode;
        }
        private void NumericUpDown_ShowMode_ValueChanged(object sender, EventArgs e)
        {

        }
        private void 要素を追加するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AddWindow.IsShown) new AddWindow().Show();
        }
    }
}
