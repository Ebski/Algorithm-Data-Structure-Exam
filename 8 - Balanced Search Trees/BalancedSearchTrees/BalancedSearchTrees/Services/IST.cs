using System;
using System.Collections;

namespace BalancedSearchTrees.Services
{
    public interface IST<Key, Val> where Key : IComparable
    {
        void put(Key key, Val val);
        Val get(Key key);
        void delete(Key key);
        bool contains(Key key);
        bool isEmpty();
        int size();
    }
}
