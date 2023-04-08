using Identity;
using Identity.Controllers;
using Identity.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace IdentityTests.Controllers
{
    public class IdentityControllerTests
    {
        private readonly IdentityController _controller;
        private readonly Mock<IIdentityService> _mockIdentityService;
        private readonly Mock<ILogger<IdentityController>> _logger;

        public IdentityControllerTests()
        {
            _mockIdentityService = new Mock<IIdentityService>();
            _logger = new Mock<ILogger<IdentityController>>();
            _controller = new IdentityController(_mockIdentityService.Object, _logger.Object);
        }

        [Fact]
        public async Task GetIdentity_ValidIdentity_ReturnsCorrectClientResponse()
        {
            // Arrange
            var testName = new ClientResponse()
            {
                Name = "Jhon",
                Gender = "male",
                Country = "CO",
                Age = 51,
                AgeBracket = "Gen X"
            };

            _mockIdentityService.Setup(x => x.GetIdentity(It.IsAny<string>())).ReturnsAsync(testName);

            // Act
            var response = await _controller.GetIdentity(testName.Name);

            // Assert
            Assert.IsType<OkObjectResult>(response);
            var okObject = response as OkObjectResult;

            Assert.IsType<ClientResponse>(okObject!.Value);
            var clientResponse = okObject!.Value as ClientResponse;

            Assert.Equal(testName.Name, clientResponse!.Name);
        }

        [Fact]
        public async Task GetIdentity_InvalidIdentity_ReturnsBadRequest()
        {
            // Arrange
            var expectedResult = new ClientResponse()
            {
                Name = "Jhon",
                Gender = "male",
                Country = "CO",
                Age = 51,
                AgeBracket = "Gen X"
            };

            _mockIdentityService.Setup(x => x.GetIdentity(It.IsAny<string>())).ReturnsAsync(expectedResult);

            // Act
            var response = await _controller.GetIdentity("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task GetIdentity_ServerError_ReturnsServerError()
        {
            // Arrange
            var testName = new ClientResponse()
            {
                Name = "Jhon",
                Gender = "male",
                Country = "CO",
                Age = 51,
                AgeBracket = "Gen X"
            };

            _mockIdentityService.Setup(x => x.GetIdentity(It.IsAny<string>())).Throws(new Exception());

            // Act
            var response = await _controller.GetIdentity(testName.Name);

            // Assert
            Assert.IsType<ObjectResult>(response);
            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }
    }
}