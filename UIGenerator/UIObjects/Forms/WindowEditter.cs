using System;
using System.Windows.Forms;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="UIWindow"/>のプロパティ情報を制御するフォーム
    /// </summary>
    public partial class WindowEditter : Form
    {
        private readonly WindowInfo info;
        private readonly MainEdittor main;
        private readonly bool inited = false;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main">メインのフォームへの参照</param>
        /// <param name="info">管理対象の<see cref="UIWindow"/>を持つ<see cref="WindowInfo"/></param>
        public WindowEditter(MainEdittor main, WindowInfo info)
        {
            this.main = main;
            info.HandleForm = this;
            this.info = info;
            InitializeComponent();
            Init();
            inited = true;
        }
        /// <summary>
        /// フォームの初期化を行う
        /// </summary>
        private void Init()
        {
            NumericUpDown_Mode.Value = info.Mode;
            NumericUpDown_Mode.Name = info.Name;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            NumericUpDown_Pos_X.Value = (decimal)info.Position.X;
            NumericUpDown_Pos_Y.Value = (decimal)info.Position.Y;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            NumericUpDown_Size_X.Value = (decimal)info.Size.X;
            NumericUpDown_Size_Y.Value = (decimal)info.Size.Y;
            NumericUpDown_Thickness.Value = info.LineThickness;
            NumericUpDown_F_R.Value = info.LineColor.R;
            NumericUpDown_F_G.Value = info.LineColor.G;
            NumericUpDown_F_B.Value = info.LineColor.B;
            NumericUpDown_F_A.Value = info.LineColor.A;
            TextBox_Name.Text = info.Name;
            CheckBox_IsClickable.Checked = info.IsClickable;
            CheckBox_Flame.Checked = info.GeneratingFlame;
        }
        /// <summary>
        /// モード変更
        /// </summary>
        private void NumericUpDown_Mode_ValueChanged(object sender, EventArgs e)
        {
            var oldMode = info.Mode;
            var newMode = (int)NumericUpDown_Mode.Value;
            if (newMode != oldMode && inited)
            {
                if (!DataBase.UIInfos.Contains(newMode, info.Name))
                {
                    var index = DataBase.UIInfos.ChangeMode(oldMode, info.Name, newMode);
                    if (oldMode == DataBase.ShowMode && info.UIObject.Layer != null) DataBase.MainScene.RemoveObject(info);
                    if (newMode == DataBase.ShowMode && info.UIObject.Layer == null) DataBase.MainScene.AddObject(info);
                    main.ListView_Objects.Items[index].SubItems[2] = new ListViewItem.ListViewSubItem(main.ListView_Objects.Items[index], newMode.ToString());
                }
                else NumericUpDown_Mode.Value = oldMode;
            }
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void WindowEditter_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBase.Forms.Remove(this);
            info.HandleForm = null;
        }
        /// <summary>
        /// 名前を設定
        /// </summary>
        private void Button_NameSet_Click(object sender, EventArgs e)
        {
            var oldName = info.Name;
            var newName = TextBox_Name.Text;
            if (newName != oldName && inited)
            {
                if (!DataBase.UIInfos.Contains(info.Mode, newName))
                {
                    var index = DataBase.UIInfos.ChangeName(info.Mode, oldName, newName);
                    main.ListView_Objects.Items[index].SubItems[1] = new ListViewItem.ListViewSubItem(main.ListView_Objects.Items[index], newName.ToString());
                }
                else TextBox_Name.Text = oldName;
            }
        }
        /// <summary>
        /// クリック可能かどうかを制御
        /// </summary>
        private void CheckBox_IsClickable_CheckedChanged(object sender, EventArgs e) => info.UIObject.IsClickable = CheckBox_IsClickable.Checked;
        /// <summary>
        /// 描画優先度を変更
        /// </summary>
        private void NumericUpDown_Priority_ValueChanged(object sender, EventArgs e) => info.DrawingPriority = (int)NumericUpDown_Priority.Value;
        /// <summary>
        /// 色のR変更
        /// </summary>
        private void NumericUpDown_R_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new Color((int)NumericUpDown_R.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 色のG変更
        /// </summary>
        private void NumericUpDown_G_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new Color(c.R, (int)NumericUpDown_G.Value, c.B, c.A);
        }
        /// <summary>
        /// 色のB変更
        /// </summary>
        private void NumericUpDown_B_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new Color(c.R, c.G, (int)NumericUpDown_B.Value, c.A);
        }
        /// <summary>
        /// 色のA変更
        /// </summary>
        private void NumericUpDown_A_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new Color(c.R, c.G, c.B, (int)NumericUpDown_A.Value);
        }
        /// <summary>
        /// 座標X変更
        /// </summary>
        private void NumericUpDown_Pos_X_ValueChanged(object sender, EventArgs e) => info.Position = new Vector2DF((float)NumericUpDown_Pos_X.Value, info.Position.Y);
        /// <summary>
        /// 座標Y変更
        /// </summary>
        private void NumericUpDown_Pos_Y_ValueChanged(object sender, EventArgs e) => info.Position = new Vector2DF(info.Position.X, (float)NumericUpDown_Pos_Y.Value);
        /// <summary>
        /// サイズX変更
        /// </summary>
        private void NumericUpDown_Size_X_ValueChanged(object sender, EventArgs e) => info.Size = new Vector2DF((float)NumericUpDown_Size_X.Value, info.Size.Y);
        /// <summary>
        /// サイズY変更
        /// </summary>
        private void NumericUpDown_Size_Y_ValueChanged(object sender, EventArgs e) => info.Size = new Vector2DF(info.Size.X, (float)NumericUpDown_Size_Y.Value);
        /// <summary>
        /// 枠線の有無の変更
        /// </summary>
        private void CheckBox_Flame_CheckedChanged(object sender, EventArgs e)
        {
            info.GeneratingFlame = CheckBox_Flame.Checked;
            NumericUpDown_Thickness.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_R.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_G.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_B.Enabled = CheckBox_Flame.Checked;
            NumericUpDown_F_A.Enabled = CheckBox_Flame.Checked;
        }
        /// <summary>
        /// 枠線の太さの変更
        /// </summary>
        private void NumericUpDown_Thickness_ValueChanged(object sender, EventArgs e) => info.LineThickness = (int)NumericUpDown_Thickness.Value;
        /// <summary>
        /// 枠線色のR変更
        /// </summary>
        private void NumericUpDown_F_R_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new Color((int)NumericUpDown_F_R.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 枠線色のG変更
        /// </summary>
        private void NumericUpDown_F_G_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new Color(c.R, (int)NumericUpDown_F_G.Value, c.B, c.A);
        }
        /// <summary>
        /// 枠線色のB変更
        /// </summary>
        private void NumericUpDown_F_B_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new Color(c.R, c.G, (int)NumericUpDown_F_B.Value, c.A);
        }
        /// <summary>
        /// 枠線色のA変更
        /// </summary>
        private void NumericUpDown_F_A_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LineColor;
            info.LineColor = new Color(c.R, c.G, c.B, (int)NumericUpDown_F_A.Value);
        }
    }
}
