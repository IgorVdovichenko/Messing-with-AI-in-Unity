using System.Linq;

namespace Dejkstra.Graph
{
    public class Graph
    {
        private readonly Connection[] _connections;

        public Graph(Connection[] connections)
        {
            _connections = connections;
        }

        public Connection[] GetConnectionFrom(Node node)
        {
            return _connections
                .Where(c => c.StartNode == node)
                .ToArray();
        }
    }
}