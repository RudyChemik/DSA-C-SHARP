using DSA_C_SHARP.Algorithms.Sorting;
using DSA_C_SHARP.Tests.Tests.Algorithms.Sorting.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.Algorithms.Sorting
{
    public class InsertionSortTests : SortingBaseTests
    {
        protected override void Sort<T>(T[] array, IComparer<T> comparer)
        {
            var insertion = new InsertionSort<T>();
            insertion.Sort(array, comparer);
        }
    }
}
