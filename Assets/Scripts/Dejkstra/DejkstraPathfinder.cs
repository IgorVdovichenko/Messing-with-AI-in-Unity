using System.Collections.Generic;
using System.Linq;
using Dejkstra.Graph;

namespace Dejkstra
{
    public class Pathfinder
    {
        private readonly Graph.Graph _graph;
        
        private PathfinderCollection _closedRecords = new PathfinderCollection();
        private PathfinderCollection _openRecords = new PathfinderCollection();

        public Pathfinder(Graph.Graph graph)
        {
            _graph = graph;
        }

        public Connection[] GetShortestPath(Node fromNode, Node toNode)
        {
            var startRecord = new NodeRecord()
            {
                Node = fromNode,
                Cost = 0,
                Connection = null
            };
            
            _openRecords.Add(startRecord);

            while (_openRecords.Count > 0)
            {
                var currentNode = _openRecords.GetRecordWithSmallestCost();

                if (currentNode.Node == toNode)
                {
                    UpdateCollections(currentNode);
                    break;
                }
                
                IterateConnectionsForNode(currentNode);
                UpdateCollections(currentNode);
            }
            
            return RevertConnections(GetReversedPath(fromNode, toNode));
        }

        private void UpdateCollections(NodeRecord record)
        {
            _openRecords.Remove(record);
            _closedRecords.Add(record);
        }

        private void IterateConnectionsForNode(NodeRecord currentNode)
        {
            var connections = _graph.GetConnectionFrom(currentNode.Node);
            
            foreach (var connection in connections)
            {
                var endNode = connection.EndNode;
                if(_closedRecords.TryGetRecordWithNode(endNode, out _)) continue;
                var costSoFar = currentNode.Cost + connection.Cost;

                var newRecord = new NodeRecord()
                {
                    Node = endNode,
                    Connection = connection,
                    Cost = costSoFar
                };
                    
                _openRecords.Add(newRecord);
            }
        }

        private Connection[] GetReversedPath(Node start, Node end)
        {
            var output = new List<Connection>();
            Node node = end;

            while (node != start)
            {
                _closedRecords.TryGetRecordWithNode(node, out var r);
                node = r.Connection.StartNode;
                output.Add(r.Connection);
            }
            
            return output.ToArray();
        }

        private static Connection[] RevertConnections(IEnumerable<Connection> connections)
        {
            return connections.Reverse().ToArray();
        }
    }
}