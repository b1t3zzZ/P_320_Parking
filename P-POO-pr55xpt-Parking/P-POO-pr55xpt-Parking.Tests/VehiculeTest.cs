using P_POO_pr55xpt_Parking;
using System.Net.Sockets;
using System.Numerics;
namespace P_POO_pr55xpt_Parking.Tests
{
    [TestClass]
    public sealed class VehiculeTest
    {
        [TestMethod]
        public void IsValidePlate_WithPlaqueValide_Result_True()
        {
            //Arrange
            string plaque = "VD-123456";
            bool result;

            //Act
            result = Vehicule.IsValidPlate(plaque);

            //Assert
            Assert.AreEqual(true, result, "Le resultat doit etre 'true'");
        }

        [TestMethod]
        public void IsValidePlate_WithPlaqueInvalide_Result_False()
        {
            //Arrange
            string plaque = "q";
            bool result;

            //Act
            result = Vehicule.IsValidPlate(plaque);

            //Assert
            Assert.AreEqual(false, result, "Le resultat doit etre 'false'");
        }

        [TestMethod]
        public void SortVehicle_LiberationDePlace_ResultTrue()
        {
            //Arrange

            Parking p = new Parking(20, 1.5m);
            p.EnterVehicle("VD-123456");
            Ticket? result;

            //Act

            result = p.SortVehicle(plaque: "VD-123456");

            //Assert
            Assert.IsNotNull(result, "Le resultat doit être 'true'");
            

        }
        
        [TestMethod]
        public void EnterVehicle_WithPlaqueValide_ResultNotNull()
        {
            //Arrange
            Parking p = new Parking(20, 1.5m);
            Ticket? result;

            //Act
            result = p.EnterVehicle("VD-123456");

            //Assert
            Assert.IsNotNull(result, "Le ticket ne doit pas être null");
        }

        [TestMethod]
        public void SumPayement_AfterTwoHours_ResultThreeChf()
        {
            //Arrange
            Vehicule v = new Vehicule("VD-123456");
            Ticket t = new Ticket(v, 1, 1.5m);
            DateTime sortie = t.EntryTime.AddHours(2);
            decimal result;

            //Act
            result = t.SumPayement(sortie);

            //Assert
            Assert.AreEqual(3.0m, result, "Le prix pour 2h à 1.5 CHF/h doit être 3.0 CHF");
        }
    }
}
