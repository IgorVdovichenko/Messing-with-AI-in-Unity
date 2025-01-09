using UnityEngine;

namespace MyFSM
{
    public interface IPatrol
    {
        Vector3 GetNextPosition();
    }
}