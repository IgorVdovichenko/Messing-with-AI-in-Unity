using UnityEngine;

namespace Cafe.AI
{
    public interface IPlayer
    {
        void MoveAgent();
        void StopAgent();
        void SetDestination(Vector3 position);
        bool AtDestination();
        Vector3 GetNextPatrolPosition();
        void Deactivate();
        void Activate();
        void Sit();
        Vector3 DespawnPosition { get; }
        Vector3 BathroomPosition { get; }
        (Vector3 Position, Vector3 Forward) InteractionLocation { get; }
        Vector3 UpDirection { get; }
        Vector3 ForwardDirection { get; }
        Quaternion Rotation { get; set; }
    }
}