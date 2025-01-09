using UnityEngine;

namespace Decisions_Tree
{
    public class GameWorldInfo : MonoBehaviour
    {
        public bool hasSpottedEnemy;
        public bool isNearEnemy;
        [Range(0, 100f)]public float health = 100f;

        public Vector3 GetPosition() => transform.position;
    }
}