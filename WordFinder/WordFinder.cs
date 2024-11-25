using DataStructures;

namespace BusinessRules
{
    public class WordFinder: IWordFinder
    {
        private readonly Trie trie;
        public WordFinder(IEnumerable<string> matrix)
        {
            trie = new Trie();
            List<string> words = Utilities.GenerateColumns(matrix);
            words.AddRange(matrix);
            foreach(string word in words)
            {
                for(int i = 0; i< word.Length; i++)
                {
                    trie.Add(word.Substring(i, word.Length - i));
                }
            }
        }
        IEnumerable<string> IWordFinder.Find(IEnumerable<string> wordStream)
        {
            var foundWords = new Dictionary<string, int>();

            foreach (var word in wordStream)
            {
                if (trie.Find(word))
                {
                    if (foundWords.ContainsKey(word))
                        foundWords[word]++;
                    else
                        foundWords[word] = 1;
                }
            }
            return foundWords.OrderByDescending(x => x.Value)
                             .Take(10)
                             .Select(x => x.Key);
        }
    }
}
