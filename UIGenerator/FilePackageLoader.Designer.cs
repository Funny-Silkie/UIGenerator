namespace UIGenerator
{
    partial class FilePackageLoader
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
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.Label_Path = new System.Windows.Forms.Label();
            this.Button_Ref = new System.Windows.Forms.Button();
            this.TextBox_PassWord = new System.Windows.Forms.TextBox();
            this.CheckBox_PassWord = new System.Windows.Forms.CheckBox();
            this.Button_Register = new System.Windows.Forms.Button();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.ListView_Packages = new System.Windows.Forms.ListView();
            this.ColumnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(37, 75);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(501, 22);
            this.TextBox_Path.TabIndex = 0;
            // 
            // Label_Path
            // 
            this.Label_Path.AutoSize = true;
            this.Label_Path.Location = new System.Drawing.Point(34, 34);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(58, 15);
            this.Label_Path.TabIndex = 1;
            this.Label_Path.Text = "FilePath";
            // 
            // Button_Ref
            // 
            this.Button_Ref.AutoSize = true;
            this.Button_Ref.Location = new System.Drawing.Point(585, 73);
            this.Button_Ref.Name = "Button_Ref";
            this.Button_Ref.Size = new System.Drawing.Size(75, 25);
            this.Button_Ref.TabIndex = 2;
            this.Button_Ref.Text = "Ref";
            this.Button_Ref.UseVisualStyleBackColor = true;
            this.Button_Ref.Click += new System.EventHandler(this.Button_Ref_Click);
            // 
            // TextBox_PassWord
            // 
            this.TextBox_PassWord.Enabled = false;
            this.TextBox_PassWord.Location = new System.Drawing.Point(167, 130);
            this.TextBox_PassWord.Name = "TextBox_PassWord";
            this.TextBox_PassWord.Size = new System.Drawing.Size(371, 22);
            this.TextBox_PassWord.TabIndex = 3;
            // 
            // CheckBox_PassWord
            // 
            this.CheckBox_PassWord.AutoSize = true;
            this.CheckBox_PassWord.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBox_PassWord.Location = new System.Drawing.Point(37, 132);
            this.CheckBox_PassWord.Name = "CheckBox_PassWord";
            this.CheckBox_PassWord.Size = new System.Drawing.Size(90, 19);
            this.CheckBox_PassWord.TabIndex = 4;
            this.CheckBox_PassWord.Text = "PassWord";
            this.CheckBox_PassWord.UseVisualStyleBackColor = true;
            this.CheckBox_PassWord.CheckedChanged += new System.EventHandler(this.CheckBox_PassWord_CheckedChanged);
            // 
            // Button_Register
            // 
            this.Button_Register.AutoSize = true;
            this.Button_Register.Location = new System.Drawing.Point(133, 191);
            this.Button_Register.Name = "Button_Register";
            this.Button_Register.Size = new System.Drawing.Size(75, 25);
            this.Button_Register.TabIndex = 5;
            this.Button_Register.Text = "Register";
            this.Button_Register.UseVisualStyleBackColor = true;
            this.Button_Register.Click += new System.EventHandler(this.Button_Register_Click);
            // 
            // Button_Remove
            // 
            this.Button_Remove.AutoSize = true;
            this.Button_Remove.Location = new System.Drawing.Point(433, 191);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 25);
            this.Button_Remove.TabIndex = 6;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // ListView_Packages
            // 
            this.ListView_Packages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader_Name});
            this.ListView_Packages.FullRowSelect = true;
            this.ListView_Packages.GridLines = true;
            this.ListView_Packages.HideSelection = false;
            this.ListView_Packages.Location = new System.Drawing.Point(37, 258);
            this.ListView_Packages.Name = "ListView_Packages";
            this.ListView_Packages.Size = new System.Drawing.Size(623, 221);
            this.ListView_Packages.TabIndex = 7;
            this.ListView_Packages.UseCompatibleStateImageBehavior = false;
            this.ListView_Packages.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader_Name
            // 
            this.ColumnHeader_Name.Text = "Package";
            this.ColumnHeader_Name.Width = 567;
            // 
            // FilePackageLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 524);
            this.Controls.Add(this.ListView_Packages);
            this.Controls.Add(this.Button_Remove);
            this.Controls.Add(this.Button_Register);
            this.Controls.Add(this.CheckBox_PassWord);
            this.Controls.Add(this.TextBox_PassWord);
            this.Controls.Add(this.Button_Ref);
            this.Controls.Add(this.Label_Path);
            this.Controls.Add(this.TextBox_Path);
            this.Name = "FilePackageLoader";
            this.Text = "FilePackageLoader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FilePackageLoader_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.Label Label_Path;
        private System.Windows.Forms.Button Button_Ref;
        private System.Windows.Forms.TextBox TextBox_PassWord;
        private System.Windows.Forms.CheckBox CheckBox_PassWord;
        private System.Windows.Forms.Button Button_Register;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.ListView ListView_Packages;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Name;
    }
}