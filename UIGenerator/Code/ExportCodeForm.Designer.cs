namespace UIGenerator
{
    partial class ExportCodeForm
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
            this.TextBox_LayerName = new System.Windows.Forms.TextBox();
            this.Label_LayerName = new System.Windows.Forms.Label();
            this.Label_Lang = new System.Windows.Forms.Label();
            this.ComboBox_Lang = new System.Windows.Forms.ComboBox();
            this.TextBox_NameSpace = new System.Windows.Forms.TextBox();
            this.Label_NameSpace = new System.Windows.Forms.Label();
            this.Label_Path = new System.Windows.Forms.Label();
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.Button_Ref = new System.Windows.Forms.Button();
            this.Button_Export = new System.Windows.Forms.Button();
            this.ComboBox_Encoding = new System.Windows.Forms.ComboBox();
            this.Label_Encoding = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox_LayerName
            // 
            this.TextBox_LayerName.Location = new System.Drawing.Point(40, 105);
            this.TextBox_LayerName.Name = "TextBox_LayerName";
            this.TextBox_LayerName.Size = new System.Drawing.Size(292, 22);
            this.TextBox_LayerName.TabIndex = 0;
            this.TextBox_LayerName.Text = "UILayer";
            // 
            // Label_LayerName
            // 
            this.Label_LayerName.AutoSize = true;
            this.Label_LayerName.Location = new System.Drawing.Point(37, 71);
            this.Label_LayerName.Name = "Label_LayerName";
            this.Label_LayerName.Size = new System.Drawing.Size(295, 15);
            this.Label_LayerName.TabIndex = 1;
            this.Label_LayerName.Text = "Layerの名前(先頭と末尾の空白は削除されます)";
            // 
            // Label_Lang
            // 
            this.Label_Lang.AutoSize = true;
            this.Label_Lang.Location = new System.Drawing.Point(37, 25);
            this.Label_Lang.Name = "Label_Lang";
            this.Label_Lang.Size = new System.Drawing.Size(37, 15);
            this.Label_Lang.TabIndex = 2;
            this.Label_Lang.Text = "言語";
            // 
            // ComboBox_Lang
            // 
            this.ComboBox_Lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Lang.FormattingEnabled = true;
            this.ComboBox_Lang.Location = new System.Drawing.Point(109, 25);
            this.ComboBox_Lang.Name = "ComboBox_Lang";
            this.ComboBox_Lang.Size = new System.Drawing.Size(223, 23);
            this.ComboBox_Lang.TabIndex = 3;
            // 
            // TextBox_NameSpace
            // 
            this.TextBox_NameSpace.Location = new System.Drawing.Point(396, 105);
            this.TextBox_NameSpace.Name = "TextBox_NameSpace";
            this.TextBox_NameSpace.Size = new System.Drawing.Size(292, 22);
            this.TextBox_NameSpace.TabIndex = 0;
            this.TextBox_NameSpace.Text = "UIProject";
            // 
            // Label_NameSpace
            // 
            this.Label_NameSpace.AutoSize = true;
            this.Label_NameSpace.Location = new System.Drawing.Point(393, 71);
            this.Label_NameSpace.Name = "Label_NameSpace";
            this.Label_NameSpace.Size = new System.Drawing.Size(278, 15);
            this.Label_NameSpace.TabIndex = 1;
            this.Label_NameSpace.Text = "名前空間(先頭と末尾の空白は削除されます)";
            // 
            // Label_Path
            // 
            this.Label_Path.AutoSize = true;
            this.Label_Path.Location = new System.Drawing.Point(37, 157);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(129, 15);
            this.Label_Path.TabIndex = 4;
            this.Label_Path.Text = "保存先のファイルパス";
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(40, 195);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(459, 22);
            this.TextBox_Path.TabIndex = 5;
            // 
            // Button_Ref
            // 
            this.Button_Ref.AutoSize = true;
            this.Button_Ref.Location = new System.Drawing.Point(533, 193);
            this.Button_Ref.Name = "Button_Ref";
            this.Button_Ref.Size = new System.Drawing.Size(75, 25);
            this.Button_Ref.TabIndex = 6;
            this.Button_Ref.Text = "Ref";
            this.Button_Ref.UseVisualStyleBackColor = true;
            this.Button_Ref.Click += new System.EventHandler(this.Button_Ref_Click);
            // 
            // Button_Export
            // 
            this.Button_Export.Location = new System.Drawing.Point(314, 319);
            this.Button_Export.Name = "Button_Export";
            this.Button_Export.Size = new System.Drawing.Size(75, 23);
            this.Button_Export.TabIndex = 7;
            this.Button_Export.Text = "Export";
            this.Button_Export.UseVisualStyleBackColor = true;
            this.Button_Export.Click += new System.EventHandler(this.Button_Export_Click);
            // 
            // ComboBox_Encoding
            // 
            this.ComboBox_Encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Encoding.FormattingEnabled = true;
            this.ComboBox_Encoding.Location = new System.Drawing.Point(223, 255);
            this.ComboBox_Encoding.MaxDropDownItems = 30;
            this.ComboBox_Encoding.Name = "ComboBox_Encoding";
            this.ComboBox_Encoding.Size = new System.Drawing.Size(276, 23);
            this.ComboBox_Encoding.TabIndex = 8;
            // 
            // Label_Encoding
            // 
            this.Label_Encoding.AutoSize = true;
            this.Label_Encoding.Location = new System.Drawing.Point(37, 258);
            this.Label_Encoding.Name = "Label_Encoding";
            this.Label_Encoding.Size = new System.Drawing.Size(104, 15);
            this.Label_Encoding.TabIndex = 9;
            this.Label_Encoding.Text = "エンコードの種類";
            // 
            // ExportCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 372);
            this.Controls.Add(this.Label_Encoding);
            this.Controls.Add(this.ComboBox_Encoding);
            this.Controls.Add(this.Button_Export);
            this.Controls.Add(this.Button_Ref);
            this.Controls.Add(this.TextBox_Path);
            this.Controls.Add(this.Label_Path);
            this.Controls.Add(this.ComboBox_Lang);
            this.Controls.Add(this.Label_Lang);
            this.Controls.Add(this.Label_NameSpace);
            this.Controls.Add(this.TextBox_NameSpace);
            this.Controls.Add(this.Label_LayerName);
            this.Controls.Add(this.TextBox_LayerName);
            this.Name = "ExportCodeForm";
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_LayerName;
        private System.Windows.Forms.Label Label_LayerName;
        private System.Windows.Forms.Label Label_Lang;
        private System.Windows.Forms.ComboBox ComboBox_Lang;
        private System.Windows.Forms.TextBox TextBox_NameSpace;
        private System.Windows.Forms.Label Label_NameSpace;
        private System.Windows.Forms.Label Label_Path;
        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.Button Button_Ref;
        private System.Windows.Forms.Button Button_Export;
        private System.Windows.Forms.ComboBox ComboBox_Encoding;
        private System.Windows.Forms.Label Label_Encoding;
    }
}