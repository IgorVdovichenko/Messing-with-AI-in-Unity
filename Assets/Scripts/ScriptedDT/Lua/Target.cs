using Decisions_Tree;
using MoonSharp.Interpreter;
using UnityEngine;

namespace ScriptedDT.Lua
{
    [MoonSharpUserData]
    public class Target
    {
        private readonly GameWorldInfo _info;
        private readonly Transform _agentTransform;

        public Target(GameWorldInfo info, Transform transform)
        {
            _info = info;
            _agentTransform = transform;
        }

        public float health()
        {
            return _info.health;
        }

        public bool spotted()
        {
            var d = _info.GetPosition() - _agentTransform.position;
            return Vector3.Dot(_agentTransform.forward, d) >= 0;
        }
        
        public float distanceTo()
        {
            return (_info.GetPosition() - _agentTransform.position).magnitude;
        }
    }
}