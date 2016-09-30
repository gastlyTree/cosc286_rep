using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class keyValue<K,V>
        where K : IComparable<K>
        where V : IComparable<V>
    {
        //Store the key
        K kKey;
        //Store the value
        V vValue;

        public keyValue (K key, V value)
        {
            kKey = key;
            vValue = value;
        }

        public K Key
        {
            get
            {
                return kKey;
            }
        }

        public V Value
        {
            get
            {
                return vValue;
            }
        }

        public override bool Equals(object obj)
        {
            keyValue<K, V> kv = (keyValue<K, V>)obj;
            return this.Key.CompareTo(kv.Key) == 0;
        }
    }
}
