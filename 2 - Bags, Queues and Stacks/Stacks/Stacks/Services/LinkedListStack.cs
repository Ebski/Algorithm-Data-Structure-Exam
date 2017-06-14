namespace Stacks.Services
{
    public class LinkedListStack<T> : IStack<T>
    {
        private Node first;

        public LinkedListStack()
        {
            first = null;
        }

        public void push(T item)
        {
            Node oldFirst = first;
            first = new Node
            {
                item = item,
                next = oldFirst
            };
        }

        public T pop()
        {
            T item = first.item;
            first = first.next;
            return item;
        }

        public bool isEmpty()
        {
            return first == null;
        }

        public int size()
        {
            int count = 0;
            Node node = first;
            while (node.next != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        private class Node
        {
            public T item;
            public Node next;
        }
        
    }
}
