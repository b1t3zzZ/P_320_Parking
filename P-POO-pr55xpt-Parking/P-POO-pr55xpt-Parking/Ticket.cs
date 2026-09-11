using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    internal class Ticket
    {
        DateTime current = DateTime.Now;
        public int TicketId { get; private set; }
        public Vehicule? VehiculePark { get; private set; }
        public int GivenPlace { get; private set; }
        public string TimeOfEnter { get; private set; }
        public int HourOfEnter { get; private set; }
        public decimal tarifPerHour { get; private set; }

        public Ticket(int place, decimal tarif) 
        {

            this.tarifPerHour = tarif;
            this.GivenPlace = place;
            this.HourOfEnter = current.Hour;
        
        }

        public void ParkDuration()
        {



        }

        public decimal SumPayement()
        {

            return HourOfEnter * tarifPerHour;

        }

    }
}
