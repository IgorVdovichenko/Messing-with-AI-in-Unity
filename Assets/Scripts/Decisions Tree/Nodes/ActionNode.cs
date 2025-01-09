namespace Decisions_Tree.Nodes
{
    public abstract class ActionNode: Node
    {
        protected abstract void GetAction();
        
        public override Node Evaluate()
        {
            GetAction();
            return this;
        }
    }
}