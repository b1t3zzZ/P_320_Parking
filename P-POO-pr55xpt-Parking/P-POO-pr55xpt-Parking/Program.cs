using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestGlobalParking.ExecuterTests();                   //Test qui est fait par l'IA

            char chrAnswer;
            bool valueOk;
            string plaque;
            bool plateOrNum;
            int choiseToSortVehicle;
            string reponse;
            Parking? p = new Parking(20, 1.5m);

            do
            {
                Console.Clear();
                //L'affichage de menu
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Entrée d'un vehicule");
                Console.WriteLine("2. Sortie d'un vehicule");
                Console.WriteLine("3. Afficher l'état du parking");
                Console.WriteLine("4. Rechercher un véhicule");
                Console.WriteLine("5. Statistique du jour");
                Console.WriteLine("6. Historique des transactions");
                Console.WriteLine("0. Quitter");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nVotre choix: ");
                valueOk = char.TryParse(Console.ReadLine(), out chrAnswer);
                Console.ResetColor();

                //La fonctionnalité selon le choix
                switch (chrAnswer)
                {
                    //Entrée vehicule
                    case '1':
                        //Demande de plaque
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nEcrivez plaque de votre véhicule: ");
                        plaque = Console.ReadLine();
                        Console.ResetColor();

                        //Creation de voiture si la plaque est bien entrée
                        if (plaque != null)
                        {
                            Ticket? t = p.EnterVehicle(plaque);                                             //Машина создается внутри метода ентервеикл парковки и возвращает Ticket

                            //Et si le ticket existe - afficher le temps d'entrée, place, tarif
                            if (t != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(t);
                                Console.ResetColor();
                            }
                        }
                        Console.Write("\nCliquez sur n'importe quel touche.");
                        Console.ReadKey();
                            break;

                    //Sorite vehicule
                    case '2':
                        //Demande plaque ou nb place
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nEntrez votre plaque ou numéro de la place: ");
                        reponse = Console.ReadLine();
                        plateOrNum = int.TryParse(reponse, out choiseToSortVehicle);
                        Console.ResetColor();

                        // Simulation de la durée 
                        Console.Write("Simuler combien d'heures de stationnement ? (0 pour temps réel): ");
                        int.TryParse(Console.ReadLine(), out int heuresSimulees);
                        
                        if (heuresSimulees < 0)
                            heuresSimulees = 0;                                                                     // Empêche d'entrer un nombre d'heures négatif
                        
                        DateTime heureSortie = DateTime.Now.AddHours(heuresSimulees);
                        
                        // 1. On cherche et affiche d'abord les informations du véhicule
                        bool vehiculeTrouve;
                        if (plateOrNum)
                        {
                            vehiculeTrouve = p.FoundVehicle(place: choiseToSortVehicle, exitTime: heureSortie);
                        }
                        else
                        {
                            vehiculeTrouve = p.FoundVehicle(plaque: reponse, exitTime: heureSortie);
                        }
                        // 2. Si le véhicule existe, on demande confirmation avant de libérer la place
                        if (vehiculeTrouve)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nVoulez-vous réellement sortir le véhicule ? (o/n): ");
                            string? confirmation = Console.ReadLine();
                            Console.ResetColor();
                            if (confirmation == "o" || confirmation == "O")
                            {
                                if (plateOrNum)
                                {
                                    p.SortVehicle(place: choiseToSortVehicle, exitTime: heureSortie);
                                }
                                else
                                {
                                    p.SortVehicle(plaque: reponse, exitTime: heureSortie);
                                }
                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nVous avez bien libéré votre place.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("\nSortie annulée, le véhicule reste dans le parking.");
                            }
                        }
                        
                        Console.Write("\nCliquez sur n'importe quel touche.");
                        Console.ReadKey();
                        break;

                    case '3':
                        p.DisplayParking();                                                                //La methode pour afficher le parking est dans parking.cs
                        Console.Write("\nCliquez sur n'importe quel touche.");
                        Console.ReadKey();
                        break;

                    case '4':

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nVotre plaque d'immatriculation ou numéro de la place: ");
                        reponse = Console.ReadLine();
                        plateOrNum = int.TryParse(reponse, out choiseToSortVehicle);
                        Console.ResetColor();

                        //Si plateOrNum = true, alors on a mis numero
                        if (plateOrNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            p.FoundVehicle(place: choiseToSortVehicle);
                            Console.ResetColor();
                        }

                        //Si plateOrNum = false, alors on a mis plaque
                        if (!plateOrNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            //Le choiseToSortVehicle est de type int, alors on a besoin 'Convert'
                            p.FoundVehicle(plaque: Convert.ToString(reponse));                  //palque: "*" - indique qu'on utilise 1 parametre
                            Console.ResetColor();
                        }
                        Console.Write("\nCliquez sur n'importe quel touche");
                        Console.ReadKey();
                        break;

                    case '5':
                        p.DisplayStatistics();
                        Console.Write("\nCliquez sur n'importe quelle touche.");
                        Console.ReadKey();
                        break;

                    case '6':
                        p.DisplayTransactions();
                        Console.Write("\nCliquez sur n'importe quelle touche.");
                        Console.ReadKey();
                        break;

                    case '0':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nAu revoir et merci d'avoir utilisé notre parking!");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nChoix invalide, veuillez entrer un chiffre entre 0 et 6.");
                        Console.ResetColor();
                        Console.Write("\nCliquez sur n'importe quelle touche.");
                        Console.ReadKey();
                        break;
                }










            } while (chrAnswer != '0');




        }
    }
}
