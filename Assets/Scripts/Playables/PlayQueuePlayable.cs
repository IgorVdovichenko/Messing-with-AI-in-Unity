using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Playables
{
    public class PlayQueuePlayable: PlayableBehaviour
    {
        private int _currentClipIndex = -1;
        private float _timetoNextClip;
        private Playable _mixer;

        public void Initialize(AnimationClip[] clipsToPlay, Playable owner, PlayableGraph graph)
        {
            owner.SetInputCount(1);
            _mixer = AnimationMixerPlayable.Create(graph, clipsToPlay.Length);
            graph.Connect(_mixer, 0, owner, 0);
            owner.SetInputWeight(0, 1);
            ConnectClipsPlayables(clipsToPlay, graph);
        }

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if(_mixer.GetInputCount() == 0) return;

            _timetoNextClip -= info.deltaTime;
            AdvanceToNextClip();
            AdjustInputsWeight();
        }

        private void ConnectClipsPlayables(AnimationClip[] clips, PlayableGraph graph)
        {
            for (var clipIndex = 0; clipIndex < _mixer.GetInputCount(); ++clipIndex)
            {
                var clipPlayable = AnimationClipPlayable.Create(graph, clips[clipIndex]);
                graph.Connect(clipPlayable, 0, _mixer, clipIndex);
            }
        }

        private void AdvanceToNextClip()
        {
            if (!(_timetoNextClip <= 0)) return;
            
            _currentClipIndex++;
            if (_currentClipIndex >= _mixer.GetInputCount()) _currentClipIndex = 0;
            var currentClip = (AnimationClipPlayable)_mixer.GetInput(_currentClipIndex);
            currentClip.SetTime(0);
            _timetoNextClip = currentClip.GetAnimationClip().length;
        }

        private void AdjustInputsWeight()
        {
            for (var clipIndex = 0; clipIndex < _mixer.GetInputCount(); ++clipIndex)
            {
                if(clipIndex == _currentClipIndex) _mixer.SetInputWeight(clipIndex, 1f);
                else _mixer.SetInputWeight(clipIndex, 0);
            }
        }
    }
}