using System;
using System.Collections.Generic;
using Graphs.Services.Algorithms;
using Graphs.Services.Model;

namespace Graphs.ExamQuestions._10
{
    public class UndirectedGrap
    {
        public void showDepthFirstAndBreathFirstSearches()
        {
            Graph graph = generateGraph();
            DepthFirstSearch dfs = new DepthFirstSearch();
            BreathFirstSearch bfs = new BreathFirstSearch();
            List<Node> dfNodes = dfs.search(graph.findNode(1));
            List<Node> bfNodes = bfs.search(graph.findNode(1));

            Console.WriteLine("DEPTH FIRST\n");
            foreach (Node node in dfNodes)
            {
                Console.WriteLine(node.id);
            }

            Console.WriteLine("\n\nBREATHFIRST\n");
            foreach (Node node in bfNodes)
            {
                Console.WriteLine(node.id);
            }
            while (true)
            {

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
            Node n7 = new Node(7, new List<Edge>());
            Node n8 = new Node(8, new List<Edge>());
            Node n9 = new Node(9, new List<Edge>());

            n1.addEdgeTo(1, n3);
            n3.addEdgeTo(1, n1);

            n1.addEdgeTo(1, n2);
            n2.addEdgeTo(1, n1);

            n3.addEdgeTo(1, n5);
            n5.addEdgeTo(1, n3);

            n4.addEdgeTo(1, n5);
            n5.addEdgeTo(1, n4);

            n5.addEdgeTo(1, n6);
            n6.addEdgeTo(1, n5);

            n6.addEdgeTo(1, n7);
            n7.addEdgeTo(1, n6);

            n6.addEdgeTo(1, n8);
            n8.addEdgeTo(1, n6);

            n6.addEdgeTo(1, n9);
            n9.addEdgeTo(1, n6);

            List<Node> nodeList = new List<Node> {n1, n2, n3, n4, n5, n6, n7, n8, n9};
            return new Graph(nodeList);
        }
    }
}