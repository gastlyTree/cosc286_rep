using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    public class StableDemo : IComparable<StableDemo>
    {
        private int value;
        private int initialIndex;

        public StableDemo(int value, int index)
        {
            this.value = value;
            this.initialIndex = index;
        }

        public int CompareTo(StableDemo other)
        {
            return value.CompareTo(other.value);
        }

        public override string ToString()
        {
            return "(" + value + ", " + initialIndex + ")";
        }
    }
}
