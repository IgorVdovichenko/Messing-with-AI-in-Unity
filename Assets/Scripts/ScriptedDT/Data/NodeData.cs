namespace ScriptedDT.Data
{
    public abstract class NodeData
    {
        public string Id { get; protected set; }

        protected NodeData(string id)
        {
            Id = id;
        }
    }
}