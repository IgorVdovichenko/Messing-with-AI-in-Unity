using UnityEngine;
using UnityEngine.Playables;

namespace PlayableNotification
{
    public class ReceiverExample: INotificationReceiver
    {
        public void OnNotify(Playable origin, INotification notification, object context)
        {
            if(notification == null) return;

            var time = origin.IsValid() ? origin.GetTime() : 0;
            Debug.LogFormat("Received notification of type {0} at time {1}", notification.GetType(), time);
        }
    }
}