using Refit;

namespace Identity
{
    public interface IAgifyClient
    {
        /// <summary>
        /// Uses Refit to call the Agify API from
        /// https://api.agify.io/ and returns only the age
        /// </summary>
        /// <param name="name">Name of the user/client</param>
        /// <returns>returns the age of the Client</returns>
        [Get("/")]
        Task<AgeResponse> GetAge(string name);
    }
}
