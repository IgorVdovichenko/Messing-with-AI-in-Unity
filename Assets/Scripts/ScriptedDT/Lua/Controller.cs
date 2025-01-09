using Decisions_Tree;
using Decisions_Tree.AnimationEngine;
using UnityEngine.AI;

namespace ScriptedDT.Lua
{
    public class Controller
    {
        private readonly IAnimator _animator;
        private readonly NavMeshAgent _agent;
        private readonly GameWorldInfo _target;

        public Controller(IAnimator animator, NavMeshAgent agent, GameWorldInfo target)
        {
            _animator = animator;
            _agent = agent;
            _target = target;
        }

        public float speed
        {
            get => _agent.speed;
            set => _agent.speed = value;
        }

        public void PlayAnimation(string animName)
        {
            _animator.PlayClip(animName);
        }

        public void Stop()
        {
            _agent.enabled = false;
        }

        public void MoveToTarget()
        {
            _agent.enabled = true;
            _agent.SetDestination(_target.GetPosition());
        }
    }
}