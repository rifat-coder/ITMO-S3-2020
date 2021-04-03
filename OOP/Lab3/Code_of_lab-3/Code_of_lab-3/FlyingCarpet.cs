using System;
namespace Code_of_lab_3
{
    public class FlyingCarpet : AirTransportsRace
    {
        public FlyingCarpet(string name, int speed)
                : base(name, speed)
        {}
        public override double distance_reducer(double distance)
        {
            if      (distance < 1000)   return distance;
            else if (distance < 5000)   return (distance * (1 - 0.03));
            else if (distance < 10000)  return (distance * (1 - 0.1));
            else                        return (distance * (1 - 0.05));
        }
    }
}
