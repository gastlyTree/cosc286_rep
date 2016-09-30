using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class Program
    {

        public static void testAdd(A_Hashtable<int, string> ht)
        {
            ht.Add(1234, "Rob");
            ht.Add(1334, "Bob");
            ht.Add(1434, "Dob");
            ht.Add(1224, "Mob");
            ht.Add(1244, "Ron");

            Console.WriteLine(ht.ToString());
        }

        static void Main(string[] args)
        {
            Linear<int, string> ht = new Linear<int, string>();
            testAdd(ht);
        }
    }
}
