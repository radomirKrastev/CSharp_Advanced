using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinics
{
    public class Program
    {
        public static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var pets = new List<Pet>();
            var clinics = new List<Clinic>();

            var commandLine = Console.ReadLine();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var tokens = commandLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                if (command == "Create")
                {
                    var type = tokens[1];
                    var name = tokens[2];
                    if (type == "Pet")
                    {
                        var age = int.Parse(tokens[3]);
                        var kind = tokens[4];
                        var newPet = new Pet(name, age, kind);
                        pets.Add(newPet);
                    }
                    else
                    {
                        var rooms = int.Parse(tokens[3]);
                        var newClinic = new Clinic(name, rooms);
                        clinics.Add(newClinic);
                    }
                }
                else if (command == "Add")
                {
                    var petName = tokens[1];
                    var clinicName = tokens[2];
                    var currentClinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                    var currentPet = pets.FirstOrDefault(x => x.Name == petName);

                    if (currentClinic != null && currentPet != null)
                    {
                        Console.WriteLine(currentClinic.AddPet(currentPet)); 
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid Operation!");
                    }
                }
                else if (command == "Release")
                {
                    var currentClinic = ValidateClinic(tokens[1], clinics);
                    Console.WriteLine(currentClinic.Release()); 
                }
                else if (command == "HasEmptyRooms")
                {
                    var currentClinic = ValidateClinic(tokens[1], clinics);
                    Console.WriteLine(currentClinic.GetEmptyRoomsAvailable()); 
                }
                else if (command == "Print" && tokens.Length == 2)
                {
                    var currentClinic = ValidateClinic(tokens[1], clinics);
                    currentClinic.Print();
                }
                else if (command == "Print" && tokens.Length == 3)
                {
                    var currentRoom = int.Parse(tokens[2]);
                    var currentClinic = ValidateClinic(tokens[1], clinics);
                    currentClinic.Print(currentRoom);
                }

                commandLine = Console.ReadLine();
            }
        }

        private static Clinic ValidateClinic(string name, List<Clinic> clinics)
        {
            var clinicName = name;
            var currentClinic = clinics.FirstOrDefault(x => x.Name == clinicName);

            if (currentClinic == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return currentClinic;
        }
    }
}
