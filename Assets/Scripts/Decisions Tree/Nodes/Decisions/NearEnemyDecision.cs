using UnityEngine;

namespace Decisions_Tree.Nodes.Decisions
{
    public class NearEnemyDecision: DecisionNode
    {
        private readonly GameWorldInfo _info;
        private readonly Transform _transform;
        
        public NearEnemyDecision(Node trueNode, Node falseNode, Transform transform, GameWorldInfo info) : base(trueNode, falseNode)
        {
            //_agent = agent;
            _info = info;
            _transform = transform;
        }

        protected override Node GetBranch()
        {
            return Vector3.Distance(_transform.position, _info.GetPosition()) < 0.1f
                ? trueNode 
                : falseNode;
        }
    }
}