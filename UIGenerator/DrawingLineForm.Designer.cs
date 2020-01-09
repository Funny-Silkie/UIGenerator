namespace UIGenerator
{
    partial class DrawingLineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_NameSet = new System.Windows.Forms.Button();
            this.NumericUpDown_Priority = new System.Windows.Forms.NumericUpDown();
            this.Label_Priority = new System.Windows.Forms.Label();
            this.NumericUpDown_Mode = new System.Windows.Forms.NumericUpDown();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.Panel_Color = new System.Windows.Forms.Panel();
            this.NumericUpDown_A = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_B = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_G = new System.Windows.Forms.NumericUpDown();
            this.Label_Color_A = new System.Windows.Forms.Label();
            this.NumericUpDown_R = new System.Windows.Forms.NumericUpDown();
            this.Label_Color_G = new System.Windows.Forms.Label();
            this.Label_Color_B = new System.Windows.Forms.Label();
            this.Label_Color = new System.Windows.Forms.Label();
            this.Label_Color_R = new System.Windows.Forms.Label();
            this.Panel_Positions = new System.Windows.Forms.Panel();
            this.NumericUpDown_Pos2_Y = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Pos1_Y = new System.Windows.Forms.NumericUpDown();
            this.Label_Size_Y = new System.Windows.Forms.Label();
            this.Label_Pos_Y = new System.Windows.Forms.Label();
            this.NumericUpDown_Pos2_X = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Pos1_X = new System.Windows.Forms.NumericUpDown();
            this.Label_Size_X = new System.Windows.Forms.Label();
            this.Label_Position2 = new System.Windows.Forms.Label();
            this.Label_Pos_X = new System.Windows.Forms.Label();
            this.Label_Position1 = new System.Windows.Forms.Label();
            this.NumericUpDown_Thickness = new System.Windows.Forms.NumericUpDown();
            this.Label_Thickness = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Priority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).BeginInit();
            this.Panel_Color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_R)).BeginInit();
            this.Panel_Positions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos2_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos1_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos2_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos1_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Thickness)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_NameSet
            // 
            this.Button_NameSet.AutoSize = true;
            this.Button_NameSet.Location = new System.Drawing.Point(486, 30);
            this.Button_NameSet.Name = "Button_NameSet";
            this.Button_NameSet.Size = new System.Drawing.Size(75, 25);
            this.Button_NameSet.TabIndex = 11;
            this.Button_NameSet.Text = "Set";
            this.Button_NameSet.UseVisualStyleBackColor = true;
            this.Button_NameSet.Click += new System.EventHandler(this.Button_NameSet_Click);
            // 
            // NumericUpDown_Priority
            // 
            this.NumericUpDown_Priority.Location = new System.Drawing.Point(183, 78);
            this.NumericUpDown_Priority.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Priority.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NumericUpDown_Priority.Name = "NumericUpDown_Priority";
            this.NumericUpDown_Priority.Size = new System.Drawing.Size(68, 22);
            this.NumericUpDown_Priority.TabIndex = 12;
            this.NumericUpDown_Priority.ValueChanged += new System.EventHandler(this.NumericUpDown_Priority_ValueChanged);
            // 
            // Label_Priority
            // 
            this.Label_Priority.AutoSize = true;
            this.Label_Priority.Location = new System.Drawing.Point(24, 80);
            this.Label_Priority.Name = "Label_Priority";
            this.Label_Priority.Size = new System.Drawing.Size(102, 15);
            this.Label_Priority.TabIndex = 13;
            this.Label_Priority.Text = "DrawingPriority";
            // 
            // NumericUpDown_Mode
            // 
            this.NumericUpDown_Mode.Location = new System.Drawing.Point(88, 32);
            this.NumericUpDown_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Mode.Name = "NumericUpDown_Mode";
            this.NumericUpDown_Mode.Size = new System.Drawing.Size(72, 22);
            this.NumericUpDown_Mode.TabIndex = 7;
            this.NumericUpDown_Mode.ValueChanged += new System.EventHandler(this.NumericUpDown_Mode_ValueChanged);
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(278, 31);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(175, 22);
            this.TextBox_Name.TabIndex = 10;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(208, 34);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Name.TabIndex = 8;
            this.Label_Name.Text = "Name";
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.Location = new System.Drawing.Point(24, 34);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Mode.TabIndex = 9;
            this.Label_Mode.Text = "Mode";
            // 
            // Panel_Color
            // 
            this.Panel_Color.BackColor = System.Drawing.Color.White;
            this.Panel_Color.Controls.Add(this.NumericUpDown_A);
            this.Panel_Color.Controls.Add(this.NumericUpDown_B);
            this.Panel_Color.Controls.Add(this.NumericUpDown_G);
            this.Panel_Color.Controls.Add(this.Label_Color_A);
            this.Panel_Color.Controls.Add(this.NumericUpDown_R);
            this.Panel_Color.Controls.Add(this.Label_Color_G);
            this.Panel_Color.Controls.Add(this.Label_Color_B);
            this.Panel_Color.Controls.Add(this.Label_Color);
            this.Panel_Color.Controls.Add(this.Label_Color_R);
            this.Panel_Color.Location = new System.Drawing.Point(27, 170);
            this.Panel_Color.Name = "Panel_Color";
            this.Panel_Color.Size = new System.Drawing.Size(566, 88);
            this.Panel_Color.TabIndex = 14;
            // 
            // NumericUpDown_A
            // 
            this.NumericUpDown_A.Location = new System.Drawing.Point(462, 39);
            this.NumericUpDown_A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_A.Name = "NumericUpDown_A";
            this.NumericUpDown_A.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_A.TabIndex = 8;
            this.NumericUpDown_A.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_A.ValueChanged += new System.EventHandler(this.NumericUpDown_A_ValueChanged);
            // 
            // NumericUpDown_B
            // 
            this.NumericUpDown_B.Location = new System.Drawing.Point(327, 39);
            this.NumericUpDown_B.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_B.Name = "NumericUpDown_B";
            this.NumericUpDown_B.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_B.TabIndex = 7;
            this.NumericUpDown_B.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_B.ValueChanged += new System.EventHandler(this.NumericUpDown_B_ValueChanged);
            // 
            // NumericUpDown_G
            // 
            this.NumericUpDown_G.Location = new System.Drawing.Point(187, 39);
            this.NumericUpDown_G.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_G.Name = "NumericUpDown_G";
            this.NumericUpDown_G.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_G.TabIndex = 6;
            this.NumericUpDown_G.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_G.ValueChanged += new System.EventHandler(this.NumericUpDown_G_ValueChanged);
            // 
            // Label_Color_A
            // 
            this.Label_Color_A.AutoSize = true;
            this.Label_Color_A.Location = new System.Drawing.Point(424, 41);
            this.Label_Color_A.Name = "Label_Color_A";
            this.Label_Color_A.Size = new System.Drawing.Size(16, 15);
            this.Label_Color_A.TabIndex = 0;
            this.Label_Color_A.Text = "A";
            // 
            // NumericUpDown_R
            // 
            this.NumericUpDown_R.Location = new System.Drawing.Point(52, 39);
            this.NumericUpDown_R.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_R.Name = "NumericUpDown_R";
            this.NumericUpDown_R.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_R.TabIndex = 5;
            this.NumericUpDown_R.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumericUpDown_R.ValueChanged += new System.EventHandler(this.NumericUpDown_R_ValueChanged);
            // 
            // Label_Color_G
            // 
            this.Label_Color_G.AutoSize = true;
            this.Label_Color_G.Location = new System.Drawing.Point(149, 41);
            this.Label_Color_G.Name = "Label_Color_G";
            this.Label_Color_G.Size = new System.Drawing.Size(17, 15);
            this.Label_Color_G.TabIndex = 0;
            this.Label_Color_G.Text = "G";
            // 
            // Label_Color_B
            // 
            this.Label_Color_B.AutoSize = true;
            this.Label_Color_B.Location = new System.Drawing.Point(289, 41);
            this.Label_Color_B.Name = "Label_Color_B";
            this.Label_Color_B.Size = new System.Drawing.Size(17, 15);
            this.Label_Color_B.TabIndex = 0;
            this.Label_Color_B.Text = "B";
            // 
            // Label_Color
            // 
            this.Label_Color.AutoSize = true;
            this.Label_Color.Location = new System.Drawing.Point(14, 14);
            this.Label_Color.Name = "Label_Color";
            this.Label_Color.Size = new System.Drawing.Size(41, 15);
            this.Label_Color.TabIndex = 0;
            this.Label_Color.Text = "Color";
            // 
            // Label_Color_R
            // 
            this.Label_Color_R.AutoSize = true;
            this.Label_Color_R.Location = new System.Drawing.Point(14, 41);
            this.Label_Color_R.Name = "Label_Color_R";
            this.Label_Color_R.Size = new System.Drawing.Size(16, 15);
            this.Label_Color_R.TabIndex = 0;
            this.Label_Color_R.Text = "R";
            // 
            // Panel_Positions
            // 
            this.Panel_Positions.BackColor = System.Drawing.Color.White;
            this.Panel_Positions.Controls.Add(this.NumericUpDown_Pos2_Y);
            this.Panel_Positions.Controls.Add(this.NumericUpDown_Pos1_Y);
            this.Panel_Positions.Controls.Add(this.Label_Size_Y);
            this.Panel_Positions.Controls.Add(this.Label_Pos_Y);
            this.Panel_Positions.Controls.Add(this.NumericUpDown_Pos2_X);
            this.Panel_Positions.Controls.Add(this.NumericUpDown_Pos1_X);
            this.Panel_Positions.Controls.Add(this.Label_Size_X);
            this.Panel_Positions.Controls.Add(this.Label_Position2);
            this.Panel_Positions.Controls.Add(this.Label_Pos_X);
            this.Panel_Positions.Controls.Add(this.Label_Position1);
            this.Panel_Positions.Location = new System.Drawing.Point(27, 285);
            this.Panel_Positions.Name = "Panel_Positions";
            this.Panel_Positions.Size = new System.Drawing.Size(566, 105);
            this.Panel_Positions.TabIndex = 15;
            // 
            // NumericUpDown_Pos2_Y
            // 
            this.NumericUpDown_Pos2_Y.Location = new System.Drawing.Point(459, 46);
            this.NumericUpDown_Pos2_Y.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Pos2_Y.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Pos2_Y.Name = "NumericUpDown_Pos2_Y";
            this.NumericUpDown_Pos2_Y.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Pos2_Y.TabIndex = 13;
            this.NumericUpDown_Pos2_Y.ValueChanged += new System.EventHandler(this.NumericUpDown_Size_Y_ValueChanged);
            // 
            // NumericUpDown_Pos1_Y
            // 
            this.NumericUpDown_Pos1_Y.Location = new System.Drawing.Point(184, 46);
            this.NumericUpDown_Pos1_Y.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Pos1_Y.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Pos1_Y.Name = "NumericUpDown_Pos1_Y";
            this.NumericUpDown_Pos1_Y.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Pos1_Y.TabIndex = 9;
            this.NumericUpDown_Pos1_Y.ValueChanged += new System.EventHandler(this.NumericUpDown_Pos_Y_ValueChanged);
            // 
            // Label_Size_Y
            // 
            this.Label_Size_Y.AutoSize = true;
            this.Label_Size_Y.Location = new System.Drawing.Point(421, 48);
            this.Label_Size_Y.Name = "Label_Size_Y";
            this.Label_Size_Y.Size = new System.Drawing.Size(16, 15);
            this.Label_Size_Y.TabIndex = 0;
            this.Label_Size_Y.Text = "Y";
            // 
            // Label_Pos_Y
            // 
            this.Label_Pos_Y.AutoSize = true;
            this.Label_Pos_Y.Location = new System.Drawing.Point(146, 48);
            this.Label_Pos_Y.Name = "Label_Pos_Y";
            this.Label_Pos_Y.Size = new System.Drawing.Size(16, 15);
            this.Label_Pos_Y.TabIndex = 0;
            this.Label_Pos_Y.Text = "Y";
            // 
            // NumericUpDown_Pos2_X
            // 
            this.NumericUpDown_Pos2_X.Location = new System.Drawing.Point(324, 46);
            this.NumericUpDown_Pos2_X.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Pos2_X.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Pos2_X.Name = "NumericUpDown_Pos2_X";
            this.NumericUpDown_Pos2_X.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Pos2_X.TabIndex = 12;
            this.NumericUpDown_Pos2_X.ValueChanged += new System.EventHandler(this.NumericUpDown_Size_X_ValueChanged);
            // 
            // NumericUpDown_Pos1_X
            // 
            this.NumericUpDown_Pos1_X.Location = new System.Drawing.Point(49, 46);
            this.NumericUpDown_Pos1_X.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Pos1_X.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Pos1_X.Name = "NumericUpDown_Pos1_X";
            this.NumericUpDown_Pos1_X.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Pos1_X.TabIndex = 8;
            this.NumericUpDown_Pos1_X.ValueChanged += new System.EventHandler(this.NumericUpDown_Pos_X_ValueChanged);
            // 
            // Label_Size_X
            // 
            this.Label_Size_X.AutoSize = true;
            this.Label_Size_X.Location = new System.Drawing.Point(286, 48);
            this.Label_Size_X.Name = "Label_Size_X";
            this.Label_Size_X.Size = new System.Drawing.Size(16, 15);
            this.Label_Size_X.TabIndex = 0;
            this.Label_Size_X.Text = "X";
            // 
            // Label_Position2
            // 
            this.Label_Position2.AutoSize = true;
            this.Label_Position2.Location = new System.Drawing.Point(286, 15);
            this.Label_Position2.Name = "Label_Position2";
            this.Label_Position2.Size = new System.Drawing.Size(66, 15);
            this.Label_Position2.TabIndex = 0;
            this.Label_Position2.Text = "Position2";
            // 
            // Label_Pos_X
            // 
            this.Label_Pos_X.AutoSize = true;
            this.Label_Pos_X.Location = new System.Drawing.Point(11, 48);
            this.Label_Pos_X.Name = "Label_Pos_X";
            this.Label_Pos_X.Size = new System.Drawing.Size(16, 15);
            this.Label_Pos_X.TabIndex = 0;
            this.Label_Pos_X.Text = "X";
            // 
            // Label_Position1
            // 
            this.Label_Position1.AutoSize = true;
            this.Label_Position1.Location = new System.Drawing.Point(11, 15);
            this.Label_Position1.Name = "Label_Position1";
            this.Label_Position1.Size = new System.Drawing.Size(66, 15);
            this.Label_Position1.TabIndex = 0;
            this.Label_Position1.Text = "Position1";
            // 
            // NumericUpDown_Thickness
            // 
            this.NumericUpDown_Thickness.Location = new System.Drawing.Point(121, 121);
            this.NumericUpDown_Thickness.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Thickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Thickness.Name = "NumericUpDown_Thickness";
            this.NumericUpDown_Thickness.Size = new System.Drawing.Size(120, 22);
            this.NumericUpDown_Thickness.TabIndex = 17;
            this.NumericUpDown_Thickness.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown_Thickness.ValueChanged += new System.EventHandler(this.NumericUpDown_Thickness_ValueChanged);
            // 
            // Label_Thickness
            // 
            this.Label_Thickness.AutoSize = true;
            this.Label_Thickness.Location = new System.Drawing.Point(24, 123);
            this.Label_Thickness.Name = "Label_Thickness";
            this.Label_Thickness.Size = new System.Drawing.Size(72, 15);
            this.Label_Thickness.TabIndex = 16;
            this.Label_Thickness.Text = "Thickness";
            // 
            // DrawingLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 420);
            this.Controls.Add(this.NumericUpDown_Thickness);
            this.Controls.Add(this.Label_Thickness);
            this.Controls.Add(this.Panel_Positions);
            this.Controls.Add(this.Panel_Color);
            this.Controls.Add(this.Button_NameSet);
            this.Controls.Add(this.NumericUpDown_Priority);
            this.Controls.Add(this.Label_Priority);
            this.Controls.Add(this.NumericUpDown_Mode);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Label_Mode);
            this.Name = "DrawingLineForm";
            this.Text = "DrawingLineForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrawingLineForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Priority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).EndInit();
            this.Panel_Color.ResumeLayout(false);
            this.Panel_Color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_R)).EndInit();
            this.Panel_Positions.ResumeLayout(false);
            this.Panel_Positions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos2_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos1_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos2_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Pos1_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Thickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_NameSet;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Priority;
        private System.Windows.Forms.Label Label_Priority;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Mode;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_Mode;
        private System.Windows.Forms.Panel Panel_Color;
        private System.Windows.Forms.NumericUpDown NumericUpDown_A;
        private System.Windows.Forms.NumericUpDown NumericUpDown_B;
        private System.Windows.Forms.NumericUpDown NumericUpDown_G;
        private System.Windows.Forms.Label Label_Color_A;
        private System.Windows.Forms.NumericUpDown NumericUpDown_R;
        private System.Windows.Forms.Label Label_Color_G;
        private System.Windows.Forms.Label Label_Color_B;
        private System.Windows.Forms.Label Label_Color;
        private System.Windows.Forms.Label Label_Color_R;
        private System.Windows.Forms.Panel Panel_Positions;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Pos2_Y;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Pos1_Y;
        private System.Windows.Forms.Label Label_Size_Y;
        private System.Windows.Forms.Label Label_Pos_Y;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Pos2_X;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Pos1_X;
        private System.Windows.Forms.Label Label_Size_X;
        private System.Windows.Forms.Label Label_Position2;
        private System.Windows.Forms.Label Label_Pos_X;
        private System.Windows.Forms.Label Label_Position1;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Thickness;
        private System.Windows.Forms.Label Label_Thickness;
    }
}