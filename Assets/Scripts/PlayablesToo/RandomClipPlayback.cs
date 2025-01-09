using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace PlayablesToo
{
    public class RandomClipPlayback : MonoBehaviour
    {
        private PlayableGraph _playableGraph;
        [SerializeField] private AnimationsCollection _clipsCollection;

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();
            var playable = ScriptPlayable<RandomClipPlayable>.Create(_playableGraph);
            var behaviour = playable.GetBehaviour();
            behaviour.Initialize(_clipsCollection.Clips, transform, playable, _playableGraph);

            var animator = GetComponent<Animator>();
            var graphOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", animator);
            graphOutput.SetSourcePlayable(playable);
            
            _playableGraph.Play();
        }

        private void OnDisable() => _playableGraph.Destroy();
    }
}