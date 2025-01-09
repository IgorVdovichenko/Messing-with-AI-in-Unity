namespace MyFSM.Transitions
{
    public class AtDestinationTransition: Transition
    {
        private IAgent _agent;

        public AtDestinationTransition(State targetState, IAgent agent) : base(targetState)
        {
            _agent = agent;
        }
        
        public override bool Validate()
        {
            return _agent.AtDestination();
        }
    }
}