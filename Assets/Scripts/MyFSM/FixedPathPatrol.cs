using UnityEngine;

namespace MyFSM
{
    public class FixedPathPatrol: MonoBehaviour, IPatrol
    {
        [SerializeField] private Transform[] _waypoints = default;
        
        private int _currentPointIndex;

        private void OnEnable()
        {
            _currentPointIndex = 0;
        }

        public Vector3 GetNextPosition()
        {
            var output = _waypoints[_currentPointIndex].position;
            _currentPointIndex = (_currentPointIndex + 1) % _waypoints.Length;
            return output;
        }
    }
}