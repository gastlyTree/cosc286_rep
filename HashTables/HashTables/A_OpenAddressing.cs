using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public abstract class A_OpenAddressing<K, V>: A_Hashtable<K, V>
        where K : IComparable<K>
        where V : IComparable<V>
    {

        // used to get the increment value (varies based on the implementation
        protected abstract int GetIncrement(int iAttempt, K key);

        //Local instance of the prime number class
        private PrimeNumber pn = new PrimeNumber();

        //constructor to set up the hashtable array
        public A_OpenAddressing()
        {
            oDataArray = new object[pn.getNextPrime()];
        }

        public override void Add(K key, V vValue)
        {
            //How many attempts were made to increment
            int iAttempt = 1;
            //get the initial hash of the key
            int iInitialHash = HashFunction(key);
            // the current location 
            int iCurrentLocation = iInitialHash;
            //position where we add
            int iPositionToAdd = -1;

            //Loop until we encounter a null (end of collision chain)
            while(oDataArray[iCurrentLocation] != null)
            {

            }


        }

        public override void Remove(K key)
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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < oDataArray.Length; i++)
            {
                sb.Append("Bucket " + i + ": ");
                if (oDataArray[i] != null)
                {
                    if (oDataArray[i].GetType() == typeof(Tombstone))
                    {
                        sb.Append("Tombstone");
                    }
                    else
                    {
                        KeyValue<K, V> kv = (KeyValue<K, V>)oDataArray[i];
                        sb.Append(kv.Value.ToString());
                    }

                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
