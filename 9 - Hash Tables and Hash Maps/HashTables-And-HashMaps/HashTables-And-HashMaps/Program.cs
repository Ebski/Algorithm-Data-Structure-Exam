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
            Console.WriteLine(ht.size());

            ht.put(101,101);

            for (int i = 80; i > 1; i--)
            {
                ht.delete(i);
            }
            Console.WriteLine(ht.size());
            ht.put(80,80);
            while (true)
            {
                
            }
        }
    }
}
