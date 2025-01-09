using MyFSM.Transitions;
using UnityEngine;

namespace MyFSM.States
{
    public class IdleState: State
    {
        public IdleState(StateMachineContext fsm, IAgent agent, IAnimator animator) : base(fsm, agent, animator){}

        public override void OnStateEnter()
        {
           _animator.PlayAnimation(AnimationType.Idle);
           _transition = new PressWTransition(_fsm.WalkState);
        }

        public override void OnStateUpdate()
        {
            
        }

        public override void OnStateExit()
        {
            
        }
    }
}