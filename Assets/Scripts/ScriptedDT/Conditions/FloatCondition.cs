using System;

namespace ScriptedDT.Conditions
{
    public class FloatCondition: Condition
    {
        private readonly FloatConditionType _floatConditionType;
        private readonly float _value;
        
        public FloatCondition(Parameter parameter, FloatConditionType floatConditionType, float value) : base(parameter)
        {
            _floatConditionType = floatConditionType;
            _value = value;
        }

        public override bool IsMatched()
        {
            var paraValue = Convert.ToSingle(Parameter.Value);
            return _floatConditionType switch
            {
                FloatConditionType.Greater => paraValue > _value,
                FloatConditionType.Less => paraValue < _value,
                FloatConditionType.GreaterOrEquals => paraValue >= _value,
                FloatConditionType.LessOrEquals => paraValue <= _value,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}