using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronGoss
{
    public class BoostPad : MonoBehaviour
    {
        private void OnEnable()
        {
            TankGameEvents.OnBoostPadActivatedEvent += BoostPadCollision;
        }

        private void OnDisable()
        {
            TankGameEvents.OnBoostPadActivatedEvent += BoostPadCollision;
        }

        private void OnTriggerEnter(Collider other)
        {
            TankGameEvents.OnBoostPadActivatedEvent();
            //BoostPadCollision();
        }

        private void OnCollisionEnter(Collision collision)
        {
            TankGameEvents.OnBoostPadActivatedEvent();
            //BoostPadCollision();
        }

        private void BoostPadCollision()
        {
            // When something collides with the boost pad, we run this method
            // Check if a Tank has collided with the boost pad
            // Check what angle the Tank collided at
            // If angle is between 0-90’, increase tank’s speed to 24
            // Else decrease tank’s speed to 6
            // After 2 seconds, reset tank’s speed to base stat of 12
            Debug.Log("BOOST");

            //TankGameEvents.OnRoundResetEvent();
        }
    }
}
