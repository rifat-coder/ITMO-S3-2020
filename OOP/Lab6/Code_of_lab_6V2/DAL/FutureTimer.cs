using System;
namespace DAL
{
    public class FutuTime
    {
        public DateTime Time { get; set; }

        public FutuTime()
        {
            Time = DateTime.Now;
        }

        public void NextMonth()
        {
            Time = Time.AddMonths(1);
        }

        public void NextDay()
        {
            Time = Time.AddDays(1);
        }
    }
}
