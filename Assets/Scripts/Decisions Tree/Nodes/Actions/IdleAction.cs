using Decisions_Tree.AnimationEngine;
using UnityEngine.AI;

namespace Decisions_Tree.Nodes.Actions
{
    public class IdleAction: ActionNode
    {
        private readonly NavMeshAgent _agent;
        private readonly IAnimator _animator;

        public IdleAction(IAnimator animator, NavMeshAgent agent)
        {
            _agent = agent;
            _animator = animator;
        }
        
        protected override void GetAction()
        {
            _agent.isStopped = true;
            _animator.PlayClip("Idle");
        }
    }
}