using System;
using System.Windows.Forms;
using asd;

namespace UIGenerator
{
    public partial class DrawingTriangleForm : Form
    {
        private readonly MainEdittor main;
        private readonly DrawingTriangleInfo info;
        private readonly bool inited = false;
        /// <summary>
        /// テクスチャの情報を格納する<see cref="ComboBox"/>を取得する
        /// </summary>
        public ComboBox ComboBox_Texture => ComboBox_texture;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main"><see cref="MainEdittor"/>への参照</param>
        /// <param name="info">操作対象の<see cref="DrawingRectangleInfo"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="main"/>または<paramref name="info"/>がnull</exception>
        public DrawingTriangleForm(MainEdittor main, DrawingTriangleInfo info)
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
            ComboBox_AlphaBlend.SelectedIndex = (int)info.AlphaBlend;
            ComboBox_texture.DataSource = DataBase.Textures.GetNames();
            var textureIndex = DataBase.Textures.IndexOf(info.Texture);
            ComboBox_texture.SelectedIndex = textureIndex == -1 ? 0 : textureIndex;
            NumericUpDown_Mode.Value = info.Mode;
            TextBox_Name.Text = info.Name;
            NumericUpDown_Pos1_X.Value = (decimal)info.Position1.X;
            NumericUpDown_Pos1_Y.Value = (decimal)info.Position1.Y;
            NumericUpDown_Pos2_X.Value = (decimal)info.Position2.X;
            NumericUpDown_Pos2_Y.Value = (decimal)info.Position2.Y;
            NumericUpDown_Pos3_X.Value = (decimal)info.Position3.X;
            NumericUpDown_Pos3_Y.Value = (decimal)info.Position3.Y;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            NumericUpDown_UV1_X.Value = (decimal)info.UV1.X;
            NumericUpDown_UV1_Y.Value = (decimal)info.UV1.Y;
            NumericUpDown_UV2_X.Value = (decimal)info.UV2.X;
            NumericUpDown_UV2_Y.Value = (decimal)info.UV2.Y;
            NumericUpDown_UV3_X.Value = (decimal)info.UV3.X;
            NumericUpDown_UV3_Y.Value = (decimal)info.UV3.Y;
            ComboBox_AlphaBlend.SelectedIndexChanged += new EventHandler(ComboBox_AlphaBlend_SelectedIndexChanged);
            ComboBox_texture.SelectedIndexChanged += new EventHandler(ComboBox_Texture_SelectedIndexChanged);
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void DrawingTriangleForm_FormClosed(object sender, FormClosedEventArgs e)
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
        /// アルファブレンド変更
        /// </summary>
        private void ComboBox_AlphaBlend_SelectedIndexChanged(object sender, EventArgs e) => info.AlphaBlend = EnumHelper.FromNumber<AlphaBlendMode>(ComboBox_AlphaBlend.SelectedIndex);
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
        /// テクスチャの変更
        /// </summary>
        private void ComboBox_Texture_SelectedIndexChanged(object sender, EventArgs e) => info.Texture = DataBase.Textures[ComboBox_texture.SelectedIndex];
        /// <summary>
        /// 座標1X変更
        /// </summary>
        private void NumericUpDown_Pos1_X_ValueChanged(object sender, EventArgs e) => info.Position1 = new Vector2DF((float)NumericUpDown_Pos1_X.Value, info.Position1.Y);
        /// <summary>
        /// 座標1Y変更
        /// </summary>
        private void NumericUpDown_Pos1_Y_ValueChanged(object sender, EventArgs e) => info.Position1 = new Vector2DF(info.Position1.X, (float)NumericUpDown_Pos1_Y.Value);
        /// <summary>
        /// 座標2X変更
        /// </summary>
        private void NumericUpDown_Pos2_X_ValueChanged(object sender, EventArgs e) => info.Position2 = new Vector2DF((float)NumericUpDown_Pos2_X.Value, info.Position2.Y);
        /// <summary>
        /// 座標2Y変更
        /// </summary>
        private void NumericUpDown_Pos2_Y_ValueChanged(object sender, EventArgs e) => info.Position2 = new Vector2DF(info.Position2.X, (float)NumericUpDown_Pos2_Y.Value);
        /// <summary>
        /// 座標3X変更
        /// </summary>
        private void NumericUpDown_Pos3_X_ValueChanged(object sender, EventArgs e) => info.Position3 = new Vector2DF((float)NumericUpDown_Pos3_X.Value, info.Position3.Y);
        /// <summary>
        /// 座標3Y変更
        /// </summary>
        private void NumericUpDown_Pos3_Y_ValueChanged(object sender, EventArgs e) => info.Position3 = new Vector2DF(info.Position3.X, (float)NumericUpDown_Pos3_Y.Value);
        /// <summary>
        /// UV1X変更
        /// </summary>
        private void NumericUpDown_UV1_X_ValueChanged(object sender, EventArgs e) => info.UV1 = new SerializableVector2DF((float)NumericUpDown_UV1_X.Value, info.UV1.Y);
        /// <summary>
        /// UV1Y変更
        /// </summary>
        private void NumericUpDown_UV1_Y_ValueChanged(object sender, EventArgs e) => info.UV1 = new SerializableVector2DF(info.UV1.X, (float)NumericUpDown_UV1_Y.Value);
        /// <summary>
        /// UV2X変更
        /// </summary>
        private void NumericUpDown_UV2_X_ValueChanged(object sender, EventArgs e) => info.UV2 = new SerializableVector2DF((float)NumericUpDown_UV2_X.Value, info.UV2.Y);
        /// <summary>
        /// UV2Y変更
        /// </summary>
        private void NumericUpDown_UV2_Y_ValueChanged(object sender, EventArgs e) => info.UV2 = new SerializableVector2DF(info.UV2.X, (float)NumericUpDown_UV2_Y.Value);
        /// <summary>
        /// UV3X変更
        /// </summary>
        private void NumericUpDown_UV3_X_ValueChanged(object sender, EventArgs e) => info.UV3 = new SerializableVector2DF((float)NumericUpDown_UV3_X.Value, info.UV3.Y);
        /// <summary>
        /// UV3Y変更
        /// </summary>
        private void NumericUpDown_UV3_Y_ValueChanged(object sender, EventArgs e) => info.UV3 = new SerializableVector2DF(info.UV3.X, (float)NumericUpDown_UV3_Y.Value);
    }
}
