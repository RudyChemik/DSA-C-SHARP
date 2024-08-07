using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Algorithms.Sorting

{
    /// <summary>
    /// -- -- BUBBLE SORT -- --  
    ///    time complexity: O(n2)  
    /// </summary>
    /// 
    public class BubbleSort<T>
    {
        /// <summary>
        ///     -- -- BUBBLE SORT  --  -- 
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        public static void Sort(T[] array, IComparer<T> comparer)
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }



    }
}
