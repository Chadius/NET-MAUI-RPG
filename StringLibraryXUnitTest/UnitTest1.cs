using MAUI_RPG;

namespace StringLibraryXUnitTest
{
    public class UnitTest1
    {
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
    }
}
