using System;

namespace MergeSort.Services
{
    public class MergeSort<T> where T : IComparable
    {
        private T[] aux;
        private T[] a;

        private void merge(int low, int mid, int high)
        {
            for (int k = low; k <= high; k++)
            {
                aux[k] = a[k];
            }
            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else if (j > high)
                {
                    a[k] = aux[i++];
                }
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }

        public T[] sort(T[] array)
        {
            a = array;
            int N = a.Length;
            aux = new T[N];
            for (int size = 1; size < N; size = size + size)
            {
                for (int low = 0; low < N - size; low += size + size)
                {
                    merge(low, low + size - 1, Math.Min(low + size + size - 1, N-1));
                }
            }
            return a;
        }
    }
}
