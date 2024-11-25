using BusinessRules;

namespace UnitTests
{
    public class WordFinderUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTwoWordsFound()
        {
            List<string> strings = new List<string>() { "ANAAB", "PEDRO", "JUANI" };
            IWordFinder wordFinder = new WordFinder(strings);
            List<string> words = new List<string>() { "CARLOS", "JUA", "AP" };
            IEnumerable<string> foundWords = wordFinder.Find(words);
            Assert.That( foundWords.Count().Equals(2));
            Assert.True(foundWords.Contains("JUA") && foundWords.Contains("AP"));
            Assert.Pass();
        }
        [Test]
        public void TestWordFoundManyTimes()
        {
            List<string> strings = new List<string>() { "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ" };
            IWordFinder wordFinder = new WordFinder(strings);
            List<string> words = new List<string>() { "CARLOS", "ANA" };
            IEnumerable<string> foundWords = wordFinder.Find(words);
            Assert.That(foundWords.Count().Equals(1));
            Assert.True(foundWords.Contains("CARLOS"));
            Assert.Pass();
        }
        [Test]
        public void TestReturnInOrderOfFound()
        {
            List<string> strings = new List<string>() { "XXXASDCARLOSJPRQ", "XXXASDCARANAJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", 
                "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCARLOSJPRQ", "XXXASDCALROSJPRQ", "XXXASDCARLSOJPRQ", "XXXASDMIGUELJPRQ" };
            IWordFinder wordFinder = new WordFinder(strings);
            List<string> words = new List<string>() { "XXX", "CARLOS", "ANA" };
            IEnumerable<string> foundWords = wordFinder.Find(words);
            Assert.That(foundWords.Count().Equals(3));
            Assert.True(foundWords.ToList().IndexOf("XXX") == 0);
            Assert.True(foundWords.ToList().IndexOf("CARLOS") == 1);
            Assert.True(foundWords.ToList().IndexOf("ANA") == 2);
            Assert.Pass();
        }
        [Test]
        public void TestFindHorizontalWords()
        {
            List<string> strings = new List<string>() { "XXXASDCARLOSJPRQ", "XXXASDANAAAAJPRQ", "XXXASDMIGUELJPRQ" };
            IWordFinder wordFinder = new WordFinder(strings);
            List<string> words = new List<string>() { "ANA", "CARLOS", "MIGUEL", "JOAQUIN" };
            IEnumerable<string> foundWords = wordFinder.Find(words);
            Assert.That(foundWords.Count().Equals(3));
            Assert.True(foundWords.Contains("ANA"));
            Assert.True(foundWords.Contains("CARLOS"));
            Assert.True(foundWords.Contains("MIGUEL"));
            Assert.False(foundWords.Contains("JOAQUIN"));
            Assert.Pass();
        }
        [Test]
        public void TestFoundVerticalWords()
        {
            //Arrange
            List<string> strings = new List<string>() { "JX", "AX", "VX", "IX", "EX", "RX" };
            IWordFinder wordFinder = new WordFinder(strings);
            List<string> words = new List<string>() { "JAVIER", "XXXX", "REIVAJ" };
            //Act
            IEnumerable<string> foundWords = wordFinder.Find(words);
            //Assert
            Assert.True(foundWords.Contains("JAVIER"));
            Assert.True(foundWords.Contains("XXXX"));
            Assert.That(foundWords.Count().Equals(2));
            Assert.Pass();
        }
    }
}