using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToLookAt;

    // Update is called once per frame
    void Update()
    {
        if(objectToLookAt != null)
        {
            // make this 'turret' look at a specific gameObject
            transform.LookAt(objectToLookAt.transform);

            // Have a timer
            // if the timer runs out...
            // Shoot();
        }
    }
}
