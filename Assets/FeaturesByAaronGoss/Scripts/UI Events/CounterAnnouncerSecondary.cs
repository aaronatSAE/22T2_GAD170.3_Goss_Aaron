using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAnnouncerSecondary : MonoBehaviour
{
    private void Start()
    {
        if (CounterAnnouncer.OnStartEvent != null)
        {
            CounterAnnouncer.OnStartEvent();
        }
    }
}
