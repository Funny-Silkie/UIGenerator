namespace UIGenerator
{
    partial class OptionForm
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
            this.NumericUpDown_Window_X = new System.Windows.Forms.NumericUpDown();
            this.Label_Window_X = new System.Windows.Forms.Label();
            this.Label_Window = new System.Windows.Forms.Label();
            this.NumericUpDown_Window_Y = new System.Windows.Forms.NumericUpDown();
            this.Label_Window_Y = new System.Windows.Forms.Label();
            this.TextBox_ProjectName = new System.Windows.Forms.TextBox();
            this.Label_ProjectName = new System.Windows.Forms.Label();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Window_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Window_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDown_Window_X
            // 
            this.NumericUpDown_Window_X.Location = new System.Drawing.Point(66, 135);
            this.NumericUpDown_Window_X.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Window_X.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Window_X.Name = "NumericUpDown_Window_X";
            this.NumericUpDown_Window_X.Size = new System.Drawing.Size(81, 22);
            this.NumericUpDown_Window_X.TabIndex = 2;
            this.NumericUpDown_Window_X.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label_Window_X
            // 
            this.Label_Window_X.AutoSize = true;
            this.Label_Window_X.Location = new System.Drawing.Point(28, 137);
            this.Label_Window_X.Name = "Label_Window_X";
            this.Label_Window_X.Size = new System.Drawing.Size(16, 15);
            this.Label_Window_X.TabIndex = 1;
            this.Label_Window_X.Text = "X";
            // 
            // Label_Window
            // 
            this.Label_Window.AutoSize = true;
            this.Label_Window.Location = new System.Drawing.Point(28, 103);
            this.Label_Window.Name = "Label_Window";
            this.Label_Window.Size = new System.Drawing.Size(81, 15);
            this.Label_Window.TabIndex = 2;
            this.Label_Window.Text = "WindowSize";
            // 
            // NumericUpDown_Window_Y
            // 
            this.NumericUpDown_Window_Y.Location = new System.Drawing.Point(219, 135);
            this.NumericUpDown_Window_Y.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Window_Y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Window_Y.Name = "NumericUpDown_Window_Y";
            this.NumericUpDown_Window_Y.Size = new System.Drawing.Size(81, 22);
            this.NumericUpDown_Window_Y.TabIndex = 3;
            this.NumericUpDown_Window_Y.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label_Window_Y
            // 
            this.Label_Window_Y.AutoSize = true;
            this.Label_Window_Y.Location = new System.Drawing.Point(181, 137);
            this.Label_Window_Y.Name = "Label_Window_Y";
            this.Label_Window_Y.Size = new System.Drawing.Size(16, 15);
            this.Label_Window_Y.TabIndex = 1;
            this.Label_Window_Y.Text = "Y";
            // 
            // TextBox_ProjectName
            // 
            this.TextBox_ProjectName.Location = new System.Drawing.Point(31, 59);
            this.TextBox_ProjectName.Name = "TextBox_ProjectName";
            this.TextBox_ProjectName.Size = new System.Drawing.Size(269, 22);
            this.TextBox_ProjectName.TabIndex = 1;
            // 
            // Label_ProjectName
            // 
            this.Label_ProjectName.AutoSize = true;
            this.Label_ProjectName.Location = new System.Drawing.Point(28, 23);
            this.Label_ProjectName.Name = "Label_ProjectName";
            this.Label_ProjectName.Size = new System.Drawing.Size(89, 15);
            this.Label_ProjectName.TabIndex = 4;
            this.Label_ProjectName.Text = "ProjectName";
            // 
            // Button_Save
            // 
            this.Button_Save.AutoSize = true;
            this.Button_Save.Location = new System.Drawing.Point(72, 193);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 25);
            this.Button_Save.TabIndex = 4;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.AutoSize = true;
            this.Button_Cancel.Location = new System.Drawing.Point(198, 193);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 25);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 253);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Label_ProjectName);
            this.Controls.Add(this.TextBox_ProjectName);
            this.Controls.Add(this.Label_Window);
            this.Controls.Add(this.Label_Window_Y);
            this.Controls.Add(this.NumericUpDown_Window_Y);
            this.Controls.Add(this.Label_Window_X);
            this.Controls.Add(this.NumericUpDown_Window_X);
            this.Name = "OptionForm";
            this.Text = "Option";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Window_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Window_Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumericUpDown_Window_X;
        private System.Windows.Forms.Label Label_Window_X;
        private System.Windows.Forms.Label Label_Window;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Window_Y;
        private System.Windows.Forms.Label Label_Window_Y;
        private System.Windows.Forms.TextBox TextBox_ProjectName;
        private System.Windows.Forms.Label Label_ProjectName;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Cancel;
    }
}