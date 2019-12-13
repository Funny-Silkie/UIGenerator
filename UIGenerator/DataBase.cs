using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;
using fslib.Collections;

namespace UIGenerator
{
    /// <summary>
    /// UIのタイプを表す
    /// </summary>
    public enum UITypes
    {
        /// <summary>
        /// テキスト
        /// </summary>
        Text,
        /// <summary>
        /// テクスチャ
        /// </summary>
        Texture,
        /// <summary>
        /// ウィンドウ
        /// </summary>
        Window
    }
    public class DataBase
    {
        /// <summary>
        /// モードの最小値
        /// </summary>
        public const int MinMode = 0;
        /// <summary>
        /// モードの最大値
        /// </summary>
        public static int MaxMode { get; private set; } = 0;
        public static int ShowMode { get; set; } = 0;
        internal static string[] Types { get; } = Enum.GetNames(typeof(UITypes));
        /// <summary>
        /// メインのシーン
        /// </summary>
        public static MainScene MainScene { get; } = new MainScene();
        public static DoubleKeyDictionary<int, string, UIInfoBase> UIInfos { get; } = new DoubleKeyDictionary<int, string, UIInfoBase>();
        public static DynamicFontInfo DefaultFont => _defaultFont ?? (_defaultFont = DynamicFontInfo.GetInstance("NotoSerifCJKjp-Medium.otf", 30, new ColorDefault(ColorSet.White), 1, new ColorDefault(ColorSet.Black)));
        private static DynamicFontInfo _defaultFont;
        public static TextureInfo DefaultTexture => _defaultTexture ?? (_defaultTexture = TextureInfo.GetInstance("DefaultPicture.png"));
        private static TextureInfo _defaultTexture;
        internal static FontCollection Fonts => _fonts ?? (_fonts = new FontCollection());
        private static FontCollection _fonts;
        internal static TextureCollection Textures => _textures ?? (_textures = new TextureCollection());
        internal static TextureCollection _textures;
        public static void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            UIInfos.Add(info.Mode, info.Name, info);
            if (ShowMode == info.Mode) MainScene.AddObject(info);
        }
        public static void RemoveObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            UIInfos.Remove(info.Mode, info.Name);
            if (ShowMode == info.Mode) MainScene.RemoveObject(info);
        }
        public static void SetMaxMode(in int value, MainEdittor edittor)
        {
            MaxMode = value;
            edittor.NumericUpDown_ShowMode.Maximum = value;
            edittor.ComboBox_Filter_Mode.DataSource = Enumerable.Range(0, value + 1).ToArray();
        }
    }
}
