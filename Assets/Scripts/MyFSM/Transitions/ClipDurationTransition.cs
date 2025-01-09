namespace MyFSM.Transitions
{
    public class ClipDurationTransition: Transition
    {
        public ClipDurationTransition(State targetState) : base(targetState)
        {
        }

        public override bool Validate()
        {
            return false;
        }
    }
}