using Decisions_Tree.AnimationEngine;
using UnityEngine.AI;

namespace Decisions_Tree.Nodes.Actions
{
    public class RunToEnemyAction: ActionNode
    {
        private readonly IAnimator _animator;
        private readonly NavMeshAgent _agent;
        private readonly GameWorldInfo _info;

        public RunToEnemyAction(IAnimator animator, NavMeshAgent agent, GameWorldInfo info)
        {
            _animator = animator;
            _agent = agent;
            _info = info;
        }
        
        protected override void GetAction()
        {
            _animator.PlayClip("Run");
            _agent.isStopped = false;
            _agent.SetDestination(_info.GetPosition());
        }
    }
}