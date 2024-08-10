using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Trees.AVLTree
{
    /// <summary>
    /// AVL tree implementation
    /// </summary>
 
    //TODO COMMENTS
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTreeNode<T> root;

        public AVLTree()
        {
            root = null;
        }

        public void Insert(T value)
        {
            root = InsertRec(root, value);
        }

        private AVLTreeNode<T> InsertRec(AVLTreeNode<T> node, T value)
        {
            if (node == null)
                return new AVLTreeNode<T>(value);

            int compare = value.CompareTo(node.Value);

            if (compare < 0) {

                node.Left = InsertRec(node.Left, value);

            }else if (compare > 0) {

                node.Right = InsertRec(node.Right, value);

            }else{

                return node;

            }

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            return Rebalance(node);
        }

        public void Remove(T value)
        {
            root = Remove(root, value);
        }

        private AVLTreeNode<T> Remove(AVLTreeNode<T> node, T value)
        {
            if (node == null)
                return node;

            int compare = value.CompareTo(node.Value);

            if (compare < 0) {
                node.Left = Remove(node.Left, value);

            }else if (compare > 0)
            {
                node.Right = Remove(node.Right, value);
            }
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    AVLTreeNode<T> temp = node.Left ?? node.Right;

                    if (temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                {
                    AVLTreeNode<T> temp = GetMin(node.Right);
                    node.Value = temp.Value;
                    node.Right = Remove(node.Right, temp.Value);
                }
            }

            if (node == null)
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            return Rebalance(node);
        }

        public T GetMin()
        {
            return GetMin(root).Value;
        }

        private AVLTreeNode<T> GetMin(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }

        public T GetMax()
        {
            return GetMax(root).Value;
        }

        private AVLTreeNode<T> GetMax(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> current = node;

            while (current.Right != null)
                current = current.Right;

            return current;
        }

        private AVLTreeNode<T> Rebalance(AVLTreeNode<T> node)
        {
            int balance = GetBalance(node);

            if (balance > 1 && GetBalance(node.Left) >= 0){
                return RightRotate(node);
            }

            if (balance > 1 && GetBalance(node.Left) < 0){
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0) {
                return LeftRotate(node);
            }
                

            if (balance < -1 && GetBalance(node.Right) > 0){
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private int GetHeight(AVLTreeNode<T> node)
        {
            return node?.Height ?? 0;
        }

        public int GetBalance(AVLTreeNode<T> node)
        {
            if (node == null)
                return 0;

            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLTreeNode<T> RightRotate(AVLTreeNode<T> y)
        {
            AVLTreeNode<T> x = y.Left;
            AVLTreeNode<T> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> x)
        {
            AVLTreeNode<T> y = x.Right;
            AVLTreeNode<T> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }
    }
   
}
