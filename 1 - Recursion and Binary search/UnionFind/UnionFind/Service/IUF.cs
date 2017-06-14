using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind.Service
{
    public interface IUF
    {
        /// <summary>
        /// Add connection between p and q.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        void union(int p, int q);
        /// <summary>
        /// Are p and q in the same component.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        bool connected(int p, int q);
        /// <summary>
        /// Find p.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        int find(int p);
        /// <summary>
        /// Number of components.
        /// </summary>
        /// <returns></returns>
        int count();
    }
}
