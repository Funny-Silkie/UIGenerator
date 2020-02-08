using System;
using System.IO;

namespace UIGenerator
{
    /// <summary>
    /// ファイルパスに関する情報を検査するクラス
    /// </summary>
    public static class FilePathHelper
    {
        private static char[] InvalidChars => _invalidChars ??= Path.GetInvalidPathChars();
        private static char[] _invalidChars;
        /// <summary>
        /// 指定したパスが無効だった場合例外をスローする
        /// </summary>
        /// <param name="path">判定するパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみからなるまたは使用できない文字を含む</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        public static void ThrowIfInvalidPath(string path)
        {
            if (!CheckLength(path)) throw new PathTooLongException();
            if (string.IsNullOrWhiteSpace(path) || HasInvalidChar(path)) throw new ArgumentException();
        }
        /// <summary>
        /// 指定したパスの長さが適切かどうかを判定する
        /// </summary>
        /// <param name="path">長さを判定するパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>パスの長さが260字未満かつディレクトリの長さが248字未満であったらtrue，それ以外でfalse</returns>
        public static bool CheckLength(string path)
        {
            if (path == null) throw new ArgumentNullException();
            return path.Length < 260 && Path.GetDirectoryName(path).Length < 248;
        }
        /// <summary>
        /// 指定した拡張子を持つ<see cref="System.Windows.Forms.FileDialog.Filter"/>として使用可能な文字列を返す
        /// </summary>
        /// <param name="message">表示するファイルの種類を表す文字列</param>
        /// <param name="extensions">フィルターするファイルの拡張子</param>
        /// <exception cref="ArgumentNullException"><paramref name="message"/>又は<paramref name="extensions"/>がnull</exception>
        /// <exception cref="FormatException"><paramref name="extensions"/>に拡張子ではない文字列が含まれていた</exception>
        /// <returns>フィルターと指定使用可能な文字列</returns>
        public static string GetFilter(string message, params string[] extensions)
        {
            if (message == null || extensions == null) throw new ArgumentNullException();
            var count = extensions.Length;
            var head = "(";
            var tail = "|";
            for (int i = 0; i < count; i++)
            {
                var e = "." + extensions[i].TrimStart('.');
                if (!IsExtension(e)) throw new FormatException();
                head += $"*{e},";
                tail += $"*{e};";
            }
            head = head.Substring(0, head.Length - 1) + ")";
            tail = tail.Substring(0, tail.Length - 1);
            return message + head + tail;
        }
        /// <summary>
        /// 指定したファイルパスの拡張子を返す
        /// </summary>
        /// <param name="path">拡張子を調べるファイルパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns>ファイル拡張子</returns>
        public static string GetExtension(string path)
        {
            if (path == null) throw new ArgumentNullException();
            var i = path.LastIndexOf(".");
            if (i == -1) return "";
            return path.Substring(i, path.Length - i);
        }
        /// <summary>
        /// 指定したパスにファイルパスに使えない文字が入っているかどうかを判定する
        /// </summary>
        /// <param name="path">判定するパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <returns><paramref name="path"/>に使用できない文字が含まれていたらtrue，それ以外でfalse</returns>
        public static bool HasInvalidChar(string path)
        {
            if (path == null) throw new ArgumentNullException();
            for (int i = 0; i < path.Length; i++)
                for (int j = 0; j < InvalidChars.Length; j++)
                    if (path[i] == InvalidChars[j])
                        return false;
            return true;
        }
        /// <summary>
        /// 指定した文字列がファイルの拡張子かどうかを返す
        /// </summary>
        /// <param name="extension">拡張子かどうかを調べる文字列</param>
        /// <returns>拡張子だったらtrue，それ以外でfalse</returns>
        public static bool IsExtension(string extension)
        {
            if (extension == null) return false;
            return extension.LastIndexOf(".") == 0;
        }
    }
}