using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class Linear<K,V>: A_OpenAddressing<K,V>
        where K : IComparable<K>
        where V : IComparable<V>
    {
        protected override int GetIncrement(int iAttempt, K key)
        {
            int iIncrement = 1;
            return iIncrement * iAttempt;
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
            bool bRemoved = false;
            //Marker for the location of the item to be removed
            int locationOfItem = iInitialHash;
            bool stopSearchingForReplacement = false;

            while (!bRemoved)
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
                            //mark the location of the item to be removed
                            locationOfItem = iCurrentLocation;

                            //indicate that it is found and overwrite it with a tombstone
                            //bRemoved = true;
                           // Tombstone tStone = new Tombstone();
                           // oDataArray[iCurrentLocation] = tStone;
                            //iCount--;
                        }
                    }
                    //increment to next location
                    iCurrentLocation = iInitialHash + GetIncrement(iAttempt++, key);
                    iCurrentLocation %= HTSize;
                }
                iNumCollisions++;

                if (oDataArray[iCurrentLocation] == null)
                {
                    while(!stopSearchingForReplacement)
                    {
                        oDataArray[iCurrentLocation - 1].
                    }
                }

            }
            if (!bRemoved)
            {
                throw new ApplicationException("Key does no exist in the table");
            }
        }
    }
}
