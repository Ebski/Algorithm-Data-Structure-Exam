using System;
using System.Collections.Generic;
using Graphs.Services.Algorithms;
using Graphs.Services.Model;

namespace Graphs.ExamQuestions._12
{
    public class WeigthedGraph
    {
        public void findShortestPath()
        {
            Graph graph = generateGraph();
            Dijstras d = new Dijstras();
            Dictionary<Node, int> shortestPathFrom1 = d.shortestPath(graph, graph.findNode(1));

            Console.WriteLine("\n\nDijstras: \n");
            foreach (KeyValuePair<Node, int> pair in shortestPathFrom1)
            {
                Console.WriteLine(pair.Key.id + ", " + pair.Value);
            }
        }

        private Graph generateGraph()
        {
            Node n1 = new Node(1, new List<Edge>());
            Node n2 = new Node(2, new List<Edge>());
            Node n3 = new Node(3, new List<Edge>());
            Node n4 = new Node(4, new List<Edge>());
            Node n5 = new Node(5, new List<Edge>());
            Node n6 = new Node(6, new List<Edge>());

            n1.addEdgeTo(5, n2);
            n1.addEdgeTo(9, n4);
            n1.addEdgeTo(2, n5);

            n2.addEdgeTo(2, n3);

            n3.addEdgeTo(3, n4);

            n5.addEdgeTo(3, n6);

            n6.addEdgeTo(2, n4);

            List<Node> nodeList = new List<Node> { n1, n2, n3, n4, n5, n6 };
            return new Graph(nodeList);
        }
    }

}
