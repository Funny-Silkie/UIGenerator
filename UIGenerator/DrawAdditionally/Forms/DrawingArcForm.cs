using System;
using System.Windows.Forms;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="DrawingArcInfo"/>のプロパティ情報を操作するクラス
    /// </summary>
    public partial class DrawingArcForm : Form
    {
        private readonly MainEdittor main;
        private readonly DrawingArcInfo info;
        private readonly bool inited = false;
        /// <summary>
        /// テクスチャの情報を格納する<see cref="ComboBox"/>を取得する
        /// </summary>
        public ComboBox ComboBox_Texture => ComboBox_texture;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main"><see cref="MainEdittor"/>への参照</param>
        /// <param name="info">操作する<see cref="DrawingArcInfo"/>への参照</param>
        /// <exception cref="ArgumentNullException"><paramref name="main"/>または<paramref name="info"/>がnull</exception>
        public DrawingArcForm(MainEdittor main, DrawingArcInfo info)
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
            ComboBox_texture.DataSource = DataBase.Textures.GetNames();
            var textureIndex = DataBase.Textures.IndexOf(info.Texture);
            ComboBox_texture.SelectedIndex = textureIndex == -1 ? 0 : textureIndex;
            NumericUpDown_Mode.Value = info.Mode;
            TextBox_Name.Text = info.Name;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            ComboBox_AlphaBlend.SelectedIndex = (int)info.AlphaBlend;
            NumericUpDown_Center_X.Value = (decimal)info.Center.X;
            NumericUpDown_Center_Y.Value = (decimal)info.Center.Y;
            NumericUpDown_VertNum.Value = info.VertNum;
            NumericUpDown_OuterDiameter.Value = (decimal)info.OuterDiameter;
            NumericUpDown_InnterDiameter.Value = (decimal)info.InnerDiameter;
            NumericUpDown_Angle.Value = (decimal)info.Angle;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            NumericUpDown_StartingVerticalAngle.Value = info.StartingVerticalAngle;
            NumericUpDown_EndingVerticalAngle.Value = info.EndingVerticalAngle;
            SetMinMax();
            ComboBox_AlphaBlend.SelectedIndexChanged += new EventHandler(ComboBox_AlphaBlend_SelectedIndexChanged);
            ComboBox_texture.SelectedIndexChanged += new EventHandler(ComboBox_Texture_SelectedIndexChanged);
        }
        /// <summary>
        /// フォームの値の範囲を設定する
        /// </summary>
        private void SetMinMax()
        {
            NumericUpDown_StartingVerticalAngle.Maximum = Math.Min(NumericUpDown_EndingVerticalAngle.Value, NumericUpDown_VertNum.Value);
            NumericUpDown_EndingVerticalAngle.Minimum = NumericUpDown_StartingVerticalAngle.Value;
            NumericUpDown_EndingVerticalAngle.Maximum = NumericUpDown_VertNum.Value;
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void DrawingArcForm_FormClosed(object sender, FormClosedEventArgs e)
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
        /// 座標X変更
        /// </summary>
        private void NumericUpDown_Pos_X_ValueChanged(object sender, EventArgs e) => info.Center = new Vector2DF((float)NumericUpDown_Center_X.Value, info.Center.Y);
        /// <summary>
        /// 座標Y変更
        /// </summary>
        private void NumericUpDown_Pos_Y_ValueChanged(object sender, EventArgs e) => info.Center = new Vector2DF(info.Center.X, (float)NumericUpDown_Center_Y.Value);
        /// <summary>
        /// VertNum変更
        /// </summary>
        private void NumericUpDown_VertNum_ValueChanged(object sender, EventArgs e)
        {
            info.VertNum = (int)NumericUpDown_VertNum.Value;
            SetMinMax();
        }
        /// <summary>
        /// 外側の半径の変更
        /// </summary>
        private void NumericUpDown_OuterDiameter_ValueChanged(object sender, EventArgs e) => info.OuterDiameter = (float)NumericUpDown_OuterDiameter.Value;
        /// <summary>
        /// 内側の半径の変更
        /// </summary>
        private void NumericUpDown_InnterDiameter_ValueChanged(object sender, EventArgs e) => info.InnerDiameter = (float)NumericUpDown_InnterDiameter.Value;
        /// <summary>
        /// 回転角度変更
        /// </summary>
        private void NumericUpDown_Angle_ValueChanged(object sender, EventArgs e) => info.Angle = (float)NumericUpDown_Angle.Value;
        /// <summary>
        /// StartingVerticalAngle変更
        /// </summary>
        private void NumericUpDown_StartingVerticalAngle_ValueChanged(object sender, EventArgs e)
        {
            info.StartingVerticalAngle = (int)NumericUpDown_StartingVerticalAngle.Value;
            SetMinMax();
        }
        /// <summary>
        /// EndingVerticalAngle変更
        /// </summary>
        private void NumericUpDown_EndingVerticalAngle_ValueChanged(object sender, EventArgs e)
        {
            info.EndingVerticalAngle = (int)NumericUpDown_EndingVerticalAngle.Value;
            SetMinMax();
        }
        /// <summary>
        /// テクスチャの変更
        /// </summary>
        private void ComboBox_Texture_SelectedIndexChanged(object sender, EventArgs e) => info.Texture = DataBase.Textures[ComboBox_texture.SelectedIndex];
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
    }
}
