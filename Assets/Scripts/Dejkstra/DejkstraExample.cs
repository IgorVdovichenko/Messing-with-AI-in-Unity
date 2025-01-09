using System;
using Dejkstra.Graph;
using UnityEngine;

namespace Dejkstra
{
    public class DejkstraExample : MonoBehaviour
    {
        private void Awake()
        {
            var a = new Node(1);
            var b= new Node(2);
            var c = new Node(3);
            var d = new Node(4);
            var e = new Node(5);
            var f = new Node(6);
            
            var ab = new Connection(a, b, 1.5);
            var ad = new Connection(a, d, 5);
            var bc = new Connection(b, c, 1.5);
            var cd = new Connection(c, d, 1.5);
            var de = new Connection(d, e, 1);
            var cf = new Connection(c, f, 3);

            var connections = new []
            {
                ab, ad, bc, cd, de, cf
            };
            
            var graph = new Graph.Graph(connections);
            
            var pathfinder = new Pathfinder(graph);
            var path = pathfinder.GetShortestPath(a, e);

            foreach (var connection in path)
            {
                Debug.LogError($"{connection.StartNode.Id} - {connection.EndNode.Id}");
            }

        }
    }
}