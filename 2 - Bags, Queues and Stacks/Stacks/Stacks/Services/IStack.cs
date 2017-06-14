namespace Stacks.Services
{
    public interface IStack<T>
    {
        /// <summary>
        /// Insert a new T2 into the stack.
        /// </summary>
        /// <param name="item"></param>
        void push (T item);
        /// <summary>
        /// Remove and return the T1 most recently added.
        /// </summary>
        /// <returns></returns>
        T pop();
        /// <summary>
        /// Is the stack empty.
        /// </summary>
        /// <returns></returns>
        bool isEmpty();
        /// <summary>
        /// Whats the size of the Stack.
        /// </summary>
        /// <returns></returns>
        int size();
    }
}
