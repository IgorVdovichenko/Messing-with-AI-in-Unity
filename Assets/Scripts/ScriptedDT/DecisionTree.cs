using System.Collections.Generic;
using System.Linq;
using ScriptedDT.Data;
using ScriptedDT.Models;
using ScriptedDT.Parsing;

namespace ScriptedDT
{
    public class DecisionTree
    {
        private readonly Node _root;
        
        private readonly List<Node> _allNodes = new List<Node>();

        private readonly DecisionTreeData _data;

        public DecisionTree(IParser parser)
        {
            _data = parser.Parse();
            
            foreach (var action in _data.Actions)
            {
                _allNodes.Add(new ActionNode(action.Id));
            }

            foreach (var decision in _data.Decisions)
            {
                var decisionNode = GetOrCreateNewDecision(decision.Id);
                if(!_allNodes.Contains(decisionNode))
                    _allNodes.Add(decisionNode);
            }
            
            _root = _allNodes.FirstOrDefault(a => a.Id == _data.RootNodeId);
        }

        public Node Run()
        {
            return _root.Evaluate();
        }

        public void SetBool(string id, bool value)
        {
            SetParameterValue(id, value);
        }

        public void SetFloat(string id, float value)
        {
            SetParameterValue(id, value);
        }

        public void SetInt(string id, int value)
        {
            SetParameterValue(id, value);
        }

        private void SetParameterValue(string id, object value)
        {
            var parameter = _data.Parameters.FirstOrDefault(p => p.Id == id);
            if(parameter == null) return;
            parameter.Value = value;
        }

        private Node GetOrCreateNewDecision(string id)
        {
            var node = _allNodes.FirstOrDefault(n => n.Id == id);
            
            if (node != null) return node;

            var nodeData = _data.Decisions.FirstOrDefault(n => n.Id == id);
            var trueNodeId = nodeData?.TrueNodeId;
            var falseNode = nodeData?.FalseNodeId;
            var newDecision = new DecisionNode(
                id,
                GetOrCreateNewDecision(trueNodeId),
                GetOrCreateNewDecision(falseNode),
                nodeData?.Conditions);
            return newDecision;
        }
    }
}