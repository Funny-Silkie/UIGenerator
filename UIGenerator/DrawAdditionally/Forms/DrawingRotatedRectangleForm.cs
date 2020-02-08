using System;
using System.Windows.Forms;
using asd;
using fslib;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// <see cref="DrawingRectangleInfo"/>のプロパティ情報を操作するフォーム
    /// </summary>
    public partial class DrawingRotatedRectangleForm : Form
    {
        private readonly MainEdittor main;
        private readonly DrawingRotatedRectangleInfo info;
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
        public DrawingRotatedRectangleForm(MainEdittor main, DrawingRotatedRectangleInfo info)
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
            NumericUpDown_Pos_X.Value = (decimal)info.DrawingArea.X;
            NumericUpDown_Pos_Y.Value = (decimal)info.DrawingArea.Y;
            NumericUpDown_Size_X.Value = (decimal)info.DrawingArea.Width;
            NumericUpDown_Size_Y.Value = (decimal)info.DrawingArea.Height;
            NumericUpDown_Priority.Value = info.DrawingPriority;
            NumericUpDown_R.Value = info.Color.R;
            NumericUpDown_G.Value = info.Color.G;
            NumericUpDown_B.Value = info.Color.B;
            NumericUpDown_A.Value = info.Color.A;
            NumericUpDown_UV_X.Value = (decimal)info.UV.X;
            NumericUpDown_UV_Y.Value = (decimal)info.UV.Y;
            NumericUpDown_UV_Width.Value = (decimal)info.UV.Width;
            NumericUpDown_UV_Height.Value = (decimal)info.UV.Height;
            NumericUpDown_Angle.Value = (decimal)info.Angle;
            NumericUpDown_Center_X.Value = (decimal)info.RotationCenter.X;
            NumericUpDown_Center_Y.Value = (decimal)info.RotationCenter.Y;
            ComboBox_AlphaBlend.SelectedIndexChanged += new EventHandler(ComboBox_AlphaBlend_SelectedIndexChanged);
            ComboBox_texture.SelectedIndexChanged += new EventHandler(ComboBox_Texture_SelectedIndexChanged);
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void DrawingRotatedRectangleForm_FormClosed(object sender, FormClosedEventArgs e)
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
        /// 座標X変更
        /// </summary>
        private void NumericUpDown_Pos_X_ValueChanged(object sender, EventArgs e) => info.DrawingArea = new SerializableRectF(new Vector2DF((float)NumericUpDown_Pos_X.Value, info.DrawingArea.Y), info.DrawingArea.Size);
        /// <summary>
        /// 座標Y変更
        /// </summary>
        private void NumericUpDown_Pos_Y_ValueChanged(object sender, EventArgs e) => info.DrawingArea = new SerializableRectF(new Vector2DF(info.DrawingArea.X, (float)NumericUpDown_Pos_Y.Value), info.DrawingArea.Size);
        /// <summary>
        /// サイズX変更
        /// </summary>
        private void NumericUpDown_Size_X_ValueChanged(object sender, EventArgs e) => info.DrawingArea = new SerializableRectF(info.DrawingArea.Position, new Vector2DF((float)NumericUpDown_Size_X.Value, info.DrawingArea.Height));
        /// <summary>
        /// サイズY変更
        /// </summary>
        private void NumericUpDown_Size_Y_ValueChanged(object sender, EventArgs e) => info.DrawingArea = new SerializableRectF(info.DrawingArea.Position, new Vector2DF(info.DrawingArea.Width, (float)NumericUpDown_Size_Y.Value));
        /// <summary>
        /// テクスチャの変更
        /// </summary>
        private void ComboBox_Texture_SelectedIndexChanged(object sender, EventArgs e) => info.Texture = DataBase.Textures[ComboBox_texture.SelectedIndex];
        /// <summary>
        /// UVX変更
        /// </summary>
        private void NumericUpDown_UV_X_ValueChanged(object sender, EventArgs e) => info.UV = new SerializableRectF(new Vector2DF((float)NumericUpDown_UV_X.Value, info.UV.Y), info.UV.Size);
        /// <summary>
        /// UVY変更
        /// </summary>
        private void NumericUpDown_UV_Y_ValueChanged(object sender, EventArgs e) => info.UV = new SerializableRectF(new Vector2DF(info.UV.X, (float)NumericUpDown_UV_Y.Value), info.UV.Size);
        /// <summary>
        /// UVWidth変更
        /// </summary>
        private void NumericUpDown_UV_Width_ValueChanged(object sender, EventArgs e) => info.UV = new SerializableRectF(info.UV.Position, new Vector2DF((float)NumericUpDown_UV_X.Value, info.UV.Height));
        /// <summary>
        /// UVHeight変更
        /// </summary>
        private void NumericUpDown_UV_Height_ValueChanged(object sender, EventArgs e) => info.UV = new SerializableRectF(info.UV.Position, new Vector2DF(info.UV.Width, (float)NumericUpDown_UV_Y.Value));
        /// <summary>
        /// 中心座標のX変更
        /// </summary>
        private void NumericUpDown_Center_X_ValueChanged(object sender, EventArgs e) => info.RotationCenter = new SerializableVector2DF((float)NumericUpDown_Center_X.Value, info.RotationCenter.Y);
        /// <summary>
        /// 中心座標のY変更
        /// </summary>
        private void NumericUpDown_Center_Y_ValueChanged(object sender, EventArgs e) => info.RotationCenter = new SerializableVector2DF(info.RotationCenter.X, (float)NumericUpDown_Center_Y.Value);
        /// <summary>
        /// 回転角度変更
        /// </summary>
        private void NumericUpDown_Angle_ValueChanged(object sender, EventArgs e) => info.Angle = (float)NumericUpDown_Angle.Value;
    }
}
