using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public class Race
    {
        public double distance
        {
            get { return distance; }
            private set { if (value < 0) { throw new Exception("Distance doesn't be less 0"); } else { distance = value; } }
        }
        public string typeOfRace
        {
            get { return typeOfRace; }
            private set
            {
                value = value.ToLower();
                switch (value)
                {
                    case "air":
                        typeOfRace = "air";
                        break;
                    case "land":
                        typeOfRace = "land";
                        break;
                    case "all":
                        typeOfRace = "all";
                        break;
                    default:
                        throw new Exception("There isn't type of race in option");
                }
            }
        }
        public List<Transport> usersOfTransport { get; protected set; } = new List<Transport>();
        private Transport results;
        double minTime = Double.MaxValue;
        double currenTime = 0;
        public Race(string typeOfRace, double distance)
        {
            this.typeOfRace = typeOfRace;
            this.distance = distance;
        }
        public void registration(Transport transport)
        {
            usersOfTransport.Add(transport);
        }
        public Transport get_results()
        {
            switch (typeOfRace)
            {
                case "air":
                    return get_results_air();
                case "land":
                    return get_results_land();
                case "all":
                    return get_results_all();
                default:
                    throw new Exception("There isn't type of race in option");
            }
        }
        public Transport get_results_air()
        {
            foreach (Transport value in usersOfTransport)
            {
                currenTime = value.get_total_race_time(distance);
                if (currenTime < minTime)
                {
                    minTime = currenTime;
                    results = value;
                }
            }
            return results;
        }
        public Transport get_results_land()
        {
            foreach (Transport value in usersOfTransport)
            {
                currenTime = value.get_total_race_time(distance);
                if (currenTime < minTime)
                {
                    minTime = currenTime;
                    results = value;
                }
            }
            return results;
        }
        public Transport get_results_all()
        {
            foreach (Transport value in usersOfTransport)
            {
                currenTime = value.get_total_race_time(distance);
                if (currenTime < minTime)
                {
                    minTime = currenTime;
                    results = value;
                }
            }
            return results;
        }
    }
}
