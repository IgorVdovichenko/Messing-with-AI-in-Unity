using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class SimpleReceiver : MonoBehaviour, INotificationReceiver
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        _agent.enabled = false;
    }
}
