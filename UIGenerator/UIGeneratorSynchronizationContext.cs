using System;
using System.Collections.Concurrent;
using System.Threading;
using fslib;

namespace UIGenerator
{
    /// <summary>
    /// 非同期処理をサポートするコンテキストのクラス
    /// </summary>
    public sealed class UIGeneratorSynchronizationContext : SynchronizationContext
    {
        /// <summary>
        /// <see cref="concurrentQueue"/>に登録されるオブジェクト
        /// </summary>
        private struct QueueEntry
        {
            /// <summary>
            /// <see cref="Update"/>にて実行される処理
            /// </summary>
            public SendOrPostCallback SendOrPostCallback { get; }
            /// <summary>
            /// <see cref="SendOrPostCallback"/>に渡されるオブジェクト
            /// </summary>
            public object State { get; }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="d">処理を委譲する<see cref="System.Threading.SendOrPostCallback"/>のインスタンス</param>
            /// <param name="state"><paramref name="d"/>に渡されるオブジェクト</param>
            public QueueEntry(SendOrPostCallback d, object state)
            {
                SendOrPostCallback = d;
                State = state;
            }
            /// <summary>
            /// <see cref="SendOrPostCallback"/>の処理を実行する
            /// </summary>
            public void Invoke() => SendOrPostCallback.Invoke(State);
        }
        /// <summary>
        /// アクション実行を通知するかどうかを取得または設定する
        /// </summary>
        public bool OutPutMessage { get; set; }
        /// <summary>
        /// 処理を格納するスレッドセーフなキュー
        /// </summary>
        private ConcurrentQueue<QueueEntry> concurrentQueue;
        /// <summary>
        /// 非同期処理を委譲する
        /// </summary>
        /// <param name="d">実行される処理</param>
        /// <param name="state"><paramref name="d"/>に渡されるオブジェクト</param>
        /// <exception cref="ArgumentNullException"><paramref name="d"/>がnull</exception>
        public override void Post(SendOrPostCallback d, object state)
        {
            Central.ThrowHelper.ThrowArgumentNullException(null, d);
            if (concurrentQueue == null) Interlocked.CompareExchange(ref concurrentQueue, new ConcurrentQueue<QueueEntry>(), null);
            concurrentQueue.Enqueue(new QueueEntry(d, state));
        }
        /// <summary>
        /// 登録されたアクションを実行する
        /// </summary>
        public void Update()
        {
            if (concurrentQueue == null) return;
            while (concurrentQueue.TryDequeue(out var result))
            {
                result.Invoke();
                if (OutPutMessage) Console.WriteLine("Done:{0}", result);
            }
        }
    }
}
