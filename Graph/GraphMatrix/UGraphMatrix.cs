using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMatrix
{
    /// <summary>
    /// An undirected graph. an edge from A to B, means you can travel
    /// in both directions . Direction is not important. if the user adds
    /// a single edge from A to B, this class will add an edge from a to b
    /// as well as B to A
    /// </summary>
    class UGraphMatrix<T> : AGraphMatrix<T> where T : IComparable<T>
    {
        public UGraphMatrix()
        {
            isDirected = false;
        }

        //since we are adding an edge in both directions, we divide by 2 to
        //return the correct number of logical edges
        public override int NumEdges
        {
            get
            {
                //call the parent' numbEdges property using "base" keyword
                return base.NumEdges/2;
            }
        }

        //since this is undirected, when a user adds an edge, we add it in both directions
        public override void AddEdge(T from, T to)
        {
            base.AddEdge(from, to);
        }

        public override void AddEdge(T from, T to, double weight)
        {
            base.AddEdge(from, to, weight);
            base.AddEdge(to, from, weight);
        }

        public override void RemoveEdge(T from, T to)
        {
            base.RemoveEdge(from, to);
            base.RemoveEdge(to, from);
        }
    }
}
