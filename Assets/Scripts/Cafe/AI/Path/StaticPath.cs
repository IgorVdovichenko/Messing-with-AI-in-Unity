using System;
using UnityEngine;

namespace Cafe.AI.Path
{
    [Serializable]
    public class StaticPath : MonoBehaviour, IPathProvider
    {
        public Transform[] patrolPoints;
        private int _currentPatrolPointIndex;
        
        public Vector3 GetNextPosition()
        {
            var output = patrolPoints[_currentPatrolPointIndex].position;
            _currentPatrolPointIndex = (_currentPatrolPointIndex + 1) % patrolPoints.Length;
            return output;
        }
    }
}