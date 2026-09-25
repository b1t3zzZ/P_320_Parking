using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
            if(Vehicule.IsValidPlate(plaque) == false)
            {
                Console.WriteLine("Ce n'est pas une bonne plaque");
                return null;
            }
            else
            {
                ParkingSpot? place = FindFirstFreeSpot();

                if (place == null)
                {
                    Console.WriteLine("Il n'y a pas de place librés");
                    return null;
                }
                else
                {
                    Vehicule v1 = new Vehicule(plaque);
                    Ticket ticket = new Ticket(v1, place.Number, HourlyRate);
                    place.Park(v1, ticket);

                    return ticket;
                }
            }
        }

        public Ticket? SortVehicle(string? plaque = null, int? place = null)
        {
            

            foreach (var spot in Spots)
            {

                if (spot.IsOccuped == true && spot.Number == place)
                {
                    spot.Release();

                    return 
                    
                }
                if(spot.IsOccuped == true && spot.VehiculePark.LicencePlate == plaque)
                {
                    spot.Release();
                }

            }
            return null;

        }

        public override string ToString()
        {
            Ticket? ticket = null;

            return $"L'heure d'entrée: {ticket.EntryTime}, l'heure de sortie: {ticket.ParkDuration(ticket.EntryTime)}," +
                    $" Montant à payer: {ticket.SumPayement(ticket.EntryTime)}";
        }

    }
}
