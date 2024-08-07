using DSA_C_SHARP.DataStructures.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.Queue
{
    /// <summary>
    /// testing class for fifo queues
    /// </summary>
    public class ListQueueTests
    {
        private ListQueue<int> queue;

        /// <summary>
        /// initialization
        /// </summary>
        [SetUp]
        public void Setup()
        {
            queue = new ListQueue<int>();
        }

        /// <summary>
        /// Testing if circurality works correctly, 
        /// 1. push
        /// 2. pop
        /// 3. push
        /// </summary>
        /// 
        [Test]
        public void CircuralTest()
        {
            queue.Enque(1);
            queue.Enque(2);
            queue.Enque(3);

            int item1 = queue.Dequeue();
            int item2 = queue.Dequeue();

            queue.Enque(4);
            queue.Enque(5);

            Assert.That(queue.Dequeue(), Is.EqualTo(3));
            Assert.That(queue.Dequeue(), Is.EqualTo(4));
            Assert.That(queue.Dequeue(), Is.EqualTo(5));
            Assert.That(queue.IsEmpty(), Is.True);
        }

        /// <summary>
        /// Counter test
        /// </summary>
        [Test]
        public void CountTest()
        {
            queue.Enque(1);
            queue.Enque(2);

            Assert.That(queue.Count(), Is.EqualTo(2));
        }

        /// <summary>
        /// Checking if empty bool works fine
        /// </summary>
        [Test]
        public void IsEmptyTest()
        {
            Assert.That(queue.IsEmpty(), Is.True);
        }

        /// <summary>
        /// Checking for exceptions while queue is prompted to dequeue while being empty
        /// </summary>
        [Test]
        public void DequeueWhileEmptyTest()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void EnqueueTest()
        {
            queue.Enque(1);
            queue.Enque(2);
            queue.Enque(3);

            Assert.That(queue.Count(), Is.EqualTo(3));
        }

        [Test]
        public void DequeueTest()
        {
            queue.Enque(1);
            queue.Enque(2);
            queue.Enque(3);

            int item1 = queue.Dequeue();
            int item2 = queue.Dequeue();
            int item3 = queue.Dequeue();

            Assert.That(item1, Is.EqualTo(1));
            Assert.That(item2, Is.EqualTo(2));
            Assert.That(item3, Is.EqualTo(3));
            Assert.That(queue.Count(), Is.EqualTo(0));
            Assert.That(queue.IsEmpty(), Is.True);
        }
    }
}
