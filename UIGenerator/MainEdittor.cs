using System;
using System.Threading;
using System.Windows.Forms;
using fslib.IO;

namespace UIGenerator
{
    public partial class MainEdittor : Form
    {
        private string usePath = "";
        public MainEdittor()
        {
            InitializeComponent();
        }
        private void NumericUpDown_ShowMode_ValueChanged(object sender, EventArgs e)
        {
            DataBase.MainScene.ChangeMode((int)NumericUpDown_ShowMode.Value);
        }
        private void 要素を追加するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AddWindow.IsShown)
            {
                var a = new AddWindow(this);
                DataBase.Forms.Add(a);
                a.Show();
            }
        }
        private void ListView_Main_ItemActivate(object sender, EventArgs e)
        {
            var selected = ListView_Main.SelectedItems;
            if (selected.Count > 0)
            {
                var first = selected[0];
                var name = first.SubItems[1].Text;
                var mode = int.Parse(first.SubItems[2].Text);
                var element = DataBase.UIInfos[mode, name];
                if (element.HandleForm == null)
                    switch (element.Type)
                    {
                        case UITypes.Text:
                            var textEdittor = new TextEdittor(this, (TextObjInfo)element);
                            DataBase.Forms.Add(textEdittor);
                            textEdittor.Show();
                            return;
                        case UITypes.Texture:
                            var textureEdittor = new TextureEdittor(this, (TextureObjInfo)element);
                            DataBase.Forms.Add(textureEdittor);
                            textureEdittor.Show();
                            return;
                        case UITypes.Window:
                            var windowEdditor = new WindowEditter(this, (WindowInfo)element);
                            DataBase.Forms.Add(windowEdditor);
                            windowEdditor.Show();
                            return;
                        default: throw new InvalidOperationException();
                    }
            }
        }
        private void フォントを編集するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FontAddForm.Instanced)
            {
                var fontform = new FontAddForm();
                DataBase.Forms.Add(fontform);
                fontform.Show();
            }
        }
        private void テクスチャを編集するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TextureAddForm.Instanced)
            {
                var textureform = new TextureAddForm();
                DataBase.Forms.Add(textureform);
                textureform.Show();
            }
        }
        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                Title = "名前を付けて保存",
                FileName = DataBase.ProjectName,
                DefaultExt = ".ugpf",
                AddExtension = true,
                Filter = FilePathHelper.GetFilter("UIGenerator's project Files", ".ugpf")
            };
            var thread = new Thread(new ParameterizedThreadStart(x =>
            {
                var state = dialog.ShowDialog();
                if (state != DialogResult.OK) return;
                usePath = dialog.FileName;
            }));
            dialog.Dispose();
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            if (string.IsNullOrWhiteSpace(usePath)) return;
            DataBase.Save(usePath);
        }
        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(usePath)) 名前を付けて保存ToolStripMenuItem_Click(sender, e);
            else DataBase.Save(usePath);
        }
        private void ファイルパッケージを管理するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FilePackageLoader.Instanced)
            {
                var form = new FilePackageLoader();
                DataBase.Forms.Add(form);
                form.Show();
            }
        }
    }
}
