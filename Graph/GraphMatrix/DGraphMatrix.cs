using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMatrix
{
    public class DGraphMatrix<T>: AGraphMatrix<T> where T: IComparable<T>
    {
        public DGraphMatrix()
        {
            isDirected = true;
        }
    }
}
