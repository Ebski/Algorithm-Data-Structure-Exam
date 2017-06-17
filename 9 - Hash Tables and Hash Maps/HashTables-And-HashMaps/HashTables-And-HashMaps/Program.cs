using System;
using HashTables_And_HashMaps.Services;

namespace HashTables_And_HashMaps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHashTable<int, int> ht = new PropingHashTable<int, int>();

            for (int i = 0; i < 100; i++)
            {
                ht.put(i, i);
            }

            Console.WriteLine(ht.get(50));
            ht.delete(50);
            Console.WriteLine(ht.get(50));

            while (true)
            {
                
            }
        }
    }
}
