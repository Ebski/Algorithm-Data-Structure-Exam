namespace HashTables_And_HashMaps.Services
{
    public interface IHashTable<Key, Value>
    {
        void put(Key key, Value val);
        Value get(Key key);
        void delete(Key key);
    }
}
