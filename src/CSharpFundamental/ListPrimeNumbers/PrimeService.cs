namespace ListPrimeNumbers
{
    internal static class PrimeService
    {
        public static async Task<List<int>> GetPrimesAsync(int start, int end)
        {
            List<int> primes = new();
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }
            return await Task.FromResult(primes);
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
