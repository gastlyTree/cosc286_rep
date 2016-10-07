using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public abstract class A_Hashtable<K, V> : I_Hashtable<K, V>
        where K : IComparable<K>
        where V : IComparable<V>
    {

        //In the case of chaining, this array will store secondary data structures.
        //in this call, we will use ArrayLists
        //in the case of open addressing (probing algorithms) they array will
        //store the key-value pairs directly
        protected object[] oDataArray;

        //store the number of elements in the array
        protected int iCount;

        //Load Factor - used to track the maximum percentage full that we will
        //allow  the array to fill.
        //The factor 0.72 is used by Microsoft for their hashtable.
        protected double dLoadFactor = 0.72;

        //Collision count - mostly for stats 
        protected int iNumCollisions = 0;

        #region Properties
        public int Count
        {
            get
            {
                return iCount;
            }

        }

        public int NumCollisions
        {
            get
            {
                return iNumCollisions;
            }
        }

        public int HTSize
        {
            get
            {
                return oDataArray.Length;
            }
        }
        #endregion

        #region Hash Function
        
        /// <summary>
        /// Given a key, return an integer within the indices of the array
        /// </summary>
        /// <param name="key">key of the data</param>
        /// <returns>Initial location in the array</returns>
        protected int HashFunction(K key)
        {
            //All objects in the C# world have a GetHashCode method
            //Note that later on, our key can override the GethashCode method.
            return Math.Abs(key.GetHashCode() % HTSize);
        }

        #endregion

        #region I_Hashtable Implementation

        public abstract void Add(K key, V vValue);

        public abstract V Get(K key);

        public abstract void Remove(K key);

        public void Clear()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Enumerator
        public abstract IEnumerator<V> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
