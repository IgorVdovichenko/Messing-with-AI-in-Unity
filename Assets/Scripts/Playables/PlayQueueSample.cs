using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    [RequireComponent(typeof(Animator))]
    public class PlayQueueSample : MonoBehaviour
    {
        [SerializeField] private AnimationClip[] _clipToPlay;

        private PlayableGraph _playableGraph;

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();

            var playQueuePlayable = ScriptPlayable<PlayQueuePlayable>.Create(_playableGraph);
            var playQueue = playQueuePlayable.GetBehaviour();
            
            playQueue.Initialize(_clipToPlay, playQueuePlayable, _playableGraph);

            var animator = GetComponent<Animator>();
            var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", animator);
            
            playableOutput.SetSourcePlayable(playQueuePlayable);
            _playableGraph.Play();
        }

        private void OnDisable() => _playableGraph.Destroy();
    }
}