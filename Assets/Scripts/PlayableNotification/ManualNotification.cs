using UnityEngine;
using UnityEngine.Playables;

namespace PlayableNotification
{
    public class ManualNotification : MonoBehaviour
    {
        private PlayableGraph _playableGraph;
        private ReceiverExample _receiver;

        private ScriptPlayableOutput _output;

        private INotification _notification;

        private void Start()
        {
            _playableGraph = PlayableGraph.Create();
            _output = ScriptPlayableOutput.Create(_playableGraph, "NotificationOutput");
            _output.SetSourcePlayable(ScriptPlayable<ClipNotificationBehaviour>.Create(_playableGraph));
            _receiver = new ReceiverExample();
            _output.AddNotificationReceiver(_receiver);
            
            // _notification = new MyNotification();
            //
            // _output.PushNotification(Playable.Null, _notification);

            _playableGraph.Play();
        }

        private void OnDestroy() => _playableGraph.Destroy();
    }
}