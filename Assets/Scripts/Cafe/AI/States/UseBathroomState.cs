using UnityEngine;

namespace Cafe.AI.States
{
    public class UseBathroomState : StateMachineBehaviour
    {
        private IPlayer _player;
        private readonly int _atDestinationParam = Animator.StringToHash("AtDestination");
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();
            _player.SetDestination(_player.BathroomPosition);
            _player.MoveAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_player.AtDestination())
            {
                _player.StopAgent();
            } 
            
            animator.SetBool(_atDestinationParam, _player.AtDestination());
        }
    }
}