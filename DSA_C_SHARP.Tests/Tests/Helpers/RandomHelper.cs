using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random rnd = new Random();

        public static int[] GetRandomArray(int n)
        {
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(1, 10000);
            }
            return array;
        }
    }
}
