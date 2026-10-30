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
        // Constructeur pour enregistrer la plaque du vehicule
        public Vehicule(string plate)
        {

            LicencePlate = plate;

        }


        //Cette methode est utilisé pour verifier si on a bien entré la plaque
         public static bool IsValidPlate(string plate)
        {
            // Regex pour verifier que la plaque suisse est valide (ex: VD-123456)
            return Regex.IsMatch(plate, @"^[A-Za-z]{2}-\d{1,6}$");
        }

        // Retourne la plaque d'immatriculation
        public override string ToString()
        {

            return LicencePlate;

        }
    }
}
