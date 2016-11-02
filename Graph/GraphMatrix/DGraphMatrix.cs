using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMatrix
{
    /// <summary>
    /// A directed graph. an 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DGraphMatrix<T>: AGraphMatrix<T> where T: IComparable<T>
    {

        public DGraphMatrix()
        {
            isDirected = true;
        }
    }
}
