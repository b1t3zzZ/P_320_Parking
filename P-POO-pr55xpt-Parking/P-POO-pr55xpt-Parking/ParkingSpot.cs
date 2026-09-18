using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    internal class ParkingSpot
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

        public void Park(Vehicule? v, Ticket t)
        {
            IsOccuped = true;
            VehiculePark = v;
            ActiveTicket = t;
        }

        public void Release()
        {
            IsOccuped = false;
            VehiculePark = null;
            ActiveTicket = null;
        }
    }
}
