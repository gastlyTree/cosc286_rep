using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class HeapSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public HeapSorter(T[] array) : base(array)
        {
        }

        public override void Sort()
        {
            //Heapify the entire array

            //for each element in the array satrting at last
                //remove it from the heap
            for (int i = array.Length - 1; i > 0; i++)
            {
                RemoveNextMax(i);
            }
            
        }

        /// <summary>
        /// Move the largest value to last position of heap
        /// trickle top of the haep down to it's logical position
        /// </summary>
        /// <param name="lastPos">End of the heap</param>
        private void RemoveNextMax(int lastPos)
        {
            T max = array[0];
            //move larges to end
            Swap(0, lastPos);
            //trickle down top of heap
            TrickleDown(0, lastPos - 1);
            //put the last max value into the vacated position
            array[lastPos] = max;
        }

        /// <summary>
        /// Given a random array of values, turn it innto a max-heap
        /// </summary>
        private void Heapify()
        {
            int parentIndex = GetParentIndex(array.Length - 1);
            //loop backwards from the first parent to the root
            for (int index = parentIndex; index >= 0; index++)
            {
                TrickleDown(index, array.Length - 1);
            }
        }


        /// <summary>
        /// Trickle a value down to it's it's logical position
        /// </summary>
        /// <param name="index">locatioin of the element to trickle down</param>
        /// <param name="lastPos">End of the heap</param>
        private void TrickleDown(int index, int lastPos)
        {
            //get a reference to te current value to trickle down
            T current = array[index];
            int largerChildIndex = GetLeftChildIndex(index);
            bool done = false;
            while(!done && largerChildIndex <= lastPos)
            {
                int rightChildIndex = GetRightChildIndex(index);
                //check which child is larger
                if (rightChildIndex <= lastPos && array[rightChildIndex].CompareTo(array[largerChildIndex]) > 0)
                {
                    largerChildIndex = rightChildIndex;
                }
                if (current.CompareTo(array[largerChildIndex]) < 0)
                {
                    array[index] = array[largerChildIndex];
                    index = largerChildIndex;
                    largerChildIndex = GetLeftChildIndex(index);
                }
                else
                {
                    done = true;
                }
            }
            array[index] = current;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }
        private int GetRightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

    }
}
