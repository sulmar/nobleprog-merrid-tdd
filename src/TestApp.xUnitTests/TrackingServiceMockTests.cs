using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestApp.Mocking;
using static TestApp.Mocking.TrackingService;

namespace TestApp.xUnitTests
{
    public class TrackingServiceMockTests
    {
        [Fact]
        public void Get_ValidFile_ShoudReturnsLocation()
        {
            // Arrange
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();

            mockFileReader
                .Setup(fr => fr.Get(It.IsAny<string>()))
                .Returns(JsonSerializer.Serialize(new Location(40.712776, -74.005974)));

            IFileReader fileReader = mockFileReader.Object;

            TrackingService trackingService = new TrackingService(fileReader);

            // Act
            var result = trackingService.Get();

            // Assert
            Assert.Equal(40.712776, result.Latitude);
            Assert.Equal(-74.005974, result.Longitude);
        }

        [Fact]
        public void Get_InvalidFile_ShoudThrowsApplicationException()
        {
            // Arrange
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();

            mockFileReader
                .Setup(fr => fr.Get(It.IsAny<string>()))
                .Returns("a");

            IFileReader fileReader = mockFileReader.Object;

            TrackingService trackingService = new TrackingService(fileReader);

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<ApplicationException>(act);
        }
    }
}
