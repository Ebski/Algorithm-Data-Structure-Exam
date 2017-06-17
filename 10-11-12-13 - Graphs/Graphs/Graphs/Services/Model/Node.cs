using System.Collections.Generic;

namespace Graphs.Services.Model
{
    public class Node
    {
        public int id { get; set; }
        public List<Edge> edges { get; set; }

        public Node()
        {        
        }

        public Node(int id, List<Edge> edges)
        {
            this.id = id;
            this.edges = edges;
        }

        public void addEdgeTo(int weight, Node to)
        {
            edges.Add(new Edge(weight, this, to));
        }

        public HashSet<Node> getAdjacent()
        {
            HashSet<Node> adjacentList = new HashSet<Node>();
            foreach (Edge edge in edges)
            {
                if (!adjacentList.Contains(edge.to))
                {
                    adjacentList.Add(edge.to);
                }
            }
            return adjacentList;
        }
    }
}
