using UnityEngine;

namespace FSM
{
    public class InteractStateBehavior : StateMachineBehaviour
    {
        private Player _player;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_player == null)
                _player = animator.GetComponent<Player>();
            
            _player.SetDestination(_player.InteractionLocation);
            _player.MoveAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            var condition = _player.AtDestination();
            if (condition)
                _player.StopAgent();
            animator.SetBool(_player.AtDestinationParam, condition);
        }
    }
}