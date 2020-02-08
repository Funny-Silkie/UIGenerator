using System;
using System.Windows.Forms;

namespace UIGenerator
{
    /// <summary>
    /// フォントの追加・削除を行うフォームのクラス
    /// </summary>
    public partial class FontIOForm : Form
    {
        /// <summary>
        /// インスタンスが生成されているかどうかを取得する
        /// </summary>
        public static bool Instanced => SigleInstance != null;
        /// <summary>
        /// 唯一のインスタンスを取得する
        /// </summary>
        public static FontIOForm SigleInstance { get; private set; } = null;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private FontIOForm()
        {
            SigleInstance = this;
            InitializeComponent();
            ResetListView(false);
            ResetComboBox();
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void FontAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            SigleInstance = null;
        }
        /// <summary>
        /// <see cref="Button_D_FileSearch"/>クリック時の挙動
        /// </summary>
        private void Button_D_FileSearch_Click(object sender, EventArgs e)
        {
            var name = TextBox_Path_D.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the Font File",
                Filter = FilePathHelper.GetFilter("Font Files", ".otf", ".ttf", ".ttc")
            };
            var state = o.ShowDialog();
            if (state == DialogResult.OK) name = o.FileName;
            o.Dispose();
            TextBox_Path_D.Text = name;
        }
        /// <summary>
        /// <see cref="Button_S_FileSearch"/>クリック時の挙動
        /// </summary>
        private void Button_S_FileSearch_Click(object sender, EventArgs e)
        {
            var name = TextBox_S_Path.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the Font File",
                Filter = FilePathHelper.GetFilter("Font Files", ".aff")
            };
            var state = o.ShowDialog();
            if (state == DialogResult.OK) name = o.FileName;
            o.Dispose();
            TextBox_S_Path.Text = name;
        }
        /// <summary>
        /// <see cref="Button_D_Register"/>クリック時の挙動
        /// </summary>
        private void Button_D_Register_Click(object sender, EventArgs e)
        {
            var fontsize = (int)NumericUpDown_D_Size.Value;
            var fontcolor = new asd.Color((int)NumericUpDown_D_FR.Value, (int)NumericUpDown_D_FG.Value, (int)NumericUpDown_D_FB.Value, (int)NumericUpDown_D_FA.Value);
            var outlinesize = (int)NumericUpDown_D_OutLineSize.Value;
            var outlinecolor = new asd.Color((int)NumericUpDown_D_OR.Value, (int)NumericUpDown_D_OG.Value, (int)NumericUpDown_D_OB.Value, (int)NumericUpDown_D_OA.Value);
            var path = TextBox_Path_D.Text;
            DynamicFontInfo fontinfo;
            if (!asd.Engine.File.Exists(path))
            {
                Console.WriteLine("FilePath Is Wrong");
                return;
            }
            try
            {
                fontinfo = DynamicFontInfo.GetInstance(path, fontsize, fontcolor, outlinesize, outlinecolor);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Failed to create font");
                return;
            }
            if (DataBase.Fonts.Contains(fontinfo))
            {
                Console.WriteLine("Font is duplicated");
                return;
            }
            DataBase.Fonts.Add(fontinfo);
            Console.WriteLine("Succeeded to create font");
            FormReset_D();
            ResetListView(true);
            ResetComboBox();
        }
        /// <summary>
        /// Dynamicのフォーム内容を初期化する
        /// </summary>
        private void FormReset_D()
        {
            NumericUpDown_D_Size.Value = 30;
            NumericUpDown_D_OutLineSize.Value = 1;
            NumericUpDown_D_FR.Value = 255;
            NumericUpDown_D_FG.Value = 255;
            NumericUpDown_D_FB.Value = 255;
            NumericUpDown_D_FA.Value = 255;
            NumericUpDown_D_OR.Value = 0;
            NumericUpDown_D_OG.Value = 0;
            NumericUpDown_D_OB.Value = 0;
            NumericUpDown_D_OA.Value = 255;
            TextBox_Path_D.Text = "";
        }
        /// <summary>
        /// Staticのフォーム内容を初期化する
        /// </summary>
        private void FormReset_S()
        {
            TextBox_S_Path.Text = "";
        }
        /// <summary>
        /// <see cref="ListView_AllFonts"/>を更新する
        /// </summary>
        /// <param name="clear">今までの要素を削除するかどうか</param>
        public void ResetListView(bool clear)
        {
            if (clear) ListView_AllFonts.Items.Clear();
            foreach (var f in DataBase.Fonts) ListView_AllFonts.Items.Add(f.ToString());
        }
        /// <summary>
        /// <see cref="ComboBox_RemoveRange"/>の要素を更新する
        /// </summary>
        public void ResetComboBox()
        {
            ComboBox_RemoveRange.DataSource = DataBase.Fonts.GetNames();
            ComboBox_RemoveRange.SelectedIndex = 0;
        }
        /// <summary>
        /// <see cref="Button_S_Register"/>クリック時の挙動
        /// </summary>
        private void Button_S_Register_Click(object sender, EventArgs e)
        {
            var path = TextBox_S_Path.Text;
            StaticFontInfo fontinfo;
            if (!asd.Engine.File.Exists(path))
            {
                Console.WriteLine("FilePath Is Wrong");
                return;
            }
            try
            {
                fontinfo = StaticFontInfo.GetInstance(path);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Failed to create font");
                return;
            }
            if (DataBase.Fonts.Contains(fontinfo))
            {
                Console.WriteLine("Font is duplicated");
                return;
            }
            DataBase.Fonts.Add(fontinfo);
            Console.WriteLine("Succeeded to create font");
            FormReset_S();
            ResetListView(true);
            ResetComboBox();
        }
        /// <summary>
        /// <see cref="Button_Remove"/>クリック時の挙動
        /// </summary>
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            var index = ComboBox_RemoveRange.SelectedIndex;
            if (index < 0 || DataBase.Fonts.Count <= index)
            {
                Console.WriteLine("選択されている要素は管理されていません");
                return;
            }
            if (index == 0)
            {
                Console.WriteLine("デフォルトのフォントは削除できません");
                return;
            }
            DataBase.Fonts.RemoveAt(index);
            Console.WriteLine("フォントの削除に成功しました");
            ResetListView(true);
            ResetComboBox();
        }
        /// <summary>
        /// インスタンスを生成して開く
        /// </summary>
        public static bool CreateAndShow()
        {
            if (!Instanced)
            {
                var fontform = new FontIOForm();
                DataBase.Forms.Add(fontform);
                fontform.Show();
                return true;
            }
            return false;
        }
    }
}
