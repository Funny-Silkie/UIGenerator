using System;
using System.Threading;
using System.Windows.Forms;
using fslib.IO;

namespace UIGenerator
{
    public partial class FontAddForm : Form
    {
        /// <summary>
        /// インスタンスが生成されているかどうかを取得する
        /// </summary>
        public static bool Instanced { get; private set; } = false;
        public FontAddForm()
        {
            Instanced = true;
            InitializeComponent();
            ResetListView(false);
        }
        private void FontAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            Instanced = false;
        }

        private void Button_FileSearch_Click(object sender, EventArgs e)
        {
            var name = TextBox_Path_D.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the Font File",
                Filter = FilePathHelper.GetFilter("Font Files", ".otf", ".ttf", ".ttc")
            };
            var thread = new Thread(new ParameterizedThreadStart(x => 
            {
                var state = o.ShowDialog(); 
                if (state == DialogResult.OK) name = o.FileName;
            }));
            o.Dispose();
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            TextBox_Path_D.Text = name;
        }
        private void Button_S_FileSearch_Click(object sender, EventArgs e)
        {
            var name = TextBox_S_Path.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the Font File",
                Filter = FilePathHelper.GetFilter("Font Files", ".aff")
            };
            var thread = new Thread(new ParameterizedThreadStart(x =>
            {
                var state = o.ShowDialog();
                if (state == DialogResult.OK) name = o.FileName;
            }));
            o.Dispose();
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            TextBox_S_Path.Text = name;
        }
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
        }
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
        private void FormReset_S()
        {
            TextBox_S_Path.Text = "";
        }
        private void ResetListView(bool clear)
        {
            if (clear) ListView_AllFonts.Items.Clear();
            foreach (var f in DataBase.Fonts)
            {
                Console.WriteLine(f.ToString());
                ListView_AllFonts.Items.Add(f.ToString());
            }
        }
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
        }
    }
}
