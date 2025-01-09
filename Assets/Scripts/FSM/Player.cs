using System;
using UnityEngine;
using UnityEngine.AI;

namespace FSM
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class Player : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _agent;
        
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private Transform _interactionLocation;
        [SerializeField] private Transform _despawnLocation;

        private int _currentPointIndex;

        private readonly int _interactParam = Animator.StringToHash("Interact");

        public readonly int AtDestinationParam = Animator.StringToHash("AtDestination");
        public Vector3 InteractionLocation => _interactionLocation.position;
        public Vector3 DespawnLocation => _despawnLocation.position;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            _currentPointIndex = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Interact();
            }
        }

        public void MoveAgent()
        {
            _agent.isStopped = false;
        }

        public void StopAgent()
        {
            _agent.isStopped = true;
        }

        public void SetDestination(Vector3 position)
        {
            _agent.SetDestination(position);
        }

        public bool AtDestination()
        {
            return _agent.remainingDistance < _agent.stoppingDistance && !_agent.pathPending;
        }

        public Vector3 GetNextPatrolPoint()
        {
            var output = _waypoints[_currentPointIndex].position;
            _currentPointIndex = (_currentPointIndex + 1) % _waypoints.Length;
            return output;
        }

        private void Interact()
        {
            _animator.SetTrigger(_interactParam);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
