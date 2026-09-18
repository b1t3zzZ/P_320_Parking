// =========================================================================================
// DOCUMENTATION ET CODE DE TEST GLOBAL DU PARKING
//
// AVERTISSEMENT / TRANSPARENCE PEDAGOGIQUE (DIRECTIVES ETML NIVEAU 2 - IA) :
// Ce fichier de test et de validation a ete genere avec l'assistance d'une Intelligence Artificielle (IA).
// Objectif : Valider et demontrer le bon fonctionnement unitaire et global des classes
// metier developpees par l'apprenti (Vehicule, ParkingSpot, Ticket, Parking).
//
// Date : 18 septembre 2026
// =========================================================================================

using System;

namespace P_POO_pr55xpt_Parking
{
    internal class TestGlobalParking
    {
        public static void ExecuterTests()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("        TEST GLOBAL DU PARKING          ");
            Console.WriteLine("========================================\n");

            // --- TEST 1 : Véhicule & Validation ---
            Console.WriteLine("--- 1. TEST PLAQUES D'IMMATRICULATION ---");
            string plaqueOk = "VD123456";
            string plaqueKo = "123INVALID";
            Console.WriteLine($"Plaque '{plaqueOk}' valide ? -> {Vehicule.IsValidPlate(plaqueOk)} (attendu: True)");
            Console.WriteLine($"Plaque '{plaqueKo}' valide ? -> {Vehicule.IsValidPlate(plaqueKo)} (attendu: False)");

            Vehicule v1 = new Vehicule(plaqueOk);
            Console.WriteLine($"Véhicule créé : {v1}\n");

            // --- TEST 2 : Initialisation Parking ---
            Console.WriteLine("--- 2. TEST INITIALISATION DU PARKING ---");
            Parking monParking = new Parking(5, 2.50m);
            Console.WriteLine($"Capacité : {monParking.Capacity} places, Tarif : {monParking.HourlyRate} CHF/h");
            
            foreach (var spot in monParking.Spots)
            {
                Console.WriteLine($"Place n°{spot.Number} - Occupée : {spot.IsOccuped}");
            }
            Console.WriteLine();

            // --- TEST 3 : Entrée & Création Ticket ---
            Console.WriteLine("--- 3. TEST ENTREE D'UN VEHICULE (Place n°1) ---");
            Ticket ticket1 = new Ticket(v1, 1, monParking.HourlyRate);
            Console.WriteLine($"Ticket généré : {ticket1}");

            monParking.Spots[0].Park(v1, ticket1);
            Console.WriteLine($"Place n°1 occupée ? -> {monParking.Spots[0].IsOccuped} (attendu: True)");
            Console.WriteLine($"Véhicule sur place 1 -> {monParking.Spots[0].VehiculePark}\n");

            // --- TEST 4 : Sortie & Calcul du prix ---
            Console.WriteLine("--- 4. TEST SORTIE & FACTURATION ---");
            // Simuler une sortie 2h30 plus tard (2.5 heures)
            DateTime heureSortie = ticket1.EntryTime.AddHours(2.5);
            TimeSpan duree = ticket1.ParkDuration(heureSortie);
            decimal prix = Math.Round(ticket1.SumPayement(heureSortie),2);

            Console.WriteLine($"Durée stationnement : {duree.Hours}h {duree.Minutes}min");
            Console.WriteLine($"Montant à payer : {prix} CHF (attendu: ~6.25 CHF)");

            // Libération de la place
            monParking.Spots[0].Release();
            Console.WriteLine($"Place n°1 libérée ? -> {!monParking.Spots[0].IsOccuped} (attendu: True)");
            Console.WriteLine($"Véhicule sur place 1 après sortie -> {monParking.Spots[0].VehiculePark ?? (object)"(aucun)"}\n");

            Console.WriteLine("========================================");
            Console.WriteLine("         TOUS LES TESTS OK !            ");
            Console.WriteLine("========================================");
        }
    }
}
