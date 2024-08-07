using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    /// -- -- Selection Sort -- --
    ///     time complexity: O(n2)   
    /// </summary>
    public class SelectionSort<T>
    {
        /// <summary>
        /// -- -- Selection Sort -- --  
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        /// 
        public void Sort(T[] array, IComparer<T> comparer)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (comparer.Compare(array[j], array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                T temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}
