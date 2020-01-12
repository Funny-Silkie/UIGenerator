namespace UIGenerator
{
    partial class DrawingTextForm
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
            this.ComboBox_AlphaBlend = new System.Windows.Forms.ComboBox();
            this.Label_AlphaBlend = new System.Windows.Forms.Label();
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
            this.ComboBox_Direction = new System.Windows.Forms.ComboBox();
            this.Label_Direction = new System.Windows.Forms.Label();
            this.Label_Font = new System.Windows.Forms.Label();
            this.ComboBox_font = new System.Windows.Forms.ComboBox();
            this.RichTextBox_Text = new System.Windows.Forms.RichTextBox();
            this.Label_Text = new System.Windows.Forms.Label();
            this.NumericUpDown_Position_Y = new System.Windows.Forms.NumericUpDown();
            this.Label_Position_Y = new System.Windows.Forms.Label();
            this.NumericUpDown_Position_X = new System.Windows.Forms.NumericUpDown();
            this.Label_Position_X = new System.Windows.Forms.Label();
            this.Label_Position = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Priority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).BeginInit();
            this.Panel_Color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Position_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Position_X)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox_AlphaBlend
            // 
            this.ComboBox_AlphaBlend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_AlphaBlend.FormattingEnabled = true;
            this.ComboBox_AlphaBlend.Location = new System.Drawing.Point(430, 79);
            this.ComboBox_AlphaBlend.Name = "ComboBox_AlphaBlend";
            this.ComboBox_AlphaBlend.Size = new System.Drawing.Size(147, 23);
            this.ComboBox_AlphaBlend.TabIndex = 93;
            // 
            // Label_AlphaBlend
            // 
            this.Label_AlphaBlend.AutoSize = true;
            this.Label_AlphaBlend.Location = new System.Drawing.Point(318, 82);
            this.Label_AlphaBlend.Name = "Label_AlphaBlend";
            this.Label_AlphaBlend.Size = new System.Drawing.Size(77, 15);
            this.Label_AlphaBlend.TabIndex = 92;
            this.Label_AlphaBlend.Text = "AlphaBlend";
            // 
            // Button_NameSet
            // 
            this.Button_NameSet.AutoSize = true;
            this.Button_NameSet.Location = new System.Drawing.Point(502, 32);
            this.Button_NameSet.Name = "Button_NameSet";
            this.Button_NameSet.Size = new System.Drawing.Size(75, 25);
            this.Button_NameSet.TabIndex = 89;
            this.Button_NameSet.Text = "Set";
            this.Button_NameSet.UseVisualStyleBackColor = true;
            this.Button_NameSet.Click += new System.EventHandler(this.Button_NameSet_Click);
            // 
            // NumericUpDown_Priority
            // 
            this.NumericUpDown_Priority.Location = new System.Drawing.Point(199, 80);
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
            this.NumericUpDown_Priority.TabIndex = 90;
            this.NumericUpDown_Priority.ValueChanged += new System.EventHandler(this.NumericUpDown_Priority_ValueChanged);
            // 
            // Label_Priority
            // 
            this.Label_Priority.AutoSize = true;
            this.Label_Priority.Location = new System.Drawing.Point(40, 82);
            this.Label_Priority.Name = "Label_Priority";
            this.Label_Priority.Size = new System.Drawing.Size(102, 15);
            this.Label_Priority.TabIndex = 91;
            this.Label_Priority.Text = "DrawingPriority";
            // 
            // NumericUpDown_Mode
            // 
            this.NumericUpDown_Mode.Location = new System.Drawing.Point(104, 34);
            this.NumericUpDown_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Mode.Name = "NumericUpDown_Mode";
            this.NumericUpDown_Mode.Size = new System.Drawing.Size(72, 22);
            this.NumericUpDown_Mode.TabIndex = 85;
            this.NumericUpDown_Mode.ValueChanged += new System.EventHandler(this.NumericUpDown_Mode_ValueChanged);
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(294, 33);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(175, 22);
            this.TextBox_Name.TabIndex = 88;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(224, 36);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Name.TabIndex = 86;
            this.Label_Name.Text = "Name";
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.Location = new System.Drawing.Point(40, 36);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Mode.TabIndex = 87;
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
            this.Panel_Color.Location = new System.Drawing.Point(26, 126);
            this.Panel_Color.Name = "Panel_Color";
            this.Panel_Color.Size = new System.Drawing.Size(566, 88);
            this.Panel_Color.TabIndex = 94;
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
            // ComboBox_Direction
            // 
            this.ComboBox_Direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Direction.FormattingEnabled = true;
            this.ComboBox_Direction.Location = new System.Drawing.Point(175, 471);
            this.ComboBox_Direction.Name = "ComboBox_Direction";
            this.ComboBox_Direction.Size = new System.Drawing.Size(169, 23);
            this.ComboBox_Direction.TabIndex = 100;
            // 
            // Label_Direction
            // 
            this.Label_Direction.AutoSize = true;
            this.Label_Direction.Location = new System.Drawing.Point(23, 474);
            this.Label_Direction.Name = "Label_Direction";
            this.Label_Direction.Size = new System.Drawing.Size(107, 15);
            this.Label_Direction.TabIndex = 98;
            this.Label_Direction.Text = "WritingDirection";
            // 
            // Label_Font
            // 
            this.Label_Font.AutoSize = true;
            this.Label_Font.Location = new System.Drawing.Point(23, 389);
            this.Label_Font.Name = "Label_Font";
            this.Label_Font.Size = new System.Drawing.Size(36, 15);
            this.Label_Font.TabIndex = 99;
            this.Label_Font.Text = "Font";
            // 
            // ComboBox_font
            // 
            this.ComboBox_font.BackColor = System.Drawing.SystemColors.Window;
            this.ComboBox_font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_font.FormattingEnabled = true;
            this.ComboBox_font.Location = new System.Drawing.Point(26, 428);
            this.ComboBox_font.Name = "ComboBox_font";
            this.ComboBox_font.Size = new System.Drawing.Size(566, 23);
            this.ComboBox_font.TabIndex = 97;
            // 
            // RichTextBox_Text
            // 
            this.RichTextBox_Text.DetectUrls = false;
            this.RichTextBox_Text.Location = new System.Drawing.Point(26, 263);
            this.RichTextBox_Text.Name = "RichTextBox_Text";
            this.RichTextBox_Text.Size = new System.Drawing.Size(566, 96);
            this.RichTextBox_Text.TabIndex = 96;
            this.RichTextBox_Text.Text = "";
            this.RichTextBox_Text.WordWrap = false;
            this.RichTextBox_Text.TextChanged += new System.EventHandler(this.RichTextBox_Text_TextChanged);
            // 
            // Label_Text
            // 
            this.Label_Text.AutoSize = true;
            this.Label_Text.Location = new System.Drawing.Point(23, 236);
            this.Label_Text.Name = "Label_Text";
            this.Label_Text.Size = new System.Drawing.Size(36, 15);
            this.Label_Text.TabIndex = 95;
            this.Label_Text.Text = "Text";
            // 
            // NumericUpDown_Position_Y
            // 
            this.NumericUpDown_Position_Y.Location = new System.Drawing.Point(196, 546);
            this.NumericUpDown_Position_Y.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Position_Y.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Position_Y.Name = "NumericUpDown_Position_Y";
            this.NumericUpDown_Position_Y.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Position_Y.TabIndex = 105;
            // 
            // Label_Position_Y
            // 
            this.Label_Position_Y.AutoSize = true;
            this.Label_Position_Y.Location = new System.Drawing.Point(158, 548);
            this.Label_Position_Y.Name = "Label_Position_Y";
            this.Label_Position_Y.Size = new System.Drawing.Size(16, 15);
            this.Label_Position_Y.TabIndex = 101;
            this.Label_Position_Y.Text = "Y";
            // 
            // NumericUpDown_Position_X
            // 
            this.NumericUpDown_Position_X.Location = new System.Drawing.Point(61, 546);
            this.NumericUpDown_Position_X.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.NumericUpDown_Position_X.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.NumericUpDown_Position_X.Name = "NumericUpDown_Position_X";
            this.NumericUpDown_Position_X.Size = new System.Drawing.Size(70, 22);
            this.NumericUpDown_Position_X.TabIndex = 104;
            // 
            // Label_Position_X
            // 
            this.Label_Position_X.AutoSize = true;
            this.Label_Position_X.Location = new System.Drawing.Point(23, 548);
            this.Label_Position_X.Name = "Label_Position_X";
            this.Label_Position_X.Size = new System.Drawing.Size(16, 15);
            this.Label_Position_X.TabIndex = 102;
            this.Label_Position_X.Text = "X";
            // 
            // Label_Position
            // 
            this.Label_Position.AutoSize = true;
            this.Label_Position.Location = new System.Drawing.Point(23, 515);
            this.Label_Position.Name = "Label_Position";
            this.Label_Position.Size = new System.Drawing.Size(58, 15);
            this.Label_Position.TabIndex = 103;
            this.Label_Position.Text = "Position";
            // 
            // DrawingTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 594);
            this.Controls.Add(this.NumericUpDown_Position_Y);
            this.Controls.Add(this.Label_Position_Y);
            this.Controls.Add(this.NumericUpDown_Position_X);
            this.Controls.Add(this.Label_Position_X);
            this.Controls.Add(this.Label_Position);
            this.Controls.Add(this.ComboBox_Direction);
            this.Controls.Add(this.Label_Direction);
            this.Controls.Add(this.Label_Font);
            this.Controls.Add(this.ComboBox_font);
            this.Controls.Add(this.RichTextBox_Text);
            this.Controls.Add(this.Label_Text);
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
            this.Name = "DrawingTextForm";
            this.Text = "DrawingTextForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrawingTextForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Priority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).EndInit();
            this.Panel_Color.ResumeLayout(false);
            this.Panel_Color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Position_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Position_X)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_AlphaBlend;
        private System.Windows.Forms.Label Label_AlphaBlend;
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
        private System.Windows.Forms.ComboBox ComboBox_Direction;
        private System.Windows.Forms.Label Label_Direction;
        private System.Windows.Forms.Label Label_Font;
        private System.Windows.Forms.RichTextBox RichTextBox_Text;
        private System.Windows.Forms.Label Label_Text;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Position_Y;
        private System.Windows.Forms.Label Label_Position_Y;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Position_X;
        private System.Windows.Forms.Label Label_Position_X;
        private System.Windows.Forms.Label Label_Position;
        private System.Windows.Forms.ComboBox ComboBox_font;
    }
}