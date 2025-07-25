using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Shared
{
    public class Counter
    {
        private int _count = 0;
        private readonly object _lock = new();

        public void Increment()
        {
            Console.WriteLine($"[Counter] Waiting to enter lock (Thread {Thread.CurrentThread.ManagedThreadId})");
            lock (_lock)
            {
                Console.WriteLine($"[Counter] Inside lock (Thread {Thread.CurrentThread.ManagedThreadId})");
                _count++;
                Thread.Sleep(300); // Simulate delay while holding lock
                Console.WriteLine($"[Counter] Incremented count to {_count}");
            }
        }


        public int GetCount()
        {
            lock (_lock)
            {
                return _count;
            }
        }
    }
}
