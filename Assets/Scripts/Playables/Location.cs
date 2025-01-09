using UnityEngine;

namespace Playables
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private AnimationClip _animationClip = default;
        public Vector3 Position => transform.position;
        public AnimationClip AnimationClip => _animationClip;
    }
}