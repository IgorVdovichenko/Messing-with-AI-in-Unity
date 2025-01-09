using MyFSM.States;
using UnityEngine;

namespace MyFSM
{
    public class StateMachineContext: MonoBehaviour
    {
        private State _currentState;
        
        public State WalkState { get; private set; }
        public State IdleState { get; private set; }

        private void Awake()
        {
            var agent = GetComponent<IAgent>();
            var animator = GetComponent<IAnimator>();
            var patrol = GetComponent<IPatrol>();
            
            WalkState = new WalkState(this, agent, animator, patrol);
            IdleState = new IdleState(this, agent, animator);
        }

        private void Start()
        {
            SetState(WalkState);
        }
        
        private void Update()
        {
            _currentState?.Update();
        }

        public void SetState(State state)
        {
            _currentState?.OnStateExit();
            _currentState = state;
            _currentState?.OnStateEnter();
        }
    }
}