namespace UIGenerator
{
    partial class MainEdittor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEdittor));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上書き保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.要素を追加するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.フォントを編集するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.テクスチャを編集するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルパッケージを管理するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListView_Main = new System.Windows.Forms.ListView();
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label_ShowMode = new System.Windows.Forms.Label();
            this.NumericUpDown_ShowMode = new System.Windows.Forms.NumericUpDown();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ShowMode)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.編集ToolStripMenuItem});
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.Name = "MainMenu";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上書き保存ToolStripMenuItem,
            this.名前を付けて保存ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            resources.ApplyResources(this.ファイルToolStripMenuItem, "ファイルToolStripMenuItem");
            // 
            // 上書き保存ToolStripMenuItem
            // 
            this.上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            resources.ApplyResources(this.上書き保存ToolStripMenuItem, "上書き保存ToolStripMenuItem");
            this.上書き保存ToolStripMenuItem.Click += new System.EventHandler(this.上書き保存ToolStripMenuItem_Click);
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            resources.ApplyResources(this.名前を付けて保存ToolStripMenuItem, "名前を付けて保存ToolStripMenuItem");
            this.名前を付けて保存ToolStripMenuItem.Click += new System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.要素を追加するToolStripMenuItem,
            this.toolStripMenuItem1,
            this.フォントを編集するToolStripMenuItem,
            this.テクスチャを編集するToolStripMenuItem,
            this.ファイルパッケージを管理するToolStripMenuItem});
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            resources.ApplyResources(this.編集ToolStripMenuItem, "編集ToolStripMenuItem");
            // 
            // 要素を追加するToolStripMenuItem
            // 
            this.要素を追加するToolStripMenuItem.Name = "要素を追加するToolStripMenuItem";
            resources.ApplyResources(this.要素を追加するToolStripMenuItem, "要素を追加するToolStripMenuItem");
            this.要素を追加するToolStripMenuItem.Click += new System.EventHandler(this.要素を追加するToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // フォントを編集するToolStripMenuItem
            // 
            this.フォントを編集するToolStripMenuItem.Name = "フォントを編集するToolStripMenuItem";
            resources.ApplyResources(this.フォントを編集するToolStripMenuItem, "フォントを編集するToolStripMenuItem");
            this.フォントを編集するToolStripMenuItem.Click += new System.EventHandler(this.フォントを編集するToolStripMenuItem_Click);
            // 
            // テクスチャを編集するToolStripMenuItem
            // 
            this.テクスチャを編集するToolStripMenuItem.Name = "テクスチャを編集するToolStripMenuItem";
            resources.ApplyResources(this.テクスチャを編集するToolStripMenuItem, "テクスチャを編集するToolStripMenuItem");
            this.テクスチャを編集するToolStripMenuItem.Click += new System.EventHandler(this.テクスチャを編集するToolStripMenuItem_Click);
            // 
            // ファイルパッケージを管理するToolStripMenuItem
            // 
            this.ファイルパッケージを管理するToolStripMenuItem.Name = "ファイルパッケージを管理するToolStripMenuItem";
            resources.ApplyResources(this.ファイルパッケージを管理するToolStripMenuItem, "ファイルパッケージを管理するToolStripMenuItem");
            this.ファイルパッケージを管理するToolStripMenuItem.Click += new System.EventHandler(this.ファイルパッケージを管理するToolStripMenuItem_Click);
            // 
            // ListView_Main
            // 
            this.ListView_Main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Type,
            this.ObjectName,
            this.Mode});
            this.ListView_Main.FullRowSelect = true;
            this.ListView_Main.GridLines = true;
            this.ListView_Main.HideSelection = false;
            resources.ApplyResources(this.ListView_Main, "ListView_Main");
            this.ListView_Main.MultiSelect = false;
            this.ListView_Main.Name = "ListView_Main";
            this.ListView_Main.UseCompatibleStateImageBehavior = false;
            this.ListView_Main.View = System.Windows.Forms.View.Details;
            this.ListView_Main.ItemActivate += new System.EventHandler(this.ListView_Main_ItemActivate);
            // 
            // Type
            // 
            resources.ApplyResources(this.Type, "Type");
            // 
            // ObjectName
            // 
            resources.ApplyResources(this.ObjectName, "ObjectName");
            // 
            // Mode
            // 
            resources.ApplyResources(this.Mode, "Mode");
            // 
            // Label_ShowMode
            // 
            resources.ApplyResources(this.Label_ShowMode, "Label_ShowMode");
            this.Label_ShowMode.Name = "Label_ShowMode";
            // 
            // NumericUpDown_ShowMode
            // 
            resources.ApplyResources(this.NumericUpDown_ShowMode, "NumericUpDown_ShowMode");
            this.NumericUpDown_ShowMode.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_ShowMode.Name = "NumericUpDown_ShowMode";
            this.NumericUpDown_ShowMode.ValueChanged += new System.EventHandler(this.NumericUpDown_ShowMode_ValueChanged);
            // 
            // MainEdittor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumericUpDown_ShowMode);
            this.Controls.Add(this.Label_ShowMode);
            this.Controls.Add(this.ListView_Main);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainEdittor";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ShowMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上書き保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Mode;
        private System.Windows.Forms.ColumnHeader ObjectName;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 要素を追加するToolStripMenuItem;
        private System.Windows.Forms.Label Label_ShowMode;
        public System.Windows.Forms.ListView ListView_Main;
        public System.Windows.Forms.NumericUpDown NumericUpDown_ShowMode;
        private System.Windows.Forms.ToolStripMenuItem フォントを編集するToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem テクスチャを編集するToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ファイルパッケージを管理するToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}