using DSA_C_SHARP.DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.Stack
{
    public class ListStackTests
    {
        private ListStack<int> stack;

        [SetUp]
        public void Setup()
        {
            stack = new ListStack<int>();
        }

        [Test]
        public void CircuralTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int item1 = stack.Pop();
            int item2 = stack.Pop();

            stack.Push(4);
            stack.Push(5);

            Assert.That(stack.Pop(), Is.EqualTo(5));
            Assert.That(stack.Pop(), Is.EqualTo(4));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.IsEmpty(), Is.True);
        }

        [Test]
        public void CountTest()
        {
            stack.Push(1);
            stack.Push(2);

            Assert.That(stack.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.That(stack.IsEmpty(), Is.True);
        }

        [Test]
        public void EnqueueTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.That(stack.Count(), Is.EqualTo(3));
        }

        [Test]
        public void DequeueTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int item1 = stack.Pop();
            int item2 = stack.Pop();
            int item3 = stack.Pop();

            Assert.That(item1, Is.EqualTo(3));
            Assert.That(item2, Is.EqualTo(2));
            Assert.That(item3, Is.EqualTo(1));
            Assert.That(stack.Count(), Is.EqualTo(0));
            Assert.That(stack.IsEmpty(), Is.True);
        }
    }
}
