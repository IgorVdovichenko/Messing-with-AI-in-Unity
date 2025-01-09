using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    public class MyFirstPlayableMixer : MonoBehaviour
    {
        [SerializeField] private AnimationClip _clip0 = default;
        [SerializeField] private AnimationClip _clip1 = default;

        [SerializeField, Range(0, 1)] private float _weight;

        private PlayableGraph _playableGraph;

        private AnimationMixerPlayable _mixerPlayable;

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();

            var animator = GetComponent<Animator>();

            var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", animator);
            
            _mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
            playableOutput.SetSourcePlayable(_mixerPlayable);

            var animPlayable0 = AnimationClipPlayable.Create(_playableGraph, _clip0);
            var animPlayable1 = AnimationClipPlayable.Create(_playableGraph, _clip1);

            _playableGraph.Connect(animPlayable0, 0, _mixerPlayable, 0);
            _playableGraph.Connect(animPlayable1, 0, _mixerPlayable, 1);
            
            _playableGraph.Play();
        }

        private void Update()
        {
            _mixerPlayable.SetInputWeight(0, 1 - _weight);
            _mixerPlayable.SetInputWeight(1, _weight);
        }

        private void OnDestroy()
        {
            _playableGraph.Destroy();
        }
    }
}