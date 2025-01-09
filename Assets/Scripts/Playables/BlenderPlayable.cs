using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class BlenderPlayable : PlayableBehaviour
{

    public AnimationMixerPlayable _mixerPlayable;

    private float t;
    private float _duration = 0.3f;
    private bool _inTransition;

    public void CrossFade(float duration)
    {
        _duration = duration;
        _inTransition = true;
    }
    
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if(!_inTransition) return;
        
        var weight = Mathf.Lerp(0, 1, t/_duration);
        t += info.deltaTime;
        
        _mixerPlayable.SetInputWeight(0, weight);
        _mixerPlayable.SetInputWeight(1, 1 - weight);

        if (!(t > _duration)) return;
        t = 0;
        _inTransition = false;

    }
}
