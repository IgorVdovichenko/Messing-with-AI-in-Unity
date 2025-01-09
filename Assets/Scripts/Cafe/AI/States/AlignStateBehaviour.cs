using UnityEngine;

namespace Cafe.AI.States
{
    public class AlignStateBehaviour : StateMachineBehaviour
    {
        private IPlayer _player;
        private int _alignedHashParam = Animator.StringToHash("Aligned");
        [SerializeField] private float speed = 8;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _player ??= animator.GetComponent<IPlayer>();
            _player.StopAgent();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            var dotProduct = Vector3.Dot(_player.ForwardDirection, _player.InteractionLocation.Forward);
            var aligned = dotProduct >= 0.99f;
            
            animator.SetBool(_alignedHashParam, aligned);

            var newRot = 
                Quaternion.LookRotation(_player.InteractionLocation.Forward, _player.UpDirection);
            _player.Rotation = Quaternion.Slerp(_player.Rotation, newRot, speed * Time.deltaTime);
        }
    }
}