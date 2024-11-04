using App.Service;
using Xunit;

namespace Starkit.TechnicalTest.Names.API.Tests.Services
{
   

    public class NameServiceTests
    {
        [Fact]
        public void GetNames_WithValidFilters_ReturnsFilteredNames()
        {
            // Arrange
            var service = new NameService();

            // Act
            var result = service.GetNames("M", "J");

            // Assert
            Assert.NotNull(result);
            Assert.All(result, name => Assert.StartsWith("J", name.Name));
            Assert.All(result, name => Assert.Equal("M", name.Gender));
        }
    }

}
