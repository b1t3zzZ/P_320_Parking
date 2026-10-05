using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    public class Vehicule
    {
        public string LicencePlate {get; private set; }
        public Vehicule(string plate)
        {

            LicencePlate = plate;

        }


        //Cette methode est utilisé pour verifier si on a bien entré la plaque
         public static bool IsValidPlate(string plate)
        {

            return Regex.IsMatch(plate, @"^[A-Z]{2}\d{1,6}$");

        }

        //Nouvelle affichage de plaque
        public override string ToString()
        {

            return LicencePlate;

        }
    }
}
