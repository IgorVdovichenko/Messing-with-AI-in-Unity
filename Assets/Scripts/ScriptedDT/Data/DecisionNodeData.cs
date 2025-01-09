using System;
using ScriptedDT.Conditions;

namespace ScriptedDT.Data
{
    [Serializable]
    public class DecisionNodeData: NodeData
    {
        public string TrueNodeId { get; private set; }
        public string FalseNodeId { get; private set; }
        public Condition[] Conditions { get; private set; }

        public DecisionNodeData(string id, string trueNodeId, string falseNodeId, Condition[] conditions) : base(id)
        {
            TrueNodeId = trueNodeId;
            FalseNodeId = falseNodeId;
            Conditions = conditions;
        }
    }
}