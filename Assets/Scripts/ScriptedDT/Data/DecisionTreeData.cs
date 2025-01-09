using System;
using ScriptedDT.Conditions;

namespace ScriptedDT.Data
{
    [Serializable]
    public class DecisionTreeData
    {
        public string RootNodeId { get; set; }
        public DecisionNodeData[] Decisions { get; set; }
        public ActionNodeData[] Actions { get; set; }
        public Parameter[] Parameters { get; set; }

        // public DecisionTreeData(string rootNodeId, DecisionNodeData[] decisions, ActionNodeData[] actions, Parameter[] parameters)
        // {
        //     RootNodeId = rootNodeId;
        //     Decisions = decisions;
        //     Actions = actions;
        //     Parameters = parameters;
        // }
    }
}