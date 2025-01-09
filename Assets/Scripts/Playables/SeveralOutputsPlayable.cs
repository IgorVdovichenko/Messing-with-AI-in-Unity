using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Playables;

namespace Playables
{
    [RequireComponent(typeof(Animator), typeof(AudioSource))]
    public class SeveralOutputsPlayable: MonoBehaviour
    {
        [SerializeField] private AnimationClip _animationClip = default;
        [SerializeField] private AudioClip _audioClip = default;

        private PlayableGraph _playableGraph;

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();

            var animator = GetComponent<Animator>();
            var audioSource = GetComponent<AudioSource>();

            var animationOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", animator);
            var audioOutput = AudioPlayableOutput.Create(_playableGraph, "Audio", audioSource);

            var animationPlayable = AnimationClipPlayable.Create(_playableGraph, _animationClip);
            var audioPlayable = AudioClipPlayable.Create(_playableGraph, _audioClip, true);
            
            animationOutput.SetSourcePlayable(animationPlayable);
            audioOutput.SetSourcePlayable(audioPlayable);
            
            _playableGraph.Play();
        }

        private void OnDisable()
        {
            _playableGraph.Destroy();
        }
    }
}