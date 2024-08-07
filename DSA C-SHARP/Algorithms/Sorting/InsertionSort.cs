using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    /// -- -- INSERTION SORT -- --  
    ///    time complexity: O(n^2) 
    /// </summary>
    /// 
    public class InsertionSort<T>
    {
        /// <summary>
        /// -- -- INSERTION SORT -- -- 
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        /// 
        public void Sort(T[] array, IComparer<T> comparer)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= 0 && comparer.Compare(array[j], key) > 0)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }


    }
}
