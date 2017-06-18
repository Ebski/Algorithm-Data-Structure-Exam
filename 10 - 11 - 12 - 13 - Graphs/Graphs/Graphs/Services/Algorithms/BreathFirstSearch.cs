using System.Collections.Generic;
using Graphs.Services.Model;

namespace Graphs.Services.Algorithms
{
    public class BreathFirstSearch
    {
        public List<Node> search(Node x)
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            List<Node> res = new List<Node>();
            queue.Enqueue(x);
            visited.Add(x);
            search(queue, visited, res);
            return res;
        }

        private void search(Queue<Node> queue, ISet<Node> visited, ICollection<Node> result)
        {
            if (queue.Count == 0) return;
            Node next = queue.Dequeue();
            result.Add(next);
            foreach (Edge e in next.edges)
            {
                Node end = e.to;
                if (visited.Contains(end)) continue;
                visited.Add(end);
                queue.Enqueue(end);
            }
            search(queue, visited, result);
        }
    }
}
