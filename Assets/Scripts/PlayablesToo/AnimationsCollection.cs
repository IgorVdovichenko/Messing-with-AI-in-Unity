using UnityEngine;

namespace PlayablesToo
{
    [CreateAssetMenu(menuName = "Animations Collection")]
    public class AnimationsCollection : ScriptableObject
    {
        public AnimationClip[] Clips;
    }
}