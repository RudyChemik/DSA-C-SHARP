using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    ///     -- -- QUICK SORT  --  --
    ///     time complexity: O(n log(n)) AVG!  
    /// </summary>
    ///
    public class QuickSort<T>
    {
        /// <summary>
        /// -- -- QUICK SORT -- --
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer to use for comparing elements</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            if (array == null || array.Length == 0)
                return;

            QuickSorter(array, 0, array.Length - 1, comparer);
        }

        /// <summary>
        /// -- Recursive quicksort --
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="lowIndex" name="highIndex">Current lowest and highest indexes from sorted array (1st iteration ex. 0 - array.Length)</param>
        private void QuickSorter(T[] array, int lowIndex, int highIndex, IComparer<T> comparer)
        {
            if (lowIndex < highIndex)
            {
                int pivotIndex = Partition(array, lowIndex, highIndex, comparer);
                QuickSorter(array, lowIndex, pivotIndex - 1, comparer);
                QuickSorter(array, pivotIndex + 1, highIndex, comparer);
            }
        }

        /// <summary>
        /// Rearaging array by chosen pivot.
        /// Elems smaller left side, greater right side
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="lowIndex" name="highIndex">Current lowest and highest indexes </param>
        /// <returns> The index of the pivot </returns>
        private int Partition(T[] array, int lowIndex, int highIndex, IComparer<T> comparer)
        {
            T pivot = array[highIndex];
            int i = lowIndex - 1;

            for (int j = lowIndex; j < highIndex; j++)
            {
                if (comparer.Compare(array[j], pivot) <= 0)
                {
                    i++;
                    Swapper(array, i, j);
                }
            }

            Swapper(array, i + 1, highIndex);
            return i + 1;
        }

        /// <summary>
        /// -- Helper to swap elements in the array --
        /// </summary>
        /// <param name="array">Array where it will take place </param>
        /// <param name="index1" name="index2">Indexes of swapping elems. </param>
        private void Swapper(T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
