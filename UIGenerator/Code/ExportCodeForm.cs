using System;
using System.IO;
using System.Windows.Forms;
using fslib;
using fslib.IO;

namespace UIGenerator
{
    public partial class ExportCodeForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ExportCodeForm()
        {
            InitializeComponent();
            ComboBox_Lang.DataSource = DataBase.CodeType;
            ComboBox_Encoding.DataSource = EnumHelper.GetNames<EncodingType>();
            ComboBox_Encoding.Text = EncodingType.UTF8.ToString();
        }
        /// <summary>
        /// 出力先選択
        /// </summary>
        private void Button_Ref_Click(object sender, EventArgs e)
        {
            var layerName = TextBox_LayerName.Text.Trim();
            using var dialog = new SaveFileDialog()
            {
                Filter = GetFilter(),
                FileName = layerName,
                DefaultExt = GetExt()
            };
            var state = dialog.ShowDialog();
            if (state == DialogResult.OK) TextBox_Path.Text = dialog.FileName;
        }
        /// <summary>
        /// <see cref="SaveFileDialog"/>のフィルターを返す
        /// </summary>
        private string GetFilter()
        {
            var lang = ComboBox_Lang.Text;
            return lang switch
            {
                "C#" => FilePathHelper.GetFilter("CSharp Code File", ".cs"),
                _ => throw new NotSupportedException(),
            };
        }
        /// <summary>
        /// 拡張子を返す
        /// </summary>
        private string GetExt()
        {
            var lang = ComboBox_Lang.Text;
            return lang switch
            {
                "C#" => ".cs",
                _ => throw new NotSupportedException(),
            };
        }
        /// <summary>
        /// エクスポート実行
        /// </summary>
        private void Button_Export_Click(object sender, EventArgs e)
        {
            var layerName = TextBox_LayerName.Text.Trim();
            var nameSpace = TextBox_NameSpace.Text.Trim();
            if (string.IsNullOrWhiteSpace(layerName) || string.IsNullOrWhiteSpace(nameSpace))
            {
                Console.WriteLine("レイヤー名または名前空間が空白です");
                return;
            }
            var path = TextBox_Path.Text;
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Console.WriteLine("ディレクトリが存在しません");
                return;
            }
            DataBase.ExportCode_CSharp(path, nameSpace, layerName, new EncodeOption(EnumHelper.FromString<EncodingType>(ComboBox_Encoding.Text)).Encoding);
            Console.WriteLine("エクスポートが終了しました");
            Close();
        }
    }
}
