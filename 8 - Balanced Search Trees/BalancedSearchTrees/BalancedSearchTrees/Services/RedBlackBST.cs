using System;

namespace BalancedSearchTrees.Services
{
    public class RedBlackBST<Key, Value> : IST<Key, Value> where Key : IComparable
    {
        private const bool RED = true;
        private const bool BLACK = false;

        private Node root = null;

        public void put(Key key, Value val)
        {
            root = put(root, key, val);
        }

        private Node put(Node x, Key key, Value val)
        {
            if (x == null)
            {
                return new Node(key, val, RED);
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

            if (isRed(x.right) && !isRed(x.left))
            {
                x = rotateLeft(x);
            }
            if (isRed(x.left) && isRed(x.left.left))
            {
                x = rotateRight(x);
            }
            if (isRed(x.left) && isRed(x.right))
            {
                flipColours(x);
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
            throw new NotImplementedException();
        }

        public bool contains(Key key)
        {
            return !(get(key).Equals(default(Value)));
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

        private bool isRed(Node x)
        {
            if (x == null)
            {
                return false;
            }
            return x.colour = RED;
        }

        private Node rotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.colour = x.left.colour;
            x.left.colour = RED;
            return x;
        }

        private Node rotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.colour = x.right.colour;
            x.left.colour = RED;
            return x;
        }

        private void flipColours(Node h)
        {
            h.colour = RED;
            h.left.colour = BLACK;
            h.right.colour = BLACK;
        }

        private class Node
        {
            public Key key;
            public Value val;
            public Node left;
            public Node right;
            public bool colour;
            public int count;

            public Node(Key key, Value val, bool colour)
            {
                this.key = key;
                this.val = val;
                this.colour = colour;
                this.count = 1;
            }
        }
    }
}
