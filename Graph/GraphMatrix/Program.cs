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

        static void processData(string data)
        {
            Console.WriteLine(data);
        }

        static void TestTraversals()
        {
            UGraphMatrix<string> uGraph = new UGraphMatrix<string>();
            uGraph.AddVertex("PA");
            uGraph.AddVertex("Saskatoon");
            uGraph.AddVertex("Regina");
            uGraph.AddVertex("Weyburn");
            uGraph.AddVertex("Estevan");
            uGraph.AddVertex("MJ");
            uGraph.AddVertex("Yorkton");
            uGraph.AddVertex("Swift");

            uGraph.AddEdge("PA", "Saskatoon", 141);
            uGraph.AddEdge("Saskatoon", "MJ", 220);
            uGraph.AddEdge("Saskatoon", "Yorkton", 328);
            uGraph.AddEdge("Yorkton", "Regina", 187);
            uGraph.AddEdge("Swift", "MJ", 190);
            uGraph.AddEdge("MJ", "Regina", 72);
            uGraph.AddEdge("Regina", "Weyburn", 115);
            uGraph.AddEdge("Weyburn", "Estevan", 86);

            //Console.WriteLine(uGraph);
            uGraph.DepthFirstTraversal("Saskatoon", processData);
        }

        static void TestShortestWeightedPath()
        {
            UGraphMatrix<string> uGraph = new UGraphMatrix<string>();
            uGraph.AddVertex("Prince Albert");
            uGraph.AddVertex("Saskatoon");
            uGraph.AddVertex("Yorkton");
            uGraph.AddVertex("Regina");
            uGraph.AddVertex("Weyburn");
            uGraph.AddEdge("Prince Albert", "Saskatoon", 2);
            uGraph.AddEdge("Saskatoon", "Yorkton", 4);
            uGraph.AddEdge("Saskatoon", "Regina", 1);
            uGraph.AddEdge("Regina", "Yorkton", 3);
            uGraph.AddEdge("Regina", "Weyburn", 5);
            uGraph.AddEdge("Yorkton", "Weyburn", 1);

            Console.WriteLine(uGraph);

            Console.WriteLine(uGraph.ShortestWeightedPath("Weyburn", "Prince Albert"));

        }

        static void testMinimumSpanningTree()
        {
            UGraphMatrix<string> uGraph = new UGraphMatrix<string>();
            uGraph.AddVertex("A");
            uGraph.AddVertex("B");
            uGraph.AddVertex("C");
            uGraph.AddVertex("D");
            uGraph.AddVertex("E");
            uGraph.AddVertex("F");
            uGraph.AddVertex("G");
            uGraph.AddVertex("H");

            uGraph.AddEdge("A", "B", 28);
            uGraph.AddEdge("B", "H", 13);
            uGraph.AddEdge("A", "F", 10);
            uGraph.AddEdge("F", "E", 25);
            uGraph.AddEdge("E", "G", 24);
            uGraph.AddEdge("E", "D", 22);
            uGraph.AddEdge("G", "D", 18);
            uGraph.AddEdge("G", "B", 14);
            uGraph.AddEdge("D", "C", 12);
            uGraph.AddEdge("B", "C", 16);

            //Console.WriteLine(uGraph);

            Console.WriteLine(uGraph.MinimumSpanningTree());
        }

        static void TestMinSpantree()
        {
            UGraphMatrix<string> uGraph = new UGraphMatrix<string>();
            uGraph.AddVertex("PA");
            uGraph.AddVertex("SC");
            uGraph.AddEdge("PA", "SC", 4);

            uGraph.AddVertex("MH");
            uGraph.AddEdge("MH", "SC", 1);

            uGraph.AddVertex("S");
            uGraph.AddEdge("MH", "S", 3);

            uGraph.AddEdge("S", "PA", 3);

            uGraph.AddVertex("MJ");

            uGraph.AddEdge("S", "MJ", 3);
            uGraph.AddEdge("SC", "MJ", 2);

            uGraph.AddVertex("Y");
            uGraph.AddEdge("S", "Y", 5);
            uGraph.AddVertex("R");
            uGraph.AddEdge("R", "Y", 3);
            uGraph.AddEdge("R", "MJ", 4);

            uGraph.AddVertex("W");
            uGraph.AddEdge("W", "R", 2);
            Console.WriteLine(uGraph.MinimumSpanningTree());


        }

        static void Main(string[] args)
        {
            testMinimumSpanningTree();
        }
    }
}
