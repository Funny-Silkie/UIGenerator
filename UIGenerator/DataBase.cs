using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;
using fslib;

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
        public static int MaxMode { get; set; } = 0;
        public static int ShowMode { get; set; } = 0;
        internal static string[] Types { get; } = Enum.GetNames(typeof(UITypes));
        /// <summary>
        /// メインのシーン
        /// </summary>
        public static MainScene MainScene { get; } = new MainScene();
        public static List<UIInfoBase> UIInfos { get; } = new List<UIInfoBase>();
        public static void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            UIInfos.Add(info);
            if (ShowMode == info.Mode) MainScene.AddObject(info);
        }
        public static void RemoveObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            UIInfos.Remove(info);
            if (ShowMode == info.Mode) MainScene.RemoveObject(info);
        }
    }
}
