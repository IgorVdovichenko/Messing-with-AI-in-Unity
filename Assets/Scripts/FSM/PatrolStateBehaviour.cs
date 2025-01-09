using UnityEngine;

namespace FSM
{
    public class PatrolStateBehaviour : StateMachineBehaviour
    {
        private Player _player;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_player == null)
                _player = animator.GetComponent<Player>();

            var point = _player.GetNextPatrolPoint();
            _player.SetDestination(point);
            _player.MoveAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            animator.SetBool(_player.AtDestinationParam, _player.AtDestination());
        }
    }
}