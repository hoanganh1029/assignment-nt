namespace AsynchronousProgramming.CookingService
{
    internal abstract class CookingBase
    {
        protected string CookingType = string.Empty;

        protected void WriteLogWithTime(string message, bool isFinal = false)
        {
            Console.ForegroundColor = isFinal ? ConsoleColor.Blue : ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss} - {CookingType}] {message}");
            Console.ResetColor();
        }

        private static readonly Object lockObj = new();
        protected void ShowThreadInformation()
        {
            var msg = string.Empty;
            Thread thread = Thread.CurrentThread;
            lock (lockObj)
            {
                msg = String.Format("{0} thread information\n", CookingType) +
                      String.Format("   Background: {0}\n", thread.IsBackground) +
                      String.Format("   Thread Pool: {0}\n", thread.IsThreadPoolThread) +
                      String.Format("   Thread ID: {0}\n", thread.ManagedThreadId);
            }
            Console.WriteLine(msg);
        }
    }
}
