using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public class RaceForAll : Race<Transport>
    {
        public RaceForAll(double distance, List<Transport> transports)
                : base(distance, transports) { }
    }
}
