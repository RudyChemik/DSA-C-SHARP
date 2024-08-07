using System;
using System.Collections.Generic;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    /// -- -- BOGO SORT -- --  
    ///    time complexity: O(n2)  
    /// </summary>
    /// 
    public class BogoSort<T>
    {
        private Random rnd = new Random();

        /// <summary>
        ///     -- -- BOGO SORT  --  -- 
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            while (!IsSorted(array, comparer))
            {
                Shuffle(array);
            }
        }

        /// <summary>
        /// Rng shuffle
        /// </summary>
        private void Shuffle(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = rnd.Next(array.Length);
                T temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        /// <summary>
        /// Checking if the array is sorted
        /// </summary>
        private bool IsSorted(T[] array, IComparer<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
