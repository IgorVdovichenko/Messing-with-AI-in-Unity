using System;

namespace ScriptedDT.Conditions
{
    public class IntCondition: Condition
    {
        private readonly IntConditionType _conditionType;
        private readonly int _value;
        
        public IntCondition(Parameter parameter, IntConditionType conditionType, int value) : base(parameter)
        {
            _conditionType = conditionType;
            _value = value;
        }

        public override bool IsMatched()
        {
            var paraValue = Convert.ToInt32(Parameter.Value);
            return _conditionType switch
            {
                IntConditionType.Greater => paraValue > _value,
                IntConditionType.Less => paraValue < _value,
                IntConditionType.Equals => paraValue == _value,
                IntConditionType.NotEquals => paraValue != _value,
                IntConditionType.GreaterOrEquals => paraValue >= _value,
                IntConditionType.LessOrEquals => paraValue <= _value,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}