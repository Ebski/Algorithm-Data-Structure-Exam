using System;

namespace HashTables_And_HashMaps.Services
{
    public class PropingHashTable<Key, Value> : IHashTable<Key, Value>
    {
        private int M;
        private int count;
        private Value[] vals;
        private Key[] keys;

        public PropingHashTable()
        {
            M = 8;
            vals = new Value[M];
            keys = new Key[M];
        }

        public void put(Key key, Value val)
        {
            bool newEntry = true;
            int i;
            for (i = hash(key); !keys[i].Equals(default(Key)); i = (i+1) % M)
            {
                if (keys[i].Equals(key))
                {
                    newEntry = false;
                    break;
                }
            }
            keys[i] = key;
            vals[i] = val;

            if (newEntry)
            {
                count++;
                doubleArrays();
            }
        }

        public Value get(Key key)
        {
            for (int i = hash(key); !keys[i].Equals(default(Key)); i = (i+1 % M))
            {
                if (keys[i].Equals(key))
                {
                    return vals[i];
                }
            }
            return default(Value);
        }

        public void delete(Key key)
        {
            int i;
            for (i = hash(key); !keys[i].Equals(default(Key)); i = (i+1) % M)
            {
                if (keys[i].Equals(key))
                {
                    keys[i] = default(Key);
                    vals[i] = default(Value);
                    count--;
                    halfArrays();
                    break;
                }
            }
        }

        public int size()
        {
            return count;
        }

        private void doubleArrays()
        {
            if ((count * 10) / keys.Length <= 5)
            {
                return;
            }
            Key[] oldKeys = keys;
            Value[] oldVals = vals;
            M = M * 2;
            keys = new Key[M];
            vals = new Value[M];
            count = 0;
            
            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (!oldKeys[i].Equals(default(Key)))
                {
                    put(oldKeys[i], oldVals[i]);
                }
            }
        }

        private void halfArrays()
        {
            if ((count * 100) / keys.Length >= 10)
            {
                return;
            }
            Key[] oldKeys = keys;
            Value[] oldVals = vals;
            M = M / 2;
            keys = new Key[M];
            vals = new Value[M];
            count = 0;

            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (!oldKeys[i].Equals(default(Key)))
                {
                    put(oldKeys[i], oldVals[i]);
                }
            }
        }

        private int hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff % M);
        }
    }
}
