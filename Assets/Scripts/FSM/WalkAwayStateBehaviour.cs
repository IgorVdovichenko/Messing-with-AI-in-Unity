using UnityEngine;

namespace FSM
{
    public class WalkAwayStateBehaviour : StateMachineBehaviour
    {
        private Player _player;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_player == null)
                _player = animator.GetComponent<Player>();
            
            _player.SetDestination(_player.DespawnLocation);
            _player.MoveAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_player.AtDestination())
                _player.Deactivate();
            
        }
    }
}