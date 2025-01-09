using MoonSharp.Interpreter;
using UnityEngine.AI;

namespace ScriptedDT.ActionManagement
{
    public class NavMeshAgentProxy
    {
        private readonly NavMeshAgent _agent;

        [MoonSharpHidden]
        public NavMeshAgentProxy(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public float Speed
        {
            get => _agent.speed;
            set => _agent.speed = value;
        }
    }
}