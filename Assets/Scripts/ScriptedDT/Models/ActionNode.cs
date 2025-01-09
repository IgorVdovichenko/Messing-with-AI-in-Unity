namespace ScriptedDT.Models
{
    public class ActionNode: Node
    {
        public ActionNode(string id)
        {
            Id = id;
        }
        
        public override Node Evaluate()
        {
            return this;
        }
    }
}