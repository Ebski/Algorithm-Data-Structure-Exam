# Bags, Queues and Stacks

Bags, Queues and Stacks are all fundamental data types. They are used to store a collection of objects, and all have the same functionality. They should all have the operations insert, remove, iterate, count and test if empty. The difference between them is how we insert and how we remove the objects in the respective collections.

### Bags

### Queues



### Stacks

Stacks makes use of LIFO (last in first out). There are two main ways to create a stack. In one a Linked List is used, and in the other an Array is used. Both works well but it should be given some thought which of them to use in which case. 

##### Linked List

With the Linked List implementation every operation takes constant time in the worst case which is great. The downside of the implementation is that it uses extra time and space to deal with the links. The linked List implementation makes use of a nested inner class called Node.

```c#
private class Node
{
    public T item;
    public Node next;
} 
```
It then adds Nodes to the front of the List to add an item.

```c#
public void push(T item)
{
    Node oldFirst = first;
    first = new Node
    {
        item = item,
        next = oldFirst
    };
}
```
And remove the front of the List to remove an item.

```c#
public T pop()
{
    T item = first.item;
    first = first.next;
    return item;
}
```
<<<<<<< Updated upstream
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Stacks/LinkedListStack.cs).
=======
Code can be found [here]().
>>>>>>> Stashed changes

##### Array

In the Array implementation every operation takes constant amortized time. That means that on average the implementation takes constant time, though there is a problem when the array needs to be double it uses O(n) time. The Array implementation also uses less space and is faster in general

The Array implementation uses a resize method to make sure that there is not to much wasted space. The idea is that the array should always be between 25% and 100% full. This is done by doubling the array when it's full and cutting the array in half when its on 25% capacity.

```c#
private void resize(int capacity)
{
    T[] copy = new T[capacity];
    for (int i = 0; i < N; i++)
    {
        copy[i] = s[i];
    }
    s = copy;
}
```
At the same time an integer called N in my example keeps track of how many items are in the stack. This allows easy array access in pus and pop methods.

```c#
public void push(T item)
{
    if (N == s.Length)
    {
        resize(2 * s.Length);
    }
    s[N++] = item;
}

public T pop()
    {
        T item = s[--N];
        s[N] = default(T);
        if (N > 0 && N == s.Length / 4)
        {
            resize(s.Length/2);
        }
        return item;
    }
```
<<<<<<< Updated upstream
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Stacks/ArrayStack.cs).
=======
Code can be found [here]().
>>>>>>> Stashed changes

##### Conclusion

The Array implementation should be the one used in most cases, though if there are information that is critical the Linked List should be used. This is due to the always constant time of the Linked List whereas the Array can only provide it amortized.