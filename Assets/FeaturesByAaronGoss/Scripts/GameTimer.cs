using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronGoss
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] float gameTimer = 60;

        // Start the game timer with 60 seconds

        private void Update()
        {
            // Count down every second
            gameTimer -= Time.deltaTime;
        }


        // Check if the timer has reached 0
        // If timer has reached 0, the round ends
        // Maybe call TankGameManager.ResetRound()?
        // Add 1 point to the winner(check if this happens already?)
        // Display victory message or tie message
        // Else continue counting down
    }
}
