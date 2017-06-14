namespace Stacks.Services
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] s;
        private int N = 0;

        public ArrayStack()
        {
            s = new T[1];
        }

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

        public bool isEmpty()
        {
            return N == 0;
        }

        public int size()
        {
            return N;
        }

        private void resize(int capacaty)
        {
            T[] copy = new T[capacaty];
            for (int i = 0; i < N; i++)
            {
                copy[i] = s[i];
            }
            s = copy;
        }
    }
}
