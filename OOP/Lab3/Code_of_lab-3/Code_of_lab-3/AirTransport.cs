using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public class AirTransport : Transport
    {
        public Dictionary<int, int> DistanceReducer { get; protected set; } = new Dictionary<int, int>();
        public AirTransport(double speed, Dictionary<int, int> DistanceReducer) : base(speed)
        {
            this.DistanceReducer = DistanceReducer;
        }
        public override double get_total_race_time(double distance)
        {
            return 1;
        }
    }
}
