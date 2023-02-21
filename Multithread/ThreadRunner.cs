using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithread
{
    internal class ThreadRunner
    {
        private static List<Thread> _threads = new List<Thread>();

        public static void Run(ThreadStart threadStart)
        {
            var thread = new Thread(threadStart);
            _threads.Add(thread);
            thread.Start();
        }

        public static void JoinAll()
        {
            foreach (var thread in _threads)
            {
                thread.Join();
            }
        }
    }
}
