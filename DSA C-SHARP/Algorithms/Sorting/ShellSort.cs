using System;
using System.Collections.Generic;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    /// -- -- SHELL SORT -- --  
    ///    time complexity: O(nlog n) 
    /// </summary>
    /// 
    public class ShellSort<T>
    {
        /// <summary>
        /// -- -- SHELL SORT -- --  
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        /// 
        public void Sort(T[] array, IComparer<T> comparer)
        {
            int n = array.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = array[i];
                    int j = i;

                    while (j >= gap && comparer.Compare(array[j - gap], temp) > 0)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }

                    array[j] = temp;
                }

                gap /= 2;
            }
        }
    }
}
