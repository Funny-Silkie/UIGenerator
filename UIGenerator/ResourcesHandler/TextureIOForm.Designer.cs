﻿namespace UIGenerator
{
    partial class TextureIOForm
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
            this.Button_Register = new System.Windows.Forms.Button();
            this.Button_FileSearch = new System.Windows.Forms.Button();
            this.Label_Path = new System.Windows.Forms.Label();
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.ListView_AllTextures = new System.Windows.Forms.ListView();
            this.ColumnHeader_Texture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControl_Texture = new System.Windows.Forms.TabControl();
            this.TabPage_Register = new System.Windows.Forms.TabPage();
            this.TabPage_Remove = new System.Windows.Forms.TabPage();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.ComboBox_RemoveRange = new System.Windows.Forms.ComboBox();
            this.TabControl_Texture.SuspendLayout();
            this.TabPage_Register.SuspendLayout();
            this.TabPage_Remove.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Register
            // 
            this.Button_Register.AutoSize = true;
            this.Button_Register.Location = new System.Drawing.Point(273, 135);
            this.Button_Register.Name = "Button_Register";
            this.Button_Register.Size = new System.Drawing.Size(75, 25);
            this.Button_Register.TabIndex = 11;
            this.Button_Register.Text = "Register";
            this.Button_Register.UseVisualStyleBackColor = true;
            this.Button_Register.Click += new System.EventHandler(this.Button_Register_Click);
            // 
            // Button_FileSearch
            // 
            this.Button_FileSearch.AutoSize = true;
            this.Button_FileSearch.Location = new System.Drawing.Point(533, 71);
            this.Button_FileSearch.Name = "Button_FileSearch";
            this.Button_FileSearch.Size = new System.Drawing.Size(75, 25);
            this.Button_FileSearch.TabIndex = 10;
            this.Button_FileSearch.Text = "Ref";
            this.Button_FileSearch.UseVisualStyleBackColor = true;
            this.Button_FileSearch.Click += new System.EventHandler(this.Button_FileSearch_Click);
            // 
            // Label_Path
            // 
            this.Label_Path.AutoSize = true;
            this.Label_Path.Location = new System.Drawing.Point(28, 33);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(86, 15);
            this.Label_Path.TabIndex = 9;
            this.Label_Path.Text = "TexturePath";
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(31, 73);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(467, 22);
            this.TextBox_Path.TabIndex = 8;
            // 
            // ListView_AllTextures
            // 
            this.ListView_AllTextures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader_Texture});
            this.ListView_AllTextures.FullRowSelect = true;
            this.ListView_AllTextures.GridLines = true;
            this.ListView_AllTextures.HideSelection = false;
            this.ListView_AllTextures.Location = new System.Drawing.Point(51, 290);
            this.ListView_AllTextures.Name = "ListView_AllTextures";
            this.ListView_AllTextures.Size = new System.Drawing.Size(641, 184);
            this.ListView_AllTextures.TabIndex = 13;
            this.ListView_AllTextures.UseCompatibleStateImageBehavior = false;
            this.ListView_AllTextures.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader_Texture
            // 
            this.ColumnHeader_Texture.Text = "Texture";
            this.ColumnHeader_Texture.Width = 480;
            // 
            // TabControl_Texture
            // 
            this.TabControl_Texture.Controls.Add(this.TabPage_Register);
            this.TabControl_Texture.Controls.Add(this.TabPage_Remove);
            this.TabControl_Texture.Location = new System.Drawing.Point(51, 38);
            this.TabControl_Texture.Name = "TabControl_Texture";
            this.TabControl_Texture.SelectedIndex = 0;
            this.TabControl_Texture.Size = new System.Drawing.Size(641, 218);
            this.TabControl_Texture.TabIndex = 14;
            // 
            // TabPage_Register
            // 
            this.TabPage_Register.Controls.Add(this.Button_Register);
            this.TabPage_Register.Controls.Add(this.TextBox_Path);
            this.TabPage_Register.Controls.Add(this.Label_Path);
            this.TabPage_Register.Controls.Add(this.Button_FileSearch);
            this.TabPage_Register.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Register.Name = "TabPage_Register";
            this.TabPage_Register.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Register.Size = new System.Drawing.Size(633, 189);
            this.TabPage_Register.TabIndex = 0;
            this.TabPage_Register.Text = "Register";
            this.TabPage_Register.UseVisualStyleBackColor = true;
            // 
            // TabPage_Remove
            // 
            this.TabPage_Remove.Controls.Add(this.ComboBox_RemoveRange);
            this.TabPage_Remove.Controls.Add(this.Button_Remove);
            this.TabPage_Remove.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Remove.Name = "TabPage_Remove";
            this.TabPage_Remove.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Remove.Size = new System.Drawing.Size(633, 189);
            this.TabPage_Remove.TabIndex = 1;
            this.TabPage_Remove.Text = "Remove";
            this.TabPage_Remove.UseVisualStyleBackColor = true;
            // 
            // Button_Remove
            // 
            this.Button_Remove.AutoSize = true;
            this.Button_Remove.Location = new System.Drawing.Point(273, 135);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 25);
            this.Button_Remove.TabIndex = 0;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // ComboBox_RemoveRange
            // 
            this.ComboBox_RemoveRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_RemoveRange.FormattingEnabled = true;
            this.ComboBox_RemoveRange.Location = new System.Drawing.Point(44, 65);
            this.ComboBox_RemoveRange.Name = "ComboBox_RemoveRange";
            this.ComboBox_RemoveRange.Size = new System.Drawing.Size(545, 23);
            this.ComboBox_RemoveRange.TabIndex = 1;
            // 
            // TextureIOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 510);
            this.Controls.Add(this.TabControl_Texture);
            this.Controls.Add(this.ListView_AllTextures);
            this.Name = "TextureIOForm";
            this.Text = "TextureIOForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TextureAddForm_FormClosed);
            this.TabControl_Texture.ResumeLayout(false);
            this.TabPage_Register.ResumeLayout(false);
            this.TabPage_Register.PerformLayout();
            this.TabPage_Remove.ResumeLayout(false);
            this.TabPage_Remove.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_Register;
        private System.Windows.Forms.Button Button_FileSearch;
        private System.Windows.Forms.Label Label_Path;
        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.ListView ListView_AllTextures;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Texture;
        private System.Windows.Forms.TabControl TabControl_Texture;
        private System.Windows.Forms.TabPage TabPage_Register;
        private System.Windows.Forms.TabPage TabPage_Remove;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.ComboBox ComboBox_RemoveRange;
    }
}