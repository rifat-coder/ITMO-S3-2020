using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public abstract class AirTransportsRace : Transport
    {
        public AirTransportsRace(string name, int speed)
                : base(name, speed)
        {}
        public abstract double distance_reducer(double distance);
        public override double amount_time(double distance)
        {
            double amount_time = distance_reducer(distance) / speed;
            return amount_time;
        }
    }
}
