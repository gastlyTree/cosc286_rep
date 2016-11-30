using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class ASorter<T> where T: IComparable<T>
    {
        //Array to sort
        protected T[] array;

        public ASorter(T [] array)
        {
            this.array = array;
        }

        #region Abstract methods

        public abstract void Sort();

        #endregion

        #region Helper Methods

        protected void Swap(int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public int Length
        {
            get { return array.Length; }
        }

        /// <summary>
        /// How to implement [] on a class
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        //Override toString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            foreach (T tVal in array)
            {
                sb.Append(tVal);
                sb.Append(", ");
            }

            if(sb.Length > 1)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            sb.Append("]");
            return sb.ToString();
        }


        #endregion
    }
}
