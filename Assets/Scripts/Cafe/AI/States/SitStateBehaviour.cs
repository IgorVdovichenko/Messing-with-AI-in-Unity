using UnityEngine;

namespace Cafe.AI.States
{
    public class SitStateBehaviour : StateMachineBehaviour
    {
        private IPlayer _player;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();
            _player.StopAgent();
        }
    }
}