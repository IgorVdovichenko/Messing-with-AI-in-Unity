namespace Decisions_Tree.Nodes
{
    public abstract class DecisionNode: Node
    {
        protected readonly Node trueNode;
        protected readonly Node falseNode;

        protected DecisionNode(Node trueNode, Node falseNode)
        {
            this.trueNode = trueNode;
            this.falseNode = falseNode;
        }

        protected abstract Node GetBranch();

        public override Node Evaluate()
        {
            var node = GetBranch();
            return node.Evaluate();
        }
    }
}