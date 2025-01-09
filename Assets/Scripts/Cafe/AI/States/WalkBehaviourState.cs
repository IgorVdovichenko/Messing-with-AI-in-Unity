using UnityEngine;

namespace Cafe.AI.States
{
    public class WalkBehaviourState : StateMachineBehaviour
    {
        private IPlayer _player;
        private readonly int _atDestinationParam = Animator.StringToHash("AtDestination");
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();

            var nextPos = _player.GetNextPatrolPosition();
            _player.SetDestination(nextPos);
            _player.MoveAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (animator.IsInTransition(layerIndex))
                return;
            animator.SetBool(_atDestinationParam, _player.AtDestination());
        }
    }
}