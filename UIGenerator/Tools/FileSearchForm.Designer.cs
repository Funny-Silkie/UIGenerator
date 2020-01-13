namespace UIGenerator
{
    partial class FileSearchForm
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
            this.Button_Search = new System.Windows.Forms.Button();
            this.RichTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(41, 70);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(423, 22);
            this.TextBox_Path.TabIndex = 0;
            // 
            // Label_Path
            // 
            this.Label_Path.AutoSize = true;
            this.Label_Path.Location = new System.Drawing.Point(38, 32);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(137, 15);
            this.Label_Path.TabIndex = 1;
            this.Label_Path.Text = "検索したいファイルパス";
            // 
            // Button_Search
            // 
            this.Button_Search.AutoSize = true;
            this.Button_Search.Location = new System.Drawing.Point(208, 132);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(75, 25);
            this.Button_Search.TabIndex = 2;
            this.Button_Search.Text = "検索";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // RichTextBox_Log
            // 
            this.RichTextBox_Log.DetectUrls = false;
            this.RichTextBox_Log.Location = new System.Drawing.Point(41, 180);
            this.RichTextBox_Log.Name = "RichTextBox_Log";
            this.RichTextBox_Log.ReadOnly = true;
            this.RichTextBox_Log.Size = new System.Drawing.Size(423, 45);
            this.RichTextBox_Log.TabIndex = 3;
            this.RichTextBox_Log.Text = "";
            // 
            // FileSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 237);
            this.Controls.Add(this.RichTextBox_Log);
            this.Controls.Add(this.Button_Search);
            this.Controls.Add(this.Label_Path);
            this.Controls.Add(this.TextBox_Path);
            this.Name = "FileSearchForm";
            this.Text = "ファイルパスを検索する";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileSearchForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.Label Label_Path;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.RichTextBox RichTextBox_Log;
    }
}