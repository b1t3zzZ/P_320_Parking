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
            //TestGlobalParking.ExecuterTests();

            char chrAnswer;
            bool valueOk;
            string plaque;
            bool plateOrNum;
            int choiseToSortVehicle;
            Parking? p = new Parking(20, 1.5m);

            do
            {
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Entrée d'un vehicule");
                Console.WriteLine("2. Sortie d'un vehicule");
                Console.WriteLine("3. Afficher l'état du parking");
                Console.WriteLine("4. Rechercher un véhicule");
                Console.WriteLine("5. Statistique du jour");
                Console.WriteLine("6. Historique des transactions");
                Console.WriteLine("0. Quitter");
                Console.Write("Votre choix: ");
                valueOk = char.TryParse(Console.ReadLine(), out chrAnswer);

                switch (chrAnswer)
                {
                    case '1':

                        Console.Write("\nEcrivez plaque de votre véhicule: ");
                        plaque = Console.ReadLine();
                        if (plaque != null)
                        {
                            Ticket? t = p.EnterVehicle(plaque);                                  //Машина создается внутри парковки и возвращает Ticket

                            if (t != null)
                            {
                                Console.WriteLine(t);
                            }
                        }
                            break;

                    case '2':
                        Console.WriteLine("\nEntrez votre plaque ou numéro de la place: ");

                        plateOrNum = int.TryParse(Console.ReadLine(), out choiseToSortVehicle);

                        if (plateOrNum)
                        {
                            Ticket ? = p.SortVehicle(choiseToSortVehicle);               //Доделать, скорее всего изменить что-то в методе SortVehicule
                        }

                        break;

                    case '3':

                        break;

                    case '4':

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
