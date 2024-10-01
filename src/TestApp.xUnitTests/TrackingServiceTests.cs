using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestApp.Mocking;

namespace TestApp.xUnitTests
{
    public class FakeValidFileReader : IFileReader
    {
        public string Get(string path)
        {
            var location = new TrackingService.Location(40.712776, -74.005974);
           
            string json = JsonSerializer.Serialize(location);

            return json;
        }
    }

    public class FakeInvalidFileReader : IFileReader
    {
        public string Get(string path)
        {
            string json = "a";

            return json;
        }
    }

    public class TrackingServiceTests
    {
        [Fact]
        public void Get_ValidFile_ShoudReturnsLocation()
        {
            // Arrange
            IFileReader fileReader = new FakeValidFileReader();

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
            IFileReader fileReader = new FakeInvalidFileReader();
            TrackingService trackingService = new TrackingService(fileReader);

            // Act
            Action act = () =>  trackingService.Get();

            // Assert
            Assert.Throws<ApplicationException>(act);
        }
    }
}
