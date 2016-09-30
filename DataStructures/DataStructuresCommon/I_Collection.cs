using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresCommon
{
    //This collection uses generics. the generic type T must be IComparable
    public interface I_Collection<T>: IEnumerable<T> where T:IComparable<T>
    {
        /// <summary>
        /// Adds the given data to the collection
        /// </summary>
        /// <param name="data">Item to add</param>
        void Add(T data);

        /// <summary>
        /// Removes all items from the collection
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines if this data structure contains the element passed in
        /// </summary>
        /// <param name="data">Data item to find</param>
        /// <returns>True if found else false</returns>
        bool Contains(T data);

        /// <summary>
        /// Remove the first instace of a value if it exists
        /// </summary>
        /// <param name="data">Item to remove</param>
        /// <returns>True if removed else false</returns>
        bool Remove(T data);

        /// <summary>
        /// Determines if this data structure is equal to another one
        /// </summary>
        /// <param name="other">Data structure to compare</param>
        /// <returns>True if equal else false</returns>
        bool Equals(object other);

        /// <summary>
        /// a C# property that returns the number of elements in the collection
        /// </summary>
        int Count
        {
            get;
        }
    }
}
