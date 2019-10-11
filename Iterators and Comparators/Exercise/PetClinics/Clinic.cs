using System;

namespace PetClinics
{
    public class Clinic
    {
        private Pet [] petPatientRooms;

        public string Name { get; private set; }
        public int RoomsCount { get; private set; }
        private int emptyRooms;
        private int centralRoom;

        public Clinic(string name, int rooms)
        {
            if (rooms % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.Name = name;
            this.RoomsCount = rooms;
            this.petPatientRooms = new Pet[this.RoomsCount];
            this.centralRoom = (this.RoomsCount - 1) / 2;
            this.emptyRooms = rooms;
        }

        public bool AddPet(Pet pet)
        {
            if (petPatientRooms[centralRoom] == null)
            {
                petPatientRooms[centralRoom] = pet;
                this.emptyRooms--;
                return true;
            }

            for (int i = 1; i <= centralRoom; i++)
            {
                if (petPatientRooms[centralRoom - i] == null)
                {
                    petPatientRooms[centralRoom - i] = pet;
                    this.emptyRooms--;
                    return true;
                }
                else if (petPatientRooms[centralRoom + i] == null)
                {
                    petPatientRooms[centralRoom + i] = pet;
                    this.emptyRooms--;
                    return true;
                }                
            }

            return false;
        }

        public bool Release()
        {
            for (int i = centralRoom; i < this.petPatientRooms.Length; i++)
            {
                if (petPatientRooms[i] != null)
                {
                    petPatientRooms[i] = null;
                    this.emptyRooms++;
                    return true;
                }
            }

            for (int i = 0; i < centralRoom; i++)
            {
                if (petPatientRooms[i] != null)
                {
                    petPatientRooms[i] = null;
                    this.emptyRooms++;
                    return true;
                }
            }

            return false;
        }

        public bool GetEmptyRoomsAvailable()
        {
            return this.emptyRooms > 0;
        }

        public void Print()
        {
            foreach (var room in petPatientRooms)
            {
                if (room == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(room.ToString());
                }                
            }
        }

        public void Print(int room)
        {
            if (room - 1 >= 0 && room - 1 < this.RoomsCount)
            {
                Console.WriteLine(petPatientRooms[room-1].ToString());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
