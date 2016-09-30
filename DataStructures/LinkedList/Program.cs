using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> myList = new LinkedList<int>();
            myList.Add(10);
            myList.Add(2);
            myList.Add(7);
            myList.Add(3);

            Console.WriteLine(myList);
            Console.WriteLine(myList.Indexof(7));

            //myList.Insert(4, 2);
            //Console.WriteLine(myList.RemoveAt(2));

            //Console.WriteLine(myList);
        }
    }
}
