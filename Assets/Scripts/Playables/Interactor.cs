using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class Interactor : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _agent;

        [SerializeField] private InteractionManager _interactionManager = default;
        [SerializeField] private RuntimeAnimatorController _controller;

        private PlayableGraph _playableGraph;
        private AnimationClipPlayable interactionClipPlayable;
        private readonly int _walkParamHash = Animator.StringToHash("IsWalking");
        private bool _isInteracting;
        private const float StoppingDistance = 0.3f;

        private bool AtDestination => _agent.remainingDistance < StoppingDistance && !_agent.pathPending;

        private InteractorPlayable _interactorBehaviour;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();
            var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", _animator);
            
            var interactorPlayable = ScriptPlayable<InteractorPlayable>.Create(_playableGraph);
            _interactorBehaviour = interactorPlayable.GetBehaviour();
            _interactorBehaviour.Initialize(_playableGraph, _controller, interactorPlayable);
            playableOutput.SetSourcePlayable(interactorPlayable);
            _interactorBehaviour.OnClipComplete += OnInteractionCompleteHandler;
            
            _playableGraph.Play();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I)) Interact();
            
            _animator.SetBool(_walkParamHash, !AtDestination);
            _agent.isStopped = AtDestination;
            
            if (_isInteracting && AtDestination) _interactorBehaviour.PlayClip();
        }

        private void OnDestroy() => _playableGraph.Destroy();
        
        private void Interact()
        {
            if(_isInteracting) return;

            var location = _interactionManager.NextLocation;
            _agent.SetDestination(location.Position);
            _interactorBehaviour.SetAnimationClip(location.AnimationClip);
            _animator.SetBool(_walkParamHash, true);
            _isInteracting = true;
        }
        
        private void OnInteractionCompleteHandler()
        {
            _agent.SetDestination(Vector3.zero);
            _isInteracting = false;
        }
    }
}