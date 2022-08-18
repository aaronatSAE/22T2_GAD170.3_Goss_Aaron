using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour
{
    public delegate void TeleportAction();
    public static event TeleportAction OnTeleportEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTeleportEvent();
    }
}
