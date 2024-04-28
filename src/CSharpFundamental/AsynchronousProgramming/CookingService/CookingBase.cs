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
        private static void ShowThreadInformation(string taskName)
        {
            var msg = string.Empty;
            Thread thread = Thread.CurrentThread;
            lock (lockObj)
            {
                msg = String.Format("{0} thread information\n", taskName) +
                      String.Format("   Background: {0}\n", thread.IsBackground) +
                      String.Format("   Thread Pool: {0}\n", thread.IsThreadPoolThread) +
                      String.Format("   Thread ID: {0}\n", thread.ManagedThreadId);
            }
            Console.WriteLine(msg);
        }
    }
}
