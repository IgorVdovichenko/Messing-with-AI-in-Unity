using Decisions_Tree.AnimationEngine;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptedDT.ActionManagement
{
    public class AgentController
    {
        private readonly IAnimator _animator;
        private readonly NavMeshAgent _agent;

        public AgentController(IAnimator animator, NavMeshAgent ai)
        {
            _animator = animator;
            _agent = ai;
        }

        public void PlayAnimation(string animationName)
        {
            _animator.PlayClip(animationName);
        }

        public void Stop()
        {
            _agent.enabled = false;
        }

        public void SetDestination()
        {
            _agent.SetDestination(Vector3.zero);
            _agent.enabled = true;
        }

        public void MoveTo(Vector3 position)
        {
            _agent.SetDestination(position);
            _agent.enabled = true;
        }
    }
}