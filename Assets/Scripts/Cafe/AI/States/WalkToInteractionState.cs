using UnityEngine;
using static UnityEngine.Animator;

namespace Cafe.AI.States
{
    public class WalkToInteractionState : StateMachineBehaviour
    {
        private IPlayer _player;
        private readonly int _atDestinationParam = StringToHash("AtDestination");
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();
            _player.MoveAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            animator.SetBool(_atDestinationParam, _player.AtDestination());
        }
    }
}