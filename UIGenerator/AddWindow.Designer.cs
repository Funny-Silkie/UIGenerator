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
            this.ComboBox_Obj_Type = new System.Windows.Forms.ComboBox();
            this.Label_Obj_Type = new System.Windows.Forms.Label();
            this.NumericUpDown_Obj_Mode = new System.Windows.Forms.NumericUpDown();
            this.Label_Obj_Mode = new System.Windows.Forms.Label();
            this.Label_Obj_Name = new System.Windows.Forms.Label();
            this.TextBox_Obj_Name = new System.Windows.Forms.TextBox();
            this.Button_Obj_Add = new System.Windows.Forms.Button();
            this.Panel_Obj = new System.Windows.Forms.Panel();
            this.Label_Object = new System.Windows.Forms.Label();
            this.Panel_Add = new System.Windows.Forms.Panel();
            this.Label_Additional = new System.Windows.Forms.Label();
            this.Label_Add_Type = new System.Windows.Forms.Label();
            this.Button_Add_Add = new System.Windows.Forms.Button();
            this.ComboBox_Add_Type = new System.Windows.Forms.ComboBox();
            this.TextBox_Add_Name = new System.Windows.Forms.TextBox();
            this.Label_Add_Mode = new System.Windows.Forms.Label();
            this.NumericUpDown_Add_Mode = new System.Windows.Forms.NumericUpDown();
            this.Label_Add_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Obj_Mode)).BeginInit();
            this.Panel_Obj.SuspendLayout();
            this.Panel_Add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Add_Mode)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox_Obj_Type
            // 
            this.ComboBox_Obj_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Obj_Type.FormattingEnabled = true;
            this.ComboBox_Obj_Type.Items.AddRange(new object[] {
            "Window",
            "Text",
            "Texture"});
            this.ComboBox_Obj_Type.Location = new System.Drawing.Point(91, 57);
            this.ComboBox_Obj_Type.Name = "ComboBox_Obj_Type";
            this.ComboBox_Obj_Type.Size = new System.Drawing.Size(121, 23);
            this.ComboBox_Obj_Type.TabIndex = 0;
            // 
            // Label_Obj_Type
            // 
            this.Label_Obj_Type.AutoSize = true;
            this.Label_Obj_Type.Location = new System.Drawing.Point(24, 60);
            this.Label_Obj_Type.Name = "Label_Obj_Type";
            this.Label_Obj_Type.Size = new System.Drawing.Size(38, 15);
            this.Label_Obj_Type.TabIndex = 1;
            this.Label_Obj_Type.Text = "Type";
            // 
            // NumericUpDown_Obj_Mode
            // 
            this.NumericUpDown_Obj_Mode.Location = new System.Drawing.Point(343, 58);
            this.NumericUpDown_Obj_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Obj_Mode.Name = "NumericUpDown_Obj_Mode";
            this.NumericUpDown_Obj_Mode.Size = new System.Drawing.Size(120, 22);
            this.NumericUpDown_Obj_Mode.TabIndex = 2;
            // 
            // Label_Obj_Mode
            // 
            this.Label_Obj_Mode.AutoSize = true;
            this.Label_Obj_Mode.Location = new System.Drawing.Point(272, 60);
            this.Label_Obj_Mode.Name = "Label_Obj_Mode";
            this.Label_Obj_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Obj_Mode.TabIndex = 1;
            this.Label_Obj_Mode.Text = "Mode";
            // 
            // Label_Obj_Name
            // 
            this.Label_Obj_Name.AutoSize = true;
            this.Label_Obj_Name.Location = new System.Drawing.Point(24, 102);
            this.Label_Obj_Name.Name = "Label_Obj_Name";
            this.Label_Obj_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Obj_Name.TabIndex = 1;
            this.Label_Obj_Name.Text = "Name";
            // 
            // TextBox_Obj_Name
            // 
            this.TextBox_Obj_Name.Location = new System.Drawing.Point(91, 99);
            this.TextBox_Obj_Name.Name = "TextBox_Obj_Name";
            this.TextBox_Obj_Name.Size = new System.Drawing.Size(372, 22);
            this.TextBox_Obj_Name.TabIndex = 3;
            // 
            // Button_Obj_Add
            // 
            this.Button_Obj_Add.AutoSize = true;
            this.Button_Obj_Add.Location = new System.Drawing.Point(190, 156);
            this.Button_Obj_Add.Name = "Button_Obj_Add";
            this.Button_Obj_Add.Size = new System.Drawing.Size(75, 25);
            this.Button_Obj_Add.TabIndex = 4;
            this.Button_Obj_Add.Text = "Add";
            this.Button_Obj_Add.UseVisualStyleBackColor = true;
            this.Button_Obj_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Panel_Obj
            // 
            this.Panel_Obj.BackColor = System.Drawing.Color.White;
            this.Panel_Obj.Controls.Add(this.Label_Object);
            this.Panel_Obj.Controls.Add(this.Label_Obj_Type);
            this.Panel_Obj.Controls.Add(this.Button_Obj_Add);
            this.Panel_Obj.Controls.Add(this.ComboBox_Obj_Type);
            this.Panel_Obj.Controls.Add(this.TextBox_Obj_Name);
            this.Panel_Obj.Controls.Add(this.Label_Obj_Mode);
            this.Panel_Obj.Controls.Add(this.NumericUpDown_Obj_Mode);
            this.Panel_Obj.Controls.Add(this.Label_Obj_Name);
            this.Panel_Obj.Location = new System.Drawing.Point(31, 23);
            this.Panel_Obj.Name = "Panel_Obj";
            this.Panel_Obj.Size = new System.Drawing.Size(486, 203);
            this.Panel_Obj.TabIndex = 5;
            // 
            // Label_Object
            // 
            this.Label_Object.AutoSize = true;
            this.Label_Object.Location = new System.Drawing.Point(24, 22);
            this.Label_Object.Name = "Label_Object";
            this.Label_Object.Size = new System.Drawing.Size(67, 15);
            this.Label_Object.TabIndex = 6;
            this.Label_Object.Text = "Object2D";
            // 
            // Panel_Add
            // 
            this.Panel_Add.BackColor = System.Drawing.Color.White;
            this.Panel_Add.Controls.Add(this.Label_Additional);
            this.Panel_Add.Controls.Add(this.Label_Add_Type);
            this.Panel_Add.Controls.Add(this.Button_Add_Add);
            this.Panel_Add.Controls.Add(this.ComboBox_Add_Type);
            this.Panel_Add.Controls.Add(this.TextBox_Add_Name);
            this.Panel_Add.Controls.Add(this.Label_Add_Mode);
            this.Panel_Add.Controls.Add(this.NumericUpDown_Add_Mode);
            this.Panel_Add.Controls.Add(this.Label_Add_Name);
            this.Panel_Add.Location = new System.Drawing.Point(31, 263);
            this.Panel_Add.Name = "Panel_Add";
            this.Panel_Add.Size = new System.Drawing.Size(486, 203);
            this.Panel_Add.TabIndex = 5;
            // 
            // Label_Additional
            // 
            this.Label_Additional.AutoSize = true;
            this.Label_Additional.Location = new System.Drawing.Point(24, 22);
            this.Label_Additional.Name = "Label_Additional";
            this.Label_Additional.Size = new System.Drawing.Size(117, 15);
            this.Label_Additional.TabIndex = 6;
            this.Label_Additional.Text = "AdditionalDrawing";
            // 
            // Label_Add_Type
            // 
            this.Label_Add_Type.AutoSize = true;
            this.Label_Add_Type.Location = new System.Drawing.Point(24, 60);
            this.Label_Add_Type.Name = "Label_Add_Type";
            this.Label_Add_Type.Size = new System.Drawing.Size(38, 15);
            this.Label_Add_Type.TabIndex = 1;
            this.Label_Add_Type.Text = "Type";
            // 
            // Button_Add_Add
            // 
            this.Button_Add_Add.AutoSize = true;
            this.Button_Add_Add.Location = new System.Drawing.Point(190, 156);
            this.Button_Add_Add.Name = "Button_Add_Add";
            this.Button_Add_Add.Size = new System.Drawing.Size(75, 25);
            this.Button_Add_Add.TabIndex = 4;
            this.Button_Add_Add.Text = "Add";
            this.Button_Add_Add.UseVisualStyleBackColor = true;
            this.Button_Add_Add.Click += new System.EventHandler(this.Button_Add_Add_Click);
            // 
            // ComboBox_Add_Type
            // 
            this.ComboBox_Add_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Add_Type.FormattingEnabled = true;
            this.ComboBox_Add_Type.Items.AddRange(new object[] {
            "Window",
            "Text",
            "Texture"});
            this.ComboBox_Add_Type.Location = new System.Drawing.Point(91, 57);
            this.ComboBox_Add_Type.Name = "ComboBox_Add_Type";
            this.ComboBox_Add_Type.Size = new System.Drawing.Size(121, 23);
            this.ComboBox_Add_Type.TabIndex = 0;
            // 
            // TextBox_Add_Name
            // 
            this.TextBox_Add_Name.Location = new System.Drawing.Point(91, 99);
            this.TextBox_Add_Name.Name = "TextBox_Add_Name";
            this.TextBox_Add_Name.Size = new System.Drawing.Size(372, 22);
            this.TextBox_Add_Name.TabIndex = 3;
            // 
            // Label_Add_Mode
            // 
            this.Label_Add_Mode.AutoSize = true;
            this.Label_Add_Mode.Location = new System.Drawing.Point(272, 60);
            this.Label_Add_Mode.Name = "Label_Add_Mode";
            this.Label_Add_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Add_Mode.TabIndex = 1;
            this.Label_Add_Mode.Text = "Mode";
            // 
            // NumericUpDown_Add_Mode
            // 
            this.NumericUpDown_Add_Mode.Location = new System.Drawing.Point(343, 58);
            this.NumericUpDown_Add_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Add_Mode.Name = "NumericUpDown_Add_Mode";
            this.NumericUpDown_Add_Mode.Size = new System.Drawing.Size(120, 22);
            this.NumericUpDown_Add_Mode.TabIndex = 2;
            // 
            // Label_Add_Name
            // 
            this.Label_Add_Name.AutoSize = true;
            this.Label_Add_Name.Location = new System.Drawing.Point(24, 102);
            this.Label_Add_Name.Name = "Label_Add_Name";
            this.Label_Add_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Add_Name.TabIndex = 1;
            this.Label_Add_Name.Text = "Name";
            // 
            // AddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 497);
            this.Controls.Add(this.Panel_Add);
            this.Controls.Add(this.Panel_Obj);
            this.Name = "AddWindow";
            this.Text = "AddWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Obj_Mode)).EndInit();
            this.Panel_Obj.ResumeLayout(false);
            this.Panel_Obj.PerformLayout();
            this.Panel_Add.ResumeLayout(false);
            this.Panel_Add.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Add_Mode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_Obj_Type;
        private System.Windows.Forms.Label Label_Obj_Type;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Obj_Mode;
        private System.Windows.Forms.Label Label_Obj_Mode;
        private System.Windows.Forms.Label Label_Obj_Name;
        private System.Windows.Forms.TextBox TextBox_Obj_Name;
        private System.Windows.Forms.Button Button_Obj_Add;
        private System.Windows.Forms.Panel Panel_Obj;
        private System.Windows.Forms.Label Label_Object;
        private System.Windows.Forms.Panel Panel_Add;
        private System.Windows.Forms.Label Label_Additional;
        private System.Windows.Forms.Label Label_Add_Type;
        private System.Windows.Forms.Button Button_Add_Add;
        private System.Windows.Forms.ComboBox ComboBox_Add_Type;
        private System.Windows.Forms.TextBox TextBox_Add_Name;
        private System.Windows.Forms.Label Label_Add_Mode;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Add_Mode;
        private System.Windows.Forms.Label Label_Add_Name;
    }
}