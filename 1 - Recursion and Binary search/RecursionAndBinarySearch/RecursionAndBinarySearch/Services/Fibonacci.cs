namespace RecursionAndBinarySearch.Services
{
    public class Fibonacci
    {
        public int getrecursiveFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return getrecursiveFibonacci(n - 1) + getrecursiveFibonacci(n - 2);
        }

        public int getarrayFionacci(int n)
        {
            int[] FibonacciNumbers = new int[n + 1];
            for (int i = 0; i < FibonacciNumbers.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    FibonacciNumbers[i] = 1;
                }
                else
                {
                    FibonacciNumbers[i] = FibonacciNumbers[i - 1] + FibonacciNumbers[i - 2];
                }
            }
            return FibonacciNumbers[n];
        }
    }
}
