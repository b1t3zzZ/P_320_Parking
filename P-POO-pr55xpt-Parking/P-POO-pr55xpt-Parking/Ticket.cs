using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_POO_pr55xpt_Parking
{
    public class Ticket
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

        //La methode pour calculer le temps restant dans le parking
        public TimeSpan ParkDuration(DateTime exitTime)
        {

            return exitTime - EntryTime;

        }

        //La methode pour caluler la somme à payer en fonctionne de temps resté
        public decimal SumPayement(DateTime exitTime)
        {

            TimeSpan interval = ParkDuration(exitTime);
            decimal durationParking = (decimal)interval.TotalHours;
            return Math.Round(durationParking, 2) * tarifPerHour;

        }

        //L'affichage de ticket
        public override string ToString() 
        {

            return "\nHeure d'entrée: " + EntryTime.ToString() + "\nPlace: " + GivenPlace + "\nTarif Horaire: " + tarifPerHour + "\n"; 

        }
    }
}
