namespace TestApp.UnitTests
{
    [TestClass]
    public class RentTests
    {

        [TestMethod]
        public void Method_Scenario_ExpectedBehavior()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void CanReturn_UserIsAdmin_ShouldReturnsTrue()
        {
            // Arrange
            Rent rent = new Rent() { Rentee = new User() };

            // Act
            bool result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanReturn_UserIsEmpty_ShouldThrowsArgumentNullException()
        {
            // Arrange
            Rent rent = new Rent() { Rentee = new User() };

            // Act
            rent.CanReturn(null);

            // Assert

        }

        [TestMethod]
        public void CanReturn_UserIsRenteeAndIsNotAdmin_ShouldReturnsTrue()
        {
            // Arrange
            User rentee = new User() { IsAdmin = false };
            Rent rent = new Rent { Rentee = rentee };

            // Act
            bool result = rent.CanReturn(rentee);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsNotRenteeAndIsNotAdmin_ShouldReturnsFalse()
        {
            // Arrange
            Rent rent = new Rent { Rentee = new User() };

            // Act
            bool result = rent.CanReturn(new User() { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }
    }
}