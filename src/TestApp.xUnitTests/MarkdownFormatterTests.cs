using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.xUnitTests
{
    public class MarkdownFormatterTests
    {
        const string NotEmpty = "a";

        [Fact]
        public void FormatAsBold_ContentIsNull_ShouldThrowNullArgumentException()
        {
            // Arrange
            MarkdownFormatter formatter = new MarkdownFormatter();

            // Act
            Action act = () => formatter.FormatAsBold(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void FormatAsBold_ContentIsEmpty_ShouldThrowArgumentException()
        {
            // Arrange
            MarkdownFormatter formatter = new MarkdownFormatter();

            // Act
            Action act = () => formatter.FormatAsBold(string.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("Lorem ipsum")]
        public void FormatAsBold_ContentIsNotEmpty_ShouldReturnsWithDoubleAsterix(string content)
        {
            // Arrange
            MarkdownFormatter formatter = new MarkdownFormatter();
          
            // Act
            string result = formatter.FormatAsBold(content);

            // Assert
            Assert.StartsWith("**", result);
            Assert.Contains(content, result);
            Assert.EndsWith("**", result);
        }


    }
}
