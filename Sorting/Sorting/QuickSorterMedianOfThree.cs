using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSorterMedianOfThree<T> : QuickSorter<T> where T : IComparable<T>
    {
        public QuickSorterMedianOfThree(T[] array) : base(array)
        {
        }

        //override the method that finds the pivot
        protected override int FindPivot(int first, int last)
        {
            int mid = (first + last) / 2;
            if (array[first].CompareTo(array[mid]) > 0)
            {
                Swap(first, mid);
            }
            if (array[first].CompareTo(array[last]) > 0)
            {
                Swap(first, last);
            }
            if (array[mid].CompareTo(array[last]) > 0)
            {
                Swap(mid, last);
            }
            return mid;
        }
    }
}
