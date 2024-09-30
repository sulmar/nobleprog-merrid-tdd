using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.UnitTests
{
    [TestClass]
    public class MarkdownFormatterTests
    {
        const string NotEmpty = "a";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatAsBold_ContentIsNull_ShouldThrowNullArgumentException()
        {
            // Arrange
            MarkdownFormatter formatter = new MarkdownFormatter();

            // Act
            formatter.FormatAsBold(null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatAsBold_ContentIsEmpty_ShouldThrowArgumentException()
        {
            // Arrange
            MarkdownFormatter formatter = new MarkdownFormatter();

            // Act
            formatter.FormatAsBold(string.Empty);

            // Assert
        }

        [TestMethod]
        public void FormatAsBold_ContentIsNotEmpty_ShouldReturnsWithDoubleAsterix()
        {
            // Arrange
            MarkdownFormatter formatter = new MarkdownFormatter();
          
            // Act
            string result = formatter.FormatAsBold(NotEmpty);

            // Assert
            Assert.AreEqual("**a**", result);
        }
    }
}
