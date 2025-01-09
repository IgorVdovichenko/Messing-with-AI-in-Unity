using Dejkstra.Graph;

namespace Dejkstra
{
    public struct NodeRecord
    {
        public Node Node { get; set; }
        public Connection Connection { get; set; }
        public double Cost { get; set; }
    }
}