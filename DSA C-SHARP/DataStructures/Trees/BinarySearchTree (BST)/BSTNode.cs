using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Trees.BinarySearchTree__BST_
{
    public class BSTNode<T> where T : IComparable<T>
    {
        public T Key { get; set; }
        public BSTNode<T>? Left { get; set; }
        public BSTNode<T>? Right { get; set; }

        public BSTNode(T key)
        {
            Key = key;
            Left = null;
            Right = null;
        }
    }
}
