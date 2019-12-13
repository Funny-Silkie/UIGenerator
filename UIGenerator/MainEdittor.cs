using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using asd;

namespace UIGenerator
{
    public partial class MainEdittor : Form
    {
        public MainEdittor()
        {
            InitializeComponent();
            ComboBox_Filter_Mode.DataSource = new int[] { 0 };
            var types = new List<string>() { "All" };
            types.AddRange(DataBase.Types);
            ComboBox_Filter_Type.DataSource = types.ToArray();
            ComboBox_Filter_Type.SelectedIndex = 0;
            NumericUpDown_ShowMode.Minimum = DataBase.MinMode;
            NumericUpDown_ShowMode.Maximum= DataBase.MaxMode;
        }
        private void NumericUpDown_ShowMode_ValueChanged(object sender, EventArgs e)
        {
            DataBase.MainScene.ChangeMode((int)NumericUpDown_ShowMode.Value);
        }
        private void 要素を追加するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AddWindow.IsShown) new AddWindow(this).Show();
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
                        case UITypes.Text: new TextEdittor((TextInfo)element).Show(); return;
                        case UITypes.Texture: new TextureEdittor((TextureObjInfo)element).Show(); return;
                        case UITypes.Window: new WindowEditter((WindowInfo)element).Show(); return;
                        default: throw new InvalidOperationException();
                    }
            }
        }
    }
}
