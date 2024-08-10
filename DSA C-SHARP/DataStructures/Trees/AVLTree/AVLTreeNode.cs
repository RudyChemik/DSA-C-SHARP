using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Trees.AVLTree
{
    public class AVLTreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public AVLTreeNode<T>? Left { get; set; }
        public AVLTreeNode<T>? Right { get; set; }
        public int Height { get; set; }

        public AVLTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}
