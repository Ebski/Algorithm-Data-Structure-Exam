using System.Collections.Generic;
using Graphs.Services.Model;

namespace Graphs.Services.Algorithms
{
    public class Dijstras
    {
        public Dictionary<Node, int> shortestPath(Graph graph, Node soruceNode)
        {
            BinaryMinHeap<Node> minHeap = new BinaryMinHeap<Node>();
            Dictionary<Node, int> distance = new Dictionary<Node, int>();
            Dictionary<Node, Node> parent = new Dictionary<Node, Node>();

            foreach (Node node in graph.nodes)
            {
                minHeap.add(int.MaxValue, node);
            }

            minHeap.decrease(soruceNode, 0);
            distance.Add(soruceNode, 0);
            parent.Add(soruceNode, null);

            while (!minHeap.isEmpty())
            {
                BinaryMinHeap<Node>.NestedNode heapNode = minHeap.extractMinNode();
                Node current = heapNode.key;

                distance[current] = heapNode.weight;

                foreach (Edge edge in current.edges)
                {
                    Node adjacent = getNodeForEdge(current, edge);

                    if (!minHeap.containsData(adjacent))
                    {
                        continue;
                    }

                    int newDistance = distance[current] + edge.weight;

                    if (minHeap.getWeight(adjacent) > newDistance)
                    {
                        minHeap.decrease(adjacent, newDistance);
                        parent[adjacent] = current;
                    }
                }
            }
            return distance;
        }

        private Node getNodeForEdge(Node v, Edge e)
        {
            return e.from.Equals(v) ? e.to : e.from;
        }
    }
}
