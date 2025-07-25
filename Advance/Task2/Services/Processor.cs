using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services
{
    public class Processor
    {
        public void ProcessData(string data)
        {
            Console.WriteLine($"[Processor] Starting processing: \"{data}\" on Thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1500); // Simulate processing delay
            Console.WriteLine($"[Processor] Finished processing: \"{data}\"");
        }
    }
}
