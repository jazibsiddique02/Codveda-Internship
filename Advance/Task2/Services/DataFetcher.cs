using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services
{
    public class DataFetcher
    {
        public async Task<string> FetchDataAsync(string sourceName)
        {
            Console.WriteLine($"Fetching from {sourceName}...");
            await Task.Delay(1000); // Simulate delay
            return $"Data from {sourceName} at {DateTime.Now}";
        }
    }
}
