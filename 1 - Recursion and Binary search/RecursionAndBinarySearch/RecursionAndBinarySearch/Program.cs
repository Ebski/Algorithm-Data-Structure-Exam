using System;
using RecursionAndBinarySearch.Services;

namespace RecursionAndBinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Fibonacci fib = new Fibonacci();
            Console.WriteLine(fib.getrecursiveFibonacci(5));
            Console.WriteLine(fib.getarrayFionacci(5));
            while (true)
            {
                
            }
        }
    }
}
