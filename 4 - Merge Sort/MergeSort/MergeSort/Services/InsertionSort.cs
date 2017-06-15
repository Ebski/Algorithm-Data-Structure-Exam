using System;

namespace MergeSort.Services
{
    public class InsertionSort<T> where T : IComparable
    {
        private T[] array;

        public T[] sort(T[] a, int low, int high)
        {
            array = a;
            int N = array.Length;
            for (int i = low; i < high + 1; i++)
            {
                for (int j = i; j > low; j--)
                {
                    if (array[j].CompareTo(array[j-1]) < 0)
                    {
                        exchange(j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }

        private void exchange(int i, int j)
        {
            T swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
    }
}
