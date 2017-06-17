namespace HashTables_And_HashMaps.Services
{
    public class PropingHashTable<Key, Value> : IHashTable<Key, Value>
    {
        private int M = 200;
        private Value[] vals;
        private Key[] keys;

        public PropingHashTable()
        {
            vals = new Value[M];
            keys = new Key[M];
        }

        public void put(Key key, Value val)
        {
            int i;
            for (i = hash(key); !keys[i].Equals(default(Key)); i = (i+1) % M)
            {
                if (keys[i].Equals(key))
                {
                    break;
                }
            }
            keys[i] = key;
            vals[i] = val;
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
                    break;
                }
            }
            keys[i] = default(Key);
            vals[i] = default(Value);
        }

        private int hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff % M);
        }
    }
}
