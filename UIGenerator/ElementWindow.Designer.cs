namespace UIGenerator
{
    partial class ElementWindow
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
            this.Label_Object = new System.Windows.Forms.Label();
            this.Label_Additional = new System.Windows.Forms.Label();
            this.Label_Add_Type = new System.Windows.Forms.Label();
            this.Button_Add_Add = new System.Windows.Forms.Button();
            this.ComboBox_Add_Type = new System.Windows.Forms.ComboBox();
            this.TextBox_Add_Name = new System.Windows.Forms.TextBox();
            this.Label_Add_Mode = new System.Windows.Forms.Label();
            this.NumericUpDown_Add_Mode = new System.Windows.Forms.NumericUpDown();
            this.Label_Add_Name = new System.Windows.Forms.Label();
            this.TabControl_Obj = new System.Windows.Forms.TabControl();
            this.TabPage_Obj_Add = new System.Windows.Forms.TabPage();
            this.TabPage_Obj_Remove = new System.Windows.Forms.TabPage();
            this.ComboBox_Obj_Remove = new System.Windows.Forms.ComboBox();
            this.Button_Obj_Remove = new System.Windows.Forms.Button();
            this.TabControl_Add = new System.Windows.Forms.TabControl();
            this.TabPage_Add_Add = new System.Windows.Forms.TabPage();
            this.TabPage_Add_Remove = new System.Windows.Forms.TabPage();
            this.ComboBox_Add_Remove = new System.Windows.Forms.ComboBox();
            this.Button_Add_Remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Obj_Mode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Add_Mode)).BeginInit();
            this.TabControl_Obj.SuspendLayout();
            this.TabPage_Obj_Add.SuspendLayout();
            this.TabPage_Obj_Remove.SuspendLayout();
            this.TabControl_Add.SuspendLayout();
            this.TabPage_Add_Add.SuspendLayout();
            this.TabPage_Add_Remove.SuspendLayout();
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
            this.ComboBox_Obj_Type.Location = new System.Drawing.Point(87, 22);
            this.ComboBox_Obj_Type.Name = "ComboBox_Obj_Type";
            this.ComboBox_Obj_Type.Size = new System.Drawing.Size(121, 23);
            this.ComboBox_Obj_Type.TabIndex = 0;
            // 
            // Label_Obj_Type
            // 
            this.Label_Obj_Type.AutoSize = true;
            this.Label_Obj_Type.Location = new System.Drawing.Point(20, 25);
            this.Label_Obj_Type.Name = "Label_Obj_Type";
            this.Label_Obj_Type.Size = new System.Drawing.Size(38, 15);
            this.Label_Obj_Type.TabIndex = 1;
            this.Label_Obj_Type.Text = "Type";
            // 
            // NumericUpDown_Obj_Mode
            // 
            this.NumericUpDown_Obj_Mode.Location = new System.Drawing.Point(339, 23);
            this.NumericUpDown_Obj_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Obj_Mode.Name = "NumericUpDown_Obj_Mode";
            this.NumericUpDown_Obj_Mode.Size = new System.Drawing.Size(120, 22);
            this.NumericUpDown_Obj_Mode.TabIndex = 1;
            // 
            // Label_Obj_Mode
            // 
            this.Label_Obj_Mode.AutoSize = true;
            this.Label_Obj_Mode.Location = new System.Drawing.Point(268, 25);
            this.Label_Obj_Mode.Name = "Label_Obj_Mode";
            this.Label_Obj_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Obj_Mode.TabIndex = 1;
            this.Label_Obj_Mode.Text = "Mode";
            // 
            // Label_Obj_Name
            // 
            this.Label_Obj_Name.AutoSize = true;
            this.Label_Obj_Name.Location = new System.Drawing.Point(20, 67);
            this.Label_Obj_Name.Name = "Label_Obj_Name";
            this.Label_Obj_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Obj_Name.TabIndex = 1;
            this.Label_Obj_Name.Text = "Name";
            // 
            // TextBox_Obj_Name
            // 
            this.TextBox_Obj_Name.Location = new System.Drawing.Point(87, 64);
            this.TextBox_Obj_Name.Name = "TextBox_Obj_Name";
            this.TextBox_Obj_Name.Size = new System.Drawing.Size(372, 22);
            this.TextBox_Obj_Name.TabIndex = 2;
            // 
            // Button_Obj_Add
            // 
            this.Button_Obj_Add.AutoSize = true;
            this.Button_Obj_Add.Location = new System.Drawing.Point(186, 121);
            this.Button_Obj_Add.Name = "Button_Obj_Add";
            this.Button_Obj_Add.Size = new System.Drawing.Size(75, 25);
            this.Button_Obj_Add.TabIndex = 3;
            this.Button_Obj_Add.Text = "Add";
            this.Button_Obj_Add.UseVisualStyleBackColor = true;
            this.Button_Obj_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Label_Object
            // 
            this.Label_Object.AutoSize = true;
            this.Label_Object.Location = new System.Drawing.Point(32, 26);
            this.Label_Object.Name = "Label_Object";
            this.Label_Object.Size = new System.Drawing.Size(67, 15);
            this.Label_Object.TabIndex = 6;
            this.Label_Object.Text = "Object2D";
            // 
            // Label_Additional
            // 
            this.Label_Additional.AutoSize = true;
            this.Label_Additional.Location = new System.Drawing.Point(32, 286);
            this.Label_Additional.Name = "Label_Additional";
            this.Label_Additional.Size = new System.Drawing.Size(117, 15);
            this.Label_Additional.TabIndex = 6;
            this.Label_Additional.Text = "AdditionalDrawing";
            // 
            // Label_Add_Type
            // 
            this.Label_Add_Type.AutoSize = true;
            this.Label_Add_Type.Location = new System.Drawing.Point(20, 28);
            this.Label_Add_Type.Name = "Label_Add_Type";
            this.Label_Add_Type.Size = new System.Drawing.Size(38, 15);
            this.Label_Add_Type.TabIndex = 1;
            this.Label_Add_Type.Text = "Type";
            // 
            // Button_Add_Add
            // 
            this.Button_Add_Add.AutoSize = true;
            this.Button_Add_Add.Location = new System.Drawing.Point(186, 124);
            this.Button_Add_Add.Name = "Button_Add_Add";
            this.Button_Add_Add.Size = new System.Drawing.Size(75, 25);
            this.Button_Add_Add.TabIndex = 7;
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
            this.ComboBox_Add_Type.Location = new System.Drawing.Point(87, 25);
            this.ComboBox_Add_Type.Name = "ComboBox_Add_Type";
            this.ComboBox_Add_Type.Size = new System.Drawing.Size(121, 23);
            this.ComboBox_Add_Type.TabIndex = 4;
            // 
            // TextBox_Add_Name
            // 
            this.TextBox_Add_Name.Location = new System.Drawing.Point(87, 67);
            this.TextBox_Add_Name.Name = "TextBox_Add_Name";
            this.TextBox_Add_Name.Size = new System.Drawing.Size(372, 22);
            this.TextBox_Add_Name.TabIndex = 6;
            // 
            // Label_Add_Mode
            // 
            this.Label_Add_Mode.AutoSize = true;
            this.Label_Add_Mode.Location = new System.Drawing.Point(268, 28);
            this.Label_Add_Mode.Name = "Label_Add_Mode";
            this.Label_Add_Mode.Size = new System.Drawing.Size(41, 15);
            this.Label_Add_Mode.TabIndex = 1;
            this.Label_Add_Mode.Text = "Mode";
            // 
            // NumericUpDown_Add_Mode
            // 
            this.NumericUpDown_Add_Mode.Location = new System.Drawing.Point(339, 26);
            this.NumericUpDown_Add_Mode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Add_Mode.Name = "NumericUpDown_Add_Mode";
            this.NumericUpDown_Add_Mode.Size = new System.Drawing.Size(120, 22);
            this.NumericUpDown_Add_Mode.TabIndex = 5;
            // 
            // Label_Add_Name
            // 
            this.Label_Add_Name.AutoSize = true;
            this.Label_Add_Name.Location = new System.Drawing.Point(20, 70);
            this.Label_Add_Name.Name = "Label_Add_Name";
            this.Label_Add_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Add_Name.TabIndex = 1;
            this.Label_Add_Name.Text = "Name";
            // 
            // TabControl_Obj
            // 
            this.TabControl_Obj.Controls.Add(this.TabPage_Obj_Add);
            this.TabControl_Obj.Controls.Add(this.TabPage_Obj_Remove);
            this.TabControl_Obj.Location = new System.Drawing.Point(31, 66);
            this.TabControl_Obj.Name = "TabControl_Obj";
            this.TabControl_Obj.SelectedIndex = 0;
            this.TabControl_Obj.Size = new System.Drawing.Size(486, 200);
            this.TabControl_Obj.TabIndex = 6;
            // 
            // TabPage_Obj_Add
            // 
            this.TabPage_Obj_Add.Controls.Add(this.Label_Obj_Type);
            this.TabPage_Obj_Add.Controls.Add(this.Label_Obj_Name);
            this.TabPage_Obj_Add.Controls.Add(this.Button_Obj_Add);
            this.TabPage_Obj_Add.Controls.Add(this.NumericUpDown_Obj_Mode);
            this.TabPage_Obj_Add.Controls.Add(this.ComboBox_Obj_Type);
            this.TabPage_Obj_Add.Controls.Add(this.Label_Obj_Mode);
            this.TabPage_Obj_Add.Controls.Add(this.TextBox_Obj_Name);
            this.TabPage_Obj_Add.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Obj_Add.Name = "TabPage_Obj_Add";
            this.TabPage_Obj_Add.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Obj_Add.Size = new System.Drawing.Size(478, 171);
            this.TabPage_Obj_Add.TabIndex = 0;
            this.TabPage_Obj_Add.Text = "Add";
            this.TabPage_Obj_Add.UseVisualStyleBackColor = true;
            // 
            // TabPage_Obj_Remove
            // 
            this.TabPage_Obj_Remove.Controls.Add(this.ComboBox_Obj_Remove);
            this.TabPage_Obj_Remove.Controls.Add(this.Button_Obj_Remove);
            this.TabPage_Obj_Remove.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Obj_Remove.Name = "TabPage_Obj_Remove";
            this.TabPage_Obj_Remove.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Obj_Remove.Size = new System.Drawing.Size(478, 171);
            this.TabPage_Obj_Remove.TabIndex = 1;
            this.TabPage_Obj_Remove.Text = "Remove";
            this.TabPage_Obj_Remove.UseVisualStyleBackColor = true;
            // 
            // ComboBox_Obj_Remove
            // 
            this.ComboBox_Obj_Remove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Obj_Remove.FormattingEnabled = true;
            this.ComboBox_Obj_Remove.Location = new System.Drawing.Point(23, 50);
            this.ComboBox_Obj_Remove.Name = "ComboBox_Obj_Remove";
            this.ComboBox_Obj_Remove.Size = new System.Drawing.Size(436, 23);
            this.ComboBox_Obj_Remove.TabIndex = 1;
            // 
            // Button_Obj_Remove
            // 
            this.Button_Obj_Remove.AutoSize = true;
            this.Button_Obj_Remove.Location = new System.Drawing.Point(186, 126);
            this.Button_Obj_Remove.Name = "Button_Obj_Remove";
            this.Button_Obj_Remove.Size = new System.Drawing.Size(75, 25);
            this.Button_Obj_Remove.TabIndex = 0;
            this.Button_Obj_Remove.Text = "Remove";
            this.Button_Obj_Remove.UseVisualStyleBackColor = true;
            this.Button_Obj_Remove.Click += new System.EventHandler(this.Button_Obj_Remove_Click);
            // 
            // TabControl_Add
            // 
            this.TabControl_Add.Controls.Add(this.TabPage_Add_Add);
            this.TabControl_Add.Controls.Add(this.TabPage_Add_Remove);
            this.TabControl_Add.Location = new System.Drawing.Point(31, 317);
            this.TabControl_Add.Name = "TabControl_Add";
            this.TabControl_Add.SelectedIndex = 0;
            this.TabControl_Add.Size = new System.Drawing.Size(486, 200);
            this.TabControl_Add.TabIndex = 7;
            // 
            // TabPage_Add_Add
            // 
            this.TabPage_Add_Add.Controls.Add(this.Label_Add_Type);
            this.TabPage_Add_Add.Controls.Add(this.Label_Add_Name);
            this.TabPage_Add_Add.Controls.Add(this.Button_Add_Add);
            this.TabPage_Add_Add.Controls.Add(this.NumericUpDown_Add_Mode);
            this.TabPage_Add_Add.Controls.Add(this.ComboBox_Add_Type);
            this.TabPage_Add_Add.Controls.Add(this.Label_Add_Mode);
            this.TabPage_Add_Add.Controls.Add(this.TextBox_Add_Name);
            this.TabPage_Add_Add.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Add_Add.Name = "TabPage_Add_Add";
            this.TabPage_Add_Add.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Add_Add.Size = new System.Drawing.Size(478, 171);
            this.TabPage_Add_Add.TabIndex = 0;
            this.TabPage_Add_Add.Text = "Add";
            this.TabPage_Add_Add.UseVisualStyleBackColor = true;
            // 
            // TabPage_Add_Remove
            // 
            this.TabPage_Add_Remove.Controls.Add(this.ComboBox_Add_Remove);
            this.TabPage_Add_Remove.Controls.Add(this.Button_Add_Remove);
            this.TabPage_Add_Remove.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Add_Remove.Name = "TabPage_Add_Remove";
            this.TabPage_Add_Remove.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Add_Remove.Size = new System.Drawing.Size(478, 171);
            this.TabPage_Add_Remove.TabIndex = 1;
            this.TabPage_Add_Remove.Text = "Remove";
            this.TabPage_Add_Remove.UseVisualStyleBackColor = true;
            // 
            // ComboBox_Add_Remove
            // 
            this.ComboBox_Add_Remove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Add_Remove.FormattingEnabled = true;
            this.ComboBox_Add_Remove.Location = new System.Drawing.Point(23, 43);
            this.ComboBox_Add_Remove.Name = "ComboBox_Add_Remove";
            this.ComboBox_Add_Remove.Size = new System.Drawing.Size(436, 23);
            this.ComboBox_Add_Remove.TabIndex = 1;
            // 
            // Button_Add_Remove
            // 
            this.Button_Add_Remove.AutoSize = true;
            this.Button_Add_Remove.Location = new System.Drawing.Point(186, 119);
            this.Button_Add_Remove.Name = "Button_Add_Remove";
            this.Button_Add_Remove.Size = new System.Drawing.Size(75, 25);
            this.Button_Add_Remove.TabIndex = 0;
            this.Button_Add_Remove.Text = "Remove";
            this.Button_Add_Remove.UseVisualStyleBackColor = true;
            this.Button_Add_Remove.Click += new System.EventHandler(this.Button_Add_Remove_Click);
            // 
            // ElementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 551);
            this.Controls.Add(this.Label_Additional);
            this.Controls.Add(this.TabControl_Add);
            this.Controls.Add(this.Label_Object);
            this.Controls.Add(this.TabControl_Obj);
            this.Name = "ElementWindow";
            this.Text = "要素の追加/削除";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Obj_Mode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Add_Mode)).EndInit();
            this.TabControl_Obj.ResumeLayout(false);
            this.TabPage_Obj_Add.ResumeLayout(false);
            this.TabPage_Obj_Add.PerformLayout();
            this.TabPage_Obj_Remove.ResumeLayout(false);
            this.TabPage_Obj_Remove.PerformLayout();
            this.TabControl_Add.ResumeLayout(false);
            this.TabPage_Add_Add.ResumeLayout(false);
            this.TabPage_Add_Add.PerformLayout();
            this.TabPage_Add_Remove.ResumeLayout(false);
            this.TabPage_Add_Remove.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_Obj_Type;
        private System.Windows.Forms.Label Label_Obj_Type;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Obj_Mode;
        private System.Windows.Forms.Label Label_Obj_Mode;
        private System.Windows.Forms.Label Label_Obj_Name;
        private System.Windows.Forms.TextBox TextBox_Obj_Name;
        private System.Windows.Forms.Button Button_Obj_Add;
        private System.Windows.Forms.Label Label_Object;
        private System.Windows.Forms.Label Label_Additional;
        private System.Windows.Forms.Label Label_Add_Type;
        private System.Windows.Forms.Button Button_Add_Add;
        private System.Windows.Forms.ComboBox ComboBox_Add_Type;
        private System.Windows.Forms.TextBox TextBox_Add_Name;
        private System.Windows.Forms.Label Label_Add_Mode;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Add_Mode;
        private System.Windows.Forms.Label Label_Add_Name;
        private System.Windows.Forms.TabControl TabControl_Obj;
        private System.Windows.Forms.TabPage TabPage_Obj_Add;
        private System.Windows.Forms.TabPage TabPage_Obj_Remove;
        private System.Windows.Forms.Button Button_Obj_Remove;
        private System.Windows.Forms.ComboBox ComboBox_Obj_Remove;
        private System.Windows.Forms.TabControl TabControl_Add;
        private System.Windows.Forms.TabPage TabPage_Add_Add;
        private System.Windows.Forms.TabPage TabPage_Add_Remove;
        private System.Windows.Forms.ComboBox ComboBox_Add_Remove;
        private System.Windows.Forms.Button Button_Add_Remove;
    }
}