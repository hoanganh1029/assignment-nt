using AsynchronousProgramming.CookingService;
using AsynchronousProgramming.CookingService.CookingAsyncServices;
using SystemTimer = System.Timers;

namespace Asynchronous;
class Program
{

    static int _counter = 0;
    static async Task Main(string[] args)
    {
        var cookingNormalService = new CookingNormalService();
        var cookingNormalAsyncService = new CookingNormalAsyncService();
        var cookingByTasksAsyncService = new CookingByTasksAsyncService();
        var cookingConcurrentlyAsyncService = new CookingConcurrentlyAsyncService();

        //cookingNormalService.CookNormal();
        var taskCookNormal = Task.Run(() =>
        {
            cookingNormalService.CookNormal();
        });

        var taskCookNormalAsync = cookingNormalAsyncService.CookAsync();
        var taskCookByTaskAsync = cookingByTasksAsyncService.CookAsync();
        var taskCookConcurrentlyAsync = cookingConcurrentlyAsyncService.CookAsync();

        await taskCookNormalAsync;
        await taskCookByTaskAsync;
        await taskCookConcurrentlyAsync;

        //await Task.WhenAll(taskCookNormalAsync, taskCookByTaskAsync, taskCookConcurrentlyAsync);
        
        SystemTimer.Timer myTimer = new(5000);
        myTimer.Elapsed += RunTimer;
        myTimer.Enabled = true;
    }

    static void RunTimer(object source, SystemTimer.ElapsedEventArgs e)
    {
        _counter++;
        Console.WriteLine("Run Timer");
    }
}
