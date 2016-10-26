using System;
using System.Collections;
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
            //Determine the intitial position in the hash table
            int iInitialHash = HashFunction(key);
            //Create a key value pair object with the data passed in
            keyValue<K, V> kv = new keyValue<K, V>(key, vValue);

            //get a reference to the arraylist
            ArrayList alCurrent = null;

            //If the hashcode location does not contain an arraylist
            if(oDataArray[iInitialHash] == null)
            {
                alCurrent = new ArrayList();
                //instantiate a new arraylist
                oDataArray[iInitialHash] = alCurrent;
                //Increment the bucket count
                iBucketCount++;
            }
            else
            {
                //reference to the exsiting arraylist
                alCurrent = (ArrayList)oDataArray[iInitialHash];

                //If the current arraylist already contains a keyvalue with
                //the same key
                if(alCurrent.Contains(kv))
                {
                    throw new ApplicationException("Key already exists in the hashtable");
                }

                iNumCollisions++;
            }

            //Add the kv into the current arrayList
            alCurrent.Add(kv);
            //increment the count
            iCount++;

            //expand the hash table, if the current hashtable
            //is overloaded
            if(IsOverLoaded())
            {
                ExpandHashTable();
            }

        }

        private bool IsOverLoaded()
        {
            //Cst to a double so we don't do integer division
            return (double)iBucketCount / HTSize > dLoadFactor;
        }

        private void ExpandHashTable()
        {
            //Create a referance to the existing data
            object[] oOldArray = oDataArray;
            //Create a new array, with the next prime number size
            oDataArray = new object[HTSize * 2];
            //reset the attributes
            iCount = 0;
            iBucketCount = 0;
            iNumCollisions = 0;

            for (int i = 0; i < oOldArray.Length; i++)
            {
                if(oDataArray[i] != null)
                {
                    //Get reference to the array list
                    ArrayList alCurrent = (ArrayList)oOldArray[i];
                    //Loop through the arraylist
                    foreach(keyValue<K,V> kv in alCurrent)
                    {
                        //Add the key value pair tothe new array
                        Add(kv.Key, kv.Value);
                    }
                }
            }

        }

        /// <summary>
        /// Returns the value(v) associated with the key(K)
        /// throws an exception if not found
        /// </summary>
        /// <param name="key">The key of the value you want to get</param>
        /// <returns>The value associated with the given key</returns>
        public override V Get(K key)
        {
            V vReturn = default(V);

            //Determine the intitial position in the hash table
            int iHashCode = HashFunction(key);

            //get a reference to the arraylist
            ArrayList alCurrent = (ArrayList)oDataArray[iHashCode];
            //index of the value in the arraylist
            int iIndexOfValue = -1;
            if (oDataArray[iHashCode] != null)
            {
                //Get the item's index in the arraylist(returns -1 if not found)
                iIndexOfValue = alCurrent.IndexOf(new keyValue<K, V>(key, default(V)));
                //if the item is in the arraylist
                if(iIndexOfValue >=0)
                {
                    //Index into the arraylist to get the key/value pair object
                    //return it's value
                    vReturn = ((keyValue<K,V>)alCurrent[iIndexOfValue]).Value;

                    
                }
            }
            //if the value was not found
            if(iIndexOfValue == -1)
            {
                throw new ApplicationException("The key does not exist in the HashTable");
            }

            return vReturn;
        }

        public override void Remove(K key)
        {
            //get the hash code for this key
            int iHashCode = HashFunction(key);

            //get a reference to the arraylist
            ArrayList alCurrent = (ArrayList)oDataArray[iHashCode];
            //index of the value in the arraylist
            int iIndexOfValue = -1;
            if (alCurrent != null)
            {
                //Get the item's index in the arraylist(returns -1 if not found)
                iIndexOfValue = alCurrent.IndexOf(new keyValue<K, V>(key, default(V)));
                //if the item is in the arraylist
                if (iIndexOfValue >= 0)
                {
                    alCurrent.RemoveAt(iIndexOfValue);

                    if (alCurrent.Count == 0)
                    {
                        oDataArray[iHashCode] = null;
                        iBucketCount--;
                    }
                }
            }
            //if the value was not found
            if (iIndexOfValue == -1)
            {
                throw new ApplicationException("The key does not exist in the HashTable");
            }
        }

        #region Enumerator Implementations

        public override IEnumerator<V> GetEnumerator()
        {
            return new ChainingEnum(this);
        }

        private class ChainingEnum : IEnumerator<V>
        {
            Chaining<K, V> ht;
            keyValue<K, V> kv = null;
            ArrayList alCurrent;
            int iArrayListIndex = 0;
            int iCurrentBucket = -1;

            public ChainingEnum(Chaining<K, V> ht)
            {
                this.ht = ht;
            }

            public V Current
            {
                get
                {
                    return kv.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return kv.Value;
                }
            }

            public void Dispose()
            {
                ht = null;
            }

            public bool MoveNext()
            {
                //Could we move or not
                bool bFound = false;

                //Move to the next bucket
                iCurrentBucket++;

                //while not found and not at the end
                while (!bFound && iCurrentBucket < ht.HTSize)
                {
                    if (ht.oDataArray[iCurrentBucket] == null ||
                        ht.oDataArray[iCurrentBucket].GetType() == typeof(Tombstone))
                    {
                        iCurrentBucket++;
                    }
                    else
                    {
                        alCurrent = (ArrayList)ht.oDataArray[iCurrentBucket];
                        while(iArrayListIndex < alCurrent.Count)
                        {
                            kv = (keyValue<K, V>)alCurrent[iArrayListIndex];
                        }

                        bFound = true;

                    }
                }

                return bFound;
            }

            public void Reset()
            {
                iCurrentBucket = -1;
                kv = null;
            }
        }

        #endregion
    }
}
