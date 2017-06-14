using System;
using System.Collections;
using System.Collections.Generic;

namespace Bags_Queues_and_Stacks.Services.Stacks
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        private class Node
        {
            public T item;
            public Node next;
        }

    }
}
