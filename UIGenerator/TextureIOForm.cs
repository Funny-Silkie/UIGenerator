using System;
using System.Windows.Forms;
using fslib.IO;

namespace UIGenerator
{
    /// <summary>
    /// テクスチャの登録や削除を実行するフォーム
    /// </summary>
    public partial class TextureIOForm : Form
    {
        /// <summary>
        /// インスタンス化されているかどうかを取得する
        /// </summary>
        public static bool Instanced { get; private set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TextureIOForm()
        {
            Instanced = true;
            InitializeComponent();
            ResetListView(false);
            ResetCombobox();
        }
        /// <summary>
        /// フォームを閉じた時に実行
        /// </summary>
        private void TextureAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            Instanced = false;
        }
        /// <summary>
        /// <see cref="ListView_AllTextures"/>を更新する
        /// </summary>
        /// <param name="clear">要素をクリアするかどうか</param>
        private void ResetListView(bool clear)
        {
            if (clear) ListView_AllTextures.Items.Clear();
            foreach (var f in DataBase.Textures) ListView_AllTextures.Items.Add(f.ToString());
        }
        /// <summary>
        /// <see cref="Button_FileSearch"/>クリック時の挙動
        /// </summary>
        private void Button_FileSearch_Click(object sender, EventArgs e)
        {
            var name = TextBox_Path.Text;
            var o = new OpenFileDialog()
            {
                Title = "Open the Texture File",
                Filter = FilePathHelper.GetFilter("Texture Files", ".png", ".jpg", ".jpeg",".gif",".tif",".tiff",".bmp")
            };
            var state = o.ShowDialog();
            if (state == DialogResult.OK) name = o.FileName;
            o.Dispose();
            TextBox_Path.Text = name;
        }
        /// <summary>
        /// <see cref="Button_Register"/>クリック時の挙動
        /// </summary>
        private void Button_Register_Click(object sender, EventArgs e)
        {
            var path = TextBox_Path.Text;
            TextureInfo textureinfo;
            if (!asd.Engine.File.Exists(path))
            {
                Console.WriteLine("FilePath Is Wrong");
                return;
            }
            try
            {
                textureinfo = TextureInfo.GetInstance(path);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Failed to create texture");
                return;
            }
            if (DataBase.Textures.Contains(textureinfo))
            {
                Console.WriteLine("Texture is duplicated");
                return;
            }
            DataBase.Textures.Add(textureinfo);
            Console.WriteLine("Succeeded to create texture");
            TextBox_Path.Text = "";
            ResetListView(true);
            ResetCombobox();
        }
        /// <summary>
        /// <see cref="Button_Remove"/>クリック時の挙動
        /// </summary>
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            var index = ComboBox_RemoveRange.SelectedIndex;
            if (index < 0 || DataBase.Textures.Count <= index)
            {
                Console.WriteLine("選択されたアイテムは管理されていません");
                return;
            }
            if (index == 0)
            {
                Console.WriteLine("デフォルトのテクスチャは削除できません");
                return;
            }
            DataBase.Textures.RemoveAt(index);
            Console.WriteLine("テクスチャの削除に成功しました");
            ResetCombobox();
        }
        /// <summary>
        /// <see cref="ComboBox_RemoveRange"/>を更新する
        /// </summary>
        private void ResetCombobox()
        {
            var array = DataBase.Textures.GetNames();
            ComboBox_RemoveRange.DataSource = array;
            ComboBox_RemoveRange.SelectedIndex = 0;
        }
    }
}
