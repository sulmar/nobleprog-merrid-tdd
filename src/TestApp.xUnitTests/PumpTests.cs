using TestApp.Fundamentals;

namespace TestApp.xUnitTests
{
    public class PumpTests
    {
        [Fact]
        public void Pump_Created_ShouldSetSetIsGroundedToFalse()
        {
            // Arrange

            // Act
            Pump pump = new Pump(0);

            // Assert
            Assert.False(pump.IsGrounded);
        }

        [Fact]
        public void Start_IsGrounded_ShouldSetIsRunningToTrue()
        {
            // Arrange
            Pump pump = new Pump(1);
            pump.Ground();

            // Act
            pump.Start();

            // Assert
            Assert.True(pump.IsRunning);
        }

        [Fact]
        public void Start_IsNotGrounded_ShouldThrowsInvalidOperationException()
        {
            // Arrange
            Pump pump = new Pump(1);

            // Act
            Action act = () => pump.Start();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void Stop_IsRunning_ShouldSetIsRunningToFalse()
        {
            // Arrange
            Pump pump = new Pump(1);
            pump.Ground();
            pump.Start();

            // Act
            pump.Stop();

            // Assert
            Assert.False(pump.IsRunning);
        }

        [Fact]
        public void Stop_IsNotRunning_ShouldSetIsRunningToFalse()
        {
            // Arrange
            Pump pump = new Pump(1);

            // Act
            pump.Stop();

            // Assert
            Assert.False(pump.IsRunning);
        }
    }
}
