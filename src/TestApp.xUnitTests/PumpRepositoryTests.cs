using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Samples;

namespace TestApp.xUnitTests
{
    public class PumpRepositoryTests
    {
        [Fact]
        public void GetPumpsByArea_AreaNotEmpty_ShouldReturnsList()
        {
            // Arrange
            PumpRepository repository = new PumpRepository();

            // Act
            List<Pump> result = repository.GetPumpsByArea("PLOAD");

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
