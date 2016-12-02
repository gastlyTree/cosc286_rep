using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public QuickSorter(T[] array) : base(array)
        {
        }

        public override void Sort()
        {
            QuickSortRec(0, array.Length - 1);
        }

        private void QuickSortRec(int first, int last)
        {
            //base case, 1 element - do nothing
            //recursive case to or more elements
            if(last - first > 0)
            {
                //find the location of the pivot
                int pivotIndex = FindPivot(first, last);
                //move the pivot to the rightmost position
                Swap(pivotIndex, last);
                //partition releative to the pivot value
                int partitionIndex = Partition(first - 1, last, array[last]);
                //swap the pivot into its correct location
                Swap(partitionIndex, last);
                //quickSort the array left of the pivot pivot
                QuickSortRec(first, partitionIndex - 1);
                //quicksort hte array right of the index
                QuickSortRec(partitionIndex + 1, last);

            }
        }

        /// <summary>
        /// Partitions the array defined by left and right
        /// </summary>
        /// <param name="left">One location tot he left of its normal starting point</param>
        /// <param name="right">one location to the right of ints normal starting position</param>
        /// <param name="pivotValue">the value of the pivot</param>
        /// <returns>the partition index (where L and R meet)</returns>
        private int Partition(int left, int right, T pivotValue)
        {
            do
            {
                //move left pointer until we find a value greater than the pivot
                while (array[++left].CompareTo(pivotValue) < 0) ;
                while (right > left && array[--right].CompareTo(pivotValue) > 0) ;
                Swap(left, right);
            } while (left < right);
            return left;
        }

        /// <summary>
        /// Set up as a virtual method, so we can override it in a child class
        /// </summary>
        /// <param name="first">Start of the array</param>
        /// <param name="last">End of the array</param>
        /// <returns>The location of the pivot</returns>
        protected virtual int FindPivot(int first, int last)
        {
            return (first + last) / 2;
        }
    }
}
