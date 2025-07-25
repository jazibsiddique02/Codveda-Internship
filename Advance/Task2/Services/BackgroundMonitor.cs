using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services
{
    public class BackgroundMonitor
    {
        private readonly BackgroundWorker _worker = new();

        public BackgroundMonitor()
        {
            _worker.DoWork += (s, e) =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"[Monitor] Monitoring... {i}/5");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("[Monitor] Monitoring completed.");
            };
        }

        public void StartMonitoring()
        {
            _worker.RunWorkerAsync();
        }
    }
}
