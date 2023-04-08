using Identity.Generation.GenerationType;

namespace Identity.Generation
{
    public interface IGenerationFactory
    {
        /// <summary>
        /// Call the IGeneration interface and gets the generation of the Client 
        /// </summary>
        /// <param name="age">Name of the user/client</param>
        /// <returns>returns the age generation of the Client</returns>
        IGeneration GetGeneration(int age);
    }
}
