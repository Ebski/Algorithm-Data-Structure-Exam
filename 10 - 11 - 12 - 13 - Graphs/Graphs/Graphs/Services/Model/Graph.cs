using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Graphs.Services.Model
{
    public class Graph
    {
        public List<Node> nodes { get; set; }

        public Graph()
        {
        }

        public Graph(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public Node findNode(int id)
        {
            return nodes.FirstOrDefault(node => node.id == id);
        }
    }
}
