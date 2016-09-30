using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_A
{
    class Program
    {
        public static void DisplayInt(int a)
        {
            Console.WriteLine(a);
        }

        public static void DisplaySquare(int a)
        {
            Console.WriteLine(a * a);
        }

        static void Main(string[] args)
        {
            Collection c = new Collection();
            c.iterate(DisplaySquare, Direction.BACKWARD);
        }
    }
}
