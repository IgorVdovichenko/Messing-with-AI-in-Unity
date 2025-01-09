
namespace MyFSM
{
    public abstract class State
    {
        protected IAnimator _animator;
        protected IAgent _agent;

        protected Transition _transition;

        protected StateMachineContext _fsm;
        
        public State(StateMachineContext fsm, IAgent agent, IAnimator animator)
        {
            _agent = agent;
            _animator = animator;
            _fsm = fsm;
        }
        
        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();

        public void Update()
        {
            if (!_transition.Validate())
            {
                OnStateUpdate();
                return;
            }
            _fsm.SetState(_transition.TargetState);
        }
    }
}