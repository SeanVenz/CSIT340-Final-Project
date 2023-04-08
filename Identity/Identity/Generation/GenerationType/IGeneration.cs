namespace Identity.Generation.GenerationType
{
    public interface IGeneration
    {
        /// <summary>
        /// returns the generation of the clients
        /// </summary>
        public string GetGeneration();
    }
}
