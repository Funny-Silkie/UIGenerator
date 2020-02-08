using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using asd;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// byte配列を用いてデータをシリアライズするクラス
    /// </summary>
    [Serializable]
    public class PackagedFile : ICloneable, IDisposable, IEquatable<PackagedFile>, ISerializable, IDeserializationCallback
    {
        #region SerializeName
        private const string S_Buffer = "S_Buffer";
        private const string S_Path = "S_Path";
        #endregion
        /// <summary>
        /// フォントデータを取得する
        /// </summary>
        public byte[] Buffer
        {
            get
            {
                ThrowIfDisposed();
                return buffer;
            }
            private set
            {
                ThrowIfDisposed();
                buffer = value;
            }
        }
        private byte[] buffer;
        /// <summary>
        /// このオブジェクトが破棄されたかどうかを取得する
        /// </summary>
        public bool IsDisposed { get; private set; } = false;
        /// <summary>
        /// ファイルパスを取得または設定する
        /// </summary>
        public string Path
        {
            get
            {
                ThrowIfDisposed();
                return path;
            }
            private set
            {
                ThrowIfDisposed();
                path = value;
            }
        }
        private string path;
        /// <summary>
        /// デシリアライズ時に渡されるデータを取得する
        /// </summary>
        /// <remarks>デシリアライズ終了時にnullが代入される</remarks>
        protected SerializationInfo SeInfo { get; private set; }
        /// <summary>
        /// 指定したパスからデータを読み込んでインスタンスを初期化する
        /// </summary>
        /// <param name="path">読み込むファイルのパス</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/>で指定されたファイルが見つからない</exception>
        /// <exception cref="IOException">ファイルが読み込めなかった</exception>
        public PackagedFile(string path)
        {
            Path = path ?? throw new ArgumentNullException();
            if (!Engine.File.Exists(path)) throw new FileNotFoundException();
            Buffer = Engine.File.CreateStaticFile(path)?.Buffer ?? throw new IOException();
        }
        /// <summary>
        /// byte配列とファイルパスからインスタンスを初期化する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="buffer">ファイルのデータ</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>または<paramref name="buffer"/>がnull</exception>
        public PackagedFile(string path, byte[] buffer)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, path, buffer);
            Path = path;
            Buffer = buffer;
        }
        /// <summary>
        /// 指定した<see cref="StaticFile"/>からインスタンスを初期化する
        /// </summary>
        /// <param name="file">初期化に使用する<see cref="StaticFile"/>のインスタンス</param>
        /// <exception cref="ArgumentException"><paramref name="file"/>の要素がnull</exception>
        /// <exception cref="ArgumentNullException"><paramref name="file"/>がnull</exception>
        public PackagedFile(StaticFile file)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, file);
            Path = file.FullPath ?? throw new ArgumentException();
            Buffer = file.Buffer ?? throw new ArgumentException();
        }
        /// <summary>
        /// シリアライズされたデータを用いてインスタンスを初期化する
        /// </summary>
        /// <param name="info">シリアライズされたデータを格納するオブジェクト</param>
        /// <param name="context">送信元の情報</param>
        protected PackagedFile(SerializationInfo info, StreamingContext context)
        {
            SeInfo = info;
        }
        /// <summary>
        /// このインスタンスの複製を作成する
        /// </summary>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        /// <returns>このインスタンスの複製</returns>
        public virtual PackagedFile Clone()
        {
            ThrowIfDisposed();
            return new PackagedFile(Path, Buffer);
        }
        object ICloneable.Clone() => Clone();
        /// <summary>
        /// 指定した2つの<see cref="PackagedFile"/>の同一性を検証する
        /// </summary>
        /// <param name="f1">同一性を確かめる<see cref="PackagedFile"/>のインスタンス</param>
        /// <param name="f2">同一性を確かめる<see cref="PackagedFile"/>のもう一つのインスタンス</param>
        /// <returns>同一性が見られたときはtrue，それ以外でfalse</returns>
        /// <remarks>どちらかがullだったとき破棄されていた場合は即falseを返す</remarks>
        public static bool Equals(PackagedFile f1, PackagedFile f2) => f1 is null ? false : f1.Equals(f2);
        /// <summary>
        /// もう1つの<see cref="PackagedFile"/>との同値性を判定する
        /// </summary>
        /// <param name="other">同値性を判定するもう一つの<see cref="PackagedFile"/>のインスタンス</param>
        /// <returns>このインスタンスと<paramref name="other"/>が同値だったらtrue，それ以外でfalse</returns>
        /// <remarks>このインスタンス又は<paramref name="other"/>が破棄されている場合無条件でfalseを返す</remarks>
        public virtual bool Equals(PackagedFile other)
        {
            if (other is null || IsDisposed || other.IsDisposed) return false;
            return GetType() == other.GetType() && Path == other.Path && Buffer.SequenceEqual(other.Buffer);
        }
        /// <summary>
        /// 指定したオブジェクトとの等価性を判定する
        /// </summary>
        /// <param name="obj">等価性を比較するオブジェクト</param>
        /// <returns><paramref name="obj"/>との間に等価性が認められたらtrue，それ以外でfalse</returns>
        public override bool Equals(object obj) => obj is PackagedFile f ? Equals(f) : false;
        /// <summary>
        /// ハッシュコードを取得する
        /// </summary>
        /// <returns>このオブジェクトのハッシュコード</returns>
        public override int GetHashCode() => path.GetHashCode() ^ Buffer.Length;
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        protected virtual void GetObjectData(SerializationInfo info)
        {
            if (info == null) throw new ArgumentNullException();
            ThrowIfDisposed();
            info.AddValue(S_Path, Path ?? throw new SerializationException());
            info.AddValue(S_Buffer, Buffer ?? throw new SerializationException());
        }
        /// <summary>
        /// シリアライズするデータを設定する
        /// </summary>
        /// <param name="info">シリアライズするデータを格納するオブジェクト</param>
        /// <param name="context">送信先の情報</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/>がnull</exception>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => GetObjectData(info);
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        protected virtual void OnDeserialization()
        {
            if (SeInfo == null) return;
            Path = SeInfo.GetString(S_Path);
            Buffer = SeInfo.GetValue<byte[]>(S_Buffer);
            SeInfo = null;
        }
        /// <summary>
        /// デシリアライズ時に実行
        /// </summary>
        /// <param name="sender">現在はサポートされていない 常にnullを返す</param>
        void IDeserializationCallback.OnDeserialization(object sender) => OnDeserialization();
        /// <summary>
        /// このインスタンスを破棄する
        /// </summary>
        /// <param name="disposing">マネージソースも破棄するかどうか</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    Buffer = null;
                    Path = null;
                }
                IsDisposed = true;
            }
        }
        /// <summary>
        /// このインスタンスを破棄する
        /// </summary>
        public void Dispose() => Dispose(true);
        /// <summary>
        /// 指定したパスにデータを保存する
        /// </summary>
        /// <param name="path">保存するファイルパス</param>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        /// <exception cref="System.Security.SecurityException">アクセスが拒否された</exception>
        public void Save() => Save(Path);
        /// <summary>
        /// 指定したパスにデータを保存する
        /// </summary>
        /// <param name="path">保存するファイルパス</param>
        /// <exception cref="ArgumentException"><paramref name="path"/>が空文字や特定の拡張子を持つ</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>がnull</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/>のディレクトリが存在しない</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/>が特定の拡張子を持つ</exception>
        /// <exception cref="ObjectDisposedException">このインスタンスが破棄されている</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/>が長すぎる</exception>
        /// <exception cref="System.Security.SecurityException">アクセスが拒否された</exception>
        public void Save(string path)
        {
            ThrowIfDisposed();
            using var stream = new FileStream(path, FileMode.Create);
            stream.Write(Buffer, 0, Buffer.Length);
        }
        /// <summary>
        /// このインスタンスが破棄されているときに<see cref="ObjectDisposedException"/>をスローする
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (IsDisposed) throw new ObjectDisposedException(GetType().ToString());
        }
        public static bool operator ==(PackagedFile f1, PackagedFile f2) => Equals(f1, f2);
        public static bool operator !=(PackagedFile f1, PackagedFile f2) => !Equals(f1, f2);
    }
}
