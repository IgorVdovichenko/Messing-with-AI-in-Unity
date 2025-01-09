using MyFSM.Transitions;

namespace MyFSM.States
{
    public class WalkState: State
    {
        private readonly IPatrol _patrol;
        
        public WalkState(StateMachineContext fsm, IAgent agent, IAnimator animator, IPatrol patrol)
            : base(fsm, agent, animator)
        {
            _patrol = patrol;
        }

        public override void OnStateEnter()
        {
            _transition = new AtDestinationTransition(_fsm.IdleState, _agent);
            _agent.MoveTo(_patrol.GetNextPosition());
            _animator.PlayAnimation(AnimationType.Walk);
        }

        public override void OnStateUpdate(){}

        public override void OnStateExit()
        {
            _agent.Stop();
        }
    }
}