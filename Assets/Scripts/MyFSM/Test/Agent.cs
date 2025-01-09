using UnityEngine;
using UnityEngine.AI;

namespace MyFSM.Test
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Agent: MonoBehaviour, IAgent
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 position)
        {
            _agent.SetDestination(position);
            _agent.isStopped = false;
            _agent.updateRotation = true;
        }

        public void Stop()
        {
            _agent.isStopped = true;
            _agent.updateRotation = false;
        }

        public bool AtDestination()
        {
            return _agent.remainingDistance < _agent.stoppingDistance && !_agent.pathPending;
        }
    }
}