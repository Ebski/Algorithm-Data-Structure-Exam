using System.Collections.Generic;
using Graphs.Services.Model;

namespace Graphs.Services.Algorithms
{
    public class TypologicalSort
    {
        public Stack<Node> topSort(Graph graph)
        {
            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            foreach (Node node in graph.nodes)
            {
                if (visited.Contains(node))
                {
                    continue;
                }
                else
                {
                    topSortUtil(node, stack, visited);
                }
            }
            return stack;
        }

        private void topSortUtil(Node node, Stack<Node> stack, HashSet<Node> visited)
        {
            visited.Add(node);
            foreach (Node child in node.getAdjacent())
            {
                if (visited.Contains(child))
                {
                    continue;
                }
                else
                {
                    topSortUtil(child, stack, visited);
                }
            }
            stack.Push(node);
        }
    }
}
