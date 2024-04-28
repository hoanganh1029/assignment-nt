namespace AsynchronousProgramming.CookingService.CookingAsyncServices
{
    internal class CookingNormalAsyncService : CookingAsyncServiceBase
    {
        public CookingNormalAsyncService()
        {
            CookingType = "NormalAsync";
        }

        public override async Task CookDetailAsync()
        {
            await NauComAsync();
            await LuocRauAsync();
            await RangThitAsync();

            WriteLogWithTime($"Do something else in {CookingType}");
        }
    }
}
