# Recursion and Binary Search

### Recursion

Recursion is a method where the solution to a problem depends on the solutions of smaller instances of that problem. An example of this could be the Fibonacci numbers. The Fibonacci number of 5 is equal to the Fibonacci number of 4 + the Fibonacci number of 3. When faced with a problem like that it's possible to write a recursive method. If the previous example is used again then to find the Fibonacci number of 5 we would have to find the Fibonacci number of 4 & 3. To find the Fibonacci number of 4 we would have to find the Fibonacci number of 3 & 2 and so on. 

```c#
public int fibonacci(int n) 
{
	if (n == 0 || n == 1)
        {
            return 1;
        }
    return fibonacci(n - 1) + fibonacci(n - 2);
} 
```
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/1%20-%20Recursion%20and%20Binary%20search/RecursionAndBinarySearch/RecursionAndBinarySearch/Services/Fibonacci.cs)

This would be a solution on how to get the Fibonacci numbers using a recursive strategy. The Fibonacci Sequence is: 1, 1, 2, 3, 5, 8, 13, 21 .......

If using the example of 5 this code would return 5 + 3 so 8. 

It's not always a good idea to use Recursive as it can be very costly on memory. So in this case it would properly be a better idea to use something like an array.

```c#
   public int fibonacci(int n) 
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
```
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/1%20-%20Recursion%20and%20Binary%20search/RecursionAndBinarySearch/RecursionAndBinarySearch/Services/Fibonacci.cs)

This is due to the amount of calls to the same method is not in anyway controlled and can become very very high. But in other cases such as balanced search trees recursion will work very well, as the cost will be more or less the same at all times. An example of this would be in the union find example of weighted quick union where the root needs to be found. Here the code looks like this.

```c#
    private int root(int i)
    {
        if (i == id[i])
        {
            return i;
        }
        id[i] = id[id[i]];
        i = id[i];
        return root(i);
    }
```
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/1%20-%20Recursion%20and%20Binary%20search/UnionFind/UnionFind/Service/WeigthedQuicUnionUF.cs)

As the tree is weighted the cost is close to constant, and will never become to high.

### Binary Search

Binary search is also know as logarithmic search. It's a way to sort through an ordered array and is done by removing half of the array where we are searching. if we assume we have an array with the numbers 1 to 9 all sorted and we where searching for the number 3. The way a binary search would do it is to then to look for the middle number in the array which would be 5 and then remove all numbers above that as 3 is lower. Then the half of 1 and 5 would be found which is 3 and the number has been found. Binary search is great as it reduces the cost of going through an array from big O(n) to big O(log n), hence why its also called logarithmic search.

The following is an example of how binary search can be used to find the square root of a number.

```c#
   public double squareRoot(int n)
   {
        double low = 0;
        double high = n;
        double mid = 0;

        while (high - low > 0.000000000000001)
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
        return mid;
    }
```
Code can be found [here]()

If we as an example was going to find the square root of 16 by using this code the code would start by finding a middle value that is 8. It will then find the value of 8^2 and find out if that is bigger than 16. As it is the new high value would become 8 and the new middle value would become 4. 4^2 is 16 and that means we would set the low value to 4 as well. Now we have that high - low is less than 0,0000000000001 and that it is actually exactly 0 which means we have found the square root of 16 by using a binary search.

### Union Find

There is also a project of Union Find located in this folder which shows how to improve on algorithms by making small steps. The first union find is called quick find and is not scalable. The next one is called quick union, and is better than quick find but still doesn't scale. The last one is called weighted quick union and is a good solution to the problem of union find.
