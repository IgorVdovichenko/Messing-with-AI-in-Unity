namespace Dejkstra.Graph
{
    public class Connection
    {
        public Node StartNode { get; }
        public Node EndNode { get; }
        public double Cost { get; }

        public Connection(Node startNode, Node endNode, double cost)
        {
            StartNode = startNode;
            EndNode = endNode;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"From node - {StartNode.Id} to node - {EndNode.Id} with cost - {Cost}";
        }
    }
}