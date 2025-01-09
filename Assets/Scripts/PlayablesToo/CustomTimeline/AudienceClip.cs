using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace PlayablesToo.CustomTimeline
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Animations Playable Asset")]
    public class AudienceClip : PlayableAsset
    {
        [SerializeField] private AnimationsCollection _clipsCollection;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var playable = ScriptPlayable<RandomClipPlayable>.Create(graph);
            playable.GetBehaviour().Initialize(_clipsCollection.Clips, go.transform, playable, graph);
            var animator = go.GetComponent<Animator>();
            var graphOutput = AnimationPlayableOutput.Create(graph, "Animation", animator);
            graphOutput.SetSourcePlayable(playable);
            return playable;
        }
    }
}
