namespace Asynchronous.CookingService.CookingAsyncServices
{
    internal class CookingConcurrentlyAsyncService : CookingAsyncServiceBase
    {
        public CookingConcurrentlyAsyncService() {
            CookingType = "ConcurrentlyAsync";
        }

        public override async Task CookDetailAsync()
        {
            var taskNauCom = NauComAsync();
            var taskLuocRau = LuocRauAsync();
            var taskRangThit = RangThitAsync();

            WriteLogWithTime($"Do something else in {CookingType}");

            await Task.WhenAll(taskNauCom, taskLuocRau, taskRangThit);            
        }
    }
}
