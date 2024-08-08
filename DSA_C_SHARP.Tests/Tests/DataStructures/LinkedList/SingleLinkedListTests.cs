using DSA_C_SHARP.DataStructures.LinkedList.SingleLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.LinkedList
{
    public class SingleLinkedListTests
    {
        private SingleLinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new SingleLinkedList<int>();
        }

        [Test]
        public void AddingNotesInTheBeginning()
        {
            _list.AddFirst(10);
            _list.AddFirst(20);
            Assert.That(_list.Get(0), Is.EqualTo(20));
            Assert.That(_list.Get(1), Is.EqualTo(10));
        }

        [Test]
        public void AddingNodesAtTheBack()
        {
            _list.AddLast(10);
            _list.AddLast(20);
            Assert.That(_list.Get(0), Is.EqualTo(10));
            Assert.That(_list.Get(1), Is.EqualTo(20));
        }

        [Test]
        public void RemovingFirstNodes()
        {
            _list.AddLast(10);
            _list.AddLast(20);
            _list.DeleteFirst();
            Assert.That(_list.Get(0), Is.EqualTo(20));
        }

        [Test]
        public void RemovingLastNodes()
        {
            _list.AddLast(10);
            _list.AddLast(20);
            _list.DeleteLast();
            Assert.That(_list.Get(0), Is.EqualTo(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => _list.Get(1));
        }

        [Test]
        public void DeletingFirstWhileEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _list.DeleteFirst());
        }

        [Test]
        public void DeletingLastWhileEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _list.DeleteLast());
        }

        [Test]
        public void GettingNodes()
        {
            _list.AddLast(10);
            _list.AddLast(20);
            Assert.That(_list.Get(0), Is.EqualTo(10));
            Assert.That(_list.Get(1), Is.EqualTo(20));
        }

        [Test]
        public void GettingNodesInvalidIndex()
        {
            _list.AddLast(10);
            Assert.Throws<ArgumentOutOfRangeException>(() => _list.Get(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _list.Get(1));
        }

        [Test]
        public void GettingLength()
        {
            Assert.That(_list.Length(), Is.EqualTo(0));
            _list.AddLast(10);
            Assert.That(_list.Length(), Is.EqualTo(1));
            _list.AddLast(20);
            Assert.That(_list.Length(), Is.EqualTo(2));
        }
    }
}

