using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class Program
    {
        /// <summary>
        /// Loads data from a file into a hashtable
        /// </summary>
        /// <param name="ht"></param>
        static void LoadDataFromFile(A_Hashtable<Person, Person> ht)
        {
            StreamReader sr = new StreamReader(File.Open("People.txt", FileMode.Open));
            string sInput = "";

            try
            {
                //Read a line from the file
                while ((sInput = sr.ReadLine()) != null)
                {
                    try
                    {
                        char[] cArray = { ' ' };
                        string[] sArray = sInput.Split(cArray);
                        int iSSN = Int32.Parse(sArray[0]);
                        Person p = new Person(iSSN, sArray[2], sArray[1]);
                        ht.Add(p, p);

                    }
                    catch (ApplicationException ae)
                    {
                        //Console.WriteLine("Exception: " + ae.Message);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sr.Close();
        }


        static void TestHT(A_Hashtable<Person, Person> ht)
        {
            LoadDataFromFile(ht);
            Console.WriteLine(ht);
            Console.WriteLine("Hash table type " + ht.GetType().ToString());
            Console.WriteLine("# of People = " + ht.Count);
            Console.WriteLine("Number of collisions: " + ht.NumCollisions + "\n");
        }

        public static void testAdd(A_Hashtable<int, string> ht)
        {
            ht.Add(1645, "Rob");
            ht.Add(8576, "Bob");
            ht.Add(4365, "Dob");
            ht.Add(9224, "nathan");
            ht.Add(3514, "Nicholas");

            Console.WriteLine(ht.ToString());
        }

        public static void testGet(A_Hashtable<int, string> ht)
        {
            try
            {
                Console.WriteLine(ht.Get(14));
                Console.WriteLine(ht.Get(1));
                Console.WriteLine(ht.Get(23));
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void testRemove(A_Hashtable<int, string> ht)
        {
            ht.Remove(4365);
            Console.WriteLine(ht);
        }

        static void Main(string[] args)
        {
            Linear<int, string> ht = new Linear<int, string>();
            testAdd(ht);
            testRemove(ht);

            //Linear<Person, Person> ht = new Linear<Person, Person>();
            //TestHT(ht);
        }
    }
}
