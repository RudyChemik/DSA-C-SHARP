using System;
using System.Collections.Generic;

namespace DSA_C_SHARP.Algorithms.Sorting
{
    /// <summary>
    /// -- -- TIM SORT -- --  
    ///    time complexity: O(n log n)  
    /// </summary>
    /// 
    public class TimSort<T>
    {    
        private const int RUN = 32; // MIN SIZE OF A RUN

        /// <summary>
        /// -- -- TIM SORT -- --  
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="comparer">Comparer</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            int n = array.Length;

            for (int i = 0; i < n; i += RUN)
            {
                InsertionSort(array, i, Math.Min(i + RUN - 1, n - 1), comparer);
            }

            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    if (mid < right)
                        Merge(array, left, mid, right, comparer);
                }
            }
        }

        private void InsertionSort(T[] array, int left, int right, IComparer<T> comparer)
        {
            for (int i = left + 1; i <= right; i++)
            {
                T temp = array[i];
                int j = i - 1;

                while (j >= left && comparer.Compare(array[j], temp) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        private void Merge(T[] array, int left, int mid, int right, IComparer<T> comparer)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            //temps
            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];

            for (int i = 0; i < n1; i++)
                leftArray[i] = array[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = array[mid + 1 + j];

            int k = left;
            int l = 0, r = 0;
            while (l < n1 && r < n2)
            {
                if (comparer.Compare(leftArray[l], rightArray[r]) <= 0)
                {
                    array[k] = leftArray[l];
                    l++;
                }
                else
                {
                    array[k] = rightArray[r];
                    r++;
                }
                k++;
            }


            while (l < n1)
            {
                array[k] = leftArray[l];
                l++;
                k++;
            }

            while (r < n2)
            {
                array[k] = rightArray[r];
                r++;
                k++;
            }
        }

    }
}
