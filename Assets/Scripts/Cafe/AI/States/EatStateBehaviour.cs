using UnityEngine;
using static UnityEngine.Animator;

namespace Cafe.AI.States
{
    public class EatStateBehaviour : StateMachineBehaviour
    {
        [SerializeField] private float duration;
        private readonly int _timerParam = StringToHash("Timer");
        private readonly int _standParam = StringToHash("Stand");

        private float _elapsedTime;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            var eatLayer = animator.GetLayerIndex("Eat");
            animator.SetLayerWeight(eatLayer, 1f);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            animator.SetFloat(_timerParam, _elapsedTime += Time.deltaTime);
            if (_elapsedTime < duration) return;
            _elapsedTime = 0;
            animator.SetTrigger(_standParam);
            var eatLayer = animator.GetLayerIndex("Eat");
            animator.SetLayerWeight(eatLayer, 0);
        }
    }
}