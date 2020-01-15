using System;
using System.IO;
using asd;
using fslib;
using fslib.Collections.BasicModel;
using fslib.IO;
using fslib.Serialization;

namespace UIGenerator
{
    /// <summary>
    /// 処理に必要なデータを格納しておくクラス
    /// </summary>
    public static class DataBase
    {
        /// <summary>
        /// 現在表示しているオブジェクトのモードを取得または設定する
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">設定しようとした値が0未満</exception>
        public static int ShowMode
        {
            get => _showMode;
            set => _showMode = value >= 0 ? value : throw new ArgumentOutOfRangeException();
        }
        private static int _showMode = 0;
        /// <summary>
        /// プロジェクト名を取得または設定する
        /// </summary>
        /// <exception cref="ArgumentNullException">設定しようとした値がnull</exception>
        public static string ProjectName
        {
            get => _projectName;
            set
            {
                _projectName = value ?? throw new ArgumentNullException();
                Engine.Title = value;
            }
        }
        private static string _projectName = "";
        /// <summary>
        /// ウィンドウの大きさを取得または設定する
        /// </summary>
        public static SerializableVector2DI WindowSize
        {
            get => _windowSize;
            set => SetWindowSize(value);
        }
        private static SerializableVector2DI _windowSize;
        /// <summary>
        /// メインのシーンを取得する
        /// </summary>
        public static MainScene MainScene { get; } = new MainScene();
        /// <summary>
        /// <see cref="UIInfo{T}"/>の情報を取得する
        /// </summary>
        public static UIInfoCollection UIInfos { get; private set; } = new UIInfoCollection();
        /// <summary>
        /// 追加描画の情報を格納するコレクションを取得する
        /// </summary>
        public static DrawingAdditionaryInfoCollection DrawingCollection { get; private set; } = new DrawingAdditionaryInfoCollection();
        /// <summary>
        /// 既定のフォントを取得する
        /// </summary>
        public static DynamicFontInfo DefaultFont => _defaultFont ?? (_defaultFont = DynamicFontInfo.GetInstance("Resource/NotoSerifCJKjp-Medium.otf", 30, new ColorPlus(ColorSet.White), 1, new ColorPlus(ColorSet.Black)));
        private static DynamicFontInfo _defaultFont;
        /// <summary>
        /// 既定の画像を取得する
        /// </summary>
        public static TextureInfo DefaultTexture => _defaultTexture ?? (_defaultTexture = TextureInfo.GetInstance("Resource/DefaultPicture.png"));
        private static TextureInfo _defaultTexture;
        /// <summary>
        /// 管理されているフォントを取得する
        /// </summary>
        public static FontCollection Fonts => _fonts ?? (_fonts = new FontCollection());
        private static FontCollection _fonts;
        /// <summary>
        /// 管理されているテクスチャを取得する
        /// </summary>
        public static TextureCollection Textures => _textures ?? (_textures = new TextureCollection());
        private static TextureCollection _textures;
        /// <summary>
        /// サブフォームを格納しておくコレクションを取得する
        /// </summary>
        public static BasicCollection<System.Windows.Forms.Form> Forms { get; } = new BasicCollection<System.Windows.Forms.Form>();
        /// <summary>
        /// 使用されるファイルパッケージのコレクションを取得する
        /// </summary>
        public static FilePackageCollection FllePackages { get; } = new FilePackageCollection();
        /// <summary>
        /// ウィンドウの中央の座標を取得する
        /// </summary>
        public static Vector2DF CenterPosition => Engine.WindowSize.To2DF() / 2;
        /// <summary>
        /// オブジェクトを追加する
        /// </summary>
        /// <param name="info">追加されるオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public static void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            UIInfos.Add(info.Mode, info.Name, info);
            if (ShowMode == info.Mode) MainScene.AddObject(info);
        }
        /// <summary>
        /// オブジェクトを削除する
        /// </summary>
        /// <param name="info">削除するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public static void RemoveObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, info);
            UIInfos.Remove(info.Mode, info.Name);
            if (ShowMode == info.Mode) MainScene.RemoveObject(info);
        }
        /// <summary>
        /// 登録されているすべてのウィンドウを閉じる
        /// </summary>
        public static void CloseAllWindow()
        {
            var array = Forms.ToArray();
            for (int i = 0; i < array.Length; i++)
                if (array[i] != null && !array[i].IsDisposed)
                    array[i].Close();
            Forms.Clear();
        }
        /// <summary>
        /// ウィンドウサイズ，タイトルを初期化する
        /// </summary>
        /// <param name="sizeX">ウィンドウのX方向の大きさ</param>
        /// <param name="sizeY">ウィンドウのY方向の大きさ</param>
        /// <param name="title">プロジェクト名</param>
        /// <exception cref="ArgumentNullException"><paramref name="title"/>がnull</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="sizeX"/>または<paramref name="sizeY"/>が0以下</exception>
        public static void Initialize(int sizeX, int sizeY, string title)
        {
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(sizeX, 1, int.MaxValue, null);
            Central.ThrowHelper.ThrowArgumentOutOfRangeException(sizeY, 1, int.MaxValue, null);
            _windowSize = new SerializableVector2DI(sizeX, sizeY);
            _projectName = title ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// プロジェクトデータをバイナリ形式でセーブする
        /// </summary>
        /// <param name="path">セーブするファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        public static void SaveProject(string path) => IOHandler.WriteBinary(path ?? throw new ArgumentNullException(), new DataCarrier());
        /// <summary>
        /// プロジェクトデータをバイナリ形式でロードする
        /// </summary>
        /// <param name="path">読み込むデータのパス</param>
        public static void LoadProject(string path)
        {
            var c = IOHandler.ReadBinary<DataCarrier>(path);
            _fonts = c.FontCollection ?? _fonts;
            _textures = c.TextureCollection ?? _textures;
            DrawingCollection = c.DrawingAdditionaryInfoCollection ?? DrawingCollection;
            UIInfos = c.UIInfoCollection ?? UIInfos;
            ProjectName = c.ProjectName ?? ProjectName;
            WindowSize = c.WindowSize;
            UpdateListView();
            ShowMode = 0;
            foreach (var obj in UIInfos)
                if (obj.Key1 == ShowMode)
                    MainScene.AddObject(obj.Value);
        }
        /// <summary>
        /// 指定したパスにリソース情報を保存する
        /// </summary>
        /// <param name="path">保存先のパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空文字のみでできている又は特定の拡張子を持つ</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>の指定するディレクトリが存在しない</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>が特定の拡張子を持つ</exception>
        /// <exception cref="IOException">IO上のエラー</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="System.Security.SecurityException">アクセスが拒否された</exception>
        public static void SaveResourcePackage(string path) => IOHandler.WriteBinary(path, new ResourcePackage());
        /// <summary>
        /// 指定したパスのリソース情報を読み込み現在の情報に上書きする
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        public static void LoadResourcePackage(string path)
        {
            var resources = IOHandler.ReadBinary<ResourcePackage>(path);
            _fonts = resources.OpenPackageFonts();
            _textures = resources.OpenPackageTextures();
            UpdateResourceControls();
        }
        /// <summary>
        /// 開かれているフォームのリソース関係のコントロールを更新する
        /// </summary>
        private static void UpdateResourceControls()
        {
            Fonts.ChangeFontComboBox();
            Textures.ChangeComboBox();
            FontIOForm.SigleInstance?.ResetComboBox();
            FontIOForm.SigleInstance?.ResetListView(true);
            TextureIOForm.SingleInstance?.ResetCombobox();
            TextureIOForm.SingleInstance?.ResetListView(true);
        }
        /// <summary>
        /// リストビューの内容を更新する
        /// </summary>
        public static void UpdateListView()
        {
            MainEdittor.SingleInstance?.ResetListView();
        }
        /// <summary>
        /// ウィンドウのサイズを変更する
        /// </summary>
        /// <param name="size">変更後のウィンドウサイズ</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/>のXまたはYの値が0以下</exception>
        private static void SetWindowSize(SerializableVector2DI size)
        {
            if (size == _windowSize) return;
            if (size.X <= 0 || size.Y <= 0) throw new ArgumentOutOfRangeException();
            _windowSize = size;
            Engine.WindowSize = size;
        }
    }
    /// <summary>
    /// バイナリでデータを保存するためにまとめるクラス
    /// </summary>
    [Serializable]
    public class DataCarrier
    {
        /// <summary>
        /// <see cref="DataBase.UIInfos"/>のインスタンス
        /// </summary>
        public UIInfoCollection UIInfoCollection { get; }
        /// <summary>
        /// <see cref="DataBase.Fonts"/>のインスタンス
        /// </summary>
        public FontCollection FontCollection { get; }
        /// <summary>
        /// <see cref="DataBase.Textures"/>のインスタンス
        /// </summary>
        public TextureCollection TextureCollection { get; }
        /// <summary>
        /// <see cref="DataBase.DrawingCollection"/>のインスタンス
        /// </summary>
        public DrawingAdditionaryInfoCollection DrawingAdditionaryInfoCollection { get; }
        /// <summary>
        /// プロジェクト名を取得または設定する
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// ウィンドウの大きさを取得または設定する
        /// </summary>
        public SerializableVector2DI WindowSize { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataCarrier()
        {
            UIInfoCollection = DataBase.UIInfos;
            FontCollection = DataBase.Fonts;
            TextureCollection = DataBase.Textures;
            DrawingAdditionaryInfoCollection = DataBase.DrawingCollection;
            ProjectName = DataBase.ProjectName;
            WindowSize = DataBase.WindowSize;
        }
    }
}
