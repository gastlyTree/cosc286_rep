using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace GraphMatrix
{
    class Program
    {
        static void TestDirectedGraph()
        {
            DGraphMatrix<string> dGraph = new DGraphMatrix<string>();
            dGraph.AddVertex("Saskatoon");
            dGraph.AddVertex("Moose Jaw");
            dGraph.AddVertex("Regina");

            dGraph.AddEdge("Saskatoon", "Moose Jaw", 255);
            dGraph.AddEdge("Saskatoon", "Regina   ", 250);
            dGraph.AddEdge("Regina", "Moose Jaw", 70);

            // Console.WriteLine(dGraph);
            //dGraph.RemoveEdge("Saskatoon", "Moose Jaw");
            List<Vertex<string>> list = (List<Vertex<string>>)dGraph.EnumerateNeighbors("Saskatoon");
            list.Remove(new Vertex<string>(2, "Regina"));
            foreach (Vertex<string> v in list)
            {
                Console.WriteLine(v.Data);
            }
        }

        static void TestUndirectedGraph()
        {
            UGraphMatrix<string> dGraph = new UGraphMatrix<string>();
            dGraph.AddVertex("Saskatoon");
            dGraph.AddVertex("Moose Jaw");
            dGraph.AddVertex("Regina   ");

            dGraph.AddEdge("Saskatoon", "Moose Jaw", 255);
            dGraph.AddEdge("Saskatoon", "Regina   ", 250);
            dGraph.AddEdge("Regina   ", "Moose Jaw", 70);

            Console.WriteLine(dGraph);
        }

        static void Main(string[] args)
        {
            TestDirectedGraph();
        }
    }
}
