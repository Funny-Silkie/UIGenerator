﻿using System;
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
        /// 現在表示しているオブジェクトのモード
        /// </summary>
        public static int ShowMode { get; set; } = 0;
        internal static string[] Types { get; } = Enum.GetNames(typeof(UITypes));
        /// <summary>
        /// メインのシーン
        /// </summary>
        public static MainScene MainScene { get; } = new MainScene();
        /// <summary>
        /// <see cref="UIInfo{T}"/>の情報を取得する
        /// </summary>
        public static UIInfoCollection UIInfos { get; } = new UIInfoCollection();
        /// <summary>
        /// 既定のフォントを取得する
        /// </summary>
        public static DynamicFontInfo DefaultFont => _defaultFont ?? (_defaultFont = DynamicFontInfo.GetInstance("NotoSerifCJKjp-Medium.otf", 30, new ColorDefault(ColorSet.White), 1, new ColorDefault(ColorSet.Black)));
        private static DynamicFontInfo _defaultFont;
        /// <summary>
        /// 既定の画像を取得する
        /// </summary>
        public static TextureInfo DefaultTexture => _defaultTexture ?? (_defaultTexture = TextureInfo.GetInstance("DefaultPicture.png"));
        private static TextureInfo _defaultTexture;
        /// <summary>
        /// 管理されているフォントを取得する
        /// </summary>
        internal static FontCollection Fonts => _fonts ?? (_fonts = new FontCollection());
        private static FontCollection _fonts;
        /// <summary>
        /// 管理されているテクスチャを取得する
        /// </summary>
        internal static TextureCollection Textures => _textures ?? (_textures = new TextureCollection());
        private static TextureCollection _textures;
        public static HashSet<System.Windows.Forms.Form> Forms { get; } = new HashSet<System.Windows.Forms.Form>();
        /// <summary>
        /// オブジェクトを追加する
        /// </summary>
        /// <param name="info">追加されるオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        public static void AddObject(UIInfoBase info)
        {
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
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
            Central.ThrowHelper.ThrowArgumentNullException(info, null);
            UIInfos.Remove(info.Mode, info.Name);
            if (ShowMode == info.Mode) MainScene.RemoveObject(info);
        }
        /// <summary>
        /// 全ての<see cref="AddWindow"/>，<see cref="TextEdittor"/>，<see cref="TextureAddForm"/>，<see cref="TextureEdittor"/>，<see cref="FontAddForm"/>を閉じる
        /// </summary>
        public static void CloseAllWindow()
        {
            foreach (var f in Forms)
                if (f != null && !f.IsDisposed)
                    f.Close();
            Forms.Clear();
        }
    }
}
