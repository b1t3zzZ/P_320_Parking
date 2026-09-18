using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    internal class Parking
    {
        public ParkingSpot[] Spots { get; private set; }
        public int Capacity { get; private set; }
        public decimal HourlyRate { get; private set; }

        public Parking(int capacity, decimal hourlyRate) 
        {
            this.Capacity = capacity;
            this.Spots = new ParkingSpot[capacity];
            this.HourlyRate = hourlyRate;

            for (int i = 0; i < capacity; i++)
            {

                this.Spots[i] = new ParkingSpot(i + 1);

            }

        }

        public ParkingSpot? FindFirstFreeSpot()
        {
            foreach (var spot in Spots)
            {

                if(spot.IsOccuped == false)
                {
                    return spot;
                }

            }
            return null;
        }

        public Ticket? EnterVehicle(string plaque)
        {
            if(Vehicule.IsValidPlate(plaque)  == false)
            {
                Console.WriteLine("Ce n'est pas une bonne plaque");
                return null;
            }
            else
            {
                if(FindFirstFreeSpot() == null)
                {
                    Console.WriteLine("Il n'y a pas de place librés");
                }
                else
                {
                    Vehicule v1 = new Vehicule(plaque);
                    Ticket ticket = new Ticket(v1);
                    ParkingSpot.Park(v1, ticket);
                }
            }

        }

        

    }
}
