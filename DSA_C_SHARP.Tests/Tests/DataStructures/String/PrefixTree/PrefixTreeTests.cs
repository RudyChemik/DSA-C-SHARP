using DSA_C_SHARP.DataStructures.String.PrefixTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.String.PrefixTree
{
    public class PrefixTreeTests
    {
        private Trie trie;

        [SetUp]
        public void Setup()
        {
            trie = new Trie();
            trie.Insert("apple");
            trie.Insert("app");
            trie.Insert("apparance");
            trie.Insert("bat");
            trie.Insert("ball");
            trie.Insert("baller");
        }

        [Test]
        public void GettingWordsByPrefixesReturnExpectedWordList()
        {
            var expForAP = new List<string> { "apple", "app", "apparance" };
            var expForBA = new List<string> { "bat", "ball", "baller" };

            var wordsAP = trie.GetWordsWithPrefix("ap");
            var wordsBA = trie.GetWordsWithPrefix("ba");

            Assert.That(wordsAP, Is.EquivalentTo(expForAP));
            Assert.That(wordsBA, Is.EquivalentTo(expForBA));
        }

        [Test]
        public void GettingWordsWithNonExistingPrefixes()
        {
            var res = trie.GetWordsWithPrefix("zaz");

            Assert.That(res, Is.Empty);
        }

        [Test]
        public void GettingWordsWithEmptyPrefixReturnWholeTrie()
        {
            var expOutput = new List<string> { "apple", "app", "apparance", "bat", "ball", "baller" };

            var res = trie.GetWordsWithPrefix("");

            Assert.That(res, Is.EquivalentTo(expOutput));
        }

        [Test]
        public void SingleCharPrefixes()
        {
            var expWordsA = new List<string> { "apple", "app", "apparance" };
            var expWordsB = new List<string> { "bat", "ball", "baller" };

            var wordsA = trie.GetWordsWithPrefix("a");
            var wordsB = trie.GetWordsWithPrefix("b");

            Assert.That(wordsA, Is.EquivalentTo(expWordsA));
            Assert.That(wordsB, Is.EquivalentTo(expWordsB));
        }

        [Test]
        public void GettingWholeWords()
        {
            var exp = new List<string> { "baller" };

            var res = trie.GetWordsWithPrefix("baller");

            Assert.That(res, Is.EquivalentTo(exp));
        }
    }
}
