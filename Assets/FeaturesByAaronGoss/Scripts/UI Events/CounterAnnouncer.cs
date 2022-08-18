using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAnnouncer : MonoBehaviour
{
    // We need our EVENTS here
    public delegate void StartAction();
    public static event StartAction OnStartEvent;

    private void Start()
    {
        if(OnStartEvent != null)
        {
            OnStartEvent();
        }
    }
}
