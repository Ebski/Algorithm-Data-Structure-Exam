using System.Collections;
using System.Collections.Generic;

namespace Bags_Queues_and_Stacks.Services.Queues
{
    public interface IQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Insert a new T into the queue.
        /// </summary>
        /// <param name="item"></param>
        void enqueue(T item);
        /// <summary>
        /// Remove and return T from the queue.
        /// </summary>
        /// <returns></returns>
        T dequeue();
        /// <summary>
        /// Is the queue empty.
        /// </summary>
        /// <returns></returns>
        bool isEmpty();
        /// <summary>
        /// Number of T in the queue.
        /// </summary>
        /// <returns></returns>
        int size();
    }
}
