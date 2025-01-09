using UnityEngine;

namespace MyFSM.Transitions
{
    public class PressWTransition: Transition
    {
        public PressWTransition(State targetState) : base(targetState)
        {
        }

        public override bool Validate()
        {
            return Input.GetKeyDown(KeyCode.W);
        }
    }
}