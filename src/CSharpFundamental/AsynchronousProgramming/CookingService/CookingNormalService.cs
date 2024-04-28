using AsynchronousProgramming.Constants;
using AsynchronousProgramming.Models;
using System.Diagnostics;

namespace AsynchronousProgramming.CookingService
{
    internal class CookingNormalService : CookingBase
    {
        public CookingNormalService()
        {
            this.CookingType = "Normal";
        }

        public void CookNormal()
        {
            var sw = new Stopwatch();
            sw.Start();

            NauCom();
            LuocRau();
            RangThit();

            sw.Stop();
            WriteLogWithTime($"Done CookNormal: {sw.Elapsed.TotalSeconds} seconds", true);
        }

        private void NauCom()
        {
            WriteLogWithTime("Vo Gạo, Đổ nước.");

            WriteLogWithTime("Cắm điện, bật nút");
            Task.Delay(CookingTime.Com).Wait();

            WriteLogWithTime("Done - Cắm cơm");
        }

        private void LuocRau()
        {
            var rauSach = NhatRau();

            WriteLogWithTime("Đun nước");
            Task.Delay(CookingTime.Rau).Wait();

            WriteLogWithTime($"Thả rau {rauSach.Name}");
            Task.Delay(CookingTime.Rau).Wait();

            WriteLogWithTime("Done - Luộc Rau");
        }

        private RauSach NhatRau()
        {
            WriteLogWithTime("Nhặt Rau");
            Task.Delay(CookingTime.Rau).Wait();
            return new RauSach { Name = "Dền" };
        }

        private void RangThit()
        {
            WriteLogWithTime("Rang Thit");
            Task.Delay(CookingTime.Thit).Wait();
        }
    }
}
