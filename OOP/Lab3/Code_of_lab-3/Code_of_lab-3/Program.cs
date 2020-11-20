using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race("land", 1000);
            LandTransport bactrianCamel = new LandTransport(10, 30, new Dictionary<int, double> { {1, 5}, {0, 8} });
            LandTransport camelFast = new LandTransport(40, 10, new Dictionary<int, double> { { 1, 5}, {2, 6.5}, { 0, 8} });
            LandTransport centaur = new LandTransport(15, 8, new Dictionary<int, double> { { 0, 2} });
            LandTransport boots = new LandTransport(6, 60, new Dictionary<int, double> { { 1, 10}, { 0, 5} });
            race.registration(bactrianCamel);
            race.registration(camelFast);
            race.registration(centaur);
            race.registration(boots);
            Console.WriteLine(race.get_results().speed);
        }
    }
}
