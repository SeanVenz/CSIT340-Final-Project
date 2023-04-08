using Refit;

namespace Identity.Gender
{
    public interface IGenderizeClient
    {
        /// <summary>
        /// Uses Refit to call the Genderize API from
        /// https://api.genderize.io/ and returns only
        /// the Gender
        /// </summary>
        /// <param name="name">Name of the user/client</param>
        /// <returns>Gender of the Client</returns>
        [Get("/")]
        Task<GenderResponse> GetGender(string name);
    }
}
