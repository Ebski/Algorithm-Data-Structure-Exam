using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Graphs.Services.Model
{
    public class DisjointSet
    {
        private Dictionary<long, Node> map = new Dictionary<long, Node>();

        private class Node
        {
            public long data;
            public Node parent;
            public int rank;
        }

        public void makeSet(long data)
        {
            Node node = new Node();
            node.data = data;
            node.parent = node;
            node.rank = 0;
            map.Add(data, node);
        }

        public bool union(long data1, long data2)
        {
            Node node1;
            Node node2;
            map.TryGetValue(data1, out node1);
            map.TryGetValue(data2, out node2);

            Node parent1 = recFindset(node1);
            Node parent2 = recFindset(node2);

            if (parent1.data.Equals(parent2.data))
            {
                return false;
            }

            if (parent1.rank >= parent2.rank)
            {
                parent1.rank = (parent1.rank == parent2.rank) ? parent1.rank + 1 : parent1.rank;
                parent2.parent = parent1;
            }
            else
            {
                parent1.parent = parent2;
            }
            return true;
        }

        public long findSet(long data)
        {
            Node node;
            map.TryGetValue(data, out node);
            return (recFindset(node).data);
        }

        private Node recFindset(Node node)
        {
            Node parent = node.parent;
            if (parent == node)
            {
                return parent;
            }
            node.parent = recFindset(node.parent);
            return node.parent;
        }
    }
}
