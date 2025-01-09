using Decisions_Tree.AnimationEngine;

namespace Decisions_Tree.Nodes.Actions
{
    public class PlayAnimationAction: ActionNode
    {
        private readonly IAnimator _animator;
        private readonly string _clip;

        public PlayAnimationAction(IAnimator animator, string clip)
        {
            _animator = animator;
            _clip = clip;
            
        }
        protected override void GetAction()
        {
            _animator.PlayClip(_clip);
        }
    }
}