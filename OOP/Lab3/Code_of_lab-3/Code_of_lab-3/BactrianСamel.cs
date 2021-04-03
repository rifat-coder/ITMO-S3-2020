using System;
namespace Code_of_lab_3
{
    public class BactrianСamel : LandTransportsRace
    {
        public BactrianСamel(string name, int speed, int rest)
            : base(name, speed, rest)
        {}
        public override double rest_duration(int count)
        {
            if (count == 1) return 5;
            else            return 8;
        }
    }
}
