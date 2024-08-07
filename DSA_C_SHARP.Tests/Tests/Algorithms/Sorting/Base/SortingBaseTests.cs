using DSA_C_SHARP.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.Algorithms.Sorting.Base
{
    /// <summary>
    /// This is a base sorting test class which acts for every integer-based sort algo
    /// </summary>
    public abstract class SortingBaseTests
    {
        protected abstract void Sort<T>(T[] array, IComparer<T> comparer);

        /// <summary>
        /// This test will check normal work flow correctness
        /// </summary>
        /// <param name="Random - int n">This will generate random length of the array to sort, 
        /// will go for 100 times as setted and test will be runned the same number of times for each n.</param>
        [Test]
        public void SortsNonEmptyArray([Random(1, 10000, 100, Distinct = true)] int n)
        {
            // Arrange
            var comparer = Comparer<int>.Default;
            var testArray = RandomHelper.GetRandomArray(n);
            var correctArray = (int[])testArray.Clone();

            // Act
            Sort(testArray, comparer);
            Array.Sort(correctArray);

            // Assert
            Assert.That(testArray, Is.EqualTo(correctArray));
        }

        /// <summary>
        /// Checking how algos work when the empty array is presented
        /// </summary>
        [Test]
        public void SortsEmptyArray()
        {

            var comparer = Comparer<int>.Default;
            var testArray = Array.Empty<int>();

            Sort(testArray, comparer);

            Assert.That(testArray, Is.Empty);
        }

        /// <summary>
        /// Checking for single integer array.
        /// </summary>
        [Test]
        public void SortsSingleElementArray()
        {

            var comparer = Comparer<int>.Default;
            var testArray = new[] { 1 };

            Sort(testArray, comparer);

            Assert.That(testArray, Is.EqualTo(new[] { 1 }));
        }

        /// <summary>
        /// Checking correctness for array containing same values
        /// </summary>
        [Test]
        public void SortsIdenticalElementsArray()
        {

            var comparer = Comparer<int>.Default;
            var identicalValue = 42;
            var size = 100;
            var testArray = new int[size];
            Array.Fill(testArray, identicalValue);
            var correctArray = (int[])testArray.Clone();

            Sort(testArray, comparer);

            Assert.That(testArray, Is.EqualTo(correctArray));
        }

        [Test]
        public void SortsDescendingArray()
        {

            var comparer = Comparer<int>.Default;
            var n = 100;
            var testArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                testArray[i] = n - i;
            }
            var correctArray = (int[])testArray.Clone();

            Sort(testArray, comparer);
            Array.Sort(correctArray);

            Assert.That(testArray, Is.EqualTo(correctArray));
        }
    }
}

