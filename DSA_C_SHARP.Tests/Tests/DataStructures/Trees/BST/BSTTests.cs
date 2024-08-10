using DSA_C_SHARP.DataStructures.Trees.BinarySearchTree__BST_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.Trees.BST
{
    public class BSTTests
    {
        BST<int> bst;
        [SetUp]
        public void Setup()
        {
            bst = new BST<int>();
        }

        [Test]
        public void InitialValueShouldBeRoot()
        {
            bst.Insert(50);

            var root = bst.Search(50);
            Assert.That(root, Is.Not.Null);
            Assert.That(root.Key, Is.EqualTo(50));
        }

        [Test]
        public void MaintainingBSTProperties()
        {

            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(60);
            bst.Insert(80);

            var node50 = bst.Search(50);
            var node30 = bst.Search(30);
            var node70 = bst.Search(70);
            var node20 = bst.Search(20);
            var node40 = bst.Search(40);
            var node60 = bst.Search(60);
            var node80 = bst.Search(80);

            Assert.That(node50, Is.Not.Null);
            Assert.That(node50.Key, Is.EqualTo(50));

            Assert.That(node30, Is.Not.Null);
            Assert.That(node30.Key, Is.EqualTo(30));
            Assert.That(node30.Left.Key, Is.EqualTo(20));
            Assert.That(node30.Right.Key, Is.EqualTo(40));

            Assert.That(node70, Is.Not.Null);
            Assert.That(node70.Key, Is.EqualTo(70));
            Assert.That(node70.Left.Key, Is.EqualTo(60));
            Assert.That(node70.Right.Key, Is.EqualTo(80));
        }

        [Test]
        public void SearchForExistingNode()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);

            var res = bst.Search(30);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Key, Is.EqualTo(30));
        }

        [Test]
        public void SearchForNonExistingNoe()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);

            var res = bst.Search(100);

            Assert.That(res, Is.Null);
        }

        [Test]
        public void GetMaxReturnMaxKey()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(80);

            var maxNode = bst.GetMax();

            Assert.That(maxNode, Is.Not.Null);
            Assert.That(maxNode.Key, Is.EqualTo(80));
        }

        [Test]
        public void GetMinReturnsMinKey()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(20);
            bst.Insert(70);

            var minNode = bst.GetMin();

            Assert.That(minNode, Is.Not.Null);
            Assert.That(minNode.Key, Is.EqualTo(20));
        }

        [Test]
        public void GetMaxEmpty()
        {
            var maxNode = bst.GetMax();

            Assert.That(maxNode, Is.Null);
        }

        [Test]
        public void GetMinEmpty()
        {

            var minNode = bst.GetMin();

            Assert.That(minNode, Is.Null);
        }
    }
}
