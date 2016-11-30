using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public InsertionSorter(T[] array) : base(array)
        {
        }

        public override void Sort()
        {
            for (int i = 1; i < array.Length; i++)
            {
                InsertInOrder(i);
            }
        }

        private void InsertInOrder(int indexUnsorted)
        {
            T temp = array[indexUnsorted];
            int currentIndex = indexUnsorted - 1;

            while(currentIndex >= 0 && temp.CompareTo(array[currentIndex]) < 0)
            {
                array[currentIndex + 1] = array[currentIndex];
                currentIndex--;
            }
            array[currentIndex + 1] = temp; ;

        }
    }
}
