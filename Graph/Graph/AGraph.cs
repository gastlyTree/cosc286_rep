using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public abstract class AGraph<T> : IGraph<T> where T : IComparable<T>
    {
        #region Attributes
        //stores the vertices of the graph
        protected List<Vertex<T>> vertices;

        //A dictionary is a hashtable. we will use it to store a data items index
        //into the vertices list.. this will make it much more efficient to lookup
        // a vertex in the vertices list.
        protected Dictionary<T, int> revLookUp;

        //store the number of edges in the graph
        protected int numEdges;

        //is the graph directed or not
        protected bool isDirected;

        //Is the graph weighted
        protected bool isWeighted;

        #endregion

        #region Constructors
        public AGraph()
        {
            vertices = new List<Vertex<T>>();
            revLookUp = new Dictionary<T, int>();
            numEdges = 0;
        }
        #endregion

        #region Properties
        public int NumEdges
        {
            get
            {
                return numEdges;
            }
        }

        public int NumVertices
        {
            get
            {
                return vertices.Count();
            }
        }
        #endregion

        #region Abstract Methods

        //a helper method that will allow us to implement the other two add edge methods
        protected abstract void AddEdge(Edge<T> e);

        public abstract IEnumerable<Vertex<T>> EnumerateNeighbors(T data);

        public abstract Edge<T> GetEdge(T from, T to);

        public abstract bool HasEdge(T from, T to);

        public abstract void RemoveEdge(T from, T to);

        //When adding a vertex here, we need to tell the child class to make room
        //for the edges of this vertex.
        public abstract void AddVertexAdjustEdges(Vertex<T> v);

        protected abstract Edge<T>[] getAllEdges();

        #endregion

        public void AddEdge(T from, T to)
        {
            // if this is the first edge, set the isWeighted Attribute to false
            if(numEdges == 0)
            {
                isWeighted = false;
            }
            else if(isWeighted)
            {
                throw new ApplicationException("Cant add unweighted edge to an weighted graph");
            }

            //Create an edge object
            Edge<T> e = new Edge<T>(GetVertex(from), GetVertex(to));
            //add the edge to whatever child implementation we are using
            AddEdge(e);
        }

        public void AddEdge(T from, T to, double weight)
        {
            // if this is the first edge, set the isWeighted Attribute to true
            if (numEdges == 0)
            {
                isWeighted = true;
            }
            else if (!isWeighted)
            {
                throw new ApplicationException("Cant add weighted edge to an unweighted graph");
            }

            //Create an edge object
            Edge<T> e = new Edge<T>(GetVertex(from), GetVertex(to), weight);
            //add the edge to whatever child implementation we are using
            AddEdge(e);
        }

        public void AddVertex(T data)
        {
            //if the vertex already exists
            if(HasVertex(data))
            {
                //throw an exception
                throw new ApplicationException("Vertex already exists");
            }
            //instantiate a vertex object
            Vertex<T> v = new Vertex<T>(vertices.Count, data);
            ////add to the vertex list
            vertices.Add(v);
            //Also add to the dictionary
            revLookUp.Add(data, v.Index);
            //Tell child class to make room for this vertices edges
            AddVertexAdjustEdges(v);

        }

        public IEnumerable<Vertex<T>> EnumerateVertices()
        {
            return vertices;
        }

        public Vertex<T> GetVertex(T data)
        {
            if(!HasVertex(data))
            {
                throw new ApplicationException("No such vertex");
            }
            //Note that c# overloads [] to get a value out of the dictionary
            int index = revLookUp[data];
            return vertices[index];
        }

        public bool HasVertex(T data)
        {
            //most efficient to look in the dictionary
            return revLookUp.ContainsKey(data);
        }

        public void RemoveVertex(T data)
        {
            throw new NotImplementedException();
        }

        #region The real shit

        public void BreadthFirstTraversal(T start, VisitorDelegate<T> whatToDo)
        {
            throw new NotImplementedException();
        }

        public void DepthFirstTraversal(T start, VisitorDelegate<T> whatToDo)
        {
            throw new NotImplementedException();
        }

        public IGraph<T> MinimumSpanningTree()
        {
            throw new NotImplementedException();
        }

        public IGraph<T> ShortestWeightedPath(T start, T end)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            //Loop through each vertice and add to the result
            foreach (Vertex<T> v in EnumerateVertices())
            {
                result.Append(v + ", ");
            }
            //Take off the last comma
            if (vertices.Count > 0)
            {
                result.Remove(result.Length - 2, 2);
            }
            return GetType().Name + "\nVertices: " + result + "\n";
        }
    }
}
