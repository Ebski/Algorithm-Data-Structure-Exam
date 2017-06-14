using System;

namespace RecursionAndBinarySearch.Services
{
    public class BinarySearch
    {
        public double getSquareRoot(int n)
        {
            double low = 0;
            double high = n;
            double mid = 0;

            while (high - low > 0.0001)
            {
                mid = low + (high - low) / 2;
                if (mid * mid > n)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            return Math.Round(mid, 2);
        }
    }
}
