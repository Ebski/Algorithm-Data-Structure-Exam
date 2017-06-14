using System;
using Bags_Queues_and_Stacks.Services.Stacks;

namespace Bags_Queues_and_Stacks
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

            while (true)
            {

            }
        }
    }
}
