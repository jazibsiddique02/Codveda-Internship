using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services
{
    public class Logger
    {
        public void Log(string message)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(200); // Simulate log delay
                Console.WriteLine($"[Logger] {message} (via ThreadPool Thread {Thread.CurrentThread.ManagedThreadId})");
            });
        }
    }
}
