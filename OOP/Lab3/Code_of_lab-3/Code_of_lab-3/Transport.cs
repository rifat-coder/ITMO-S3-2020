using System;
namespace Code_of_lab_3
{
    public class Transport
    {
        public double speed { get; protected set; }
        public Transport(double speed)
        {
            this.speed = speed;
        }
        public virtual double get_total_race_time(double distance) //чистый
        {
            return distance / speed;
        }
    }
}
