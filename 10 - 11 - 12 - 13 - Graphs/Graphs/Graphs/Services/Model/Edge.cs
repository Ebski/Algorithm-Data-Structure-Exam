using System;

namespace Graphs.Services.Model
{
    public class Edge : IComparable<Edge>
    {
        public int weight { get; set; }
        public Node from { get; set; }
        public Node to { get; set; }
        public Edge(int weight, Node from, Node to)
        {
            this.weight = weight;
            this.from = from;
            this.to = to;
        }

        public int CompareTo(Edge other)
        {
            if (this.weight <= other.weight)
            {
                return -1;
            }
            else
            {
                return -2;
            }
        }
    }
}
