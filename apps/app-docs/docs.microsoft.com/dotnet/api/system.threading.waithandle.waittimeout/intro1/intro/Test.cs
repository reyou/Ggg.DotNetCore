using System;
using System.IO;
using System.Threading;

namespace intro
{
    static class Test
    {
        static void Main()
        {
            Search search = new Search();
            search.FindFile("SomeFile.dat");
            Console.WriteLine("main finished");
            Console.ReadLine();
        }
    }

    internal class Search
    {

        // Maintain state information to pass to FindCallback.
        class State
        {
            public AutoResetEvent autoEvent;
            public string fileName;

            /// <summary>
            /// AutoResetEvent Notifies a waiting thread that an event has occurred.
            /// This class cannot be inherited.
            /// </summary>
            /// <param name="autoEvent"></param>
            /// <param name="fileName"></param>
            public State(AutoResetEvent autoEvent, string fileName)
            {
                this.autoEvent = autoEvent;
                this.fileName = fileName;
            }
        }
        AutoResetEvent[] autoEvents;
        String[] diskLetters;
        public Search()
        {
            // Retrieve an array of disk letters.
            diskLetters = Environment.GetLogicalDrives();

            autoEvents = new AutoResetEvent[diskLetters.Length];
            for (int i = 0; i < diskLetters.Length; i++)
            {
                autoEvents[i] = new AutoResetEvent(false);
            }
        }
        /// <summary>
        /// Search for fileName in the root directory of all disks.
        /// </summary>
        /// <param name="somefileDat"></param>
        public void FindFile(string fileName)
        {
            for (int i = 0; i < diskLetters.Length; i++)
            {
                Console.WriteLine("Searching for {0} on {1}.", fileName, diskLetters[i]);
                // ThreadPool Provides a pool of threads that can be used to execute tasks,
                // post work items, process asynchronous I/O, wait on behalf of
                // other threads, and process timers
                // QueueUserWorkItem Queues a method for execution, and specifies an object
                // containing data to be used by the method. The method executes when a thread
                // pool thread becomes available
                object stateq = new State(autoEvents[i], diskLetters[i] + fileName);
                ThreadPool.QueueUserWorkItem(FindCallback, state: stateq);
            }
            // Wait for the first instance of the file to be found.
            // WaitHandle Encapsulates operating system–specific objects that wait for
            // exclusive access to shared resources
            // Waits for any of the elements in the specified array to receive a signal,
            // using a 32-bit signed integer to specify the time interval, and specifying
            // exitContext whether to exit the synchronization domain before the wait
            // true to exit the synchronization domain for the context before
            // the wait (if in a synchronized context), and reacquire it afterward; otherwise, false
            // returns The array index of the object that satisfied the wait, or
            // <see cref="System.Threading.WaitHandle.WaitTimeout"></see> if no object satisfied the
            // wait and a time interval equivalent to <paramref name="millisecondsTimeout">millisecondsTimeout</paramref>
            // has passed
            int index = WaitHandle.WaitAny(autoEvents, 3000, false);
            Console.WriteLine("WaitHandle index: {0}", index);
            if (index == WaitHandle.WaitTimeout)
            {
                Console.WriteLine("\n{0} not found.", fileName);
            }
            else
            {
                Console.WriteLine("\n{0} found on {1}.", fileName, diskLetters[index]);
            }

        }

        // Search for stateInfo.fileName.
        void FindCallback(object state)
        {
            State stateInfo = (State)state;
            Console.WriteLine("FindCallback called. ThreadId: {0} fileName: {1}",
                Thread.CurrentThread.ManagedThreadId, stateInfo.fileName);
            // Signal if the file is found.
            if (File.Exists(stateInfo.fileName))
            {
                // Sets the state of the event to signaled,
                // allowing one or more waiting threads to proceed
                stateInfo.autoEvent.Set();
            }
        }
    }
}
