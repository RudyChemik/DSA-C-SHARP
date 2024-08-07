using DSA_C_SHARP.DataStructures.Queue;
using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.Queue
{
    public class ArrayQueueTests
    {
        private ArrayQueue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new ArrayQueue<int>(3);
        }

        [Test]
        public void EnqueueTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.That(queue.Count(), Is.EqualTo(3));
            Assert.That(queue.IsFull(), Is.True);
        }

        [Test]
        public void DequeueTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int item1 = queue.Dequeue();
            int item2 = queue.Dequeue();
            int item3 = queue.Dequeue();

            Assert.That(item1, Is.EqualTo(1));
            Assert.That(item2, Is.EqualTo(2));
            Assert.That(item3, Is.EqualTo(3));
            Assert.That(queue.Count(), Is.EqualTo(0));
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void EnqueueWhileOverflowedTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Throws<InvalidOperationException>(() => queue.Enqueue(4));
        }

        [Test]
        public void DequeueWhileEmptyTest()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void IsFullTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.That(queue.IsFull(), Is.True);
        }

        [Test]
        public void CountTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CircuralTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int item1 = queue.Dequeue();
            int item2 = queue.Dequeue();

            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.IsEmpty(), Is.True);
        }
    }
}
