using P_POO_pr55xpt_Parking;
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
    }
}
