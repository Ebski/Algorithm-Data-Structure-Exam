using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind.Service
{
    public class QuickFindUF : IUF
    {
        private int[] id;
        public QuickFindUF(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }

        public void union(int p, int q)
        {
            int pid = id[p];
            int qid = id[q];
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pid) id[i] = qid;
            }
        }

        public bool connected(int p, int q)
        {
            return id[p] == id[q];
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
