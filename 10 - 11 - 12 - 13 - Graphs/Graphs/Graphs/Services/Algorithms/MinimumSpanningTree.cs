using System.Collections.Generic;
using System.Linq;
using Graphs.Services.Model;

namespace Graphs.Services.Algorithms
{
    public class MinimumSpanningTree
    {
        public List<Edge> getMinimumSpanningTree(Graph graph)
        {
            List<Edge> allEdges = new List<Edge>();
            foreach (Node node in graph.nodes)
            {
                foreach (Edge edge in node.edges)
                {
                    allEdges.Add(edge);
                }
            }

            allEdges = allEdges.OrderBy(e => e.weight).ToList();
            DisjointSet disjointSet = new DisjointSet();

            foreach (Node node in graph.nodes)
            {
                disjointSet.makeSet(node.id);
            }

            List<Edge> resultEdges = new List<Edge>();

            foreach (Edge edge in allEdges)
            {
                long root1 = disjointSet.findSet(edge.from.id);
                long root2 = disjointSet.findSet(edge.to.id);

                if (root1 == root2)
                {
                    continue;
                }
                else
                {
                    resultEdges.Add(edge);
                    disjointSet.union(edge.from.id, edge.to.id);
                }
            }
            return resultEdges;
        }
    }
}
