using System;

namespace ScriptedDT.Conditions
{
    public class BooleanCondition: Condition
    {
        private readonly bool _value;
        
        public BooleanCondition(Parameter parameter, bool value) : base(parameter)
        {
            _value = value;
        }

        public override bool IsMatched()
        {
            return Convert.ToBoolean(Parameter.Value) == _value;
        }
    }
}