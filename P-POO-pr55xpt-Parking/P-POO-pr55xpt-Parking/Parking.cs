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
        public decimal TotalPaid { get; private set; }
        public List<string> Transactions { get; private set; }

        public Parking(int capacity, decimal hourlyRate) 
        {
            this.Capacity = capacity;
            this.Spots = new ParkingSpot[capacity];
            this.HourlyRate = hourlyRate;
            this.Transactions = new List<string>();
            
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
                
                foreach (var spot in Spots)                                       // Vérification si la voiture est déjà dans le parking
                {
                    if (spot.IsOccuped == true && spot.VehiculePark?.LicencePlate == plaque)
                    {
                        Console.WriteLine("\nCe véhicule est déjà dans le parking\n");
                        return null;
                    }
                }
                
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
                    
                    Transactions.Add($"ENTREE ({ticket.EntryTime}) - {v1.LicencePlate} (Place n°{place.Number})");
                    
                    return ticket;
                }
            }
        }
        
        // La méthode pour sortir le véhicule
        public Ticket? SortVehicle(string? plaque = null, int? place = null, DateTime? exitTime = null)
        {
            DateTime tempsFin;

            if (exitTime != null)
            {
                tempsFin = exitTime.Value; // Si un temps simulé a été transmis, nous l'utilisons.
            }
            else
            {
                tempsFin = DateTime.Now;   // Sinon, on prend l'heure actuelle
            }                                      

            foreach (var spot in Spots)                                                          // On fait une boucle pour vérifier toutes les places
            {
                if (spot.IsOccuped == true && spot.Number == place)                              // Si on a entré la place
                {
                    Ticket? t = spot.ActiveTicket;                                               // Création ticket pour le donner après l'annulation
                    if (t != null)
                    {
                        TotalPaid += t.SumPayement(tempsFin);                                                                                                   // On ajoute le montant payé au total du jour
                        Transactions.Add($"SORTIE ({tempsFin}) - {spot.VehiculePark?.LicencePlate} (Place n°{spot.Number}, {t.SumPayement(tempsFin)} CHF)");
                    }
                    spot.Release();
                    return t;
                }
                if (spot.IsOccuped == true && spot.VehiculePark?.LicencePlate == plaque)                                                                        // Si on a entré la plaque
                {
                    Ticket? t = spot.ActiveTicket;
                    if (t != null)
                    {
                        TotalPaid += t.SumPayement(tempsFin);                                                                                                   // On ajoute le montant payé au total du jour
                        Transactions.Add($"SORTIE ({tempsFin}) - {spot.VehiculePark?.LicencePlate} (Place n°{spot.Number}, {t.SumPayement(tempsFin)} CHF)");
                    }
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

        // La méthode pour rechercher et afficher le véhicule
        public bool FoundVehicle(string? plaque = null, int? place = null, DateTime? exitTime = null)
        {
            DateTime tempsFin = exitTime ?? DateTime.Now;

            foreach (var spot in Spots)                                                          // On fait une boucle pour vérifier toutes les places
            {
                if (spot.IsOccuped == true && (spot.Number == place || spot.VehiculePark?.LicencePlate == plaque))
                {
                    TimeSpan duree = spot.ActiveTicket!.ParkDuration(tempsFin);

                    Console.WriteLine($"\nVoiture:         {spot.VehiculePark?.LicencePlate}");
                    Console.WriteLine($"Place:           {spot.Number}");
                    Console.WriteLine($"Heure d'entrée:  {spot.ActiveTicket.EntryTime}");
                    Console.WriteLine($"Heure de sortie: {tempsFin}");
                    Console.WriteLine($"Durée:           {(int)duree.TotalHours}h {duree.Minutes}min {duree.Seconds}s");
                    Console.WriteLine($"Prix à payer:    {spot.ActiveTicket.SumPayement(tempsFin)} CHF");
                    return true;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAucun véhicule trouvé.");
            Console.ResetColor();
            return false;
        }
        
        
        // La méthode pour afficher les statistiques du jour
        public void DisplayStatistics()
        {
            int placesOccupees = 0;
            TimeSpan dureeTotale = TimeSpan.Zero;

            foreach (var spot in Spots)
            {
                if (spot.IsOccuped == true && spot.ActiveTicket != null)
                {
                    placesOccupees++;
                    dureeTotale += spot.ActiveTicket.ParkDuration(DateTime.Now);                                                                // Additionne la durée de stationnement de tous les véhicules actuellement garés sur le parking.
                }
            }

            double pourcentage = (double)placesOccupees / Capacity * 100;                                                                       // Calcule le pourcentage de places occupées

            Console.WriteLine("\n=== STATISTIQUES DU JOUR ===");
            Console.WriteLine($"Places occupées :        {placesOccupees} / {Capacity}");
            Console.WriteLine($"Taux d'occupation :      {pourcentage} %");
            Console.WriteLine($"Montant total payé :     {TotalPaid} CHF");                                                                     // Affiche le montant total en CHF déjà réglé par les véhicules ayant quitté les lieux
            Console.WriteLine($"Durée totale actuelle :  {(int)dureeTotale.TotalHours}h {dureeTotale.Minutes}min {dureeTotale.Seconds}s");
        }
        // La méthode pour afficher l'historique des transactions
        public void DisplayTransactions()
        {
            Console.WriteLine("\n=== HISTORIQUE DES TRANSACTIONS ===");

            if (Transactions.Count == 0)
            {
                Console.WriteLine("Aucune transaction effectuée.");
            }
            else
            {
                foreach (string transaction in Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }
        
    }
}
