namespace UIGenerator
{
    partial class DrawingCircleForm
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
            this.NumericUpDown_Angle = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_InnterDiameter = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_OuterDiameter = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_VertNum = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Center_Y = new System.Windows.Forms.NumericUpDown();
            this.Label_Angle = new System.Windows.Forms.Label();
            this.Label_InnerDiameter = new System.Windows.Forms.Label();
            this.Label_OuterDiameter = new System.Windows.Forms.Label();
            this.Llabel_VertNum = new System.Windows.Forms.Label();
            this.Label_Center_Y = new System.Windows.Forms.Label();
            this.NumericUpDown_Center_X = new System.Windows.Forms.NumericUpDown();
            this.Label_Center_X = new System.Windows.Forms.Label();
            this.Label_Center = new System.Windows.Forms.Label();
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
            this.ComboBox_AlphaBlend = new System.Windows.Forms.ComboBox();
            this.Label_AlphaBlend = new System.Windows.Forms.Label();
            this.Button_NameSet = new System.Windows.Forms.Button();
            this.NumericUpDown_Priority = new System.Windows.Forms.NumericUpDown();
            this.Label_Priority = new System.Windows.Forms.Label();
            this.NumericUpDown_Mode = new System.Windows.Forms.NumericUpDown();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.ComboBox_texture = new System.Windows.Forms.ComboBox();
            this.Label_Texture = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_InnterDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_OuterDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_VertNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Center_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Center_X)).BeginInit();
            this.Panel_Color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Priority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDown_Angle
            // 
            this.NumericUpDown_Angle.Location = new System.Drawing.Point(512, 316);
            this.NumericUpDown_Angle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.NumericUpDown_Angle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.NumericUpDown_Angle.Name = "NumericUpDown_Angle";
            this.NumericUpDown_Angle.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Angle.TabIndex = 57;
            this.NumericUpDown_Angle.ValueChanged += new System.EventHandler(this.NumericUpDown_Angle_ValueChanged);
            // 
            // NumericUpDown_InnterDiameter
            // 
            this.NumericUpDown_InnterDiameter.Location = new System.Drawing.Point(317, 316);
            this.NumericUpDown_InnterDiameter.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_InnterDiameter.Name = "NumericUpDown_InnterDiameter";
            this.NumericUpDown_InnterDiameter.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_InnterDiameter.TabIndex = 56;
            this.NumericUpDown_InnterDiameter.ValueChanged += new System.EventHandler(this.NumericUpDown_InnterDiameter_ValueChanged);
            // 
            // NumericUpDown_OuterDiameter
            // 
            this.NumericUpDown_OuterDiameter.Location = new System.Drawing.Point(114, 316);
            this.NumericUpDown_OuterDiameter.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_OuterDiameter.Name = "NumericUpDown_OuterDiameter";
            this.NumericUpDown_OuterDiameter.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_OuterDiameter.TabIndex = 55;
            this.NumericUpDown_OuterDiameter.ValueChanged += new System.EventHandler(this.NumericUpDown_OuterDiameter_ValueChanged);
            // 
            // NumericUpDown_VertNum
            // 
            this.NumericUpDown_VertNum.Location = new System.Drawing.Point(417, 267);
            this.NumericUpDown_VertNum.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_VertNum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown_VertNum.Name = "NumericUpDown_VertNum";
            this.NumericUpDown_VertNum.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_VertNum.TabIndex = 54;
            this.NumericUpDown_VertNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown_VertNum.ValueChanged += new System.EventHandler(this.NumericUpDown_VertNum_ValueChanged);
            // 
            // NumericUpDown_Center_Y
            // 
            this.NumericUpDown_Center_Y.Location = new System.Drawing.Point(200, 267);
            this.NumericUpDown_Center_Y.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Center_Y.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Center_Y.Name = "NumericUpDown_Center_Y";
            this.NumericUpDown_Center_Y.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Center_Y.TabIndex = 53;
            this.NumericUpDown_Center_Y.ValueChanged += new System.EventHandler(this.NumericUpDown_Center_Y_ValueChanged);
            // 
            // Label_Angle
            // 
            this.Label_Angle.AutoSize = true;
            this.Label_Angle.Location = new System.Drawing.Point(429, 318);
            this.Label_Angle.Name = "Label_Angle";
            this.Label_Angle.Size = new System.Drawing.Size(42, 15);
            this.Label_Angle.TabIndex = 45;
            this.Label_Angle.Text = "Angle";
            // 
            // Label_InnerDiameter
            // 
            this.Label_InnerDiameter.AutoSize = true;
            this.Label_InnerDiameter.Location = new System.Drawing.Point(230, 318);
            this.Label_InnerDiameter.Name = "Label_InnerDiameter";
            this.Label_InnerDiameter.Size = new System.Drawing.Size(53, 15);
            this.Label_InnerDiameter.TabIndex = 46;
            this.Label_InnerDiameter.Text = "Inner.D";
            // 
            // Label_OuterDiameter
            // 
            this.Label_OuterDiameter.AutoSize = true;
            this.Label_OuterDiameter.Location = new System.Drawing.Point(27, 318);
            this.Label_OuterDiameter.Name = "Label_OuterDiameter";
            this.Label_OuterDiameter.Size = new System.Drawing.Size(57, 15);
            this.Label_OuterDiameter.TabIndex = 47;
            this.Label_OuterDiameter.Text = "Outer.D";
            // 
            // Llabel_VertNum
            // 
            this.Llabel_VertNum.AutoSize = true;
            this.Llabel_VertNum.Location = new System.Drawing.Point(330, 269);
            this.Llabel_VertNum.Name = "Llabel_VertNum";
            this.Llabel_VertNum.Size = new System.Drawing.Size(63, 15);
            this.Llabel_VertNum.TabIndex = 48;
            this.Llabel_VertNum.Text = "VertNum";
            // 
            // Label_Center_Y
            // 
            this.Label_Center_Y.AutoSize = true;
            this.Label_Center_Y.Location = new System.Drawing.Point(162, 269);
            this.Label_Center_Y.Name = "Label_Center_Y";
            this.Label_Center_Y.Size = new System.Drawing.Size(16, 15);
            this.Label_Center_Y.TabIndex = 49;
            this.Label_Center_Y.Text = "Y";
            // 
            // NumericUpDown_Center_X
            // 
            this.NumericUpDown_Center_X.Location = new System.Drawing.Point(65, 267);
            this.NumericUpDown_Center_X.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Center_X.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Center_X.Name = "NumericUpDown_Center_X";
            this.NumericUpDown_Center_X.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Center_X.TabIndex = 52;
            this.NumericUpDown_Center_X.ValueChanged += new System.EventHandler(this.NumericUpDown_Center_X_ValueChanged);
            // 
            // Label_Center_X
            // 
            this.Label_Center_X.AutoSize = true;
            this.Label_Center_X.Location = new System.Drawing.Point(27, 269);
            this.Label_Center_X.Name = "Label_Center_X";
            this.Label_Center_X.Size = new System.Drawing.Size(16, 15);
            this.Label_Center_X.TabIndex = 50;
            this.Label_Center_X.Text = "X";
            // 
            // Label_Center
            // 
            this.Label_Center.AutoSize = true;
            this.Label_Center.Location = new System.Drawing.Point(27, 236);
            this.Label_Center.Name = "Label_Center";
            this.Label_Center.Size = new System.Drawing.Size(51, 15);
            this.Label_Center.TabIndex = 51;
            this.Label_Center.Text = "Center";
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
            this.Panel_Color.Location = new System.Drawing.Point(30, 130);
            this.Panel_Color.Name = "Panel_Color";
            this.Panel_Color.Size = new System.Drawing.Size(566, 88);
            this.Panel_Color.TabIndex = 44;
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
            // ComboBox_AlphaBlend
            // 
            this.ComboBox_AlphaBlend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_AlphaBlend.FormattingEnabled = true;
            this.ComboBox_AlphaBlend.Location = new System.Drawing.Point(417, 75);
            this.ComboBox_AlphaBlend.Name = "ComboBox_AlphaBlend";
            this.ComboBox_AlphaBlend.Size = new System.Drawing.Size(147, 23);
            this.ComboBox_AlphaBlend.TabIndex = 43;
            this.ComboBox_AlphaBlend.SelectedIndexChanged += new System.EventHandler(this.ComboBox_AlphaBlend_SelectedIndexChanged);
            // 
            // Label_AlphaBlend
            // 
            this.Label_AlphaBlend.AutoSize = true;
            this.Label_AlphaBlend.Location = new System.Drawing.Point(305, 78);
            this.Label_AlphaBlend.Name = "Label_AlphaBlend";
            this.Label_AlphaBlend.Size = new System.Drawing.Size(77, 15);
            this.Label_AlphaBlend.TabIndex = 42;
            this.Label_AlphaBlend.Text = "AlphaBlend";
            // 
            // Button_NameSet
            // 
            this.Button_NameSet.AutoSize = true;
            this.Button_NameSet.Location = new System.Drawing.Point(489, 28);
            this.Button_NameSet.Name = "Button_NameSet";
            this.Button_NameSet.Size = new System.Drawing.Size(75, 25);
            this.Button_NameSet.TabIndex = 39;
            this.Button_NameSet.Text = "Set";
            this.Button_NameSet.UseVisualStyleBackColor = true;
            this.Button_NameSet.Click += new System.EventHandler(this.Button_NameSet_Click);
            // 
            // NumericUpDown_Priority
            // 
            this.NumericUpDown_Priority.Location = new System.Drawing.Point(186, 76);
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
            this.NumericUpDown_Priority.TabIndex = 40;
            this.NumericUpDown_Priority.ValueChanged += new System.EventHandler(this.NumericUpDown_Priority_ValueChanged);
            // 
            // Label_Priority
            // 
            this.Label_Priority.AutoSize = true;
            this.Label_Priority.Location = new System.Drawing.Point(27, 78);
            this.Label_Priority.Name = "Label_Priority";
            this.Label_Priority.Size = new System.Drawing.Size(102, 15);
            this.Label_Priority.TabIndex = 41;
            this.Label_Priority.Text = "DrawingPriority";
            // 
            // NumericUpDown_Mode
            // 
            this.NumericUpDown_Mode.Location = new System.Drawing.Point(91, 30);
            this.NumericUpDown_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Mode.Name = "NumericUpDown_Mode";
            this.NumericUpDown_Mode.Size = new System.Drawing.Size(72, 22);
            this.NumericUpDown_Mode.TabIndex = 35;
            this.NumericUpDown_Mode.ValueChanged += new System.EventHandler(this.NumericUpDown_Mode_ValueChanged);
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(281, 29);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(175, 22);
            this.TextBox_Name.TabIndex = 38;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(211, 32);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Name.TabIndex = 36;
            this.Label_Name.Text = "Name";
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.Location = new System.Drawing.Point(27, 32);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Mode.TabIndex = 37;
            this.Label_Mode.Text = "Mode";
            // 
            // ComboBox_texture
            // 
            this.ComboBox_texture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_texture.FormattingEnabled = true;
            this.ComboBox_texture.Location = new System.Drawing.Point(30, 390);
            this.ComboBox_texture.Name = "ComboBox_texture";
            this.ComboBox_texture.Size = new System.Drawing.Size(566, 23);
            this.ComboBox_texture.TabIndex = 59;
            // 
            // Label_Texture
            // 
            this.Label_Texture.AutoSize = true;
            this.Label_Texture.Location = new System.Drawing.Point(27, 356);
            this.Label_Texture.Name = "Label_Texture";
            this.Label_Texture.Size = new System.Drawing.Size(57, 15);
            this.Label_Texture.TabIndex = 58;
            this.Label_Texture.Text = "Texture";
            // 
            // DrawingCircleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 450);
            this.Controls.Add(this.ComboBox_texture);
            this.Controls.Add(this.Label_Texture);
            this.Controls.Add(this.NumericUpDown_Angle);
            this.Controls.Add(this.NumericUpDown_InnterDiameter);
            this.Controls.Add(this.NumericUpDown_OuterDiameter);
            this.Controls.Add(this.NumericUpDown_VertNum);
            this.Controls.Add(this.NumericUpDown_Center_Y);
            this.Controls.Add(this.Label_Angle);
            this.Controls.Add(this.Label_InnerDiameter);
            this.Controls.Add(this.Label_OuterDiameter);
            this.Controls.Add(this.Llabel_VertNum);
            this.Controls.Add(this.Label_Center_Y);
            this.Controls.Add(this.NumericUpDown_Center_X);
            this.Controls.Add(this.Label_Center_X);
            this.Controls.Add(this.Label_Center);
            this.Controls.Add(this.Panel_Color);
            this.Controls.Add(this.ComboBox_AlphaBlend);
            this.Controls.Add(this.Label_AlphaBlend);
            this.Controls.Add(this.Button_NameSet);
            this.Controls.Add(this.NumericUpDown_Priority);
            this.Controls.Add(this.Label_Priority);
            this.Controls.Add(this.NumericUpDown_Mode);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Label_Mode);
            this.Name = "DrawingCircleForm";
            this.Text = "DrawingCircleForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrawingCircleForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_InnterDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_OuterDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_VertNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Center_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Center_X)).EndInit();
            this.Panel_Color.ResumeLayout(false);
            this.Panel_Color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Priority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumericUpDown_Angle;
        private System.Windows.Forms.NumericUpDown NumericUpDown_InnterDiameter;
        private System.Windows.Forms.NumericUpDown NumericUpDown_OuterDiameter;
        private System.Windows.Forms.NumericUpDown NumericUpDown_VertNum;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Center_Y;
        private System.Windows.Forms.Label Label_Angle;
        private System.Windows.Forms.Label Label_InnerDiameter;
        private System.Windows.Forms.Label Label_OuterDiameter;
        private System.Windows.Forms.Label Llabel_VertNum;
        private System.Windows.Forms.Label Label_Center_Y;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Center_X;
        private System.Windows.Forms.Label Label_Center_X;
        private System.Windows.Forms.Label Label_Center;
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
        private System.Windows.Forms.ComboBox ComboBox_AlphaBlend;
        private System.Windows.Forms.Label Label_AlphaBlend;
        private System.Windows.Forms.Button Button_NameSet;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Priority;
        private System.Windows.Forms.Label Label_Priority;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Mode;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_Mode;
        private System.Windows.Forms.ComboBox ComboBox_texture;
        private System.Windows.Forms.Label Label_Texture;
    }
}