using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public class RaceForLand : Race<LandTransportsRace>
    {
        public RaceForLand(double distance, List<LandTransportsRace> transports)
                : base(distance, transports) { }
    }
}
