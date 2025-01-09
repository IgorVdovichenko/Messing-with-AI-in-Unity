using Decisions_Tree.AnimationEngine;

namespace Decisions_Tree.Nodes.Actions
{
    public class AttackAction: ActionNode
    {
        private readonly IAnimator _animator;
        
        public AttackAction(IAnimator animator)
        {
            _animator = animator;
        }
        
        protected override void GetAction()
        {
            _animator.PlayClip("Attack");
        }
    }
}