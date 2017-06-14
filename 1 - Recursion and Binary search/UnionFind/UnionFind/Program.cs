using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind.Service;

namespace UnionFind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUF uf = new WeigthedQuicUnionUF(10);

            uf.union(1,2);
            uf.union(4,2);
            uf.union(8,7);
            uf.union(3,4);
            uf.union(4,7);

            Console.WriteLine(uf.connected(1,7));
            Console.WriteLine(uf.connected(1,9));

            uf.union(7,9);

            Console.WriteLine(uf.connected(1,9));

            while (true)
            {
                
            }
        }
    }
}
