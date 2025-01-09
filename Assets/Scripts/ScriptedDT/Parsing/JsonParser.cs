using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptedDT.Conditions;
using ScriptedDT.Data;

namespace ScriptedDT.Parsing
{
    public class JsonParser: IParser
    {
        private readonly IJsonReader _jsonReader;

        private const string RootNodeIdPropertyName = "RootNodeId";
        private const string ActionsPropertyName = "Actions";
        private const string DecisionsPropertyName = "Decisions";
        private const string ParametersPropertyName = "Parameters";
        private const string ValueParameterName = "Value";
        private const string ConditionsParameterName = "Conditions";
        private const string ConditionTypeParameterName = "ConditionType";
        private const string ParameterIdParameterName = "ParameterId";
        private const string IdParameterName = "Id";
        private const string TrueNodeIdParameterName = "TrueNodeId";
        private const string FalseNodeIdParameterName = "FalseNodeId";

        public JsonParser(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }
        
        public DecisionTreeData Parse()
        {
            var json = _jsonReader.Read();
            var jsonData = JObject.Parse(json);
            
            var decisionTreeData = new DecisionTreeData
            {
                RootNodeId = jsonData[RootNodeIdPropertyName]?.ToObject<string>(),
                Actions = jsonData[ActionsPropertyName]?.ToObject<ActionNodeData[]>(),
                Parameters = jsonData[ParametersPropertyName]?.ToObject<Parameter[]>()
            };
            
            var decisions = new List<DecisionNodeData>();
            var decisionsData = jsonData[DecisionsPropertyName] as JArray;
            
            foreach (var decision in decisionsData)
            {
                var conditions = decision[ConditionsParameterName] as JArray;
                var output = new List<Condition>();
                
                foreach (var condition in conditions)
                {
                    var id = condition[ParameterIdParameterName]?.ToString();
                    var param = decisionTreeData.Parameters.FirstOrDefault(p => p.Id == id);
                    output.Add(CreateCondition(condition, param));
                }
                
                decisions.Add(new DecisionNodeData(
                    decision[IdParameterName]?.ToObject<string>(),
                    decision[TrueNodeIdParameterName]?.ToObject<string>(),
                    decision[FalseNodeIdParameterName]?.ToObject<string>(),
                    output.ToArray()
                    ));
            }
            
            decisionTreeData.Decisions = decisions.ToArray();
            
            return decisionTreeData;
        }

        private static Condition CreateCondition(JToken token, Parameter parameter)
        {
            var valueToken = token[ValueParameterName];
            if (valueToken == null)
            {
                throw new Exception($"Token with name {ValueParameterName} not found!");
            }
            
            var conditionToken = token[ConditionTypeParameterName];
            if (conditionToken == null && parameter.Type != ParameterType.Boolean)
            {
                throw new Exception($"Token with name {ConditionTypeParameterName} not found!");
            }
            
            return parameter.Type switch
            {
                ParameterType.Boolean => new BooleanCondition(
                    parameter,
                    valueToken.ToObject<bool>()),
                
                ParameterType.Integer => new IntCondition(parameter,
                    conditionToken.ToObject<IntConditionType>(),
                    valueToken.ToObject<int>()),
                
                ParameterType.Float => new FloatCondition(parameter,
                    conditionToken.ToObject<FloatConditionType>(),
                    valueToken.ToObject<float>()),
                
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}