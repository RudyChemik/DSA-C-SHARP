using System;
using System.Collections.Generic;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    ///     -- -- RADIX SORT (INT) --  --
    ///     time complexity: O(n*d) AVG!  
    /// </summary>
    ///
    public class RadixSort<T>
    {
        /// <summary>
        /// -- -- RADIX SORT -- --
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer to use for comparing elements</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            if (typeof(T) != typeof(int))
            {
                throw new ArgumentException("Implemented for integers o n l y");
            }

            int[] intArray = Array.ConvertAll(array, item => Convert.ToInt32(item));
            int maxNumber = GetMax(intArray);

            for (int exp = 1; maxNumber / exp > 0; exp *= 10)
            {
                CountingSort(intArray, exp);
            }

            // Convert back to T[]
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (T)Convert.ChangeType(intArray[i], typeof(T));
            }
        }

        private int GetMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        private void CountingSort(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10]; //since dealing withh digits

            for (int i = 0; i < n; i++)
                count[(array[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
                array[i] = output[i];
        }
    }
}
