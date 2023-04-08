using Identity.Generation.GenerationType;
using Xunit;

namespace Identity.Generation.Tests
{
    public class GenerationFactoryTests
    {
        [Fact]
        public void GetGeneration_ValidGenarationType_ReturnsExpectedGenerationType()
        {
            // Arrange
            var factory = new GenerationFactory();
            var testCases = new Dictionary<int, Type>
            {
                { 0, typeof(GenAlphaGeneration) },
                { 9, typeof(GenAlphaGeneration) },
                { 10, typeof(GenZGeneration) },
                { 25, typeof(GenZGeneration) },
                { 26, typeof(MillennialsGeneration) },
                { 41, typeof(MillennialsGeneration) },
                { 42, typeof(GenXGeneration) },
                { 57, typeof(GenXGeneration) },
                { 58, typeof(BoomersIIGeneration) },
                { 67, typeof(BoomersIIGeneration) },
                { 68, typeof(BoomersIGeneration) },
                { 76, typeof(BoomersIGeneration) },
                { 77, typeof(PostWarGeneration) },
                { 94, typeof(PostWarGeneration) },
                { 95, typeof(WWIIGeneration) }
            };

            // Act and Assert
            foreach (var testCase in testCases)
            {
                var age = testCase.Key;
                var expectedType = testCase.Value;
                var generation = factory.GetGeneration(age);
                Assert.IsType(expectedType, generation);
            }
        }
    }
}
