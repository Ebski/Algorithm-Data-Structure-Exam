# Quick Sort

Quick Sort has been named as one of the most important algorithms of the 20th century. It uses recursion as merge sort does but instead of halving the objects to be sorted it uses partitioning to find the right placement for one element in the array. Then it does the same again on the left side of the partitioning and then on the right. The average number of compares when using quick sort is **1.39 N lg N** which is 39% more than merge sort. The amount of compares needed for quick sort depends on how shuffled the array we are sorting is. If the array is not sorted then the amount of compares needed is quadratic **N*N**. Due to this the first thing that is done when using quick sort is to randomly shuffle the array. That way we can ensure that the algorithms keeps a good speed. A visual example of this:

| 0    | 1    | 2     | 3    | 4    | 5    | 6     | 7     | 8    |
| ---- | ---- | ----- | ---- | ---- | ---- | ----- | ----- | ---- |
| 1    | 2    | 3     | 4    | 5    | 6    | 7     | 8     | 9    |
| 3    | 4    | 8     | 1    | 2    | 9    | 7     | 5     | 6    |
| 1    | 2    | **3** | 4    | 8    | 9    | 7     | 5     | 6    |
| 1    | 2    | 3     | 4    | 7    | 5    | 6     | **8** | 9    |
| 1    | 2    | 3     | 4    | 5    | 6    | **7** | 8     | 9    |

So here we see how quick sort in action works. The numbers being partitioned are shown in **bold**. The first number is 3, so everything smaller than 3 is moved to the left side, and everything higher is moved to the right side. Then the same is done for 8, and last for 7, and we have a sorted array.

```c#
public T[] sort(T[] a)
{
    Random ran = new Random();
    a = a.OrderBy(x => ran.Next()).ToArray();
    sort(a, 0, a.Length - 1);
    return a;
}

private void sort(T[] a, int low, int high)
{
    if (high <= low)
    {
        return;
    }

    int j = partition(a, low, high);
    sort(a, low, j - 1);
    sort(a, j + 1, high);
}
```
As mentioned before the algorithm uses 39% more compares than merge sort, but the algorithm is faster than merge sort due to less data movement. We also don't need an axillary array which also makes quick sort use less memory. 

Just as with merge sort it's possible to improve on Quick sort by using insertion sort when the partition subsets gets small. This is again due to insertion sort is fast at sorting small subset and quicksort having to much overhead with the recursion calls. This is done as with merge sort.

```c#
if (high <= low + 10 - 1)
{
    a = insertion.sort(a, low, high);
    return;
} 
```
 Another way is to guide the partitioning to be closer to an object in the middle. To do this we take the median of 3 objects, the object about to be partitioned, one close to the middle, and one in the end. That way we increase the performance of the search even though we will do more swaps, as we will put that median in the spot of the object that is about to be partitioned. This can be done with the following code.

```c#
  int m = medianOf3(low, low + (high - low) / 2, high);
  exchange(a, low, m);
  
  private int medianOf3(int a, int b, int c)
  {
      return Math.Max(Math.Min(a, b), Math.Min(Math.Max(a, b), c));
  }
```

Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/5%20-%20Quick%20Sort/QuickSort/QuickSort/Services/QuickSortAlgorithm.cs).
