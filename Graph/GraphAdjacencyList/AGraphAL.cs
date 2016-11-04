using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAdjacencyList
{
    public abstract class AGraphAL<T> : AGraph<T> where T : IComparable<T>
    {
        #region Attributes

        protected List<List<Edge<T>>> listListEdges;
        
        #endregion

        public AGraphAL()
        {
            listListEdges = new List<List<Edge<T>>>();
        }

        public override void AddVertexAdjustEdges(Vertex<T> v)
        {
            //add a new list to the end of the lisst of lists
            listListEdges.Add(new List<Edge<T>>());
        }

        public override IEnumerable<Vertex<T>> EnumerateNeighbors(T data)
        {
            throw new NotImplementedException();
        }

        public override Edge<T> GetEdge(T from, T to)
        {
            throw new NotImplementedException();
        }

        public override bool HasEdge(T from, T to)
        {
            //get the vertex objrcts for from and to
            Vertex<T> vFrom = GetVertex(from);
            Vertex<T> vTo = GetVertex(to);
            //get the list of edges for "from" vertex
            List<Edge<T>> al = listListEdges[vFrom.Index];

            return al.Contains(new Edge<T>(vFrom, vTo));

        }

        public override void RemoveEdge(T from, T to)
        {
            throw new NotImplementedException();
        }

        public override void RemoveVertexAdjustEdges(Vertex<T> v)
        {
            throw new NotImplementedException();
        }

        protected override void AddEdge(Edge<T> e)
        {
            //if the edge already exists, trow an exception
            if(HasEdge(e.From.Data, e.To.Data))
            {
                throw new ApplicationException("Edge already exists");
            }

            //add an edge to the list of edges for the "from" vertex
            listListEdges[e.From.Index].Add(e);
            //increment the edge count
            numEdges++;

        }

        protected override Edge<T>[] getAllEdges()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sbEdges = new StringBuilder("Edges:\n");
            for (int r = 0; r < listListEdges.Count; r++)
            {
                sbEdges.Append("Index " + r + ": ");
                bool commaAdded = false;
                foreach (Edge<T> e in listListEdges[r])
                {
                    sbEdges.Append(e + ", ");
                    commaAdded = true;
                }
                if (commaAdded)
                {
                    sbEdges.Remove(sbEdges.Length - 2, 2);
                }
                sbEdges.Append("\n");
            }
            return base.ToString() + sbEdges;
        }
    }
}
