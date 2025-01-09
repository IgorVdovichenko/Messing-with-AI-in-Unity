namespace MyFSM
{
    public abstract class Transition
    {
        public abstract bool Validate();
        public State TargetState { get; private set; }

        public Transition(State targetState)
        {
            TargetState = targetState;
        }
    }
}