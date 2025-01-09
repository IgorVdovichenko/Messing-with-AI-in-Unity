namespace ScriptedDT.Models
{
    public abstract class Node
    {
        public string Id;
        public abstract Node Evaluate();
    }
}