using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Bags_Queues_and_Stacks.Services.Bags
{
    public class LinkedListBag<T> : IBag<T>
    {
        private Node first;

        public LinkedListBag()
        {
            first = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;
            while (current != null)
            {
                yield return current.item;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void add(T item)
        {
            Node oldFirst = first;
            first = new Node
            {
                item = item,
                next = oldFirst
            };
        }

        public int size()
        {
            int count = 0;
            Node current = first;
            while (current != null)
            {
                count++;
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
