using System;
namespace Code_of_lab_3
{
    public class SpeedСamel : LandTransportsRace
    {
        public SpeedСamel(string name, int speed, int rest)
                : base(name, speed, rest)
        {}

        public override double rest_duration(int count)
        {
            if      (count == 1) return 5;
            else if (count == 2) return 6.5;
            else                 return 8;
        }
    }
}
