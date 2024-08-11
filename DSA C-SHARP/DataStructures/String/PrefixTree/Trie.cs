using System;
using System.Collections.Generic;

namespace DSA_C_SHARP.DataStructures.String.PrefixTree
{
    /// <summary>
    /// PREFIX TREE IMPLEMENTATION! also knows as TRIE.
    /// </summary>
    public class Trie
    {
        //root does not have any character.
        private TrieNode root;

        //constructor
        public Trie()
        {
            root = new TrieNode();
        }

        /// <summary>
        /// Inserting the word into the structure
        /// </summary>
        /// <param name="words">inserting word</param>>
        public void Insert(string word)
        {
            var currentNode = root;

            //foreach char in inserting word check if there is already node with given char
            //if not create
            foreach (char c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    currentNode.Children.Add(c, new TrieNode(c));
                }

                currentNode = currentNode.Children[c];
            }

            currentNode.IsLeaf = true;
        }

        /// <summary>
        /// Get all of the words with given prefix.
        /// </summary>
        /// <param name="prefix">prefix to get words from</param>>
        public List<string> GetWordsWithPrefix(string prefix)
        {
            //starting from the root 
            var currentNode = root;

            foreach (char c in prefix)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    return new List<string>(); //return empty as it didnt find any.
                }

                currentNode = currentNode.Children[c];
            }

            // Collect all words
            var words = new List<string>();

            DFS(currentNode, prefix, words);

            return words;
        }

        //DFS
        private void DFS(TrieNode node, string prefix, List<string> words)
        {
            if (node.IsLeaf)
            {
                words.Add(prefix);
            }

            foreach (var child in node.Children)
            {
                DFS(child.Value, prefix + child.Key, words);
            }
        }
    }
}
