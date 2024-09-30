namespace TestApp.UnitTests
{
    [TestClass]
    public class RentTests
    {
        private Rent rent;

        [TestInitialize]
        public void Init()
        {
            // Arrange
            rent = new Rent() { Rentee = new User() };
        }

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
            // Act
            bool result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanReturn_UserIsEmpty_ShouldThrowsArgumentNullException()
        {
            // Act
            rent.CanReturn(null);

            // Assert

        }

        [TestMethod]
        public void CanReturn_UserIsRenteeAndIsNotAdmin_ShouldReturnsTrue()
        {
            // Arrange
            User rentee = new User() { IsAdmin = false };
            rent.Rentee = rentee;

            // Act
            bool result = rent.CanReturn(rentee);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsNotRenteeAndIsNotAdmin_ShouldReturnsFalse()
        {
            // Act
            bool result = rent.CanReturn(new User() { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }
    }
}