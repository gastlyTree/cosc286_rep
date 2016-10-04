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
            ht.Add(12, "Rob");
            ht.Add(134, "Bob");
            ht.Add(1, "Dob");
            ht.Add(1224, "nathan");
            ht.Add(14, "Nicholas");

            Console.WriteLine(ht.ToString());
        }

        static void Main(string[] args)
        {
            Linear<int, string> ht = new Linear<int, string>();
            testAdd(ht);
        }
    }
}
