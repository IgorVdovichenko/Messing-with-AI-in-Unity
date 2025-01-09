namespace ScriptedDT.Conditions
{
    public abstract class Condition
    {
        protected readonly Parameter Parameter;

        protected Condition(Parameter parameter)
        {
            Parameter = parameter;
        }

        public abstract bool IsMatched();
    }
}