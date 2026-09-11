using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    internal class Vehicule
    {
        public string LicencePlate {get; private set; }
        public Vehicule(string plate)
        {

            LicencePlate = plate;

        }

         public static bool IsValidPlate(string plate)
        {

            return Regex.IsMatch(plate, @"^[A-Z]{2}\d{1,6}$");

        }

        public override string ToString()
        {

            return LicencePlate;

        }
    }
}
