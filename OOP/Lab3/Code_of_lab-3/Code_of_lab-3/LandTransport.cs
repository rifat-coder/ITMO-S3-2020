using System;
using System.Collections.Generic;

namespace Code_of_lab_3
{
    public class LandTransport : Transport
    {
        public double RestInterval { get; protected set; }
        public Dictionary<int, double> StepRestDuration { get; private set; } = new Dictionary<int, double>(); // array
        public LandTransport(double speed, double RestInterval, Dictionary<int, double> StepRestDuration) : base(speed)
        {
            this.RestInterval = RestInterval;
            this.StepRestDuration = StepRestDuration;
        }
        public override double get_total_race_time(double distance)
        {
            int steps = Convert.ToInt32(distance / (RestInterval * speed));
            double timeAllchill = 0;
            int currentStep = 1;
            int oversteps = 0;
            int lengthMap = StepRestDuration.Count;
            foreach (KeyValuePair<int, double> value in StepRestDuration)
            {
                if (currentStep == value.Key)
                {
                    timeAllchill += value.Value;
                    currentStep++;
                }
                else if (value.Key == 0)
                {
                    oversteps = steps - lengthMap + 1;
                    timeAllchill += oversteps * value.Value;
                }
                else
                {
                    throw new Exception("Not correct RestDuration");
                }
            }
            return (steps * RestInterval + timeAllchill);
        }
    }
}
