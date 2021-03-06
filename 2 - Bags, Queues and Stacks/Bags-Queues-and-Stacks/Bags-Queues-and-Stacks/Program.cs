﻿using System;
using Bags_Queues_and_Stacks.Services.Bags;
using Bags_Queues_and_Stacks.Services.Queues;
using Bags_Queues_and_Stacks.Services.Stacks;

namespace Bags_Queues_and_Stacks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Stack");
            IStack<int> stack = new ArrayStack<int>();
            stack.push(1);
            stack.push(2);
            stack.push(5);
            Console.WriteLine(stack.pop());
            stack.push(3);
            stack.push(4);
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());

            Console.WriteLine("\n---------------------\n");

            Console.WriteLine("Queue");
            IQueue<int> queue = new ArrayQueue<int>();
            queue.enqueue(1);
            queue.enqueue(2);
            queue.enqueue(3);
            queue.enqueue(4);
            queue.enqueue(5);
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());

            Console.WriteLine("\n---------------------\n");

            Console.WriteLine("Bag");
            IBag<int> bag = new LinkedListBag<int>();
            bag.add(1);
            bag.add(8);
            bag.add(3);
            bag.add(2);
            bag.add(4);

            foreach (int i in bag)
            {
                Console.WriteLine(i);   
            }

            while (true)
            {

            }
        }
    }
}
