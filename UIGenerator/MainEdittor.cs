using System;
using System.IO;
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
        /// 唯一のインスタンスを取得する
        /// </summary>
        public static MainEdittor SingleInstance { get; private set; }
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
            SingleInstance = this;
            InitializeComponent();
        }
        /// <summary>
        /// <see cref="NumericUpDown_ShowMode"/>の値が変化したときに実行
        /// </summary>
        private void NumericUpDown_ShowMode_ValueChanged(object sender, EventArgs e) => DataBase.MainScene.ChangeMode((int)NumericUpDown_ShowMode.Value);
        /// <summary>
        /// <see cref="要素を追加削除するToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void 要素を追加削除するToolStripMenuItem_Click(object sender, EventArgs e) => ElementWindow.CreateAndShow(this);
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
        private void フォントを編集するToolStripMenuItem_Click(object sender, EventArgs e) => FontIOForm.CreateAndShow();
        /// <summary>
        /// <see cref="テクスチャを編集するToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void テクスチャを編集するToolStripMenuItem_Click(object sender, EventArgs e) => TextureIOForm.CreateAndShow();
        /// <summary>
        /// <see cref="名前を付けて保存ToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point:
            using (var dialog = new SaveFileDialog()
            {
                FileName = DataBase.ProjectName,
                DefaultExt = ".ugpf",
                AddExtension = true,
                Filter = FilePathHelper.GetFilter("UIGenerator project Files", ".ugpf")
            })
            {
                var state = dialog.ShowDialog();
                if (state != DialogResult.OK) return;
                usePath = dialog.FileName;
            }
            if (!Directory.Exists(Path.GetDirectoryName(usePath)))
            {
                Console.WriteLine("ディレクトリが存在しません");
                goto Point;
            }
            DataBase.SaveProject(usePath);
            Console.WriteLine("プロジェクトの保存に成功しました");
        }
        /// <summary>
        /// <see cref="上書き保存ToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(usePath)) 名前を付けて保存ToolStripMenuItem_Click(sender, e);
            else DataBase.SaveProject(usePath);
        }
        /// <summary>
        /// <see cref="ファイルToolStripMenuItem"/>クリック時の挙動
        /// </summary>
        private void ファイルパッケージを管理するToolStripMenuItem_Click(object sender, EventArgs e) => FilePackageLoader.CreateAndShow();
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void MainEdittor_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.CloseAllWindow();
            Program.ContinueUpdating = false;
            SingleInstance = null;
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
        /// <summary>
        /// ファイルチェックウィンドウを開く
        /// </summary>
        private void ファイルの有無をチェックToolStripMenuItem_Click(object sender, EventArgs e) => FileSearchForm.CreateAndShow();
        /// <summary>
        /// プロジェクトファイルを開く
        /// </summary>
        private void プロジェクトを開く_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog()
            {
                FileName = DataBase.ProjectName,
                DefaultExt = ".ugpf",
                AddExtension = true,
                Filter = FilePathHelper.GetFilter("UIGenerator project Files", ".ugpf")
            })
            {
                var state = dialog.ShowDialog();
                if (state != DialogResult.OK) return;
                usePath = dialog.FileName;
            }
            if (!File.Exists(usePath))
            {
                Console.WriteLine("ディレクトリが存在しません");
                return;
            }
            DataBase.LoadProject(usePath);
            Console.WriteLine("プロジェクトの読み込みが完了しました");
        }
        /// <summary>
        /// リソースファイルの保存
        /// </summary>
        private void リソース情報を保存するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point:
            using (var dialog = new SaveFileDialog()
            {
                Filter = FilePathHelper.GetFilter("UIGenertor Resource Pack File", ".ugrpf"),
                FileName = DataBase.ProjectName,
                DefaultExt = ".ugrpf"
            })
            {
                var state = dialog.ShowDialog();
                if (state != DialogResult.OK) return;
                var path = dialog.FileName;
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Console.WriteLine("ディレクトリが存在しません");
                    goto Point;
                }
                DataBase.SaveResourcePackage(path);
                Console.WriteLine("リソースファイルの保存が完了しました");
            }
        }
        /// <summary>
        /// リソースファイルの読込
        /// </summary>
        private void リソース情報を読み込むToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog()
            {
                Filter = FilePathHelper.GetFilter("UIGenertor Resource Pack File", ".ugrpf"),
                FileName = DataBase.ProjectName,
                DefaultExt = ".ugrpf"
            })
            {
                var state = dialog.ShowDialog();
                if (state != DialogResult.OK) return;
                var path = dialog.FileName;
                if (!File.Exists(path))
                {
                    Console.WriteLine("ファイルが存在しません");
                    return;
                }
                DataBase.LoadResourcePackage(path);
                Console.WriteLine("リソースファイルの読み込みが完了しました");
            }
        }
        /// <summary>
        /// リストビューの内容を更新する
        /// </summary>
        public void ResetListView()
        {
            ListView_objects.Items.Clear();
            ListView_additional.Items.Clear();
            foreach (var obj in DataBase.UIInfos)
            {
                var item = ListView_Objects.Items.Add(obj.Value.Type.ToString());
                item.SubItems.Add(obj.Key2);
                item.SubItems.Add(obj.Key1.ToString());
            }
            foreach (var add in DataBase.DrawingCollection)
            {
                var item = ListView_Additionalies.Items.Add(add.Value.DrawingAdditionalMode.ToString());
                item.SubItems.Add(add.Key2);
                item.SubItems.Add(add.Key1.ToString());
            }
        }
        /// <summary>
        /// エクスポートウィンドウを開く
        /// </summary>
        private void エクスポートToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new ExportCodeForm()) form.ShowDialog();
        }
    }
}
