using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Services
{
    public class FileSaver
    {
        private readonly string _filePath = "result.txt";

        public async Task SaveToFileAsync(string content)
        {
            await File.AppendAllTextAsync(_filePath, content + Environment.NewLine);
            Console.WriteLine("Saved to file.");
        }
    }
}
