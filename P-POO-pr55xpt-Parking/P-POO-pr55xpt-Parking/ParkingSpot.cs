using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    public class ParkingSpot
    {
        public int Number { get; private set;}
        public bool IsOccuped { get; private set;}
        public Vehicule? VehiculePark { get; private set;}
        public Ticket? ActiveTicket { get; private set;}

        public ParkingSpot(int number) 
        { 
        
            this.Number = number;
            this.IsOccuped = false;
        
        }
        //La methode pour entrer la voiture
        public void Park(Vehicule? v, Ticket t)
        {
            this.IsOccuped = true;                           //Changement d'état de parking (Occupé)
            this.VehiculePark = v;                           //Enregistrement de vehicule entrée
            this.ActiveTicket = t;                           //Enregistrement de ticket entrée
        }

        //La methode pour liberer la place
        public void Release()
        {
            IsOccuped = false;                          //Changement d'état de parking (libre)
            VehiculePark = null;                        //Libération de vehicule
            ActiveTicket = null;                        //Libération de ticket
        }
    }
}
