using System;
using System.Security.Cryptography.X509Certificates;

namespace HashTables_And_HashMaps.Services
{
    public class LinkedListHashTable<Key, Value> : IHashTable<Key, Value>
    {
        private int N;
        private int M;
        private Node[] st;

        public LinkedListHashTable()
        {
            N = 0;
            M = 2;
            st = new Node[M];
        }

        public void put(Key key, Value val)
        {
            int i = hash(key);
            for (Node x = st[i]; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.val = val;
                    return;
                }
            }
            st[i] = new Node(key, val, st[i]);
            N++;
            doubleArrays();
        }

        public Value get(Key key)
        {
            int i = hash(key);
            for (Node x = st[i]; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    return (Value)x.val;
                }
            }
            return default(Value);
        }

        public void delete(Key key)
        {
            Node current;
            Node previous = null;
            int i = hash(key);
            for (current = st[i]; current != null; current = current.next)
            {
                if (key.Equals(current.key))
                {
                    break;
                }
                previous = current;
            }
            if (current == null)
            {
                return;
            }
            if (previous != null)
            {
                if (current.next == null)
                {
                    previous.next = null;
                    return;
                }
                previous.next = current.next;
                current.next = null;
            }
            else
            {
                if (current.next == null)
                {
                    st[i] = null;
                }
                else
                {
                    st[i] = current.next;
                }
            }
            N--;
            halfArrays();
        }

        private int hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff % M);
        }

        public int size()
        {
            return N;
        }

        private void doubleArrays()
        {
            if ((N / M) * 10 < 50)
            {
                return;
            }
            Node[] oldST = st;
            M = M * 2;
            st = new Node[M];
            N = 0;

            foreach (Node n in oldST)
            {
                Node node = n;
                if (node != null)
                {
                    while (node != null)
                    {
                        put(node.key, node.val);
                        node = node.next;
                    }
                }
            }
        }

        private void halfArrays()
        {
            if ((N / M) * 10 < 70)
            {
                return;
            }
            Node[] oldST = st;
            M = M / 2;
            st = new Node[M];
            N = 0;

            foreach (Node n in oldST)
            {
                Node node = n;
                if (node != null)
                {
                    while (node != null)
                    {
                        put(node.key, node.val);
                        node = node.next;
                    }
                }
            }
        }

        private class Node
        {
            public Key key;
            public Value val;
            public Node next;

            public Node(Key key, Value val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }
    }
}
