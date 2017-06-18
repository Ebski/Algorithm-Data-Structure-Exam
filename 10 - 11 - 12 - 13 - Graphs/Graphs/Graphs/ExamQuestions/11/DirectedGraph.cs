using System;
using System.Collections;
using System.Collections.Generic;
using Graphs.Services.Algorithms;
using Graphs.Services.Model;

namespace Graphs.ExamQuestions._11
{
    public class DirectedGraph
    {
        public void showCycleDetection()
        {
            Graph graph = generateGraph();
            CycleDetection cd = new CycleDetection();
            TypologicalSort ts = new TypologicalSort();
            MinimumSpanningTree mpt = new MinimumSpanningTree();
            HashSet <Node> cycleSet = cd.findCycle(graph);
            Stack<Node> typologicalSortedStack = ts.topSort(graph);
            List<Edge> minimumSpanningList = mpt.getMinimumSpanningTree(graph);

            Console.WriteLine("\n\nCycle Detection: \n");
            foreach (Node node in cycleSet)
            {
                Console.WriteLine(node.id);
            }

            // Not a good example as there are cycles in the graph.
            Console.WriteLine("\n\nTypological Sort: \n");
            foreach (Node node in typologicalSortedStack)
            {
                Console.WriteLine(node.id);
            }

            Console.WriteLine("\n\nminumum spanning tree: \n");
            foreach (Edge edge in minimumSpanningList)
            {
                Console.WriteLine(edge.from.id + " , " + edge.to.id);
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
            
            n1.addEdgeTo(3, n2);
            n1.addEdgeTo(5, n7);
            n1.addEdgeTo(9, n8);
            n2.addEdgeTo(4, n3);
            n3.addEdgeTo(1, n4);
            n4.addEdgeTo(7, n5);
            n5.addEdgeTo(9, n6);
            n6.addEdgeTo(3, n3);
            n8.addEdgeTo(7, n9);

            List<Node> nodeList = new List<Node> {n1, n2, n3, n4, n5, n6, n7, n8, n9};
            
            return new Graph(nodeList);

        }
    }
}
