using UnityEngine;
using static UnityEngine.Animator;

namespace MyFSM.Test
{
    [RequireComponent(typeof(Animator))]
    public class NpcAnimator: MonoBehaviour, IAnimator
    {
        private Animator _animator;

        private readonly int _walkHashParam = StringToHash("Walk");
        private readonly int _idleHashParam = StringToHash("Idle");
        
        private const float NORMALIZED_TRANSITION_DURATION = 0.05f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimation(AnimationType anim)
        {
            _animator.CrossFade(GetHashParam(anim), NORMALIZED_TRANSITION_DURATION);
        }

        public float GetCurrentAnimationDuration()
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.length;
        }

        private int GetHashParam(AnimationType anim)
        {
            return anim switch
            {
                AnimationType.Walk => _walkHashParam,
                AnimationType.Idle => _idleHashParam,
                _ => _idleHashParam
            };
        }
    }
}