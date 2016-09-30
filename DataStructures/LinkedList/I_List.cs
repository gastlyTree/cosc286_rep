using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    public interface I_List<T>: I_Collection<T> where T : IComparable<T>
    {
        /// <summary>
        /// Returns the element at a particular index
        /// </summary>
        /// <param name="index">The index of the item defined</param>
        /// <returnsThe item at index></returns>
        T Elementat(int index);

        /// <summary>
        /// Geven a data item, find it's first instance and return the index
        /// </summary>
        /// <param name="data">the item to find</param>
        /// <returns>The index of the item found</returns>
        int Indexof(T data);

        /// <summary>
        /// Insert an item at a particular location
        /// </summary>
        /// <param name="index">Location to insert at</param>
        /// <param name="data">Item to insert</param>
        void Insert(int index, T data);

        /// <summary>
        /// Remove an element at a particular location
        /// </summary>
        /// <param name="index">Index of item to remove</param>
        /// <returns>Item that was removed</returns>
        T RemoveAt(int index);

        /// <summary>
        /// replace existing data item with the one passed in
        /// </summary>
        /// <param name="index">location of item to be replaced</param>
        /// <param name="data">data item to replace existing one</param>
        /// <returns>Existing data item that was replaced</returns>
        T ReplaceAt(int index, T data);
       
    }
}
