using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Animator;

namespace Cafe.AI.States
{
    public class IdleStateBehaviour : StateMachineBehaviour
    {
        private IPlayer _player;
        private readonly int _indexParam = StringToHash("Index");

        [SerializeField] private int numberOfStates;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();
            var rndIndex = Range(0, numberOfStates);
            animator.SetInteger(_indexParam, rndIndex);
            _player.StopAgent();
        }
    }
}