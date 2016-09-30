using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_A
{
    //create a delegate data type
    public delegate void HandleAnInt(int x);

    //Define an enumeration that can be used as a direction flag
    public enum Direction
    {
        FORWARD,
        BACKWARD
    }

    public class Collection
    {
        private int[] iArray = { 5, 10, 20 };

        public void iterate(HandleAnInt fp, Direction dir)
        {
            switch (dir)
            {
                case Direction.FORWARD:
                    {
                        for (int i = 0; i < iArray.Length; i++)
                        {
                            //Hard code a method that does something to the data
                            //Console.WriteLine(iArray[i]);
                            fp(iArray[i]);
                        }
                    }
                    break;
                case Direction.BACKWARD:
                    {
                        for (int i = iArray.Length - 1; i >= 0; i--)
                        {
                            fp(iArray[i]);
                        }
                    }
                    break;
                default:
                    break;
            }

            
        }
    }
}
