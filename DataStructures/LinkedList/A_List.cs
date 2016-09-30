using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    public abstract class A_List<T> : A_Collection<T>, I_List<T> where T : IComparable<T>
    {
        #region Abstract Methods

        public abstract void Insert(int index, T data);

        public abstract T RemoveAt(int index);

        public abstract T ReplaceAt(int index, T data);

        #endregion

        public T Elementat(int index)
        {
            int curentIndex = 0;
            bool found = false;
            T value = default(T);
            //Get an instance of the enumerator
            IEnumerator<T> myEnum = GetEnumerator();
            //Begin enumerating at the start of the collection
            myEnum.Reset();

            while (!found && myEnum.MoveNext())
            {
                
                if(curentIndex == index)
                {
                    found = true;
                    value = myEnum.Current;
                }
                curentIndex++;
            }

            return value;
        }

        public int Indexof(T data)
        {
            int index = 0;
            bool found = false;
            //Get an instance of the enumerator
            IEnumerator<T> myEnum = GetEnumerator();
            //Begin enumerating at the start of the collection
            myEnum.Reset();

            while (!found && myEnum.MoveNext())
            {
                
                found = myEnum.Current.Equals(data);
                if(!found)
                {
                    index++;
                }
            }
            return index;
        }
    }
}
