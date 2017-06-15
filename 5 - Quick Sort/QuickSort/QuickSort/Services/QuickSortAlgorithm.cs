using System;
using System.Linq;
using System.Security.Authentication;

namespace QuickSort.Services
{
    public class QuickSortAlgorithm<T> where T : IComparable
    {
        InsertionSort<T> insertion = new InsertionSort<T>();
        public T[] sort(T[] a)
        {
            Random ran = new Random();
            a = a.OrderBy(x => ran.Next()).ToArray();
            sort(a, 0, a.Length - 1);
            return a;
        }

        private void sort(T[] a, int low, int high)
        {
            if (high <= low + 10 - 1)
            {
                a = insertion.sort(a, low, high);
                return;
            }

            int m = medianOf3(low, low + (high - low) / 2, high);
            exchange(a, low, m);

            int j = partition(a, low, high);
            sort(a, low, j - 1);
            sort(a, j + 1, high);
        }


        private int partition(T[] a, int low, int high)
        {
            int i = low;
            int j = high;
            while (true)
            {
                while (a[++i].CompareTo(a[low]) < 0)
                {
                    if (i == high)
                    {
                        break;
                    }
                }
                while (a[low].CompareTo(a[--j]) < 0)
                {
                    if (j == low)
                    {
                        break;
                    }   
                }
                if (i >= j)
                {
                    break;
                }
                exchange(a, i, j);
            }
            exchange(a, low, j);
            return j;
        }

        private void exchange(T[] a, int low, int i)
        {
            T swap = a[i];
            a[i] = a[low];
            a[low] = swap;
        }

        private int medianOf3(int a, int b, int c)
        {
            return Math.Max(Math.Min(a, b), Math.Min(Math.Max(a, b), c));
        }
    }
}
