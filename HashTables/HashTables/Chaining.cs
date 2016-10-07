using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    //Note that this implementation of a hash table uses an 
    //ArrayList for secondary storage

    public class Chaining<K, V> : A_Hashtable<K, V>
        where K : IComparable<K>
        where V : IComparable<V>
    {
        //Track the buckets that are containing ArrayLists
        private int iBucketCount = 0;

        //initial Table Size
        private const int iInitialSize = 4;

        #region Constructors
        public Chaining()
        {
            //Set up the initial array according tot he default size
            oDataArray = new object[iInitialSize];
            //load factor will be set to the default of 0.72
        }

        public Chaining(int iInitialSize, double dLoadFactor)
        {
            //allow for the user to pass in an initial size and load factor.
            this.oDataArray = new object[iInitialSize];
            this.dLoadFactor = dLoadFactor;
        }
        #endregion
        
        public override void Add(K key, V vValue)
        {
            throw new NotImplementedException();
        }

        public override V Get(K key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<V> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override void Remove(K key)
        {
            throw new NotImplementedException();
        }
    }
}
