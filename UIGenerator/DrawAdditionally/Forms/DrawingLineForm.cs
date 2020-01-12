using System;
using System.Windows.Forms;
using asd;
using fslib;

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
            Init();
            ComboBox_AlphaBlend.SelectedIndexChanged += new EventHandler(ComboBox_AlphaBlend_SelectedIndexChanged);
            inited = true;
        }
        /// <summary>
        /// フォーム情報の初期化を行う
        /// </summary>
        private void Init()
        {
            ComboBox_AlphaBlend.DataSource = Enum.GetNames(typeof(AlphaBlendMode));
            ComboBox_AlphaBlend.SelectedIndex = (int)info.AlphaBlend;
            NumericUpDown_Mode.Value = info.Mode;
            TextBox_Name.Text = info.Name;
            NumericUpDown_Pos1_X.Value = (decimal)info.Point1.X;
            NumericUpDown_Pos1_Y.Value = (decimal)info.Point1.Y;
            NumericUpDown_Pos2_X.Value = (decimal)info.Point2.X;
            NumericUpDown_Pos2_Y.Value = (decimal)info.Point2.Y;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            NumericUpDown_Thickness.Value = (decimal)info.Thickness;
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
                    main.ListView_Additionalies.Items[index].SubItems[2] = new ListViewItem.ListViewSubItem(main.ListView_Additionalies.Items[index], newMode.ToString());
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
                    main.ListView_Additionalies.Items[index].SubItems[1] = new ListViewItem.ListViewSubItem(main.ListView_Additionalies.Items[index], newName.ToString());
                }
                else TextBox_Name.Text = oldName;
            }
        }
        /// <summary>
        /// 描画優先度変更
        /// </summary>
        private void NumericUpDown_Priority_ValueChanged(object sender, EventArgs e) => info.DrawingPriority = (int)NumericUpDown_Priority.Value;
        /// <summary>
        /// 線の太さ変更
        /// </summary>
        private void NumericUpDown_Thickness_ValueChanged(object sender, EventArgs e) => info.Thickness = (int)NumericUpDown_Thickness.Value;
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
        /// 座標1X変更
        /// </summary>
        private void NumericUpDown_Pos_X_ValueChanged(object sender, EventArgs e) => info.Point1 = new Vector2DF((float)NumericUpDown_Pos1_X.Value, info.Point1.Y);
        /// <summary>
        /// 座標1Y変更
        /// </summary>
        private void NumericUpDown_Pos_Y_ValueChanged(object sender, EventArgs e) => info.Point1 = new Vector2DF(info.Point1.X, (float)NumericUpDown_Pos1_Y.Value);
        /// <summary>
        /// 座標2X変更
        /// </summary>
        private void NumericUpDown_Size_X_ValueChanged(object sender, EventArgs e) => info.Point2 = new Vector2DF((float)NumericUpDown_Pos2_X.Value, info.Point2.Y);
        /// <summary>
        /// 座標2Y変更
        /// </summary>
        private void NumericUpDown_Size_Y_ValueChanged(object sender, EventArgs e) => info.Point2 = new Vector2DF(info.Point2.X, (float)NumericUpDown_Pos2_Y.Value);
        /// <summary>
        /// アルファブレンド変更
        /// </summary>
        private void ComboBox_AlphaBlend_SelectedIndexChanged(object sender, EventArgs e) => info.AlphaBlend = EnumHelper.FromNumber<AlphaBlendMode>(ComboBox_AlphaBlend.SelectedIndex);
    }
}
