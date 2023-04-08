using Identity.Country;
using Identity.Gender;
using Identity.Generation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Identity.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IAgifyClient _agiftClient;
        private readonly IGenderizeClient _genderizeClient;
        private readonly INationalizeClient _nationalizeClient;
        private readonly IGenerationFactory _generationFactory;

        public IdentityService(IAgifyClient agifyClient, IGenderizeClient genderizeClient, INationalizeClient nationalizeClient, IGenerationFactory generationFactory)
        {
            _agiftClient = agifyClient;
            _genderizeClient = genderizeClient;
            _nationalizeClient = nationalizeClient;
            _generationFactory = generationFactory;
        }

        public async Task<ClientResponse> GetIdentity(string name)
        {
            var ageResponse = await _agiftClient.GetAge(name);
            var genderRespone = await _genderizeClient.GetGender(name);
            var response = await _nationalizeClient.GetCountry(name);
            var generationResponse = _generationFactory.GetGeneration(ageResponse.Age).GetGeneration();

            var clientResponse = new ClientResponse()
            {
                Name = name,
                Gender = genderRespone.Gender,
                Age = ageResponse.Age,
                AgeBracket = generationResponse,
                Country = response.Country[0].Country_Id
            };

            return clientResponse;
        }

    }
}
