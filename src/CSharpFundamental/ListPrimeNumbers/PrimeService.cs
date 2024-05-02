namespace ListPrimeNumbers
{
    internal static class PrimeService
    {
        public static async Task<IEnumerable<int>> GetPrimesAsync(int start, int end)
        {            
            return await Task.Run(() =>
            {
                var primes = new List<int>();
                for (int i = start; i <= end; i++)
                {
                    if (IsPrime(i))
                        primes.Add(i);
                }
                return primes;
            });
        }

        public static IEnumerable<int> GetPrimes(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                    yield return i;
            }
        }

        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
