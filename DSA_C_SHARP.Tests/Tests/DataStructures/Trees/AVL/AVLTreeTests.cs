using DSA_C_SHARP.DataStructures.Trees.AVLTree;
using DSA_C_SHARP.DataStructures.Trees.BinarySearchTree__BST_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.Trees.AVL
{
    public class AVLTreeTests
    {
        AVLTree<int> tree;

        [SetUp]
        public void SetUp() 
        {
            tree = new AVLTree<int>();
        }

        [Test]
        public void InsertShouldAdd()
        {
            tree.Insert(10);

            Assert.That(tree.GetMin(), Is.EqualTo(10));
            Assert.That(tree.GetMax(), Is.EqualTo(10));
        }

        [Test]
        public void MinMaxShouldWork()
        {
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            Assert.That(tree.GetMin(), Is.EqualTo(10));
            Assert.That(tree.GetMax(), Is.EqualTo(30));
        }

        [Test]
        public void RemoveShouldRemove()
        {
            tree.Insert(10);
            tree.Insert(20);
            tree.Remove(10);

            Assert.That(tree.GetMin(), Is.EqualTo(20));
            Assert.That(tree.GetMax(), Is.EqualTo(20));
        }

        [Test]
        public void RemoveNodeWithTwoChildsShouldRebalance()
        {
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Remove(20);

            Assert.That(tree.GetMin(), Is.EqualTo(10));
            Assert.That(tree.GetMax(), Is.EqualTo(30));
        }

        [Test]
        public void RemoveNodeWithOneChildsShouldRebalance()
        {
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(3);
            tree.Remove(5);

            Assert.That(tree.GetMin(), Is.EqualTo(3));
            Assert.That(tree.GetMax(), Is.EqualTo(10));
        }

        [Test]
        public void GetMinShouldReturnMin()
        {
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);

            Assert.That(tree.GetMin(), Is.EqualTo(5));
        }

        [Test]
        public void GetMaxShouldReturnMAX()
        {
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);

            Assert.That(tree.GetMax(), Is.EqualTo(20));
        }

        [Test]
        public void ShouldHaveAvlProps()
        {
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(20);
            tree.Insert(10);

            Assert.That(tree.GetMin(), Is.EqualTo(10));
            Assert.That(tree.GetMax(), Is.EqualTo(50));

            Assert.That(CheckAvlProps(tree), Is.True);
        }

        private bool CheckAvlProps(AVLTree<int> tree)
        {
            return CheckAvlProps(tree.root);
        }

        private bool CheckAvlProps(AVLTreeNode<int> node)
        {
            if (node == null)
            {
                return true;
            }

            int balance = tree.GetBalance(node);

            if (balance < -1 || balance > 1)
            {
                return false;
            }

            return CheckAvlProps(node.Left) && CheckAvlProps(node.Right);
        }

    }
}
