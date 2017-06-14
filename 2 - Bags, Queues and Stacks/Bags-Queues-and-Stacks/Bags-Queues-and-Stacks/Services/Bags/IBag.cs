using System.Collections;
using System.Collections.Generic;

namespace Bags_Queues_and_Stacks.Services.Bags
{
    public interface IBag<T> : IEnumerable<T>
    {
        void add(T item);
        int size();
    }
}
