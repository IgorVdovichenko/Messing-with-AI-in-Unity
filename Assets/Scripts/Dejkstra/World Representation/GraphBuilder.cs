using System.Collections.Generic;
using System.Linq;
using Dejkstra.Graph;
using UnityEngine;

namespace Dejkstra.World_Representation
{
    public class GraphBuilder : MonoBehaviour
    {
        [SerializeField] private Edge[] _edges;
        
        private List<Node> nodes = new List<Node>();

        private void Awake()
        {
            var graph = new Graph.Graph(GetConnections());

            var start = nodes.FirstOrDefault(n => n.Id == 0);
            var end = nodes.FirstOrDefault(n => n.Id == 5);
            
            var pathfinder = new Pathfinder(graph);
            var path = pathfinder.GetShortestPath(start, end);
            
            foreach (var connection in path)
            {
                Debug.LogError($"{connection.StartNode.Id} - {connection.EndNode.Id}");
            }
        }

        private Connection[] GetConnections()
        {
            var output = new List<Connection>();
            foreach (var edge in _edges)
            {
                var startNode = nodes.FirstOrDefault(n => n.Id == GetId(edge.StartNode))
                                ?? new Node(GetId(edge.StartNode));
                
                var endNode = nodes.FirstOrDefault(n => n.Id == GetId(edge.EndNode))
                                ?? new Node(GetId(edge.EndNode));
                
                if(!nodes.Contains(startNode)) nodes.Add(startNode);
                if(!nodes.Contains(endNode)) nodes.Add(endNode);
                
                var connection = new Connection(startNode, endNode, edge.GetCost);
                output.Add(connection);
            }

            return output.ToArray();
        }

        private int GetId(Transform t)
        {
            int output = 0;
            int.TryParse(t.gameObject.name, out output);
            return output;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            foreach (var edge in _edges)
            {
                Gizmos.DrawLine(edge.StartNode.position, edge.EndNode.position);
            }
        }
    }
}