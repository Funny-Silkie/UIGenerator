using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="DrawingLineInfo"/>のプロパティ情報を操作するフォーム
    /// </summary>
    public partial class DrawingLineForm : Form
    {
        private readonly DrawingLineInfo info;
        private readonly MainEdittor main;
        private readonly bool inited = false;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main"><see cref="MainEdittor"/>への参照</param>
        /// <param name="info">操作対象の<see cref="DrawingLineInfo"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="main"/>または<paramref name="info"/>がnull</exception>
        public DrawingLineForm(MainEdittor main, DrawingLineInfo info)
        {
            this.main = main ?? throw new ArgumentNullException();
            this.info = info ?? throw new ArgumentNullException();
            info.HandleForm = this;
            InitializeComponent();
            inited = true;
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void DrawingLineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            info.HandleForm = null;
        }
        /// <summary>
        /// 描画モード変更
        /// </summary>
        private void NumericUpDown_Mode_ValueChanged(object sender, EventArgs e)
        {
            var oldMode = info.Mode;
            var newMode = (int)NumericUpDown_Mode.Value;
            if (newMode != oldMode && inited)
            {
                if (!DataBase.UIInfos.Contains(newMode, info.Name))
                {
                    var index = DataBase.DrawingCollection.ChangeMode(oldMode, info.Name, newMode);
                    main.ListView_Main.Items[index].SubItems[2] = new ListViewItem.ListViewSubItem(main.ListView_Main.Items[index], newMode.ToString());
                }
                else NumericUpDown_Mode.Value = oldMode;
            }
        }
        /// <summary>
        /// 名前の設定
        /// </summary>
        private void Button_NameSet_Click(object sender, EventArgs e)
        {
            var oldName = info.Name;
            var newName = TextBox_Name.Text;
            if (newName != oldName && inited)
            {
                if (!DataBase.UIInfos.Contains(info.Mode, newName))
                {
                    var index = DataBase.DrawingCollection.ChangeName(info.Mode, oldName, newName);
                    main.ListView_Main.Items[index].SubItems[1] = new ListViewItem.ListViewSubItem(main.ListView_Main.Items[index], newName.ToString());
                }
                else TextBox_Name.Text = oldName;
            }
        }
    }
}
