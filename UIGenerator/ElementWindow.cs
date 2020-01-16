using System;
using System.Windows.Forms;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// 要素を追加するウィンドウ
    /// </summary>
    public partial class ElementWindow : Form
    {
        private readonly MainEdittor mainEdittor;
        /// <summary>
        /// インスタンスが存在しているかどうかを取得する
        /// </summary>
        public static bool Instanced => SingleInstance != null;
        /// <summary>
        /// 唯一のインスタンスを取得する
        /// </summary>
        public static ElementWindow SingleInstance { get; private set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="main"><see cref="MainEdittor"/></param>への参照
        /// <exception cref="ArgumentNullException"><paramref name="main"/>がnull</exception>
        private ElementWindow(MainEdittor main)
        {
            mainEdittor = main ?? throw new ArgumentNullException();
            SingleInstance = this;
            InitializeComponent();
            ComboBox_Obj_Type.DataSource = Enum.GetNames(typeof(UITypes));
            ComboBox_Add_Type.DataSource = Enum.GetNames(typeof(DrawingAdditionalMode));
        }
        /// <summary>
        /// フォームが閉じられたときの挙動
        /// </summary>
        private void AddWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingleInstance = null;
            DataBase.Forms.Remove(this);
        }
        /// <summary>
        /// Object2D要素の追加
        /// </summary>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            var mode = (int)NumericUpDown_Obj_Mode.Value;
            var type = (UITypes)Enum.Parse(typeof(UITypes), ComboBox_Obj_Type.Text);
            var name = TextBox_Obj_Name.Text;
            if (!DataBase.UIInfos.Contains(mode, name))
            {
                DataBase.AddObject(UIInfoBase.GetInstance(type, mode, name));
                var item = mainEdittor.ListView_Objects.Items.Add(type.ToString());
                item.SubItems.Add(name);
                item.SubItems.Add(mode.ToString());
                Reset_Obj();
            }
        }
        /// <summary>
        /// Object2D周辺のフォーム情報のリセット
        /// </summary>
        private void Reset_Obj()
        {
            TextBox_Obj_Name.Text = "";
            NumericUpDown_Obj_Mode.Value = 0;
        }
        /// <summary>
        /// 追加描画要素の追加
        /// </summary>
        private void Button_Add_Add_Click(object sender, EventArgs e)
        {
            var mode = (int)NumericUpDown_Add_Mode.Value;
            var type = EnumHelper.FromString<DrawingAdditionalMode>(ComboBox_Add_Type.Text);
            var name = TextBox_Add_Name.Text;
            if (!DataBase.DrawingCollection.Contains(mode, name))
            {
                DataBase.DrawingCollection.Add(DrawingAdditionaryInfoBase.GetInstance(type, mode, name));
                var item = mainEdittor.ListView_Additionalies.Items.Add(type.ToString());
                item.SubItems.Add(name);
                item.SubItems.Add(mode.ToString());
                Reset_Add();
            }
        }
        /// <summary>
        /// 追加描画周辺のフォーム情報のリセット
        /// </summary>
        private void Reset_Add()
        {
            TextBox_Add_Name.Text = "";
            NumericUpDown_Add_Mode.Value = 0;
        }
        /// <summary>
        /// インスタンスを生成して表示する
        /// </summary>
        /// <param name="main">メインのエディターへの参照</param>
        /// <exception cref="ArgumentNullException"><paramref name="main"/>がnull</exception>
        public static bool CreateAndShow(MainEdittor main)
        {
            if (!Instanced)
            {
                var a = new ElementWindow(main);
                DataBase.Forms.Add(a);
                a.Show();
                return true;
            }
            return false;
        }
    }
}
