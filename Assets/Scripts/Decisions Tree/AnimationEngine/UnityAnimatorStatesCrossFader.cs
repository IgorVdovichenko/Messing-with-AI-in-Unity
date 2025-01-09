using UnityEngine;

namespace Decisions_Tree.AnimationEngine
{
    public class UnityAnimatorStatesCrossFader: IAnimator
    {
        private readonly Animator _animator;
        private const float NormalizedTransitionDuration = 0.025f;

        public UnityAnimatorStatesCrossFader(Animator animator)
        {
            _animator = animator;
        }
        
        public void PlayClip(string name)
        {
            var clipHash = Animator.StringToHash(name);
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if(stateInfo.shortNameHash == clipHash || _animator.IsInTransition(0)) return;
            _animator.CrossFade(clipHash, NormalizedTransitionDuration);
        }
    }
}