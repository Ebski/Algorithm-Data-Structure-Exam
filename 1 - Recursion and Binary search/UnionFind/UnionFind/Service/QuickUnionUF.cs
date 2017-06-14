using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind.Service
{
    public class QuickUnionUF : IUF
    {
        private int[] id;

        public QuickUnionUF(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }

        /// <summary>
        /// Searches for the root of a given int.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int root(int i)
        {
            while (i != id[i])
            {
                i = id[i];
            }
            return i;
        }

        public void union(int p, int q)
        {
            int i = root(p);
            int j = root(q);
            id[i] = j;
        }

        public bool connected(int p, int q)
        {
            return root(p) == root(q);
        }

        public int find(int p)
        {
            return id[p];
        }

        public int count()
        {
            return id.Length;
        }
    }
}
