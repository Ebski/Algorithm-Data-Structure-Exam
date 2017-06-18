using System;
using HashTables_And_HashMaps.Services;

namespace HashTables_And_HashMaps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHashTable<int, int> ht = new LinkedListHashTable<int, int>();

            for (int i = 0; i < 100; i++)
            {
                ht.put(i, i);
            }

            for (int i = 0; i < 80; i++)
            {
                ht.delete(i);
            }

            Console.WriteLine(ht.size());

            while (true)
            {
                
            }
        }
    }
}
