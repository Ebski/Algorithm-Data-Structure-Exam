using System;

namespace MergeSort.Services
{
    public class RecursiveMergeSort<T> where T : IComparable
    {
        private T[] array;
        private InsertionSort<T> insertion = new InsertionSort<T>();
        public T[] sort(T[] a)
        {
            array = a;
            T[] aux = new T[array.Length];
            sort(array, aux, 0, array.Length - 1);
            return array;
        }

        private void sort(T[] a, T[] aux, int low, int high)
        {
            if (high <= low + 7 - 1)
            {
                a = insertion.sort(a, low, high);
                return;
            }
            int mid = low + (high - low) / 2;
            sort(a, aux, low, mid);
            sort(a, aux, mid + 1, high);
            if (a[mid + 1].CompareTo(a[mid]) > 0)
            {
                return;
            }
            merge(a, aux, low, mid, high);
        }

        private void merge(T[] a, T[] aux, int low, int mid, int high)
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


    }
}
