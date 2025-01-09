using UnityEngine;
using UnityEngine.AI;

namespace Cafe.AI
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class Player : MonoBehaviour, IPlayer
    {
        private NavMeshAgent _agent;
        private Animator _animator;

        [SerializeField] private Transform[] patrolPoints;
        private int _currentPatrolPointIndex;

        private readonly int _sitParam = Animator.StringToHash("Sit");

        [SerializeField] private Transform sitLocation,
            despawnLocation,
            bathroomPosition;

        public Vector3 DespawnPosition => despawnLocation.position;

        public Vector3 BathroomPosition => bathroomPosition.position;

        public Vector3 UpDirection => transform.up;

        public Vector3 ForwardDirection => transform.forward;

        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        public (Vector3 Position, Vector3 Forward) InteractionLocation =>
            (sitLocation.position, sitLocation.forward);

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        public void MoveAgent() => _agent.isStopped = false;

        public void StopAgent() => _agent.isStopped = true;
        
        public void SetDestination(Vector3 position) => _agent.SetDestination(position);
        
        public bool AtDestination() =>
             _agent.remainingDistance < _agent.stoppingDistance && !_agent.pathPending;

        public Vector3 GetNextPatrolPosition()
        {
            var output = patrolPoints[_currentPatrolPointIndex].position;
            _currentPatrolPointIndex = (_currentPatrolPointIndex + 1) % patrolPoints.Length;
            return output;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _currentPatrolPointIndex = 0;
        }

        public void Activate() => gameObject.SetActive(true);

        public void Sit()
        {
            _animator.SetTrigger(_sitParam);
            SetDestination(InteractionLocation.Position);
        }
    }
}
