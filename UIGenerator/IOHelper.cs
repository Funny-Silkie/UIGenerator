using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;
using System.Xml.Serialization;
using asd;

namespace UIGenerator
{
    /// <summary>
    /// ファイルの読み書きなどに関して
    /// </summary>
    public static class IOHandler
    {
        /// <summary>
        /// <see cref="StreamReader"/>を使ってcsvファイルからテキストを読み込む。
        /// 行ごとにコレクションの要素になる。
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <param name="option">エンコードのオプション</param>
        /// <exception cref="ArgumentException">filenameが空文字または指定エンコードが不正な値だった場合</exception>
        /// <exception cref="ArgumentNullException">filenameがnull</exception>
        /// <exception cref="DirectoryNotFoundException">ファイルのパスが存在しない</exception>
        /// <exception cref="FileNotFoundException">ファイルが見つからない</exception>
        /// <exception cref="NotSupportedException">ファイルパスが不正な値だった場合</exception>
        /// <exception cref="OutOfMemoryException">メモリが不足している</exception>
        /// <exception cref="IOException"><see cref="System.IO"/>上のエラー</exception>
        public static IEnumerable<string> ReadTextS(string path, EncodeOption option)
        {
            var list = new List<string>();
            using (var streamReader = new StreamReader(path, option.Encoding))
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    list.Add(line);
                }
            return list;
        }
        /// <summary>
        /// <see cref="StreamReader"/>を使ってcsvファイルからテキストを読み込む。
        /// 行ごとに分割された文字列がコレクションの要素になる。
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <param name="splitWord">文字列を分割する単語</param>
        /// <param name="option">エンコードのオプション</param>
        /// <exception cref="ArgumentException">filenameが空文字または指定エンコードが不正な値だった場合</exception>
        /// <exception cref="ArgumentNullException">filenameがnull</exception>
        /// <exception cref="DirectoryNotFoundException">ファイルのパスが存在しない</exception>
        /// <exception cref="FileNotFoundException">ファイルが見つからない</exception>
        /// <exception cref="NotSupportedException">ファイルパスが不正な値だった場合</exception>
        /// <exception cref="OutOfMemoryException">メモリが不足している</exception>
        /// <exception cref="IOException"><see cref="System.IO"/>上のエラー</exception>
        public static IEnumerable<string[]> ReadTextS(string path, EncodeOption option, params char[] splitWord)
        {
            var list = new List<string[]>();
            using (var streamReader = new StreamReader(path, option.Encoding))
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    var words = line.Split(splitWord);
                    list.Add(words);
                }
            return list;
        }
        /// <summary>
        /// テキスト形式のファイルに出力する。
        /// </summary>
        /// <param name="path">ファイルのパス</param>
        /// <param name="txt">書き込むテキスト</param>
        /// <param name="option">エンコードのオプション</param>
        /// <param name="mode">書き込み方のモード</param>
        /// <exception cref="ArgumentException">filenameが空文字または指定エンコードが不正な値だった場合</exception>
        /// <exception cref="ArgumentNullException">filenameがnull</exception>
        /// <exception cref="DirectoryNotFoundException">ファイルのパスが存在しない</exception>
        /// <exception cref="FileNotFoundException">ファイルが見つからない</exception>
        /// <exception cref="NotSupportedException">ファイルパスが不正な値だった場合</exception>
        /// <exception cref="OutOfMemoryException">メモリが不足している</exception>
        /// <exception cref="IOException"><see cref="System.IO"/>上のエラー</exception>
        public static void WriteText(string path, string txt, EncodeOption option, WriteTextMode mode)
        {
            using var text = new StreamWriter(path, false, option.Encoding);
            switch (mode)
            {
                case WriteTextMode.Overwrite:
                    text.Write(txt);
                    return;
                case WriteTextMode.AddBeggining:
                    var t1 = ReadTextS(path, option);
                    text.WriteLine(txt);
                    foreach (var t in t1)
                        text.WriteLine(t);
                    return;
                case WriteTextMode.AddEnd:
                    var t2 = ReadTextS(path, option);
                    foreach (var t in t2)
                        text.WriteLine(t);
                    text.Write(txt);
                    return;
            }
        }
        /// <summary>
        /// テキスト形式のファイルに出力する。
        /// 要素ごとに改行して入力する。
        /// </summary>
        /// <param name="path">ファイルのパス</param>
        /// <param name="txts">書き込むテキストのコレクション</param>
        /// <param name="option">エンコードのオプション</param>
        /// <param name="mode">書き込み方のモード</param>
        /// <exception cref="ArgumentException">filenameが空文字または指定エンコードが不正な値だった場合</exception>
        /// <exception cref="ArgumentNullException">filenameがnull</exception>
        /// <exception cref="DirectoryNotFoundException">ファイルのパスが存在しない</exception>
        /// <exception cref="FileNotFoundException">ファイルが見つからない</exception>
        /// <exception cref="NotSupportedException">ファイルパスが不正な値だった場合</exception>
        /// <exception cref="OutOfMemoryException">メモリが不足している</exception>
        /// <exception cref="IOException"><see cref="System.IO"/>上のエラー</exception>
        public static void WriteText(string path, IEnumerable<string> txts, EncodeOption option, WriteTextMode mode)
        {
            using var text = new StreamWriter(path, false, option.Encoding);
            switch (mode)
            {
                case WriteTextMode.Overwrite:
                    foreach (var t in txts)
                        text.WriteLine(t);
                    return;
                case WriteTextMode.AddBeggining:
                    var t1 = ReadTextS(path, option);
                    foreach (var t in txts)
                        text.WriteLine(t);
                    foreach (var t in t1)
                        text.WriteLine(t);
                    return;
                case WriteTextMode.AddEnd:
                    var t2 = ReadTextS(path, option);
                    foreach (var t in t2)
                        text.WriteLine(t);
                    foreach (var t in txts)
                        text.WriteLine(t);
                    return;
            }
        }
        /// <summary>
        /// Altseedを使ってcsvファイルからテキストを読み込む。
        /// 行ごとにコレクションの要素になる。
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <param name="option">エンコードのオプション</param>
        /// <exception cref="ArgumentException">filenameが空文字または指定エンコードが不正な値だった場合</exception>
        /// <exception cref="ArgumentNullException">filenameがnull</exception>
        /// <exception cref="DecoderFallbackException">フォールバックが発生</exception>
        public static IEnumerable<string> ReadTextA(string path, EncodeOption option)
        {
            var file = Engine.File.CreateStaticFile(path);
            var text = option.Encoding.GetString(file.Buffer);
            var csv = text.Split('\n').ToList();
            return csv;
        }
        /// <summary>
        /// Altseedを使ってcsvファイルからテキストを読み込む。
        /// 行ごとにコレクションの要素になる。
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <param name="option">エンコードのオプション</param> 
        /// <param name="splitWord">文字列を分割する単語</param>
        /// <exception cref="ArgumentException">filenameが空文字または指定エンコードが不正な値だった場合</exception>
        /// <exception cref="ArgumentNullException">filenameがnull</exception>
        /// <exception cref="DecoderFallbackException">フォールバックが発生</exception>
        public static IEnumerable<string[]> ReadTextA(string path, EncodeOption option, params char[] splitWord)
        {
            var file = Engine.File.CreateStaticFile(path);
            var text = option.Encoding.GetString(file.Buffer);
            var csv = text.Split('\n').Select(x => x.Split(splitWord)).ToList();
            return csv;
        }
        /// <summary>
        /// ファイルをコピーして生成する
        /// ファイルパッケージ内の要素も対象コピーできる
        /// 既にファイルが存在していた場合は上書きし，保存先ディレクトリが見つからなかった場合は新しく構築する
        /// </summary>
        /// <param name="basefilePath">コピーされるファイルのパス</param>
        /// <param name="newfilePath">コピー後生成されるファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="basefilePath"/>または<paramref name="newfilePath"/>が空文字または空白で形成されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="basefilePath"/>または<paramref name="newfilePath"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="basefilePath"/>で指定したファイルが存在していなかった</exception>
        /// <exception cref="NotSupportedException">:の位置が不正，指定拡張子がサポートされていない</exception>
        /// <exception cref="IOException">ファイルを読み込めなかった</exception>
        /// <exception cref="PathTooLongException"><paramref name="basefilePath"/>または<paramref name="newfilePath"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセス許可がない</exception>
        /// <exception cref="UnauthorizedAccessException">アクセスが拒否された</exception>
        public static void Copy(string basefilePath, string newfilePath) => Copy(basefilePath, newfilePath, true, true);
        /// <summary>
        /// ファイルをコピーして生成する
        /// ファイルパッケージ内の要素も対象コピーできる
        /// </summary>
        /// <param name="basefilePath">コピーされるファイルのパス</param>
        /// <param name="newfilePath">コピー後生成されるファイルのパス</param>
        /// <param name="overwrite">既にファイルがあった場合上書きするかどうか</param>
        /// <param name="generateDirectory">ディレクトリが存在しなかった場合自動生成するかどうか</param>
        /// <exception cref="ArgumentException"><paramref name="basefilePath"/>または<paramref name="newfilePath"/>が空文字または空白で形成されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="basefilePath"/>または<paramref name="newfilePath"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="generateDirectory"/>がfalseの時に保存先ディレクトリが存在していなかった</exception>
        /// <exception cref="FileNotFoundException"><paramref name="basefilePath"/>で指定したファイルが存在していなかった</exception>
        /// <exception cref="NotSupportedException">:の位置が不正，指定拡張子がサポートされていない</exception>
        /// <exception cref="IOException">ファイルを読み込めなかった，<paramref name="overwrite"/>がfalseの時に既にファイルが存在していた</exception>
        /// <exception cref="PathTooLongException"><paramref name="basefilePath"/>または<paramref name="newfilePath"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセス許可がない</exception>
        /// <exception cref="UnauthorizedAccessException">アクセスが拒否された</exception>
        public static void Copy(string basefilePath, string newfilePath, bool overwrite, bool generateDirectory)
        {
            if (basefilePath == null) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(basefilePath)) throw new ArgumentException();
            if (!Engine.File.Exists(basefilePath)) throw new FileNotFoundException();
            var file = Engine.File.CreateStaticFile(basefilePath) ?? throw new IOException();
            if (generateDirectory && !Directory.Exists(newfilePath)) Directory.CreateDirectory(newfilePath);
            using var stream = new FileStream(newfilePath, overwrite ? FileMode.Create : FileMode.CreateNew);
            stream.Write(file.Buffer, 0, file.Buffer.Length);
        }
        /// <summary>
        /// <see cref="BinaryFormatter"/>を用いたデータのセーブを行う
        /// </summary>
        /// <param name="path">セーブデータのパス</param>
        /// <param name="data">セーブされるデータ</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白又は値が不正</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>又は<paramref name="data"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>の値が不正</exception>
        /// <exception cref="IOException">I/Oエラーが発生した又はストリームが閉じられている</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>が非ファイルデバイスを参照している</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定長を超えている</exception>
        /// <exception cref="SecurityException">呼び出し元に必要なアクセス許可がない</exception>
        /// <exception cref="SerializationException"><paramref name="data"/>がシリアル可能としてマークされていない</exception>
        public static void WriteBinary<T>(string path, in T data)
        {
            var bf1 = new BinaryFormatter();
            using var fs1 = new FileStream(path, FileMode.Create);
            bf1.Serialize(fs1, data);
        }
        /// <summary>
        /// <see cref="BinaryFormatter"/>を用いたデータのセーブを行う
        /// </summary>
        /// <param name="path">セーブデータのパス</param>
        /// <param name="data">セーブされるデータ</param>
        /// <param name="surrogateSelector">シリアル化時に使用する<see cref="ISurrogateSelector"/>のインスタンス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白又は値が不正</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>又は<paramref name="data"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>の値が不正</exception>
        /// <exception cref="IOException">I/Oエラーが発生した又はストリームが閉じられている</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>が非ファイルデバイスを参照している</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定長を超えている</exception>
        /// <exception cref="SecurityException">呼び出し元に必要なアクセス許可がない</exception>
        /// <exception cref="SerializationException"><paramref name="data"/>がシリアル可能としてマークされていない</exception>
        public static void WriteBinary<T>(string path, in T data, ISurrogateSelector surrogateSelector)
        {
            var bf1 = new BinaryFormatter() { SurrogateSelector = surrogateSelector };
            using var fs1 = new FileStream(path, FileMode.Create);
            bf1.Serialize(fs1, data);
        }
        /// <summary>
        /// <see cref="BinaryFormatter"/>を用いたデータのロードを行う
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白又は値が不正</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>の値が不正</exception>
        /// <exception cref="FileNotFoundException">開くファイルが見つからない</exception>
        /// <exception cref="InvalidCastException">読み込んだデータを<typeparamref name="T"/>にキャストできない</exception>
        /// <exception cref="IOException">I/Oエラーが発生した又はストリームが閉じられている</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>が非ファイルデバイスを参照している</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定長を超えている</exception>
        /// <exception cref="SecurityException">呼び出し元に必要なアクセス許可がない</exception>
        /// <exception cref="SerializationException">データの長さが0</exception>
        /// <returns>読み込まれたデータ</returns>
        public static T ReadBinary<T>(string path)
        {
            var bf2 = new BinaryFormatter();
            using var fs2 = new FileStream(path, FileMode.Open);
            return (T)bf2.Deserialize(fs2);
        }
        /// <summary>
        /// <see cref="BinaryFormatter"/>を用いたデータのロードを行う
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <param name="surrogateSelector">シリアル化時に使用する<see cref="ISurrogateSelector"/>のインスタンス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白又は値が不正</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>の値が不正</exception>
        /// <exception cref="FileNotFoundException">開くファイルが見つからない</exception>
        /// <exception cref="InvalidCastException">読み込んだデータを<typeparamref name="T"/>にキャストできない</exception>
        /// <exception cref="IOException">I/Oエラーが発生した又はストリームが閉じられている</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>が非ファイルデバイスを参照している</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が指定長を超えている</exception>
        /// <exception cref="SecurityException">呼び出し元に必要なアクセス許可がない</exception>
        /// <exception cref="SerializationException">データの長さが0</exception>
        /// <returns>読み込まれたデータ</returns>
        public static T ReadBinary<T>(string path, ISurrogateSelector surrogateSelector)
        {
            var bf2 = new BinaryFormatter() { SurrogateSelector = surrogateSelector };
            using var fs2 = new FileStream(path, FileMode.Open);
            return (T)bf2.Deserialize(fs2);
        }
        /// <summary>
        /// <see cref="XmlSerializer"/>を用いたデータのセーブを行う
        /// </summary>
        /// <param name="path">保存するパス</param>
        /// <param name="data">保存するデータ</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみで形成されている またはファイル特定の拡張子が使用されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>のディレクトリが見つからない</exception>
        /// <exception cref="InvalidOperationException">xmlの書き込み失敗</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>の拡張子がサポートされていない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセス許可がない</exception>
        public static void WriteXML<T>(string path, in T data)
        {
            var xml = new XmlSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.Create);
            xml.Serialize(stream, data);
        }
        /// <summary>
        /// <see cref="XmlSerializer"/>を用いたデータのセーブを行う
        /// </summary>
        /// <param name="path">保存するパス</param>
        /// <param name="data">保存するデータ</param>
        /// <param name="types">シリアル化する為の他の要素の型の配列</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみで形成されている またはファイル特定の拡張子が使用されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>のディレクトリが見つからない</exception>
        /// <exception cref="InvalidOperationException">xmlの書き込み失敗</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>の拡張子がサポートされていない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセス許可がない</exception>
        public static void WriteXML<T>(string path, in T data, Type[] types)
        {
            var xml = new XmlSerializer(typeof(T), types);
            using var stream = new FileStream(path, FileMode.Create);
            xml.Serialize(stream, data);
        }
        /// <summary>
        /// <see cref="XmlSerializer"/>を用いたデータのロードを行う
        /// </summary>
        /// <param name="path">読み込むデータのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字のみで形成されている またはファイル特定の拡張子が使用されている</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>のディレクトリが見つからない</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="InvalidCastException">読み込んだデータを<typeparamref name="T"/>にキャストできない</exception>
        /// <exception cref="InvalidOperationException">xmlの読み込み失敗</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>の拡張子がサポートされていない</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセス許可がない</exception>
        /// <returns>読み込まれたデータ</returns>
        public static T ReadXML<T>(string path)
        {
            var xml = new XmlSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.Open);
            return (T)xml.Deserialize(stream);
        }
        /// <summary>
        /// <see cref="FileStream"/>を用いてファイルを読み込み<see cref="byte"/>配列を取得する
        /// </summary>
        /// <param name="path">開くファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字からなるまたは特定の拡張子を持つ</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>で指定されたディレクトリが存在しない</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルパスが存在しない</exception>
        /// <exception cref="IOException">I/O上のエラー</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>で指定されたファイルが特定の拡張子を持つ</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセスが拒否された</exception>
        /// <returns>読み込んだファイルのデータ</returns>
        public static byte[] ReadBufferS(string path)
        {
            using var stream = new FileStream(path, FileMode.Open);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        /// <summary>
        /// <see cref="StaticFile"/>を用いてファイルを読み込み<see cref="byte"/>配列を取得する
        /// </summary>
        /// <param name="path">開くファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字からなる</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="IOException">ファイルの読み込みに失敗した</exception>
        /// <returns>開かれたファイルのデータ</returns>
        public static byte[] ReadBufferA(string path)
        {
            if (path == null) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            return Engine.File.CreateStaticFile(path).Buffer ?? throw new IOException();
        }
        /// <summary>
        /// <see cref="FileStream"/>を用いて<see cref="byte"/>配列のデータをファイルに書き込む
        /// </summary>
        /// <param name="path">開くファイルのパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空白文字からなるまたは特定の拡張子を持つ</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="buffer"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>で指定されたディレクトリが存在しない</exception>
        /// <exception cref="IOException">I/O上のエラー</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>で指定されたファイルが特定の拡張子を持つ</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="SecurityException">アクセスが拒否された</exception>
        /// <returns>読み込んだファイルのデータ</returns>
        public static void WriteBuffer(string path, byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException();
            using var stream = new FileStream(path, FileMode.Create);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}