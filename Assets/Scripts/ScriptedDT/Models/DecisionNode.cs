using System.Linq;
using ScriptedDT.Conditions;

namespace ScriptedDT.Models
{
    public class DecisionNode: Node
    {
        private readonly Node _trueNode;
        private readonly Node _falseNode;
        private readonly Condition[] _conditions;

        public DecisionNode(string id, Node trueNode, Node falseNode, Condition[] conditions)
        {
            Id = id;
            _trueNode = trueNode;
            _falseNode = falseNode;
            _conditions = conditions;
        }
        
        public override Node Evaluate()
        {
            var outNode = AllConditionsAreMet()
                ? _trueNode
                : _falseNode;
            return outNode.Evaluate();
        }

        private bool AllConditionsAreMet()
        {
            return _conditions.All(c => c.IsMatched());
        }
    }
}