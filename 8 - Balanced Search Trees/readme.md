# Binary Search Trees

A Binary Search Tree or BST, is a data structure that is build with the idea of binary search in mind. To create a BST, a nested Node class is used to store information in, and the only one the BSTcan access is the root node. 

```c#
    private Node root = null;
    
    private class Node<Key, Value> {
        public Key key;
        public Value val;
        public Node left;
        public Node right;
        
        public Node(Key key, Value val) {
            this.key = key;
            this.val = val;
        }
```
 So our the entire tree will be build up around Nodes. The first Node being inserted into the BST will be the root Node, and the following Nodes will be places to the left of the root Node if the value of their key is less than the value of the roots key, or to the right if the opposite holds true. This structure will give an average depth of **1.39 log N** when keys are inserted at random. The thing about a BST is that we can't ensure that Nodes are inserted at random as we can with quick sort, and that's is the biggest shortcoming of BST. Imagine if N amount of keys that are ordered is inserted. If that is the case the depth of our BST will be N, and our BST will perform slowly.

Recursion is used to create BST, and that is done for multiple reason. First it makes the code easy and clean to read, secondly it makes it possible to update different values on the different Nodes in the tree, when we  go back up the tree after. The insert statement looks like this:

```c#
    public void put(Key key, Value val)
        {
            root = put(root, key, val);
        }

        private Node put(Node x, Key key, Value val)
        {
            if (x == null)
            {
                return new Node(key, val);
            }

            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = put(x.left, key, val);
            }
            else if (cmp > 0)
            {
                x.right = put(x.right, key, val);
            }
            else
            {
                x.val = val;
            }
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }
```
In the previous piece of code it's possible to see how a new key is inserted. The insert starts at the root, and if that is null a new Node is created and assigned as root. If there is already a root Node the compare to method then figures out if the new Node should be on the left or the right of the root Node, which happens recursively down through the BST. If there is already a Node with the given key, the Nodes value is simply overwritten. Big O for an insert is relative to the depth of the BST but the average time when dealing with random inserts of keys is **1.39 log N**.

To get information from a BST works just as the insert does. Though instead of creating a new Node when the comparator return 0, we return the value of that Node. If there is no Node associated with the given key, we simply return null, or the default value for the value. The average time for a select is also **1.39 log N**.

Deleting in a BST is a bit tricky, but it's possible to do a lazy approach where we simply delete the value from a Node and then leaves the Node in the tree. This is not particularly good code, so instead a proper deletion strategy should be used. There are 4 cases when it comes to delete.

-  Node to be deleted has 0 children (no left and no right Nodes).
- Node to be deleted has 1 children (has left Node, but not right Node).
- Node to be deleted has 1 children (has right Node, but not left Node).
- Node to be deleted has 2 children (has both a left and a right Node).

The first case is very simply. Here we can simply remove the link from the parent of the Node to be deleted and let the garbage collector do the rest of the work.

Second case is also simple as here we just overwrite the link from the parent Node to the Node to be deleted, into the left Node of the Node to be deleted. This will again leave the Node for the garbage collector.

The two last cases is where it becomes a bit more tricky. It actually doesn't matter if there is a left link or not, the case is the same. What needs to be done here is to find the minimum key value to the right of the Node that has to be deleted and replace it with the Node we want to delete. This will ensure that every key on the right side is still of a higher value that the Node we just deleted. 

The previous examples can be done with the following code:

```c#
    public void delete(Key key)
    {
        root = delete(root, key);
    }
    
    private Node delete(Node x, Key key)
    {
        if (x == null)
        {
            return null;
        }

        int cmp = key.CompareTo(x.key);
        if (cmp < 0)
        {
            x.left = delete(x.left, key);
        }
        else if (cmp > 0)
        {
            x.right = delete(x.right, key);
        }
        else
        {
            if (x.right == null) return x.left;
            if (x.left == null) return x.right;

            Node t = x;
            x = min(t.right.key);
            x.right = deleteMin(t.right);
            x.left = t.left;
        }
        x.count = 1 + size(x.left) + size(x.right);
        return x;
    } 
```
The fun thing about deleting in a BST is that it will skew the BST to the left. What this means is that we will no longer have the average height of **1.39 log N** when deleting is allowed. Instead we will have the average height of **square root N**.

Code for BST can be found [here]().

To optimize a BST we need to find a way to make sure that the operations have a guaranteed time of **log N**. And for that we use a slight modification called the **Red Black Binary Search Tree** (RBBST). A RBBST does this by balancing the tree every time a Node is inserted or deleted. Therefor we give the Node a boolean attribute colour. If colour is true the link between a Node and its parent is red, and if it's false then the link is black. Now when we create a Node we set the colour of  the link to red. If we have a Node with a red link to its right child we flip the tree to the left. If we have a Node with a red link to its parent and a red link to its left child we flip the parent Node to the right. And if we have a Node with red links to both its children we flip the colours of both and add a red link to the parent. If this is done then the tree will stay balanced. 

So say we put in the sequence of numbers 1,2,3. What would happen is that 1would be placed. Then we would add in 2 and then tree would shift to the left so that 2 is now the root Node with 1 as its left child. 3 would then be put as 2 right child, and we have a balanced search tree.

Code can be found [here]().

