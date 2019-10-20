using System;

namespace SpaceStationRecruitment
{
    public class StartUp
    {
        public static void Main()
        {
            SpaceStation spaceStation = new SpaceStation("Apolo", 4);
            spaceStation.Add(new Astronaut("Izrael", 2, "Congo"));
            spaceStation.Add(new Astronaut("Jongo", 12, "Bulgaria"));
            spaceStation.Add(new Astronaut("Jongo", 13, "Mavritaniq"));
            spaceStation.Add(new Astronaut("Jongo", 12, "Mavritaniq"));

            Console.WriteLine(spaceStation.Count);
            Console.WriteLine(spaceStation.GetOldestAstronaut());
            Console.WriteLine(spaceStation.Report());
            Console.WriteLine(spaceStation.Remove("Jongo"));
            spaceStation.Add(new Astronaut("Vongo", 125, "Mavritaniq"));
            Console.WriteLine(spaceStation.Count);
            Console.WriteLine(spaceStation.Report());
            //Astronaut astronaut = new Astronaut("Stephen", 5, "Bulgaria");
            
            //spaceStation.Add(astronaut);

            //Console.WriteLine(spaceStation.Remove("Astronaut name"));

            //Astronaut secondAstronaut = new Astronaut("Mark", 34, "UK");

            //spaceStation.Add(secondAstronaut);

            //Astronaut oldestAstronaut = spaceStation.GetOldestAstronaut(); 
            //Astronaut astronautStephen = spaceStation.GetAstronaut("Stephen"); 
            //Console.WriteLine(oldestAstronaut); 
            //Console.WriteLine(astronautStephen); 

            //Console.WriteLine(spaceStation.Count);

            //Console.WriteLine(spaceStation.Report());
        }
    }
}
