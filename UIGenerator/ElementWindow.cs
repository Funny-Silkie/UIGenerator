using System;
using System.Windows.Forms;

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
            ResetObjComboBox();
            ResetAdditionalComboBox();
            ComboBox_Obj_Type.DataSource = EnumHelper.GetNames<UITypes>();
            ComboBox_Add_Type.DataSource = EnumHelper.GetNames<DrawingAdditionalMode>();
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
                ResetObjComboBox();
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
                ResetAdditionalComboBox();
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
        /// <summary>
        /// <see cref="ComboBox_Add_Remove"/>の内容を更新する
        /// </summary>
        public void ResetAdditionalComboBox() => ComboBox_Add_Remove.DataSource = DataBase.DrawingCollection.GetNames();
        /// <summary>
        /// <see cref="ComboBox_Obj_Remove"/>の内容を更新する
        /// </summary>
        public void ResetObjComboBox() => ComboBox_Obj_Remove.DataSource = DataBase.UIInfos.GetNames();
        /// <summary>
        /// UIオブジェクトを削除
        /// </summary>
        private void Button_Obj_Remove_Click(object sender, EventArgs e)
        {
            var index = ComboBox_Obj_Remove.SelectedIndex;
            if (!DataBase.UIInfos.IsCompatibleIndex(index))
            {
                Console.WriteLine("指定したオブジェクトを削除できませんでした");
                return;
            }
            DataBase.RemoveObject(DataBase.UIInfos[index]);
            DataBase.UpdateUIObjectControls();
            Console.WriteLine("指定したオブジェクトを削除できました");
        }
        /// <summary>
        /// 追加描画オブジェクトを削除
        /// </summary>
        private void Button_Add_Remove_Click(object sender, EventArgs e)
        {
            var index = ComboBox_Add_Remove.SelectedIndex;
            if (!DataBase.DrawingCollection.IsCompatibleIndex(index))
            {
                Console.WriteLine("指定した要素を削除できませんでした");
                return;
            }
            DataBase.DrawingCollection.RemoveAt(index);
            DataBase.UpdateUIObjectControls();
            Console.WriteLine("指定したオブジェクトを削除できました");
        }
    }
}
