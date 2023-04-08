using Identity.Generation.GenerationType;

namespace Identity.Generation
{
    public class GenerationFactory : IGenerationFactory
    {
        public IGeneration GetGeneration(int age)
        {
            IGeneration generation;

            if (age >= 0 && age <= 9)
            {
                generation = new GenAlphaGeneration();
            }
            else if (age >= 10 && age <= 25)
            {
                generation = new GenZGeneration();
            }
            else if (age >= 26 && age <= 41)
            {
                generation = new MillennialsGeneration();
            }
            else if (age >= 42 && age <= 57)
            {
                generation = new GenXGeneration();
            }
            else if (age >= 58 && age <= 67)
            {
                generation = new BoomersIIGeneration();
            }
            else if (age >= 68 && age <= 76)
            {
                generation = new BoomersIGeneration();
            }
            else if (age >= 77 && age <= 94)
            {
                generation = new PostWarGeneration();
            }
            else
            {
                generation = new WWIIGeneration();
            }
            return generation;
        }
    }
}
