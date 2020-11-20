using System;
using System.Collections.Generic;
namespace Code_of_lab_3
{
    public class GameEngine
    {
        public List<Race> allRaces { get; private set; } = new List<Race>();
        public GameEngine()
        {
        }
        public void create_race(string typeOfRace, int distance)
        {
            Race race = new Race(typeOfRace, distance);
            allRaces.Add(race);
        }

    }
}
