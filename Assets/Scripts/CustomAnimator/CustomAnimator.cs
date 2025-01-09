using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace CustomAnimator
{
    [RequireComponent(typeof(Animator))]
    public class CustomAnimator : MonoBehaviour
    {
        private PlayableGraph _graph;
        private AnimationMixerPlayable _mixer;

        [SerializeField] private AnimationClip _defaultClip = default;

        [SerializeField] private AnimationClip[] _clips;

        private int _inputPort;
        
        private bool _isBlending;
        private const float BlendSpeed = 2f;

        private void Awake()
        {
            _graph = PlayableGraph.Create();
            var output = AnimationPlayableOutput.Create(_graph, "Animation", GetComponent<Animator>());
            
            _mixer = AnimationMixerPlayable.Create(_graph, 2);
            output.SetSourcePlayable(_mixer);

            var clipPlayable0 = AnimationClipPlayable.Create(_graph, _defaultClip);
            
            _graph.Connect(clipPlayable0, 0, _mixer, _inputPort);
            
            _mixer.SetInputWeight(0, 1f);
            

            _graph.Play();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                CrossFade(GetRandomClip());
            }
            
            if (!_isBlending) return;


            var inputToDisconnect = _inputPort == 0 ? 1 : 0;
            var maxDelta = Time.deltaTime * BlendSpeed;
            var currentWeight = _mixer.GetInputWeight(_inputPort);
            var weight = Mathf.MoveTowards(1 - currentWeight, 1f, maxDelta);
            _mixer.SetInputWeight(inputToDisconnect, Mathf.Clamp01(weight));
            _mixer.SetInputWeight(_inputPort, Mathf.Clamp01(1f - weight));
            
            if (!Mathf.Approximately(_mixer.GetInputWeight(inputToDisconnect), 1f)) return;

            _isBlending = false;
            _inputPort = inputToDisconnect;
        }

        private void OnDestroy()
        {
            if(_graph.IsValid()) _graph.Destroy();
        }

        public void CrossFade(AnimationClip clip)
        {
            var clipPlayable = AnimationClipPlayable.Create(_graph, clip);
            var inputToDisconnect = _inputPort == 0 ? 1 : 0;
            _mixer.DisconnectInput(inputToDisconnect);
            _graph.Connect(clipPlayable, 0, _mixer, inputToDisconnect);
            _isBlending = true;
        }

        private AnimationClip GetRandomClip()
        {
            return _clips[Random.Range(0, _clips.Length)];
        }
    }
}