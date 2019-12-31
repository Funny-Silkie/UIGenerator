using System;
using System.Threading;
using System.Windows.Forms;

namespace UIGenerator
{
    public partial class TextureAddForm : Form
    {
        /// <summary>
        /// インスタンス化されているかどうかを取得する
        /// </summary>
        public static bool Instanced { get; private set; }
        public TextureAddForm()
        {
            Instanced = true;
            InitializeComponent();
            ResetListView(false);
        }
        private void TextureAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            Instanced = false;
        }

        private void ResetListView(bool clear)
        {
            if (clear) ListView_AllTextures.Items.Clear();
            foreach (var f in DataBase.Textures)
            {
                Console.WriteLine(f.ToString());
                ListView_AllTextures.Items.Add(f.ToString());
            }
        }
        private void Button_FileSearch_Click(object sender, EventArgs e)
        {
            var name = TextBox_Path.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the Texture File",
                Filter = "Texture Files (*.png,*.jpg,*.jpeg,*.gif,*.tif,*.tiff,*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.tif;*.tiff;*.bmp"
            };
            var thread = new Thread(new ParameterizedThreadStart(x =>
            {
                var state = o.ShowDialog();
                if (state == DialogResult.OK)
                {
                    name = o.FileName;
                }
            }));
            o.Dispose();
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            TextBox_Path.Text = name;
        }
        private void Button_Register_Click(object sender, EventArgs e)
        {
            var path = TextBox_Path.Text;
            TextureInfo textureinfo;
            if (!asd.Engine.File.Exists(path))
            {
                Label_Succeed.Text = "FilePath Is Wrong";
                return;
            }
            try
            {
                textureinfo = TextureInfo.GetInstance(path);
            }
            catch (System.IO.IOException)
            {
                Label_Succeed.Text = "Failed to create texture";
                return;
            }
            if (DataBase.Textures.Contains(textureinfo))
            {
                Label_Succeed.Text = "Texture is duplicated";
                return;
            }
            DataBase.Textures.Add(textureinfo);
            Label_Succeed.Text = "Succeeded to create texture";
            TextBox_Path.Text = "";
            ResetListView(true);
        }
    }
}
