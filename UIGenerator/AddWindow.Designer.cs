namespace UIGenerator
{
    partial class AddWindow
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
            this.ComboBox_Type = new System.Windows.Forms.ComboBox();
            this.Label_Type = new System.Windows.Forms.Label();
            this.NumericUpDown_Mode = new System.Windows.Forms.NumericUpDown();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Button_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox_Type
            // 
            this.ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Type.FormattingEnabled = true;
            this.ComboBox_Type.Items.AddRange(new object[] {
            "Window",
            "Text",
            "Texture"});
            this.ComboBox_Type.Location = new System.Drawing.Point(93, 20);
            this.ComboBox_Type.Name = "ComboBox_Type";
            this.ComboBox_Type.Size = new System.Drawing.Size(121, 23);
            this.ComboBox_Type.TabIndex = 0;
            // 
            // Label_Type
            // 
            this.Label_Type.AutoSize = true;
            this.Label_Type.Location = new System.Drawing.Point(26, 23);
            this.Label_Type.Name = "Label_Type";
            this.Label_Type.Size = new System.Drawing.Size(38, 15);
            this.Label_Type.TabIndex = 1;
            this.Label_Type.Text = "Type";
            // 
            // NumericUpDown_Mode
            // 
            this.NumericUpDown_Mode.Location = new System.Drawing.Point(345, 21);
            this.NumericUpDown_Mode.Name = "NumericUpDown_Mode";
            this.NumericUpDown_Mode.Size = new System.Drawing.Size(120, 22);
            this.NumericUpDown_Mode.TabIndex = 2;
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.Location = new System.Drawing.Point(274, 23);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Mode.TabIndex = 1;
            this.Label_Mode.Text = "Mode";
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(26, 65);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Name.TabIndex = 1;
            this.Label_Name.Text = "Name";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(93, 62);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(372, 22);
            this.TextBox_Name.TabIndex = 3;
            // 
            // Button_Add
            // 
            this.Button_Add.AutoSize = true;
            this.Button_Add.Location = new System.Drawing.Point(192, 119);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 25);
            this.Button_Add.TabIndex = 4;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // AddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 160);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.NumericUpDown_Mode);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Label_Mode);
            this.Controls.Add(this.Label_Type);
            this.Controls.Add(this.ComboBox_Type);
            this.Name = "AddWindow";
            this.Text = "AddWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Mode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_Type;
        private System.Windows.Forms.Label Label_Type;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Mode;
        private System.Windows.Forms.Label Label_Mode;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Button Button_Add;
    }
}