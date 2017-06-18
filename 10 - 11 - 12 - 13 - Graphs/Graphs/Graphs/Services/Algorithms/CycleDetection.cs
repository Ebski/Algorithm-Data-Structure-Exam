using System.Collections.Generic;
using Graphs.Services.Model;

namespace Graphs.Services.Algorithms
{
    public class CycleDetection
    {
        private Dictionary<Node, Node> parentMap = new Dictionary<Node, Node>();
        private HashSet<Node> cycleNodes = new HashSet<Node>();

        public HashSet<Node> findCycle(Graph graph)
        {
            HashSet<Node> whiteset = new HashSet<Node>();
            HashSet<Node> greyset = new HashSet<Node>();
            HashSet<Node> blackset = new HashSet<Node>();

            foreach (Node node in graph.nodes)
            {
                whiteset.Add(node);
            }
            
            foreach (Node current in whiteset)
            {
                if (dfs(current, whiteset, greyset, blackset))
                {
                    return cycleNodes;
                }
            }
            return null;
        }

        private bool dfs(Node current, HashSet<Node> whiteset, HashSet<Node> greyset, HashSet<Node> blackset)
        {
            moveNode(current, whiteset, greyset);

            foreach (Node neighbor in current.getAdjacent())
            {
                parentMap[neighbor] = current;
                if (blackset.Contains(neighbor))
                {
                    continue;
                }
                if (greyset.Contains(neighbor))
                {
                    cycleNodes.Add(neighbor);
                    while (current != neighbor)
                    {
                        cycleNodes.Add(current);
                        current = parentMap[current];
                    };
                    return true;
                }
                if (dfs(neighbor, whiteset, greyset, blackset))
                {
                    return true;
                }
            }
            moveNode(current, greyset, blackset);
            return false;
        }

        private void moveNode(Node node, HashSet<Node> fromSet, HashSet<Node> toSet)
        {
            fromSet.Remove(node);
            toSet.Add(node);
        }
    }
}
