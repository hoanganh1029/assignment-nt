using System.Diagnostics;

namespace ListPrimeNumbers;
class Program
{       
    static async Task Main(string[] args)
    {
        int startNumber = 0;
        int batchSize = 10;

        while (true)
        {
            Console.Write("Enter maximum number: ");
            if (!int.TryParse(Console.ReadLine(), out var endNumber))
            {
                Console.WriteLine("Invalid number" + Environment.NewLine);
                continue;
            }

            Console.Write("Enter batch size: ");
            if (!int.TryParse(Console.ReadLine(), out batchSize))
            {
                Console.WriteLine("Invalid number" + Environment.NewLine);
                continue;
            }

            var sw = new Stopwatch();            
            
            //Async
            sw.Start();
            List<Task<List<int>>> tasks = new();
            for (int i = startNumber; i <= endNumber; i += batchSize)
            {
                int chunkEnd = Math.Min(i + batchSize - 1, endNumber);
                tasks.Add(PrimeService.GetPrimesAsync(i, chunkEnd));
            }
            
            var primeLists = await Task.WhenAll(tasks);

            sw.Stop();
            
            var asyncPrimes = primeLists.SelectMany(p => p);
 
            Console.WriteLine($"[Async] {asyncPrimes.Count()} Prime numbers between {startNumber} and {endNumber} in {sw.Elapsed.TotalMilliseconds}: {string.Join(", ", asyncPrimes)}");

            //Sync
            sw.Restart();
            var syncPrimes = new List<int>();
            for (int i = startNumber; i <= endNumber; i += batchSize)
            {
                int chunkEnd = Math.Min(i + batchSize - 1, endNumber);
                syncPrimes.AddRange(PrimeService.GetPrimes(i, chunkEnd));
            }
            // Output the prime numbers
            Console.WriteLine($"[Sync] {syncPrimes.Count} Prime numbers between {startNumber} and {endNumber} in {sw.Elapsed.TotalMilliseconds}: {string.Join(", ", syncPrimes)}");


        }
    }
}
