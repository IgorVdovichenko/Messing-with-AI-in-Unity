using UnityEngine;

namespace Cafe.AI.States
{
    public class GoAwayStateBehaviour : StateMachineBehaviour
    {
        private IPlayer _player;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();
            _player.SetDestination(_player.DespawnPosition);
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