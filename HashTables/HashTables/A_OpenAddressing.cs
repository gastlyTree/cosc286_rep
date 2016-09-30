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

    }
}
