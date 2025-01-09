using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    public class CrossFadeAnimationMixerPlayable : PlayableBehaviour
    {
        private PlayableGraph _graph;
        private AnimationMixerPlayable _mixer;
        private float _transitionDuration;
        private bool _inTransition;
        private float _weight;
        private AnimatorControllerPlayable _controllerPlayable;
        private AnimationClipPlayable _clipPlayable;

        public void Initialize(PlayableGraph graph, Playable owner, AnimatorControllerPlayable controllerPlayable)
        {
            _controllerPlayable = controllerPlayable;
            _graph = graph;
            owner.SetInputCount(1);
            owner.SetInputWeight(0, 1);
            _mixer = AnimationMixerPlayable.Create(graph, 2);
            graph.Connect(_mixer, 0, owner, 0);
            graph.Connect(controllerPlayable, 0, _mixer, 0);
            _mixer.SetInputWeight(0, 1f);
        }

        public void ConnectAnimationPlayable(AnimationClipPlayable playable)
        {
            _clipPlayable = playable;
            if(_mixer.GetInput(1).IsValid()) _mixer.DisconnectInput(1);
            _graph.Connect(playable, 0, _mixer, 1);
            _mixer.SetInputWeight(1, 1f);
            playable.Pause();
        }

        public void CrossFade(float weight, float duration)
        {
            _transitionDuration = duration;
            _inTransition = true;
            _weight = weight;
        }
    
        
        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if(_inTransition) return;
            
            
        }

        private void SetWeight(float value)
        {
            _mixer.SetInputWeight(0, value);
            _mixer.SetInputWeight(1, 1 - value);
        }
    }
}
