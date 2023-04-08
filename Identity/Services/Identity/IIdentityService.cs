namespace Identity.Services.Identity
{
    public interface IIdentityService
    {
        /// <summary>
        /// Get the identity of a person
        /// </summary>
        /// <param name="name">Name of the person that would be the basis in gettting the Identity</param>
        /// <returns>
        /// A client response containing the identity of the person :
        ///     1. Name
        ///     2. Gender
        ///     3. Country
        ///     4. Age
        ///     5. AgeBracket
        /// </returns>
        Task<ClientResponse> GetIdentity(string name);
    }
}