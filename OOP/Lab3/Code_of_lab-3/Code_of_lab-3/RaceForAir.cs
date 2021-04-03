using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public class RaceForAir : Race<AirTransportsRace>
    {
        public RaceForAir(double distance, List<AirTransportsRace> transports)
                : base(distance, transports) { }
    }
}
