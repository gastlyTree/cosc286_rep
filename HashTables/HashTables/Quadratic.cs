using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class Quadratic<K, V> : A_OpenAddressing<K, V>
        where K : IComparable<K>
        where V : IComparable<V>
    {
        protected override int GetIncrement(int iAttempt, K key)
        {
            double c1 = 0.5;
            double c2 = 0.5; //cannot be 0.

            //Implement the formula for quadratic
            return (int)(c1 * iAttempt + c2 * Math.Pow(iAttempt, 2));       
        }

        public Quadratic()
        {
            //Recall that the load factor must be 50% max to avoid
            //potential endless loops. This problem only applies to
            //quadratic implementations.
            this.dLoadFactor = 0.5;
        }

    }
}
