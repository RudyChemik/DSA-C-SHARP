using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Trees.BinarySearchTree__BST_
{
    /// <summary>
    /// Binary search tree implementation
    /// </summary>
    public class BST<T> where T : IComparable<T>
    {
        //"head" of the tree - top node.
        private BSTNode<T>? root;

        /// <summary>
        /// Constructor of the bst class, creating empty bst
        /// </summary>
        public BST()
        {
            root = null;
        }

        /// <summary>
        /// Adding new node to the bst,
        /// </summary>
        /// <param name="key">Key of the new node, which will be inserted into the structure</param>>
        public void Insert(T key)
        {
            root = InsertRec(root, key);
        }

        /// <summary>
        /// Recurency method for insering new node.
        /// </summary>
        /// <param name="node">currently checked node -> for the 1st iteration its root.</param>>
        /// <param name="key">new node insering key</param>
        /// <returns>BSTnode, which will become new root node</returns>>
        private BSTNode<T> InsertRec(BSTNode<T>? node, T key)
        {
            if (node == null)
            {
                node = new BSTNode<T>(key);
                return node;
            }

            //comparing inserting key to the node key, if the value is greater then 0 call recurency method for the right node
            //we are calling right node beacuse in bst the keys bigger then the current nodes key are stored always from the right side
            if (key.CompareTo(node.Key) < 0)
                node.Left = InsertRec(node.Left, key);

            else if (key.CompareTo(node.Key) > 0)
                node.Right = InsertRec(node.Right, key);

            return node;
        }

        /// <summary>
        /// Searching for the key in the bst rree
        /// </summary>
        /// <param name="key">key we are searching for</param>
        /// <returns>Searched bts node</returns>>
        public BSTNode<T>? Search(T key)
        {
            return SearchRec(root, key);
        }

        /// <summary>
        /// Recursive method for searching
        /// </summary>
        /// <param name="key">key we are searching for</param>
        /// <param name="node">root node</param>>
        /// <returns>Searched bts node</returns>>
        private BSTNode<T>? SearchRec(BSTNode<T>? node, T key)
        {
            //found searched node -> return
            if (node == null || node.Key.CompareTo(key) == 0)
                return node;

            //smaller, search left side
            if (key.CompareTo(node.Key) < 0)
                return SearchRec(node.Left, key);

            //def -> bigger, search righ side
            return SearchRec(node.Right, key);
        }

        /// <summary>
        /// Recursive method for going through the tree in order, along with printing the values into the console
        /// </summary>
        public void InOrderTraversal()
        {
            InOrderTraversalRec(root);
        }

        private void InOrderTraversalRec(BSTNode<T>? node)
        {
            if (node != null)
            {
                InOrderTraversalRec(node.Left);
                Console.WriteLine(node.Key + " ");
                InOrderTraversalRec(node.Right);
            }
        }

        /// <summary>
        /// Recursive method for getting the maximum value of the bst
        /// </summary>
        public BSTNode<T>? GetMax() 
        {
            return GetMaxRecu(root);
        }

        private BSTNode<T>? GetMaxRecu(BSTNode<T>? node) 
        {
            if (node == null || node.Right == null)
            {
                return node;
            }

            return GetMaxRecu(node.Right);
        }

        /// <summary>
        /// Recursive method for getting the minimum value of the bst
        /// </summary>
        public BSTNode<T>? GetMin()
        {
            return GetMinRecu(root);
        }

        private BSTNode<T>? GetMinRecu(BSTNode<T>? node)
        {
            if (node == null || node.Left == null)
            {
                return node;
            }

            return GetMinRecu(node.Left);
        }


    }
}
