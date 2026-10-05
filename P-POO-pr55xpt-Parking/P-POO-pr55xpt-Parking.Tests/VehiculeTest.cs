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
            string plaque = "VD123456";
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
            p.EnterVehicle("VD123456");
            Ticket? result;

            //Act

            result = p.SortVehicle(plaque: "VD123456");

            //Assert
            Assert.IsNotNull(result, "Le resultat doit être 'true'");
            

        }
    }
}
