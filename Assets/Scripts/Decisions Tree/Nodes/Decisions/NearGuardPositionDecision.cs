using UnityEngine;

namespace Decisions_Tree.Nodes.Decisions
{
    public class NearGuardPositionDecision: DecisionNode
    {
        private readonly Transform _transform;
        
        public NearGuardPositionDecision(Node trueNode, Node falseNode, Transform transform) : base(trueNode, falseNode)
        {
            _transform = transform;
        }

        protected override Node GetBranch()
        {
            return null;
        }
    }
}