using System;
using System.Collections.Generic;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    /// -- -- COUNTING SORT -- --  
    ///    time complexity: O(n+k) as diff in keys
    /// </summary>
    /// 
    public class CountingSort<T>
    {
        /// <summary>
        ///     -- -- COUNTING SORT  --  --
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        public void Sort(T[] array, IComparer<T> comparer, Func<T, int> keySelector, int maxKey)
        {
            int n = array.Length;
            T[] output = new T[n];
            int[] count = new int[maxKey + 1];

            for (int i = 0; i <= maxKey; i++)
                count[i] = 0;

            for (int i = 0; i < n; i++)
                count[keySelector(array[i])]++;

            for (int i = 1; i <= maxKey; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int key = keySelector(array[i]);
                output[count[key] - 1] = array[i];
                count[key]--;
            }

            for (int i = 0; i < n; i++) {
                array[i] = output[i];
            }

        }
    }
}
