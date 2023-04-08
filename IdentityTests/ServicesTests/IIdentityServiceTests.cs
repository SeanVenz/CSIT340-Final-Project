using Identity;
using Identity.Country;
using Identity.Gender;
using Identity.Generation;
using Identity.Generation.GenerationType;
using Identity.Services.Identity;
using Moq;

namespace IdentityTests.ServicesTests
{
    public class IIdentityServiceTests
    {
        private readonly Mock<IAgifyClient> _agiftClient;
        private readonly Mock<IGenderizeClient> _genderizeClient;
        private readonly Mock<INationalizeClient> _nationalizeClient;
        private readonly Mock<IGenerationFactory> _generationFactory;
        private readonly IIdentityService _identityService;

        public IIdentityServiceTests()
        {
            _agiftClient = new Mock<IAgifyClient>();
            _genderizeClient = new Mock<IGenderizeClient>();
            _nationalizeClient = new Mock<INationalizeClient>();
            _generationFactory = new Mock<IGenerationFactory>();
            _identityService = new IdentityService(_agiftClient.Object, _genderizeClient.Object, _nationalizeClient.Object, _generationFactory.Object);
        }

        [Fact]
        public async Task GetIdentity_ExistingIdentiy_ReturnsIdentity()
        {
            //Arrage
            var testName = new ClientResponse()
            {
                Name = "Jhon",
                Gender = "male",
                Country = "CO",
                Age = 51,
                AgeBracket = "Gen X"
            };

            _agiftClient.Setup(x => x.GetAge(testName.Name)).ReturnsAsync(new AgeResponse { Age = 51 });
            _genderizeClient.Setup(x => x.GetGender(testName.Name)).ReturnsAsync(new GenderResponse { Gender = "male" });
            _nationalizeClient.Setup(x => x.GetCountry(testName.Name)).ReturnsAsync(new NationalityResponse { Country = new List<Country> { new Country { Country_Id = "CO" } } });
            _generationFactory.Setup(x => x.GetGeneration(testName.Age)).Returns(new GenXGeneration());

            
            //Act
            var response = await _identityService.GetIdentity(testName.Name);

            //Assert
            Assert.Equal(testName.Name, response.Name);
            Assert.Equal(testName.Gender, response.Gender);
            Assert.Equal(testName.Country, response.Country);
            Assert.Equal(testName.Age, response.Age);
            Assert.Equal(testName.AgeBracket, response.AgeBracket);
        }
    }
}
