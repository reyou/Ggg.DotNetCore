using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTasksSample.Services.Singletons
{
    #region snippet1

    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private ConcurrentQueue<Func<CancellationToken, Task>> _workItems =
            new ConcurrentQueue<Func<CancellationToken, Task>>();
        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void QueueBackgroundWorkItem(
            Func<CancellationToken, Task> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            _workItems.Enqueue(workItem);
            _signal.Release();
        }

        public async Task<Func<CancellationToken, Task>> DequeueAsync(
            CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);
            _workItems.TryDequeue(out Func<CancellationToken, Task> workItem);

            return workItem;
        }
    }
    #endregion
}
