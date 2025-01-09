using System;
using UnityEngine;

namespace Dejkstra.World_Representation
{
    [Serializable]
    public class Edge
    {
        [SerializeField] public Transform StartNode;
        [SerializeField] public Transform EndNode;

        public float GetCost => Vector3.Distance(StartNode.position, EndNode.position);
    }
}