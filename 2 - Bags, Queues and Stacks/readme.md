# Bags, Queues and Stacks

Bags, Queues and Stacks are all fundamental data types. They are used to store a collection of objects, and all have the same functionality. queues and stacks should have the operations insert, remove, iterate, count and test if empty. Bag is simpler and should just have add and then a way to iterate through all items in the bag. The difference between them is how we insert and how we remove the objects in the respective collections.

### Bags

Bags are the simples datatypes. They work exactly like a bag in the way that we throw stuff in there and are not really interested in how they land. What we are interested in is to iterate through the bag at some point to find all the data down there. To do this with an Array is extremely simple. We have an array, an add method, a resize method, a count method and an Iterate method.

C# implementation can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Bags/ArrayBag.cs).

We can also implement a bag using a Linked List. As with the array this is also very easy. We create a nested inner class called Node, has a reference to a node called first, and every time we add a Node we just add it to the front of the List. We then also have an iterator that can go through the linked list and print everything in the bag.

C# implementation can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Bags/LinkedListBag.cs).

### Queues

Queues makes use of FIFO (first in first out). The easiest way to make a queue is using Linked List. This is nearly identical to making a Linked list Stack here there is just an extra reference to the last Node while at the same time keeping a reference to the first Node. This is done so new Nodes can be put in at the end of the Linked List. A check is also made to see if the List is empty when the new Node is being created. If thats the case the last Node in the list will also be the first one.

```c#
 public void enqueue(T item)
 {
    Node oldLast = last;
    last = new Node
    {
        item = item,
        next = oldLast
    };

    if (isEmpty())
    {
        first = last;
    }
    else
    {
        oldLast.next = last;
    }
}
```

To dequeue from a queue is just as dequeueing from a stack. The only difference is that a check has to be put in to see if the last Node in the list is being removed. If thats the case the last reference is set to 0.

```c#
public T dequeue()
{
    T item = first.item;
    first = first.next;
    if (isEmpty())
    {
        last = null;
    }
    return item;
}
```

Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Queues/LinkedListQueue.cs).

It's also possible to make a queue with an array but it's a lot more cumbersome. For this we need to keep a reference to the head and the tail of the objects in the array. When we enqueue we add a new item at the tail, and when we dequeue we remove an item from the head. The problem with this is that we can end up with arrays that looks like this:

| Array values    | null | null | 1    | 2    | 3    | 4    | 5    | null | null |
| --------------- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- |
| Array placement | 0    | 1    | 2    | 3    | 4    | 5    | 6    | 7    | 8    |
| references      |      |      | head |      |      |      | tail |      |      |

Furthermore we have to resize when the tail reaches the end of the array as well as if the array gets to big. An example of a try of implementing this can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Queues/ArrayQueue.cs)

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
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Stacks/LinkedListStack.cs).

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
Code can be found [here](https://github.com/Ebski/Algorithm-Data-Structure-Exam/blob/master/2%20-%20Bags%2C%20Queues%20and%20Stacks/Bags-Queues-and-Stacks/Bags-Queues-and-Stacks/Services/Stacks/ArrayStack.cs).

##### Conclusion

The Array implementation should be the one used in most cases, though if there are information that is critical the Linked List should be used. This is due to the always constant time of the Linked List whereas the Array can only provide it amortized.
