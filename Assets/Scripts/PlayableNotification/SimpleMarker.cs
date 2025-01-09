using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SimpleMarker : Marker, INotification
{
    public PropertyName id { get; }

    [SerializeField] private bool _isActive;
}
