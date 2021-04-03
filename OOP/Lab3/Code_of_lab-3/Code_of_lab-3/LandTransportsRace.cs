using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public abstract class LandTransportsRace : Transport
    {
        public int rest_interval { get; private set; }
        public LandTransportsRace(string name, int speed, int restInterval)
                    : base(name, speed) => rest_interval = restInterval;
        public abstract double rest_duration(int count);
        public override double amount_time(double distance)
        {
            double time = distance / speed; double timeForChill = 0;
            for (int i = 1; i < distance / rest_interval; i++)
            {
                timeForChill += rest_duration(i);
            }
            return time + timeForChill;
        }
    }
}
