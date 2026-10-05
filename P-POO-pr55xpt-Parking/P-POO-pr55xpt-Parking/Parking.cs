using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    public class Parking
    {
        public ParkingSpot[] Spots { get; private set; }
        public int Capacity { get; private set; }
        public decimal HourlyRate { get; private set; }

        const int TAILLEDETABLLEAU = 50;

        public Parking(int capacity, decimal hourlyRate) 
        {
            this.Capacity = capacity;
            this.Spots = new ParkingSpot[capacity];
            this.HourlyRate = hourlyRate;

            for (int i = 0; i < capacity; i++)                                     //On entre dans la liste toute les parking spots
            {

                this.Spots[i] = new ParkingSpot(i + 1);

            }

        }

        //La methode pour rechercher des places libre
        public ParkingSpot? FindFirstFreeSpot()
        {
            foreach (var spot in Spots)                                           //On entre dans la liste Spots pour verifier lequel est libre 
            {

                if(spot.IsOccuped == false)                                       //Si la place n'est pas occupé, alors on return un place
                {
                    return spot;
                }

            }
            return null;                                                          //Si on n'a pas trouve place libre, on return rien
        }

        //La methode pour entrer la vehicule
        public Ticket? EnterVehicle(string plaque)                  
        {
            if(Vehicule.IsValidPlate(plaque) == false)                            //Verification si la plaque est valide
            {
                Console.WriteLine("\nCe n'est pas une bonne plaque\n");
                return null;
            }
            else                                                                  //Si oui, on cherche la place
            {
                ParkingSpot? place = FindFirstFreeSpot();

                if (place == null)                                                //Au cas si la place est null
                {
                    Console.WriteLine("\nIl n'y a pas de place librés\n");
                    return null;
                }
                else                                                              //Si on a trouve la place, on entre les données 
                {
                    Vehicule v1 = new Vehicule(plaque);
                    Ticket ticket = new Ticket(v1, place.Number, HourlyRate);
                    place.Park(v1, ticket);

                    return ticket;
                }
            }
        }

        //La methode pour sortir le vehicule
        public Ticket? SortVehicle(string? plaque = null, int? place = null)
        {       
            foreach (var spot in Spots)                                                          //On fait un boucle pour verifier toutes les places libres
            {

                if (spot.IsOccuped == true && spot.Number == place)                              //Si on a entré la place
                {
                    Ticket? t = spot.ActiveTicket;                                               //Creation ticket pour le donner après l'annulation
                    spot.Release();
                    return t;
                }
                if(spot.IsOccuped == true && spot.VehiculePark?.LicencePlate == plaque)          //Si on a entré la plaque
                {
                    Ticket? t = spot.ActiveTicket;
                    spot.Release();
                    return t;
                }

            }
            return null;
        }

        //La methode pour afficher le parking
        public void DisplayParking()
        {
            Console.WriteLine("\nPlan du parking (L=Libre, X=Occupé):");

            foreach (var spot in this.Spots)                                                    //Parcour toutes les elements dans le spots
            {
                if(spot.IsOccuped == true )                                                     //Si la place est occupé
                {
                    if (spot.Number < 10)                                                       //Si le numero de la place est moins de 10 on va écrire le 0 avant
                    {
                        if (spot.Number % 4 == 0)                                               //Si le modulo de 4 est 0 on va faire un saut de ligne
                        {
                            Console.WriteLine($"| 0{spot.Number}: X | ");
                        }
                        else
                        {
                            Console.Write($"| 0{spot.Number}: X | ");
                        }
                    }
                    else
                    {
                        if (spot.Number % 4 == 0)
                        {
                            Console.WriteLine($"| {spot.Number}: X | ");
                        }
                        else
                        {
                            Console.Write($"| {spot.Number}: X | ");
                        }
                    }
                }
                else                                                                           //Si la place n'est pas occupé   
                {
                    if(spot.Number < 10)
                    {
                        if (spot.Number % 4 == 0)
                        {
                            Console.WriteLine($"| 0{spot.Number}: L | ");
                        }
                        else
                        {
                            Console.Write($"| 0{spot.Number}: L | ");
                        }
                    }
                    else
                    {
                        if (spot.Number % 4 == 0)
                        {
                            Console.WriteLine($"| {spot.Number}: L | ");
                        }
                        else
                        {
                            Console.Write($"| {spot.Number}: L | ");
                        }
                    }  
                }
            }
            Console.WriteLine();
        }

        //La methode pour sortir le vehicule
        public void FoundVehicle(string? plaque = null, int? place = null)
        {
            foreach (var spot in Spots)                                                          //On fait un boucle pour verifier toutes les places libres
            {
                if (spot.IsOccuped == true && spot.Number == place)                              //Si on a entré la place
                {
                    Ticket? t = spot.ActiveTicket;                                               //Creation ticket pour le donner après l'annulation
                    Console.WriteLine($"\nVoiture:        {spot.VehiculePark?.LicencePlate} ");
                    Console.WriteLine($"Place:          {spot.Number} ");
                    Console.WriteLine($"Heure d'entrée: {spot.ActiveTicket?.EntryTime} ");
                    Console.WriteLine($"Durée:          {spot.ActiveTicket?.ParkDuration(DateTime.Now)} ");
                    Console.WriteLine($"Prix à payer:          {spot.ActiveTicket?.SumPayement(DateTime.Now)} ");
                }
                if (spot.IsOccuped == true && spot.VehiculePark?.LicencePlate == plaque)          //Si on a entré la plaque
                {
                    Ticket? t = spot.ActiveTicket;
                    Console.WriteLine($"\nVoiture:        {spot.VehiculePark?.LicencePlate} ");
                    Console.WriteLine($"Place:          {spot.Number} ");
                    Console.WriteLine($"Heure d'entrée: {spot.ActiveTicket?.EntryTime} ");
                    Console.WriteLine($"Durée:          {spot.ActiveTicket?.ParkDuration(DateTime.Now)} ");
                    Console.WriteLine($"Prix à payer:          {spot.ActiveTicket?.SumPayement(DateTime.Now)} ");
                }

            }
        }

        
    }
}
