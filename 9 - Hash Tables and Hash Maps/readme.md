# Hashtables and Hashmaps

## Hashtables

Hashtables are another example of a simple table implementation. Other implementations include Binary Search Tree and Red Black Binary Search Tree. The main difference between BSTs and Hashtables are that Hashtables can't do ordered implementations. The upside to Hashtables is that they are faster. 

A Hashtable works from the idea of hashing the Key that needs to be stored into an integer. That integer needs to be between 0 and the size of the array we store in. That size is often referred to as M. We do this by using a hash method:

```c#
private int hash(Key key)
{
    return (key.GetHashCode() & 0x7fffffff % M);
} 
```
This method makes sure that we return a positive number that is M's size at its maximum. When we have created the hash we then insert the key on the hash position in the array. That way we always know where in the array we need to search, and doesn't have to run through the array. Since we are using the size of the array in the hashing we might run into some overlay on different positions in the array, and we have to consider that when creating the code for the Hashtable. There are two main solutions to dealing with that problem. One is using a Linked list on every position in the array, and the other is by using a technique called linear probing. We will start out by doing the Linked list case.

### Linked List Hashtable

The idea here is to keep M smaller than the amount of Keys we want to store (N), but not so small that the Linked list chains are too long. We should strive for keeping M to be around N/5. This will make hashing faster for search, inserts and deletes than Red Black BSTs as it will use **constant time** instead of **lg N**.

As we are using a Linked list we need to have a Node class, that should have a key, a value and a next attribute:

```c#
private class Node
{
    public Key key;
    public Value val;
    public Node next;

    public Node(Key key, Value val, Node next)
    {
        this.key = key;
        this.val = val;
        this.next = next;
    }
}
```
Then when we insert into the hashtable, we find the hash of the key, run through the linked list to see if the key already exist. If it does we overwrite the value, and if it doesn't we add a new Node to the front of the List:

```c#
public void put(Key key, Value val)
{
    int i = hash(key);
    for (Node x = st[i]; x != null; x = x.next)
    {
        if (key.Equals(x.key))
        {
            x.val = val;
            return;
        }
    }
    st[i] = new Node(key, val, st[i]);
}
```
The search works the same way. Again we hash the key and look in the Array if it exists. If it does, we run through the Linked list to find the Key and return its value.

Deleting is a little bit problematic but still fairly simple. We start by finding the Node we want to delete and also checks if there is a Node before that Node. If there is we set the previous Nodes next to the Node we want to deletes next, and the Node we want to deletes next to null. If there isn't we simply move the next Node into the array, thereby deleting the Node in front of it.

Code can be found [here]().

### Linear Probing

Linear probing requires M to be bigger than N. Linear Probing works a bit as parking cars does. We drive by spaces in the array until we find an empty one and then we store the Key there. For this to work efficiently we need M to around twice as big as N or M/2 = N. When we have that the displacement of Keys is around 3/2, meaning that half the Keys will be put in the right spot on the first try, and the other half will have to try one more time. 

To implement this we use two arrays, one for Keys and one for Values. When we insert we again start by hashing the Key, and then put the key, and value into their respective arrays. If there is already another value at the spot we try an insert the key and value at i+1. We do that until we find an empty slot for our insert:

```c#
    public void put(Key key, Value val)
    {
        int i;
        for (i = hash(key); !keys[i].Equals(default(Key)); i = (i+1) % M)
        {
            if (keys[i].Equals(key))
            {
                break;
            }
        }
        keys[i] = key;
        vals[i] = val;
    }
```
We do the exact same thing for select and delete. So an upside to this method over the Linked list is that deletion becomes simpler. 

Code can be found [here]().

For both table it's needed that we have some resizing mechanisms in place to keep the size of M close to the optimal size for M. 

## Hashmap

Hashtables and Hashmaps does the same thing, but does it a little different in java. The main difference is that Hashmaps are not synchronized, and not thread safe. This means that multiple clients will be able to access the Hashmap at the same time but be put in a queue if we where using a Hashtable instead.

Hashmaps also allow null values to be stored as values, and one key is also allowed to be null.

Hashmaps are faster and uses less memory than Hashtable as Hashmap is unsynchronized. 

Hashtables are a subclass of the Dictionary class in java which is now obsolete, so it's not used anymore. If a Synchronized Hashmap is needed the ConcurrentMap should be used.    