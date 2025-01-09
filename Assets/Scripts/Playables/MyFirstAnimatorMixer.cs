using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    [RequireComponent(typeof(Animator))]
    public class MyFirstAnimatorMixer : MonoBehaviour
    {
        [SerializeField] private AnimationClip _clip = default;
        [SerializeField] private RuntimeAnimatorController _controller = default;
        [SerializeField, Range(0, 1)] private float _weight = default;

        private PlayableGraph _playableGraph;
        private AnimationMixerPlayable _mixerPlayable;

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();
            var animator = GetComponent<Animator>();
            var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", animator);
            
            _mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
            playableOutput.SetSourcePlayable(_mixerPlayable);

            var clipPlayable = AnimationClipPlayable.Create(_playableGraph, _clip);
            var controllerPlayable = AnimatorControllerPlayable.Create(_playableGraph, _controller);

            _playableGraph.Connect(clipPlayable, 0, _mixerPlayable, 0);
            _playableGraph.Connect(controllerPlayable, 0, _mixerPlayable, 1);
            
            _playableGraph.Play();
        }

        private void Update()
        {
            _mixerPlayable.SetInputWeight(0, 1 - _weight);
            _mixerPlayable.SetInputWeight(1, _weight);
        }

        private void OnDisable()
        {
            _playableGraph.Destroy();
        }
    }
}