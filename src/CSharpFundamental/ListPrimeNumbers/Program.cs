using System.Diagnostics;

namespace ListPrimeNumbers;
class Program
{
    static async Task Main(string[] args)
    {
        int startNumber = 0;
        int batchSize = 10;
        bool isDisplayPrimeResult = false;

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

            Console.Write("Display list prime number result (y/n): ");
            var input = Console.ReadLine();
            isDisplayPrimeResult = (input ?? string.Empty).Equals("y", StringComparison.OrdinalIgnoreCase);

            var sw = new Stopwatch();

            //Async
            sw.Start();
            List<Task<IEnumerable<int>>> tasks = new();
            for (int i = startNumber; i <= endNumber; i += batchSize)
            {
                int batchEnd = Math.Min(i + batchSize - 1, endNumber);
                Console.WriteLine($"Batch info: begin {i}, end {batchEnd}");
                tasks.Add(PrimeService.GetPrimesAsync(i, batchEnd));
            }

            var primeLists = await Task.WhenAll(tasks);

            sw.Stop();

            var asyncPrimes = primeLists.SelectMany(p => p);
            var strListPrime = isDisplayPrimeResult ? string.Join(", ", asyncPrimes) : string.Empty;
            Console.WriteLine($"\n[Async] {asyncPrimes.Count()} prime numbers between {startNumber} and {endNumber} in {sw.Elapsed.TotalMilliseconds}ms \n {strListPrime}");

            //Sync
            sw.Restart();
            var syncPrimes = new List<int>();
            for (int i = startNumber; i <= endNumber; i += batchSize)
            {
                int chunkEnd = Math.Min(i + batchSize - 1, endNumber);
                syncPrimes.AddRange(PrimeService.GetPrimes(i, chunkEnd));
            }
            // Output the prime numbers
            strListPrime = isDisplayPrimeResult ? string.Join(", ", syncPrimes) : string.Empty;
            Console.WriteLine($"[Sync] {syncPrimes.Count} prime numbers between {startNumber} and {endNumber} in {sw.Elapsed.TotalMilliseconds}ms \n {strListPrime}");

            Console.WriteLine("====END====");
        }
    }
}
