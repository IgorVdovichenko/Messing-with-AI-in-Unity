namespace Decisions_Tree.Nodes.Decisions
{
    public class EnemySpottedDecision: DecisionNode
    {
        private readonly GameWorldInfo _info;
        
        public EnemySpottedDecision(Node trueNode, Node falseNode, GameWorldInfo info) : base(trueNode, falseNode)
        {
            _info = info;
        }

        protected override Node GetBranch()
        {
            return _info.hasSpottedEnemy ? trueNode : falseNode;
        }
    }
}