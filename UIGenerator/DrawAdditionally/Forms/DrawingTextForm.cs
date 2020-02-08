using System;
using System.Windows.Forms;
using asd;
using fslib;

namespace UIGenerator
{
    public partial class DrawingTextForm : Form
    {
        private readonly MainEdittor main;
        private readonly DrawingTextInfo info;
        private readonly bool inited = false;
        /// <summary>
        /// フォントの情報を格納する<see cref="ComboBox"/>を取得する
        /// </summary>
        public ComboBox ComboBox_Font => ComboBox_font;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main"><see cref="MainEdittor"/>への参照</param>
        /// <param name="info">操作対象の<see cref="DrawingTextInfo"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="main"/>または<paramref name="info"/>がnull</exception>
        public DrawingTextForm(MainEdittor main, DrawingTextInfo info)
        {
            this.main = main ?? throw new ArgumentNullException();
            this.info = info ?? throw new ArgumentNullException();
            info.HandleForm = this;
            InitializeComponent();
            Init();
            inited = true;
        }
        /// <summary>
        /// フォーム情報の初期化を行う
        /// </summary>
        private void Init()
        {
            ComboBox_AlphaBlend.DataSource = EnumHelper.GetNames<AlphaBlendMode>();
            ComboBox_font.DataSource = DataBase.Fonts.GetNames();
            var fontIndex = DataBase.Fonts.IndexOf(info.FontInfo);
            ComboBox_font.SelectedIndex = fontIndex == -1 ? 0 : fontIndex;
            NumericUpDown_Mode.Value = info.Mode;
            TextBox_Name.Text = info.Name;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            ComboBox_AlphaBlend.SelectedIndex = (int)info.AlphaBlend;
            NumericUpDown_Position_X.Value = (decimal)info.Position.X;
            NumericUpDown_Position_Y.Value = (decimal)info.Position.Y;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            RichTextBox_Text.Text = info.Text;
            ComboBox_Direction.DataSource = EnumHelper.GetNames<WritingDirection>();
            ComboBox_Direction.SelectedIndex = (int)info.WritingDirection;
            ComboBox_AlphaBlend.SelectedIndexChanged += new EventHandler(ComboBox_AlphaBlend_SelectedIndexChanged);
            ComboBox_font.SelectedIndexChanged += new EventHandler(ComboBox_Font_SelectedIndexChanged);
            ComboBox_Direction.SelectedIndexChanged += new EventHandler(ComboBox_Direction_SelectedIndexChanged);
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void DrawingTextForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            info.HandleForm = null;
            DataBase.Forms.Remove(this);
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
        /// アルファブレンド変更
        /// </summary>
        private void ComboBox_AlphaBlend_SelectedIndexChanged(object sender, EventArgs e) => info.AlphaBlend = EnumHelper.FromNumber<AlphaBlendMode>(ComboBox_AlphaBlend.SelectedIndex);
        /// <summary>
        /// 色のR変更
        /// </summary>
        private void NumericUpDown_R_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new ColorPlus((int)NumericUpDown_R.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 色のG変更
        /// </summary>
        private void NumericUpDown_G_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new ColorPlus(c.R, (int)NumericUpDown_G.Value, c.B, c.A);
        }
        /// <summary>
        /// 色のB変更
        /// </summary>
        private void NumericUpDown_B_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new ColorPlus(c.R, c.G, (int)NumericUpDown_B.Value, c.A);
        }
        /// <summary>
        /// 色のA変更
        /// </summary>
        private void NumericUpDown_A_ValueChanged(object sender, EventArgs e)
        {
            var c = info.Color;
            info.Color = new ColorPlus(c.R, c.G, c.B, (int)NumericUpDown_A.Value);
        }
        /// <summary>
        /// テクスチャの変更
        /// </summary>
        private void ComboBox_Font_SelectedIndexChanged(object sender, EventArgs e) => info.FontInfo = DataBase.Fonts[ComboBox_font.SelectedIndex];
        /// <summary>
        /// 文字列の変更
        /// </summary>
        private void RichTextBox_Text_TextChanged(object sender, EventArgs e) => info.Text = RichTextBox_Text.Text;
        /// <summary>
        /// 描画方向変更
        /// </summary>
        private void ComboBox_Direction_SelectedIndexChanged(object sender, EventArgs e) => info.WritingDirection = EnumHelper.FromString<WritingDirection>(ComboBox_Direction.Text);
    }
}
