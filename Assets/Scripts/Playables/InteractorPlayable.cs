using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    public class InteractorPlayable : PlayableBehaviour
    {
        private PlayableGraph _graph;
        private AnimationMixerPlayable _mixer;
        private AnimationClipPlayable _clipPlayable;

        public event Action OnClipComplete;

        private bool _isPlayingClip;
        
        public void Initialize(PlayableGraph graph, RuntimeAnimatorController controller, Playable owner)
        {
            _graph = graph;
            owner.SetInputCount(1);
            owner.SetInputWeight(0, 1);
            _mixer = AnimationMixerPlayable.Create(graph, 2);
            graph.Connect(_mixer, 0, owner, 0);

            var controllerPlayable = AnimatorControllerPlayable.Create(graph, controller);
            graph.Connect(controllerPlayable, 0, _mixer, 0);
            SetWeight(1f);
        }

        public void SetAnimationClip(AnimationClip clip)
        {
            _clipPlayable = AnimationClipPlayable.Create(_graph, clip);
            if(_mixer.GetInput(1).IsValid()) _mixer.DisconnectInput(1);
            _graph.Connect(_clipPlayable, 0, _mixer, 1);
            _clipPlayable.SetDuration(clip.length);
            _clipPlayable.Pause();
            SetWeight(1);
        }

        public void PlayClip()
        {
            if (!_clipPlayable.IsValid()) return;
            
            _clipPlayable.Play();
            SetWeight(0);
            _isPlayingClip = true;
        }
        

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if(!_isPlayingClip) return;
            if (!_clipPlayable.IsValid() || !_clipPlayable.IsDone()) return;
            
            SetWeight(1f);
            _isPlayingClip = false;
            OnClipComplete?.Invoke();
        }
        
        private void SetWeight(float value)
        {
            _mixer.SetInputWeight(0, value);
            _mixer.SetInputWeight(1, 1 - value);
        }
    }
}
