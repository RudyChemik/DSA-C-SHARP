using DSA_C_SHARP.Algorithms.Sorting;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] array1 = new int[1000];
        Random random = new Random();
        Comparer<int> comparer = Comparer<int>.Default;

        for (int i = 0; i < 1000; i++)
        {
            array1[i] = random.Next(1, 9999);
        }

        SelectionSort<int> xd = new SelectionSort<int>();
        xd.Sort(array1, comparer);

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(array1[i]);
        }
    }
}
