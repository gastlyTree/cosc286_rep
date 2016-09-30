using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void testAdd(BST<int> myTree)
        {
            myTree.Add(10);
            myTree.Add(20);
            myTree.Add(25);
            

        }

        static void HandleAnInt(int x)
        {
            Console.Write(x + ", ");
        }

        static void testEnumerator(BST <int> myBST)
        {
            Console.WriteLine(myBST.ToString());
        }

        static void testIterateBreadth(BST<int> myBST)
        {
            myBST.IterateBreadth(HandleAnInt);
        }

        static void testGetHeightDifference()
        {

        }

        static void TestRandomTree()
        {
            long start = 0;
            long end = 0;
            int iMax = 1000000; // max number of generated numbers
            int iLargest = iMax * 10;

            //Create a tree instance
            AVLT<int> tree = new AVLT<int>();
            //get start time
            start = Environment.TickCount;

            //create a random number generator, seeded with the starrt time
            Random randNumber = new Random((int)start);

            //Generate numbers and add them to the tree
            for (int i = 0; i < iMax; i++)
            {
                //generate numbers between 1 and the largest
                tree.Add(randNumber.Next(1, iLargest));
            }

            //get the current time
            end = Environment.TickCount;

            //display the results
            Console.WriteLine("Time to add: " + (end - start).ToString() + "ms");
            Console.WriteLine("Theoretical Minimum Height: " + Math.Truncate(Math.Log(iMax, 2)));
            Console.WriteLine("Actual Height: " + tree.Height());


        }



        static void Main(string[] args)
        {
            //AVLT<int> myAVLT = new AVLT<int>();
            //testAdd(myAVLT);
            //Console.WriteLine(myAVLT.ToString());
            //Console.WriteLine(myAVLT.Height());
            //myAVLT.testHeightDiff();


            //Console.WriteLine(myBST.Count);
            //myBST.IterateBreadth(HandleAnInt, TRAVERSALORDER.IN_ORDER);
            // myBST.Remove(10);
            //Console.WriteLine("Remove \n");
            //myBST.Iterate(HandleAnInt, TRAVERSALORDER.IN_ORDER);

            //testEnumerator(myBST);
            //myBST.IterateBreadth(HandleAnInt);


            TestRandomTree();

        }
    }
}
