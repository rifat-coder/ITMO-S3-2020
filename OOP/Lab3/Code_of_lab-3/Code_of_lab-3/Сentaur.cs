using System;
namespace Code_of_lab_3
{
    public class Centaur : LandTransportsRace
    {
        public Centaur(string name, int speed, int rest)
                : base(name, speed, rest)
        {}
        public override double rest_duration(int count)
                { return 2; }
    }
}
