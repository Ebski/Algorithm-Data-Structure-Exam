namespace Bags_Queues_and_Stacks.Services.Queues
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private Node first;
        private Node last;

        public LinkedListQueue()
        {
            first = null;
            last = null;
        }
        
        public void enqueue(T item)
        {
            Node oldLast = last;
            last = new Node
            {
                item = item,
                next = oldLast
            };

            if (isEmpty())
            {
                first = last;
            }
            else
            {
                oldLast.next = last;
            }
        }

        public T dequeue()
        {
            T item = first.item;
            first = first.next;
            if (isEmpty())
            {
                last = null;
            }
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