using Task2.Services;
using Task2.Shared;

var fetcher = new DataFetcher();
var processor = new Processor();
var saver = new FileSaver();
var logger = new Logger();
var monitor = new BackgroundMonitor();
var counter = new Counter();

monitor.StartMonitoring(); // Run in background

// Simulate fetching from 3 sources
var sources = new[] { "API_1", "API_2", "API_3" };

var fetchTasks = sources.Select(source => fetcher.FetchDataAsync(source)).ToArray();
var fetchedData = await Task.WhenAll(fetchTasks); // TPL Parallel

var processingTasks = fetchedData.Select(data => Task.Run(() =>
{
    processor.ProcessData(data);
    counter.Increment(); // Thread-safe
    logger.Log("Data processed");
})).ToArray();

await Task.WhenAll(processingTasks);

Console.WriteLine("All processing threads finished. Waiting briefly...");
await Task.Delay(2000); // give logger and counter time to finish


// Save to file one by one
foreach (var data in fetchedData)
{
    await saver.SaveToFileAsync(data);
}

Console.WriteLine($"\nAll done. Processed count: {counter.GetCount()}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();