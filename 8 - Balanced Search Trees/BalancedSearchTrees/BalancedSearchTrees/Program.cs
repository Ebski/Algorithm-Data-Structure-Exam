using System;
using System.Collections.Generic;
using BalancedSearchTrees.Services;
using BalancedSearchTrees.Services.Queue;

namespace BalancedSearchTrees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BST<int, int> bst = new BST<int, int>();

            Console.WriteLine(bst.isEmpty());
            bst.put(7,7);
            bst.put(2,2);
            bst.put(5,5);
            bst.put(1,1);
            bst.put(3,3);
            bst.put(4,4);
            bst.put(6,6);
            Console.WriteLine("Size: " + bst.size());
            Console.WriteLine("Does 4 exist in the tree? " + bst.contains(4));
            bst.delete(4);
            Console.WriteLine("Does 4 still exist in the tree? " + bst.contains(4));
            Console.WriteLine("Getting 3 " + bst.get(3));

            // Doesn't work but shoud.

            // IQueue<int> queue = bst.keys();
            // Console.WriteLine("Number of keys: " + queue.size());
            // Console.WriteLine("printing keys");
            // foreach (int i in queue)
            // {
            //     Console.WriteLine(i);
            // }
            
        }
    }
}
