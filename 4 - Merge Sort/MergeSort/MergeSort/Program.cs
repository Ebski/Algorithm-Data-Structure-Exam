using System;
using MergeSort.Services;

namespace MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MergeSort<int> sort = new MergeSort<int>();
            Random ran = new Random();
            int[] a = new int[256];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ran.Next(0,100);
            }
            sort.sort(a);

            foreach (int t in a)
            {
                Console.WriteLine(t);
            }

            while (true)
            {
                
            }
        }
    }
}
