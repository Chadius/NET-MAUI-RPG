using MAUI_RPG;
using Moq;

namespace StringLibraryXUnitTest
{
    public class UnitTest1
    {
        private Mock<IRandomIntegerGenerator>? _randomIntegerGeneratorMock;

        public UnitTest1()
        {
            _randomIntegerGeneratorMock = new Mock<IRandomIntegerGenerator>();
        }

        [Theory]
        [InlineData("Alphabet")]
        [InlineData("Zebra")]
        [InlineData("ABC")]
        [InlineData("Αθήνα")]
        [InlineData("Москва")]
        public void TestStartsWithUpper(string word)
        {
            bool result = word.StartsWithUpper();
            Assert.True(result,
                    string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
        }

        [Theory]
        [InlineData("alphabet")]
        [InlineData("zebra")]
        [InlineData("abc")]
        [InlineData("αυτοκινητοβιομηχανία")]
        [InlineData("государство")]
        [InlineData("1234")]
        [InlineData(".")]
        [InlineData(";")]
        [InlineData(" " )]
        public void TestDoesNotStartWithUpper(string word)
        {
            bool result = word.StartsWithUpper();
            Assert.False(result,
                    string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
        }

        [Fact]
        public void DirectCallWithNullOrEmpty()
        {
            // Tests that we expect to return false.
            string?[] words = { string.Empty, null };
            foreach (var word in words)
            {
                bool result = StringLibrary.StartsWithUpper(word);
                Assert.False(result,
                       string.Format("Expected for '{0}': false; Actual: {1}",
                                     word == null ? "<null>" : word, result));
            }
        }

        [Theory]
        [InlineData(0, "a")]
        [InlineData(12, "m")]
        [InlineData(13, "n")]
        [InlineData(25, "z")]
        public void GenerateRandomLetterIsPredictableBasedOnRandom(Int32 mockResult, string expectedLetter)
        {
            Assert.NotNull(_randomIntegerGeneratorMock);
            _randomIntegerGeneratorMock.Setup(p => p.Next(It.IsAny<Int32>())).Returns(mockResult);

            string randomLetter = StringLibrary.GenerateRandomLetter(_randomIntegerGeneratorMock.Object);
            Assert.Equal(expectedLetter, randomLetter);
        }
    }
}
