using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace BinarySearchTree
{
    //Define a delegate type that will point to a method that will perform some
    //action on a data member of type T
    public delegate void ProcessData<T>(T data);
    //an enumerations to determine the  order of iteration

    public enum TRAVERSALORDER { PRE_ORDER, IN_ORDER, POST_ORDER}; 

    public interface I_BST<T>: I_Collection<T> where T:IComparable<T>
    {
        /// <summary>
        /// Given a data element, find the corresponding element of equal value and return it.
        /// </summary>
        /// <param name="data">Item to find</param>
        /// <returns>A referance to the item if found, else default for T</returns>
        T Find(T data);

        /// <summary>
        /// Returns the height of the tree. Example 3 levels = height of 2.
        /// </summary>
        /// <returns>Height of the tree</returns>
        int Height();

        /// <summary>
        /// Similar to an enumerator, but more efficient. Also, it 
        /// utilizes a delegate to perform some action on each data item.
        /// </summary>
        /// <param name="pd">a delegate to method</param>
        /// <param name="to">the order in which the tree is traversed</param>
        void Iterate(ProcessData<T> pd, TRAVERSALORDER to);
    }
}
