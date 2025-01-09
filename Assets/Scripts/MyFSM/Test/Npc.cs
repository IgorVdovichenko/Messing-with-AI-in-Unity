using UnityEngine;

namespace MyFSM.Test
{
    public class Npc: MonoBehaviour
    {
        private StateMachineContext _fsm;

        private void Awake()
        {
            _fsm = GetComponent<StateMachineContext>();
        }
    }
}