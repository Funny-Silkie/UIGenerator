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
            this.ComboBox_Type.Location = new System.Drawing.Point(70, 20);
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
            // AddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Label_Type);
            this.Controls.Add(this.ComboBox_Type);
            this.Name = "AddWindow";
            this.Text = "AddWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_Type;
        private System.Windows.Forms.Label Label_Type;
    }
}