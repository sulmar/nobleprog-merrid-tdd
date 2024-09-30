using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.xUnitTests
{
    public class LoggerTests
    {
        const string MessageNotEmpty = "a";

        [Fact]
        public void Log_MessageNotEmpty_ShouldSetLastMessage()
        {
            // Arrange
            Logger logger = new Logger();

            // Act
            logger.Log(MessageNotEmpty);

            // Assert
            Assert.Equal(MessageNotEmpty, logger.LastMessage);
        }
    }
}
