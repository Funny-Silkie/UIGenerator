using System;
using System.Threading;
using System.Windows.Forms;
using fslib.IO;

namespace UIGenerator
{
    /// <summary>
    /// メイン操作を行うフォーム
    /// </summary>
    public partial class MainEdittor : Form
    {
        private string usePath = "";
        /// <summary>
        /// オブジェクトを格納する<see cref="ListView"/>を取得する
        /// </summary>
        public ListView ListView_Objects => ListView_objects;
        /// <summary>
        /// 追加描画の情報を格納する<see cref="ListView"/>を取得する
        /// </summary>
        public ListView ListView_Additionalies => ListView_additional;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainEdittor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// <see cref="NumericUpDown_ShowMode"/>の値が変化したときに実行
        /// </summary>
        private void NumericUpDown_ShowMode_ValueChanged(object sender, EventArgs e) => DataBase.MainScene.ChangeMode((int)NumericUpDown_ShowMode.Value);
        /// <summary>
        /// <see cref="要素を追加削除するToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void 要素を追加削除するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ElementWindow.IsShown)
            {
                var a = new ElementWindow(this);
                DataBase.Forms.Add(a);
                a.Show();
            }
        }
        /// <summary>
        /// <see cref="ListView_objects"/>のアイテムダブルクリック時の挙動
        /// </summary>
        private void ListView_Objects_ItemActivate(object sender, EventArgs e)
        {
            var selected = ListView_objects.SelectedItems;
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
        /// <summary>
        /// <see cref="フォントを編集するToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void フォントを編集するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FontIOForm.Instanced)
            {
                var fontform = new FontIOForm();
                DataBase.Forms.Add(fontform);
                fontform.Show();
            }
        }
        /// <summary>
        /// <see cref="テクスチャを編集するToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void テクスチャを編集するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TextureIOForm.Instanced)
            {
                var textureform = new TextureIOForm();
                DataBase.Forms.Add(textureform);
                textureform.Show();
            }
        }
        /// <summary>
        /// <see cref="名前を付けて保存ToolStripMenuItem"/>クリック時の挙動
        /// </summary>
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
        /// <summary>
        /// <see cref="上書き保存ToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(usePath)) 名前を付けて保存ToolStripMenuItem_Click(sender, e);
            else DataBase.Save(usePath);
        }
        /// <summary>
        /// <see cref="ファイルToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void ファイルパッケージを管理するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FilePackageLoader.Instanced)
            {
                var form = new FilePackageLoader();
                DataBase.Forms.Add(form);
                form.Show();
            }
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void MainEdittor_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.CloseAllWindow();
            Program.ContinueUpdating = false;
        }
        /// <summary>
        /// 追加描画情報のウィンドウ開放
        /// </summary>
        private void ListView_additional_ItemActivate(object sender, EventArgs e)
        {
            var selected = ListView_Additionalies.SelectedItems;
            if (selected.Count > 0)
            {
                var first = selected[0];
                var name = first.SubItems[1].Text;
                var mode = int.Parse(first.SubItems[2].Text);
                var element = DataBase.DrawingCollection[mode, name];
                if (element.HandleForm == null)
                    switch (element.DrawingAdditionalMode)
                    {
                        case DrawingAdditionalMode.Arc:
                            var form_arc = new DrawingArcForm(this, (DrawingArcInfo)element);
                            DataBase.Forms.Add(form_arc);
                            form_arc.Show();
                            return;
                        case DrawingAdditionalMode.Circle:
                            var form_circle = new DrawingCircleForm(this, (DrawingCircleInfo)element);
                            DataBase.Forms.Add(form_circle);
                            form_circle.Show();
                            return;
                        case DrawingAdditionalMode.Line:
                            var form_line = new DrawingLineForm(this, (DrawingLineInfo)element);
                            DataBase.Forms.Add(form_line);
                            form_line.Show();
                            return;
                        case DrawingAdditionalMode.Rectangle:
                            var form_rect = new DrawingRectangleForm(this, (DrawingRectangleInfo)element);
                            DataBase.Forms.Add(form_rect);
                            form_rect.Show();
                            return;
                        case DrawingAdditionalMode.RotatedRectangle:
                            var form_rotatedrect = new DrawingRotatedRectangleForm(this, (DrawingRotatedRectangleInfo)element);
                            DataBase.Forms.Add(form_rotatedrect);
                            form_rotatedrect.Show();
                            return;
                        case DrawingAdditionalMode.Sprite:
                            var form_sprite = new DrawingSpriteForm(this, (DrawingSpriteInfo)element);
                            DataBase.Forms.Add(form_sprite);
                            form_sprite.Show();
                            return;
                        case DrawingAdditionalMode.Text:
                            var form_text = new DrawingTextForm(this, (DrawingTextInfo)element);
                            DataBase.Forms.Add(form_text);
                            form_text.Show();
                            return;
                        case DrawingAdditionalMode.Triangle:
                            var form_triangle = new DrawingTriangleForm(this, (DrawingTriangleInfo)element);
                            DataBase.Forms.Add(form_triangle);
                            form_triangle.Show();
                            return;
                        default: throw new InvalidOperationException();
                    }
            }
        }
        /// <summary>
        /// オプションメニューを開始
        /// </summary>
        private void オプションToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new OptionForm()) form.ShowDialog();
        }
    }
}
