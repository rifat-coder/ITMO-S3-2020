using System;
namespace Code_of_lab_3
{
    public class Boots : LandTransportsRace
    {
        public Boots(string name, int speed, int rest)
                : base(name, speed, rest)
        {}
        public override double rest_duration(int count)
        {
            if (count == 1) return 10;
            else            return 5;
        }
    }
}
