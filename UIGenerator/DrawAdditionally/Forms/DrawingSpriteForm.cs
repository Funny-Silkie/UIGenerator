using System;
using System.Windows.Forms;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    public partial class DrawingSpriteForm : Form
    {
        private readonly MainEdittor main;
        private readonly DrawingSpriteInfo info;
        private readonly bool inited = false;
        /// <summary>
        /// テクスチャの情報を格納する<see cref="ComboBox"/>を取得する
        /// </summary>
        public ComboBox ComboBox_Texture => ComboBox_texture;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main"><see cref="MainEdittor"/>への参照</param>
        /// <param name="info">操作対象の<see cref="DrawingSpriteInfo"/>のインスタンス</param>
        /// <exception cref="ArgumentNullException"><paramref name="main"/>または<paramref name="info"/>がnull</exception>
        public DrawingSpriteForm(MainEdittor main, DrawingSpriteInfo info)
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
            ComboBox_AlphaBlend.DataSource = Enum.GetNames(typeof(AlphaBlendMode));
            ComboBox_AlphaBlend.SelectedIndex = (int)info.AlphaBlend;
            ComboBox_texture.DataSource = DataBase.Textures.GetNames();
            var textureIndex = DataBase.Textures.IndexOf(info.Texture);
            ComboBox_texture.SelectedIndex = textureIndex == -1 ? 0 : textureIndex;
            NumericUpDown_Mode.Value = info.Mode;
            TextBox_Name.Text = info.Name;
            NumericUpDown_Pos1_X.Value = (decimal)info.UpperLeftPos.X;
            NumericUpDown_Pos1_Y.Value = (decimal)info.UpperLeftPos.Y;
            NumericUpDown_Pos2_X.Value = (decimal)info.UpperRightPos.X;
            NumericUpDown_Pos2_Y.Value = (decimal)info.UpperRightPos.Y;
            NumericUpDown_Pos3_X.Value = (decimal)info.LowerRightPos.X;
            NumericUpDown_Pos3_Y.Value = (decimal)info.LowerRightPos.Y;
            NumericUpDown_Pos4_X.Value = (decimal)info.LowerLeftPos.X;
            NumericUpDown_Pos4_Y.Value = (decimal)info.LowerLeftPos.Y;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            NumericUpDown_R1.Value = info.UpperLeftColor.R;
            NumericUpDown_G1.Value = info.UpperLeftColor.G;
            NumericUpDown_B1.Value = info.UpperLeftColor.B;
            NumericUpDown_A1.Value = info.UpperLeftColor.A;
            NumericUpDown_R2.Value = info.UpperRightColor.R;
            NumericUpDown_G2.Value = info.UpperRightColor.G;
            NumericUpDown_B2.Value = info.UpperRightColor.B;
            NumericUpDown_A2.Value = info.UpperRightColor.A;
            NumericUpDown_R3.Value = info.LowerRightColor.R;
            NumericUpDown_G3.Value = info.LowerRightColor.G;
            NumericUpDown_B3.Value = info.LowerRightColor.B;
            NumericUpDown_A3.Value = info.LowerRightColor.A;
            NumericUpDown_R4.Value = info.LowerLeftColor.R;
            NumericUpDown_G4.Value = info.LowerLeftColor.G;
            NumericUpDown_B4.Value = info.LowerLeftColor.B;
            NumericUpDown_A4.Value = info.LowerLeftColor.A;
            NumericUpDown_UV1_X.Value = (decimal)info.UpperLeftUV.X;
            NumericUpDown_UV1_Y.Value = (decimal)info.UpperLeftUV.Y;
            NumericUpDown_UV2_X.Value = (decimal)info.UpperRightUV.X;
            NumericUpDown_UV2_Y.Value = (decimal)info.UpperRightUV.Y;
            NumericUpDown_UV3_X.Value = (decimal)info.LowerRightUV.X;
            NumericUpDown_UV3_Y.Value = (decimal)info.LowerRightUV.Y;
            NumericUpDown_UV4_X.Value = (decimal)info.LowerLeftUV.X;
            NumericUpDown_UV4_Y.Value = (decimal)info.LowerLeftUV.Y;
            ComboBox_AlphaBlend.SelectedIndexChanged += new EventHandler(ComboBox_AlphaBlend_SelectedIndexChanged);
            ComboBox_texture.SelectedIndexChanged += new EventHandler(ComboBox_Texture_SelectedIndexChanged);
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void DrawingSpriteForm_FormClosed(object sender, FormClosedEventArgs e)
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
        /// テクスチャの変更
        /// </summary>
        private void ComboBox_Texture_SelectedIndexChanged(object sender, EventArgs e) => info.Texture = DataBase.Textures[ComboBox_texture.SelectedIndex];
        /// <summary>
        /// 座標1X変更
        /// </summary>
        private void NumericUpDown_Pos1_X_ValueChanged(object sender, EventArgs e) => info.UpperLeftPos = new Vector2DF((float)NumericUpDown_Pos1_X.Value, info.UpperLeftPos.Y);
        /// <summary>
        /// 座標1Y変更
        /// </summary>
        private void NumericUpDown_Pos1_Y_ValueChanged(object sender, EventArgs e) => info.UpperLeftPos = new Vector2DF(info.UpperLeftPos.X, (float)NumericUpDown_Pos1_Y.Value);
        /// <summary>
        /// 座標2X変更
        /// </summary>
        private void NumericUpDown_Pos2_X_ValueChanged(object sender, EventArgs e) => info.UpperRightPos = new Vector2DF((float)NumericUpDown_Pos2_X.Value, info.UpperRightPos.Y);
        /// <summary>
        /// 座標2Y変更
        /// </summary>
        private void NumericUpDown_Pos2_Y_ValueChanged(object sender, EventArgs e) => info.UpperRightPos = new Vector2DF(info.UpperRightPos.X, (float)NumericUpDown_Pos2_Y.Value);
        /// <summary>
        /// 座標3X変更
        /// </summary>
        private void NumericUpDown_Pos3_X_ValueChanged(object sender, EventArgs e) => info.LowerRightPos = new Vector2DF((float)NumericUpDown_Pos3_X.Value, info.LowerRightPos.Y);
        /// <summary>
        /// 座標3Y変更
        /// </summary>
        private void NumericUpDown_Pos3_Y_ValueChanged(object sender, EventArgs e) => info.LowerRightPos = new Vector2DF(info.LowerRightPos.X, (float)NumericUpDown_Pos3_Y.Value);
        /// <summary>
        /// 座標4X変更
        /// </summary>
        private void NumericUpDown_Pos4_X_ValueChanged(object sender, EventArgs e) => info.LowerLeftPos = new Vector2DF((float)NumericUpDown_Pos4_X.Value, info.LowerLeftPos.Y);
        /// <summary>
        /// 座標4Y変更
        /// </summary>
        private void NumericUpDown_Pos4_Y_ValueChanged(object sender, EventArgs e) => info.LowerLeftPos = new Vector2DF(info.LowerLeftPos.X, (float)NumericUpDown_Pos4_Y.Value);
        /// <summary>
        /// UV1X変更
        /// </summary>
        private void NumericUpDown_UV1_X_ValueChanged(object sender, EventArgs e) => info.UpperLeftUV = new SerializableVector2DF((float)NumericUpDown_UV1_X.Value, info.UpperLeftUV.Y);
        /// <summary>
        /// UV1Y変更
        /// </summary>
        private void NumericUpDown_UV1_Y_ValueChanged(object sender, EventArgs e) => info.UpperLeftUV = new SerializableVector2DF(info.UpperLeftUV.X, (float)NumericUpDown_UV1_Y.Value);
        /// <summary>
        /// UV2X変更
        /// </summary>
        private void NumericUpDown_UV2_X_ValueChanged(object sender, EventArgs e) => info.UpperRightUV = new SerializableVector2DF((float)NumericUpDown_UV2_X.Value, info.UpperRightUV.Y);
        /// <summary>
        /// UV2Y変更
        /// </summary>
        private void NumericUpDown_UV2_Y_ValueChanged(object sender, EventArgs e) => info.UpperRightUV = new SerializableVector2DF(info.UpperRightUV.X, (float)NumericUpDown_UV2_Y.Value);
        /// <summary>
        /// UV3X変更
        /// </summary>
        private void NumericUpDown_UV3_X_ValueChanged(object sender, EventArgs e) => info.LowerRightUV = new SerializableVector2DF((float)NumericUpDown_UV3_X.Value, info.LowerRightUV.Y);
        /// <summary>
        /// UV3Y変更
        /// </summary>
        private void NumericUpDown_UV3_Y_ValueChanged(object sender, EventArgs e) => info.LowerRightUV = new SerializableVector2DF(info.LowerRightUV.X, (float)NumericUpDown_UV3_Y.Value);
        /// <summary>
        /// UV4X変更
        /// </summary>
        private void NumericUpDown_UV4_X_ValueChanged(object sender, EventArgs e) => info.LowerLeftUV = new SerializableVector2DF((float)NumericUpDown_UV4_X.Value, info.LowerLeftUV.Y);
        /// <summary>
        /// UV4Y変更
        /// </summary>
        private void NumericUpDown_UV4_Y_ValueChanged(object sender, EventArgs e) => info.LowerLeftUV = new SerializableVector2DF(info.LowerLeftUV.X, (float)NumericUpDown_UV4_Y.Value);
        /// <summary>
        /// 色1のR変更
        /// </summary>
        private void NumericUpDown_R1_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperLeftColor;
            info.UpperLeftColor = new Color((int)NumericUpDown_R1.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 色1のG変更
        /// </summary>
        private void NumericUpDown_G1_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperLeftColor;
            info.UpperLeftColor = new Color(c.R, (int)NumericUpDown_G1.Value, c.B, c.A);
        }
        /// <summary>
        /// 色1のB変更
        /// </summary>
        private void NumericUpDown_B1_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperLeftColor;
            info.UpperLeftColor = new Color(c.R, c.G, (int)NumericUpDown_B1.Value, c.A);
        }
        /// <summary>
        /// 色1のA変更
        /// </summary>
        private void NumericUpDown_A1_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperLeftColor;
            info.UpperLeftColor = new Color(c.R, c.G, c.B, (int)NumericUpDown_A1.Value);
        }
        /// <summary>
        /// 色2のR変更
        /// </summary>
        private void NumericUpDown_R2_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperRightColor;
            info.UpperRightColor = new Color((int)NumericUpDown_R2.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 色2のG変更
        /// </summary>
        private void NumericUpDown_G2_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperRightColor;
            info.UpperRightColor = new Color(c.R, (int)NumericUpDown_G2.Value, c.B, c.A);
        }
        /// <summary>
        /// 色2のB変更
        /// </summary>
        private void NumericUpDown_B2_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperRightColor;
            info.UpperRightColor = new Color(c.R, c.G, (int)NumericUpDown_B2.Value, c.A);
        }
        /// <summary>
        /// 色2のA変更
        /// </summary>
        private void NumericUpDown_A2_ValueChanged(object sender, EventArgs e)
        {
            var c = info.UpperRightColor;
            info.UpperRightColor = new Color(c.R, c.G, c.B, (int)NumericUpDown_A2.Value);
        }
        /// <summary>
        /// 色3のR変更
        /// </summary>
        private void NumericUpDown_R3_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerRightColor;
            info.LowerRightColor = new Color((int)NumericUpDown_R3.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 色3のG変更
        /// </summary>
        private void NumericUpDown_G3_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerRightColor;
            info.LowerRightColor = new Color(c.R, (int)NumericUpDown_G3.Value, c.B, c.A);
        }
        /// <summary>
        /// 色3のB変更
        /// </summary>
        private void NumericUpDown_B3_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerRightColor;
            info.LowerRightColor = new Color(c.R, c.G, (int)NumericUpDown_B3.Value, c.A);
        }
        /// <summary>
        /// 色3のA変更
        /// </summary>
        private void NumericUpDown_A3_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerRightColor;
            info.LowerRightColor = new Color(c.R, c.G, c.B, (int)NumericUpDown_A3.Value);
        }
        /// <summary>
        /// 色4のR変更
        /// </summary>
        private void NumericUpDown_R4_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerLeftColor;
            info.LowerLeftColor = new Color((int)NumericUpDown_R4.Value, c.G, c.B, c.A);
        }
        /// <summary>
        /// 色4のG変更
        /// </summary>
        private void NumericUpDown_G4_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerLeftColor;
            info.LowerLeftColor = new Color(c.R, (int)NumericUpDown_G4.Value, c.B, c.A);
        }
        /// <summary>
        /// 色4のB変更
        /// </summary>
        private void NumericUpDown_B4_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerLeftColor;
            info.LowerLeftColor = new Color(c.R, c.G, (int)NumericUpDown_B4.Value, c.A);
        }
        /// <summary>
        /// 色4のA変更
        /// </summary>
        private void NumericUpDown_A4_ValueChanged(object sender, EventArgs e)
        {
            var c = info.LowerLeftColor;
            info.LowerLeftColor = new Color(c.R, c.G, c.B, (int)NumericUpDown_A4.Value);
        }
    }
}
