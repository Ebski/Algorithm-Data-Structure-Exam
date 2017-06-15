# Merge Sort

Merge sort is together with quick sort two of the classic sorting algorithms used in computer science. Merge sort uses the divide and conquer principle to sort. What this means is that if we have an array of 8 objects that array would be split in first 2 then 4 and then 8. The idea is to have 2 sorted arrays and then merge those two arrays together. If we where to make an example of this.

| 0    | 1    | 2    | 3    | 4    | 5    | 6    | 7    |
| ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- |
| 8    | 4    | 6    | 2    | 9    | 3    | 1    | 5    |
| 4    | 8    | 2    | 6    | 3    | 9    | 1    | 5    |
| 2    | 4    | 6    | 8    | 1    | 3    | 5    | 9    |
| 1    | 2    | 3    | 4    | 5    | 6    | 8    | 9    |

So If we look at the table, where the top row is the placement in the array, we can see how a merge sort works. First we split the array into groups of two and sort those. That can be seen in column 3. Then we split the array into groups of 4 and sort those. That can be seen in column 4 and now we have an array with 2 sorted halves so we merge them together and we have a sorted array. To implement merge sort we use recursion as that works very well with the divide and conquer principle. 

```c#
public T[] sort(T[] a)
{
    array = a;
    T[] aux = new T[array.Length];
    sort(array, aux, 0, array.Length - 1);
    return array;
}

private void sort(T[] a, T[] aux, int low, int high)
{
    if (high <= low)
    {  
        return;
    }
    int mid = low + (high - low) / 2;
    sort(a, aux, low, mid);
    sort(a, aux, mid + 1, high);
    merge(a, aux, low, mid, high);
}  
```
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/4%20-%20Merge%20Sort/MergeSort/MergeSort/Services/RecursiveMergeSort.cs).

This is a very efficient way of sorting an array and Merge sort uses at most **N lg N** compares and **6 N lg N** array accesses to sort any array of size N. In comparison to something like insertion sort or selection sort who both uses quadratic or **N*N** time this is a significant improvement. 

What the above means is that if we where running a program and wanted to sort a million objects, the time for insertion sort on a normal computer would be more than 2 hours, whereas merge sort should be able to handle that in a second. Merge sort uses extra memory proportional to N, due to the auxiliary array. That means you can only sort half of what the memory of the pc can fit. 

To improve the original merge sort a few easy steps can be taken. The most simple is too use insertion sort to sort parts of the array when they are at a tiny size. Insertion sorts is great at sorting tiny amounts of data and when the subsets gets small there is to much overhead from the recursion calls to get the sort done efficiently. That can be done with very few lines of code to the original merge sort algorithm.

```c#
 if (high <= low + 7 - 1)
{
    a = insertion.sort(a, low, high);
    return;
}
```
Another improvement is to check if the subsets are already in order before we merge them together. If they are no merge is needed. Again that can be done with very few lines of code.

```c#
if (a[mid + 1].CompareTo(a[mid]) > 0)
{
    return;
}
```
It's also possible to create a merge sort algorithm that doesn't use recursion. The way to do that is to think of the array being sorted as sub arrays of the size 1. Then the sub arrays are merged together into subarrays of size 2 and then into sub arrays of size 4 and so on. The only downside with this algorithm again is that it uses extra memory proportional to N again due to the auxiliary array.

Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/4%20-%20Merge%20Sort/MergeSort/MergeSort/Services/MergeSort.cs).

One of the goals about algorithms is to create optimal algorithm and it turns out that merge sort is optimal for sorting when it comes to compares. The lower bound of compares when sorting an algorithm is **N log N** and that is exactly the amount of compares Merge sort does. Merge sort is not optimal with respect to space usage as merge sort still uses extra memory proportional to N. 
