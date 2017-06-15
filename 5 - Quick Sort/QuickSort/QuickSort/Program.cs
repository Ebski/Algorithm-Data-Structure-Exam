using System;
using QuickSort.Services;

namespace QuickSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random ran = new Random();
            QuickSortAlgorithm<int> qs = new QuickSortAlgorithm<int>();
            
            int[] a = new int[100];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ran.Next(0, 100);
            }
            
            a = qs.sort(a);

            foreach (int i in a)
            {
                Console.WriteLine(i);
            }

            while (true)
            {
                
            }
        }
    }
}
