namespace UIGenerator
{
    partial class TextureAddForm
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
            this.SuspendLayout();
            // 
            // Button_Register
            // 
            this.Button_Register.AutoSize = true;
            this.Button_Register.Location = new System.Drawing.Point(333, 144);
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
            this.Button_FileSearch.Location = new System.Drawing.Point(617, 75);
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
            this.Label_Path.Location = new System.Drawing.Point(48, 37);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(86, 15);
            this.Label_Path.TabIndex = 9;
            this.Label_Path.Text = "TexturePath";
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(51, 76);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(538, 22);
            this.TextBox_Path.TabIndex = 8;
            // 
            // ListView_AllTextures
            // 
            this.ListView_AllTextures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader_Texture});
            this.ListView_AllTextures.FullRowSelect = true;
            this.ListView_AllTextures.GridLines = true;
            this.ListView_AllTextures.HideSelection = false;
            this.ListView_AllTextures.Location = new System.Drawing.Point(51, 218);
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
            // TextureAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 450);
            this.Controls.Add(this.ListView_AllTextures);
            this.Controls.Add(this.Button_Register);
            this.Controls.Add(this.Button_FileSearch);
            this.Controls.Add(this.Label_Path);
            this.Controls.Add(this.TextBox_Path);
            this.Name = "TextureAddForm";
            this.Text = "TextureAddForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TextureAddForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button_Register;
        private System.Windows.Forms.Button Button_FileSearch;
        private System.Windows.Forms.Label Label_Path;
        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.ListView ListView_AllTextures;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Texture;
    }
}