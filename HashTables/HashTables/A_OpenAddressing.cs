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

        protected abstract int GetIncrement(int iAttempt, K key);

        private PrimeNumber pn = new PrimeNumber();
 
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
            while (oDataArray[iCurrentLocation] != null)
            {
                //if the current value is a key-value pair
                if (oDataArray[iCurrentLocation].GetType() == typeof(keyValue<K, V>))
                {
                    //Check to see if the current value is the same key
                    //as the value we are adding
                    keyValue<K, V> kv = (keyValue<K, V>)oDataArray[iCurrentLocation];
                    if (kv.Key.CompareTo(key) == 0)
                    {
                        throw new ApplicationException("Item already exists");

                    }
                }
                else //its a tombstone
                {
                    if (iPositionToAdd == -1)
                    {
                        iPositionToAdd = iCurrentLocation;
                    }

                }
                //Increment to the next location
                iCurrentLocation = iInitialHash + GetIncrement(iAttempt++, key);
                //Loop back up to the top of the table, if we fall off the bottom
                iCurrentLocation %= HTSize;

                iNumCollisions++;

            }
            //if we have not found a position to add
            if(iPositionToAdd == -1)
            {
                //Initial hash location was null
                iPositionToAdd = iCurrentLocation;
            }

            //add the key-value pair
            keyValue<K, V> kvNew = new keyValue<K, V>(key, vValue);
            oDataArray[iPositionToAdd] = kvNew;
            iCount++;

            if(IsOverLoaded())
            {
                ExpandHashTable();
            }

        }

        private void ExpandHashTable()
        {
            //Create a referance to the existing data
            object[] oOldArray = oDataArray;
            //Create a new array, with the next prime number size
            oDataArray = new object[pn.getNextPrime()];
            //reset the attributes
            iCount = 0;
            iNumCollisions = 0;

            //loop through the existing table a re-hash each item
            for (int i = 0; i < oOldArray.Length; i++)
            {
                if(oOldArray[i] != null)
                {
                    //if it is a KV pair 
                    if(oOldArray[i].GetType() == typeof(keyValue<K,V>))
                    {
                        //get a referance to the current key value pair
                        keyValue<K, V> kv = (keyValue<K,V>)oOldArray[i];
                        this.Add(kv.Key, kv.Value);
                    }
                }
            }


        }

        private bool IsOverLoaded()
        {
            return iCount / (Double) HTSize > dLoadFactor;
        }

        public override void Remove(K key)
        {
            //Get the hash code
            int iInitialHash = HashFunction(key);
            //Current location we are looking at in the collision chain
            int iCurrentLocation = iInitialHash;
            //how many attempts were made to increment
            int iAttempt = 1;
            //indicator that the item was found
            bool iFound = false;

            while (oDataArray[iCurrentLocation] != null && !iFound)
            {
                //if the current value is a key-value pair
                if (oDataArray[iCurrentLocation].GetType() == typeof(keyValue<K, V>))
                {

                    if (oDataArray[iCurrentLocation].GetType() == typeof(keyValue<K, V>))
                    {
                        //it is a key value
                        keyValue<K, V> kv = (keyValue<K, V>)oDataArray[iCurrentLocation];
                        //Is it the key value we are looking for
                        if (kv.Key.CompareTo(key) == 0)
                        {
                            //indicate that it is found and overwrite it with a tombstone
                            iFound = true;
                            Tombstone tStone = new Tombstone();
                            oDataArray[iCurrentLocation] = tStone;
                            iCount--;
                        }
                    }
                    //increment to next location
                    iCurrentLocation = iInitialHash + GetIncrement(iAttempt++, key);
                    iCurrentLocation %= HTSize;
                }
                iNumCollisions++;

            }
            if (!iFound)
            {
                throw new ApplicationException("Key does no exist in the table");
            }
        }

        public override V Get(K key)
        {
            //Get the hash code
            int iInitialHash = HashFunction(key);
            //Current location we are looking at in the collision chain
            int iCurrentLocation = iInitialHash;
            //how many attempts were made to increment
            int iAttempt = 1;
            //indicator that the item was found
            bool iFound = false;

            V vReturn = default(V);

            while (oDataArray[iCurrentLocation] != null && !iFound)
            {
                //if the current value is a key-value pair
                if (oDataArray[iCurrentLocation].GetType() == typeof(keyValue<K, V>))
                {
                   
                    if (oDataArray[iCurrentLocation].GetType() == typeof (keyValue<K,V>))
                    {
                        //it is a key value
                        keyValue<K, V> kv = (keyValue<K, V>)oDataArray[iCurrentLocation];
                        //Is it the key value we are looking for
                        if (kv.Key.CompareTo(key) == 0)
                        {
                            //indicate that it is found and set the return value
                            iFound = true;
                            vReturn = kv.Value;
                        }
                    }
                    //increment to next location
                    iCurrentLocation = iInitialHash + GetIncrement(iAttempt++, key);
                    iCurrentLocation %= HTSize;
                }
                iNumCollisions++;

            }
            if (!iFound)
            {
                throw new ApplicationException("Key does no exist in the table");
            }
            return vReturn;

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
                        keyValue<K, V> kv = (keyValue<K, V>)oDataArray[i];
                        sb.Append(kv.Value.ToString() + " IH = " + HashFunction(kv.Key));
                    }

                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
