using AsynchronousProgramming.Constants;
using AsynchronousProgramming.Models;
using System.Diagnostics;

namespace AsynchronousProgramming.CookingService.CookingAsyncServices
{
    internal class CookingAsyncServiceBase : CookingBase
    {
        public async Task CookAsync()
        {
            ShowThreadInformation();

            var sw = new Stopwatch();

            sw.Start();
            await CookDetailAsync();
            sw.Stop();

            WriteLogWithTime($"Done {CookingType}: {sw.Elapsed.TotalSeconds} seconds", true);
        }

        public virtual async Task CookDetailAsync()
        {
            await Task.CompletedTask;
        }

        protected async Task NauComAsync()
        {
            WriteLogWithTime("Vo Gạo, Đổ nước.");

            WriteLogWithTime("Cắm điện, bật nút");
            await Task.Delay(CookingTime.Com);

            WriteLogWithTime("Done - Cắm cơm");
        }

        protected async Task LuocRauAsync()
        {
            var rauSach = await NhatRauAsync();

            WriteLogWithTime("Đun nước");
            await Task.Delay(CookingTime.Rau);

            WriteLogWithTime($"Thả rau {rauSach.Name}");
            await Task.Delay(CookingTime.Rau);

            WriteLogWithTime("Done - Luộc Rau");
        }

        protected async Task<RauSach> NhatRauAsync()
        {
            WriteLogWithTime("Nhat Rau");

            return await Task.Run(async () =>
            {
                await Task.Delay(CookingTime.Rau);
                return new RauSach { Name = "Dền" };
            });
        }

        protected async Task RangThitAsync()
        {
            WriteLogWithTime("Rang thịt");
            await Task.Delay(CookingTime.Thit);

            WriteLogWithTime("Done - Rang thịt");
        }
    }
}
