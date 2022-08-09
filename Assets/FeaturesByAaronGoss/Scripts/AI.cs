using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronGoss
{
    public class AI : MonoBehaviour
    {
        [SerializeField] Tank playerTank;
        [SerializeField] Tank aiTank;
        [SerializeField] Transform aiTankTurret;

        // know where player tank is
        // turn to face it
        // move towards it
        // shoot every second

        private void Start()
        {
            aiTank = GetComponent<Tank>();
        }

        private void Update()
        {
            if (playerTank)
            {
                // use dot product here to get facings
                aiTank.tankMovement.HandleMovement(0.4f, 0f, 0f);
                //aiTankTurret.LookAt(playerTank.transform.position);
                aiTank.transform.LookAt(playerTank.transform.position);
                //aiTank.tankMainGun
            }
        }
    }
}
