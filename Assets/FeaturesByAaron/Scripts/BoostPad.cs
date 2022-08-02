using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronGoss
{
    public class BoostPad : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            BoostPadCollision();
        }

        private void BoostPadCollision()
        {
            // When something collides with the boost pad, we run this method
            // Check if a Tank has collided with the boost pad
            // Check what angle the Tank collided at
            // If angle is between 0-90’, increase tank’s speed to 24
            // Else decrease tank’s speed to 6
            // After 2 seconds, reset tank’s speed to base stat of 12
        }
    }
}
