using UnityEngine;
using UnityEngine.Playables;

namespace PlayablesToo
{
    public class SimplePlayableUtility : MonoBehaviour
    {
        [SerializeField] private AnimationClip _clip;
        
        PlayableGraph graph;
        private void Start()
        {
            var animator = GetComponent<Animator>();
            AnimationPlayableUtilities.PlayClip(animator, _clip, out graph);
        }
        
        private void OnDisable()
        {
            graph.Destroy();
        }
    }
}
