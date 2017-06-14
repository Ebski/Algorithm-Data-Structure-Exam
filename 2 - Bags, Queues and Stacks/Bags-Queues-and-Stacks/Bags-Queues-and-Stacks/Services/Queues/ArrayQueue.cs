using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Bags_Queues_and_Stacks.Services.Queues
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] q;
        private int head;
        private int tail;
        private int N;

        public ArrayQueue()
        {
            q = new T[1];
            head = 0;
            tail = 0;
            N = 0;
        }

        public void enqueue(T item)
        {
            if (tail == q.Length)
            {
                resize(2 * q.Length);
                head = 0;
                tail = N;
            }
            q[tail++] = item;
            N++;
        }

        public T dequeue()
        {
            T item = q[head];
            N--;
            q[head] = default(T);
            head++;
            if (N > 0 && N == q.Length / 4)
            {
                resize(q.Length / 2);
                head = 0;
                tail = N;
            }
            if (isEmpty())
            {
                head = 0;
                tail = 0;
            }
            return item;
        }

        public bool isEmpty()
        {
            return N == 0;
        }

        public int size()
        {
            return N;
        }

        private void resize(int capacity)
        {
            T[] copy = new T[capacity];
            for (int i = 0; i < N; i++)
            {
                copy[i] = q[head + i];
            }
            q = copy;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < N; i++)
            {
                yield return q[i + head];
            }
        }
    }
}
