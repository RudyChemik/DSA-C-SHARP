using DSA_C_SHARP.DataStructures.Trees.BinarySearchTree__BST_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.String.PrefixTree
{
    public class TrieNode
    {
        public char Value { get; set; }
        public bool IsLeaf { get; set; }
        public SortedList<char, TrieNode> Children { get; set; }
        public TrieNode(char value)
        {
            Value = value;
            Children = new SortedList<char, TrieNode>();
            IsLeaf = false;
        }

        public TrieNode() : this(' ')
        {
        }

    }


}
