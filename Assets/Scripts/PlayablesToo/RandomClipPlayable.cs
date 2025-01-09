using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace PlayablesToo
{
    public class RandomClipPlayable : PlayableBehaviour
    {
        private Playable _mixer;
        private int _activePlayableIndex;
        private int _nextPlayableIndex;

        private bool _isBlending;
        private const float BlendSpeed = 1f;

        private Transform _rootTransform;
        private Vector3 _initPosition;
        private Quaternion _initRotation;

        public void Initialize(AnimationClip[] clips, Transform rootTransform, Playable owner, PlayableGraph graph)
        {
            _rootTransform = rootTransform;
            _initPosition = _rootTransform.position;
            _initRotation = rootTransform.rotation;
            owner.SetInputCount(1);
            _mixer = AnimationMixerPlayable.Create(graph, clips.Length);
            graph.Connect(_mixer, 0, owner, 0);
            SetMixerInputs(clips, graph);
            SetMixerInputWeights(_nextPlayableIndex);
            PlayRandomClipPlayable();
        }

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if(_mixer.GetInput(_nextPlayableIndex).IsDone())
                PlayRandomClipPlayable();
            
            if (!_isBlending) return;


            var maxDelta = info.deltaTime * BlendSpeed;
            var currentWeight = _mixer.GetInputWeight(_nextPlayableIndex);
            var weight = Mathf.MoveTowards(currentWeight, 1f, maxDelta);
            _mixer.SetInputWeight(_nextPlayableIndex, Mathf.Clamp01(weight));
            _mixer.SetInputWeight(_activePlayableIndex, Mathf.Clamp01(1f - weight));

            if (!Mathf.Approximately(_mixer.GetInputWeight(_nextPlayableIndex), 1f)) return;
            
            _isBlending = false;
            _activePlayableIndex = _nextPlayableIndex;
            SetMixerInputWeights(_activePlayableIndex);
        }

        private void SetMixerInputs(AnimationClip[] clips, PlayableGraph graph)
        {
            for (var i = 0; i < clips.Length; i++)
            {
                var clipPlayable = AnimationClipPlayable.Create(graph, clips[i]);
                clipPlayable.SetDuration(clips[i].length);
                graph.Connect(clipPlayable, 0, _mixer, i);
            }
        }

        private void PlayRandomClipPlayable()
        {
            _nextPlayableIndex = Random.Range(0, _mixer.GetInputCount());
            var playable = _mixer.GetInput(_nextPlayableIndex);
            playable.SetTime(0f);
            playable.SetDone(false);
            _isBlending = _nextPlayableIndex != _activePlayableIndex;
        }

        private void SetMixerInputWeights(int activeInputIndex)
        {
            for (var i = 0; i < _mixer.GetInputCount(); i++)
            {
                var weight = i == activeInputIndex ? 1f : 0f;
                _mixer.SetInputWeight(i, weight);
            }
        }
    }
}
