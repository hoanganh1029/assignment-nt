namespace Asynchronous.CookingService.CookingAsyncServices
{
    internal class CookingByTasksAsyncService : CookingAsyncServiceBase
    {
        public CookingByTasksAsyncService()
        {
            CookingType = "ByTasksAsync";
        }

        public override async Task CookDetailAsync()
        {
            var taskNauCom = NauComAsync();
            var taskLuocRau = LuocRauAsync();
            var taskRangThit = RangThitAsync();

            WriteLogWithTime($"Do something else in {CookingType}");

            await taskNauCom;
            await taskLuocRau;
            await taskRangThit;

        }
    }
}
