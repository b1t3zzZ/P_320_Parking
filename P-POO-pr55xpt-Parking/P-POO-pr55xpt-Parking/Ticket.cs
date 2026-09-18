using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    internal class Ticket
    {
        public int TicketId { get; private set; }
        public Vehicule? VehiculePark { get; private set; }
        public int GivenPlace { get; private set; }
        public DateTime EntryTime { get; private set; }
        public decimal tarifPerHour { get; private set; }

        public Ticket(Vehicule vehicule, int place, decimal tarif) 
        {
            this.VehiculePark = vehicule;
            this.tarifPerHour = tarif;
            this.GivenPlace = place;
            this.EntryTime = DateTime.Now;
        
        }

        public TimeSpan ParkDuration(DateTime exitTime)
        {

            return exitTime - EntryTime;

        }

        public decimal SumPayement(DateTime exitTime)
        {

            TimeSpan interval = ParkDuration(exitTime);
            decimal durationParking = (decimal)interval.TotalHours;
            return Math.Round(durationParking, 2) * tarifPerHour;

        }
        public override string ToString() 
        {

            return EntryTime.ToString() + " " + GivenPlace + " " + tarifPerHour; 

        }
    }
}
