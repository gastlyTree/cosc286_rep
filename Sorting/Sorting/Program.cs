using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        /// <summary>
        /// Runs the sort on an array. Displays how long the sort took as well
        /// </summary>
        /// <param name="Sorter"></param>
        public static void TestSorter(ASorter<int> Sorter)
        {
            //display the sorter type and how many elements it has
            Console.WriteLine(Sorter.GetType().Name + " with " + Sorter.Length + " elements.");
            //Display the array if it is shoter or equal to 50 elements
            if(Sorter.Length <= 50)
            {
                Console.WriteLine("Before sort:\n + " + Sorter);
            }

            //Calculate roughly how long it takes to sort
            long startTime = Environment.TickCount;
            Sorter.Sort();
            long endTime = Environment.TickCount;

            //Displaythe sorted array if it is shoter or equal to 50 elements
            if (Sorter.Length <= 50)
            {
                Console.WriteLine("After sort:\n + " + Sorter);
            }
            //display the time elapsed
            Console.WriteLine("Sort took " + (endTime - startTime) + " miliseconds");
        }

        public static void SorterTest()
        {
            Console.WriteLine("Enter the number of elements");
            String input = Console.ReadLine();
            int arraySize = Int32.Parse(input);
            int[] array = new int[arraySize];
            //seed the random nummber generator to get a different sequence every time
            Random r = new Random(Environment.TickCount);
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = r.Next(array.Length * 100);
            }
            //TestSorter(new InsertionSorter<int>(array) );
            TestSorter(new HeapSorter<int>(array));
        }

        static void Main(string[] args)
        {
            SorterTest();
        }
    }
}
