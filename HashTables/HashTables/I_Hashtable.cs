using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{

    //K --> Generic valule representing the data type of the key
    //v --> Generic valule representing the data type of the data stored
    public interface I_Hashtable<K,V>: IEnumerable<V>
        where K : IComparable<K>
        where V : IComparable<V>
    {
        /// <summary>
        /// Return a value from a hash table
        /// </summary>
        /// <param name="key">the key of the value to return</param>
        /// <returns>the value of the item found</returns>
        V Get(K key);

        /// <summary>
        /// Add the key and value as a key-value pair to the hash table
        /// </summary>
        /// <param name="key">Determines the location in the hashtable</param>
        /// <param name="vValue">value to store at that location</param>
        void Add(K key, V vValue);

        /// <summary>
        /// Remove the value asscociated with the key passed in
        /// </summary>
        /// <param name="key">Unique identifier of the element to remove</param>
        void Remove(K key);

        /// <summary>
        /// Romove all key-value pairs from the hashtable ind initialize to the default
        /// </summary>
        void Clear();
    }
}
