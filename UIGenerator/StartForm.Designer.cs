namespace UIGenerator
{
    partial class StartForm
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
            this.StartMenu = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Label_wide = new System.Windows.Forms.Label();
            this.Label_length = new System.Windows.Forms.Label();
            this.TextBox_wide = new System.Windows.Forms.TextBox();
            this.TextBox_length = new System.Windows.Forms.TextBox();
            this.Button_init = new System.Windows.Forms.Button();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.StartMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartMenu
            // 
            this.StartMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.StartMenu.Location = new System.Drawing.Point(0, 0);
            this.StartMenu.Name = "StartMenu";
            this.StartMenu.Size = new System.Drawing.Size(494, 28);
            this.StartMenu.TabIndex = 0;
            this.StartMenu.Text = "Menu";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(65, 26);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.開くToolStripMenuItem.Text = "開く";
            // 
            // Label_wide
            // 
            this.Label_wide.AutoSize = true;
            this.Label_wide.Location = new System.Drawing.Point(24, 121);
            this.Label_wide.Name = "Label_wide";
            this.Label_wide.Size = new System.Drawing.Size(36, 15);
            this.Label_wide.TabIndex = 2;
            this.Label_wide.Text = "Wide";
            // 
            // Label_length
            // 
            this.Label_length.AutoSize = true;
            this.Label_length.Location = new System.Drawing.Point(188, 121);
            this.Label_length.Name = "Label_length";
            this.Label_length.Size = new System.Drawing.Size(51, 15);
            this.Label_length.TabIndex = 2;
            this.Label_length.Text = "Length";
            // 
            // TextBox_wide
            // 
            this.TextBox_wide.Location = new System.Drawing.Point(66, 118);
            this.TextBox_wide.Name = "TextBox_wide";
            this.TextBox_wide.Size = new System.Drawing.Size(100, 22);
            this.TextBox_wide.TabIndex = 1;
            // 
            // TextBox_length
            // 
            this.TextBox_length.Location = new System.Drawing.Point(245, 118);
            this.TextBox_length.Name = "TextBox_length";
            this.TextBox_length.Size = new System.Drawing.Size(100, 22);
            this.TextBox_length.TabIndex = 2;
            // 
            // Button_init
            // 
            this.Button_init.Location = new System.Drawing.Point(388, 117);
            this.Button_init.Name = "Button_init";
            this.Button_init.Size = new System.Drawing.Size(75, 23);
            this.Button_init.TabIndex = 3;
            this.Button_init.Text = "Init";
            this.Button_init.UseVisualStyleBackColor = true;
            this.Button_init.Click += new System.EventHandler(this.Button_init_Click);
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(73, 57);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(390, 22);
            this.TextBox_Name.TabIndex = 0;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(24, 60);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(43, 15);
            this.Label_Name.TabIndex = 2;
            this.Label_Name.Text = "Name";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 178);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Button_init);
            this.Controls.Add(this.TextBox_length);
            this.Controls.Add(this.TextBox_wide);
            this.Controls.Add(this.Label_length);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Label_wide);
            this.Controls.Add(this.StartMenu);
            this.MainMenuStrip = this.StartMenu;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.StartMenu.ResumeLayout(false);
            this.StartMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip StartMenu;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.Label Label_wide;
        private System.Windows.Forms.Label Label_length;
        private System.Windows.Forms.TextBox TextBox_wide;
        private System.Windows.Forms.TextBox TextBox_length;
        private System.Windows.Forms.Button Button_init;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Name;
    }
}