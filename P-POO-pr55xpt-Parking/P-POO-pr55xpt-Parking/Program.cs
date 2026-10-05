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
                            Ticket? t = p.EnterVehicle(plaque);                                  //Машина создается внутри парковки и возвращает Ticket

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


                        //Si plateOrNum = true, alors on a mis numero
                        if (plateOrNum)
                        {

                            p.SortVehicle(place: choiseToSortVehicle);                                     //place: "*" - indique qu'on utilise 2 parametre
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nVous avez bien liberé votre palce");
                            Console.ResetColor();

                        }

                        //Si plateOrNum = false, alors on a mis plaque
                        if (!plateOrNum)
                        {   

                            //Le choiseToSortVehicle est de type int, alors on a besoin 'Convert'
                            p.SortVehicle(plaque: Convert.ToString(reponse));                  //plaque: "*" - indique qu'on utilise 1 parametre
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nVous avez bien liberé votre palce");
                            Console.ResetColor();

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
                            p.FoundVehicle(place: choiseToSortVehicle);
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"");

                            Console.ResetColor();
                        }

                        //Si plateOrNum = false, alors on a mis plaque
                        if (!plateOrNum)
                        {
                            //Le choiseToSortVehicle est de type int, alors on a besoin 'Convert'
                            p.FoundVehicle(plaque: Convert.ToString(reponse));                  //palque: "*" - indique qu'on utilise 1 parametre
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine();

                            Console.ResetColor();
                        }
                        Console.Write("\nCliquez sur n'importe quel touche");
                        Console.ReadKey();
                        break;

                    case '5':

                        break;

                    case '6':

                        break;

                    case '0':

                        break;
                }










            } while (chrAnswer != '0');




        }
    }
}
