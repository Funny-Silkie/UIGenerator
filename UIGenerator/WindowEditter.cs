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
using fslib;

namespace UIGenerator
{
    public partial class WindowEditter : Form
    {
        private readonly WindowInfo info;
        private readonly MainEdittor main;
        public WindowEditter(MainEdittor main, WindowInfo info)
        {
            this.main = main;
            info.HandleForm = this;
            this.info = info;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            NumericUpDown_Mode.Value = info.Mode;
            NumericUpDown_Mode.Name = info.Name;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            NumericUpDown_Pos_X.Value = (decimal)info.Position.X;
            NumericUpDown_Pos_Y.Value = (decimal)info.Position.Y;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            NumericUpDown_Size_X.Value = (decimal)info.Size.X;
            NumericUpDown_Size_Y.Value = (decimal)info.Size.Y;
            NumericUpDown_Thickness.Value = info.LineThickness;
            NumericUpDown_F_R.Value = info.LineColor.R;
            NumericUpDown_F_G.Value = info.LineColor.G;
            NumericUpDown_F_B.Value = info.LineColor.B;
            NumericUpDown_F_A.Value = info.LineColor.A;
            TextBox_Name.Text = info.Name;
            CheckBox_IsClickable.Checked = info.IsClickable;
            CheckBox_Flame.Checked = info.GeneratingFlame;
        }
        private void NumericUpDown_Mode_ValueChanged(object sender, EventArgs e)
        {
            var oldMode = info.Mode;
            var newMode = (int)NumericUpDown_Mode.Value;
            if (newMode != oldMode)
            {
                if (!DataBase.UIInfos.ContainsKeyPair(newMode, info.Name)) info.Mode = newMode;
                else NumericUpDown_Mode.Value = oldMode;
            }
        }
        private void WindowEditter_FormClosed(object sender, FormClosedEventArgs e)
        {
            info.HandleForm = null;
        }
        private void Button_NameSet_Click(object sender, EventArgs e)
        {
            var oldName = info.Name;
            var newName = TextBox_Name.Text;
            if (oldName != newName)
            {
                if (!DataBase.UIInfos.ContainsKeyPair(info.Mode, newName)) info.Name = newName;
                else TextBox_Name.Text = oldName;
            }
        }
        private void CheckBox_IsClickable_CheckedChanged(object sender, EventArgs e) => info.UIObject.IsClickable = CheckBox_IsClickable.Checked;
        private void NumericUpDown_Priority_ValueChanged(object sender, EventArgs e) => info.DrawingPriority = (int)NumericUpDown_Priority.Value;
        private void NumericUpDown_R_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new asd.Color((int)NumericUpDown_R.Value, c.G, c.B, c.A);
        }
        private void NumericUpDown_G_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new asd.Color(c.R, (int)NumericUpDown_G.Value, c.B, c.A);
        }
        private void NumericUpDown_B_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new asd.Color(c.R, c.G, (int)NumericUpDown_B.Value, c.A);
        }
        private void NumericUpDown_A_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new asd.Color(c.R, c.G, c.B, (int)NumericUpDown_A.Value);
        }
        private void NumericUpDown_Pos_X_ValueChanged(object sender, EventArgs e) => info.Position = new Vector2DF((float)NumericUpDown_Pos_X.Value, info.Position.Y);
        private void NumericUpDown_Pos_Y_ValueChanged(object sender, EventArgs e) => info.Position = new Vector2DF(info.Position.X, (float)NumericUpDown_Pos_Y.Value);
        private void NumericUpDown_Size_X_ValueChanged(object sender, EventArgs e) => info.Size = new Vector2DF((float)NumericUpDown_Size_X.Value, info.Size.Y);
        private void NumericUpDown_Size_Y_ValueChanged(object sender, EventArgs e) => info.Size = new Vector2DF(info.Size.X, (float)NumericUpDown_Size_Y.Value);
        private void CheckBox_Flame_CheckedChanged(object sender, EventArgs e)
        {
            info.GeneratingFlame = CheckBox_Flame.Checked;
            NumericUpDown_Thickness.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_R.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_G.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_B.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_A.Enabled = CheckBox_Flame.Checked;
        }
        private void NumericUpDown_Thickness_ValueChanged(object sender, EventArgs e) => info.LineThickness = (int)NumericUpDown_Thickness.Value;
        private void NumericUpDown_F_R_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new asd.Color((int)NumericUpDown_F_R.Value, c.G, c.B, c.A);
        }
        private void NumericUpDown_F_G_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new asd.Color(c.R, (int)NumericUpDown_F_G.Value, c.B, c.A);
        }
        private void NumericUpDown_F_B_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new asd.Color(c.R, c.G, (int)NumericUpDown_F_B.Value, c.A);
        }
        private void NumericUpDown_F_A_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new asd.Color(c.R, c.G, c.B, (int)NumericUpDown_F_A.Value);
        }
    }
}