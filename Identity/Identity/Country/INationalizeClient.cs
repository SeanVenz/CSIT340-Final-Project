using Refit;

namespace Identity.Country
{
    public interface INationalizeClient
    {
        /// <summary>
        /// Uses Refit to call the Nationalize API from
        /// https://api.nationalize.io/ and returns only the country
        /// </summary>
        /// <param name="name">Name of the user/client</param>
        /// <returns>returns the country of the Client</returns>
        [Get("/")]
        Task<NationalityResponse> GetCountry(string name);
    }
}
