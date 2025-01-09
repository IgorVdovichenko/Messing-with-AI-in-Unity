using UnityEngine;

namespace FSM
{
    public class IdleStateBehaviour : StateMachineBehaviour
    {
        private Player _player;
        private readonly int _idleIndexParam = Animator.StringToHash("IdleIndex");

        [SerializeField] private int _statesAmount;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (_player == null)
                _player = animator.GetComponent<Player>();
            
            _player.StopAgent();

            var index = Random.Range(0, _statesAmount);
            animator.SetInteger(_idleIndexParam, index);
        }
    }
}