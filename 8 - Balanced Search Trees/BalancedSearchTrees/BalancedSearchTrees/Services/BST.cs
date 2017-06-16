using System;
using System.Collections.Generic;
using BalancedSearchTrees.Services.Queue;

namespace BalancedSearchTrees.Services
{
    public class BST<Key, Value> : IST<Key, Value> where Key : IComparable
    {
        private Node root = null;

        public void put(Key key, Value val)
        {
            root = put(root, key, val);
        }

        private Node put(Node x, Key key, Value val)
        {
            if (x == null)
            {
                return new Node(key, val);
            }

            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = put(x.left, key, val);
            }
            else if (cmp > 0)
            {
                x.right = put(x.right, key, val);
            }
            else
            {
                x.val = val;
            }
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }

        public Value get(Key key)
        {
            return get(root, key);
        }

        private Value get(Node x, Key key)
        {
            if (x == null)
            {
                return default(Value);
            }
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                return get(x.left, key);
            }
            else if (cmp > 0)
            {
                return get(x.right, key);
            }
            else
            {
                return x.val;
            }
        }

        public void delete(Key key)
        {
            root = delete(root, key);
        }

        private Node delete(Node x, Key key)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = delete(x.left, key);
            }
            else if (cmp > 0)
            {
                x.right = delete(x.right, key);
            }
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;

                Node t = x;
                x = min(t.right.key);
                x.right = deleteMin(t.right);
                x.left = t.left;
            }
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }

        private Node min(Key key)
        {
            Node x = root;
            int cmp = 100;
            while (cmp != 0)
            {
                cmp = key.CompareTo(x.key);
                if (cmp < 0) x = x.left;
                if (cmp > 0) x = x.right;
            }

            while (x.left != null)
            {
                x = x.left;
            }
            return x;
        }

        private Node deleteMin(Node x)
        {
            if (x.left == null)
            {
                return x.right;
            }
            x.left = deleteMin(x.left);
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }

        public bool contains(Key key)
        {
            return !get(key).Equals(default(Value));
        }

        public bool isEmpty()
        {
            return root == null;
        }

        public int size()
        {
            return size(root);
        }

        private int size(Node x)
        {
            if (x == null)
            {
                return 0;
            }
            return x.count;
        }

        public IQueue<Key> keys()
        {
            IQueue<Key> q = new LinkedListQueue<Key>();
            inorder(root, q);
            return q;
        }

        private void inorder(Node x, IQueue<Key> q)
        {
            if (x == null)
            {
                return;
            }
            inorder(x.left, q);
            q.enqueue(x.key);
            inorder(x.right, q);
        }

        private class Node
        {
            public Key key;
            public Value val;
            public Node left;
            public Node right;
            public int count;

            public Node(Key key, Value val)
            {
                this.key = key;
                this.val = val;
                this.count = 1;
            }
        }
    }
}
