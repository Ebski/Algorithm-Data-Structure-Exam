using System;
using System.Collections;
using System.Collections.Generic;

namespace Bags_Queues_and_Stacks.Services.Bags
{
    public class ArrayBag<T> :  IBag<T>
    {
        private T[] b;
        private int N;

        public ArrayBag()
        {
            b = new T[1];
            N = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < N; i++)
            {
                yield return b[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void add(T item)
        {
            if (N == b.Length)
            {
                resize(2 * b.Length);
            }
            b[N++] = item;
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
                copy[i] = b[i];
            }
            b = copy;
        }
    }
}
