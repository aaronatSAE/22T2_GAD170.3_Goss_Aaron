using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronGoss
{
    public class AI : MonoBehaviour
    {
        [SerializeField] Tank targetTank;
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
            if (targetTank && Vector3.Distance(transform.position, targetTank.transform.position) < 50)
            {
                float acceleration = 0.4f;
                float tankForwardThrust = 0f;
                float tankRotationTorque = 0f;
                float turretRotationTorque = 0f;

                float idealShootingDistanceToTarget = 14f;

                Vector3 directionToTarget = targetTank.transform.position - transform.position;
                float distanceToTarget = Vector3.Distance(targetTank.transform.position, transform.position);

                // Move toward the player tank if it is too far away, and move away if it is too close.
                if(distanceToTarget < idealShootingDistanceToTarget - 2)
                {
                    //tankForwardThrust = -0.5f;
                    tankForwardThrust -= acceleration;
                }
                else if(distanceToTarget > idealShootingDistanceToTarget + 2)
                {
                    //tankForwardThrust = 0.5f;
                    tankForwardThrust += acceleration;
                }
                else
                {
                    tankForwardThrust = 0f;
                }

                // Turn the tank towards the player tank if it is not already facing it.
                // (Could use dot product here to get facings...)
                // If the target tank is to the right of our facing...
                if(AngleDir(transform.forward, directionToTarget, Vector3.up) > 0.3)
                {
                    // ...add torque to make the tank turn right.
                    //tankRotationTorque += Mathf.Clamp(Time.deltaTime * aiTank.tankMovement.turnSpeed;
                    //tankRotationTorque = Mathf.Clamp(tankRotationTorque += aiTank.tankMovement.turnSpeed * Time.deltaTime, -1f, 1f);
                    tankRotationTorque = acceleration / 2f;
                }
                // Otherwise, if the target tank is to the left of our facing...
                else if (AngleDir(transform.forward, directionToTarget, Vector3.up) < -0.3)
                {
                    // ...add torque to make the tank turn left.
                    //tankRotationTorque = Mathf.Clamp(tankRotationTorque -= aiTank.tankMovement.turnSpeed * Time.deltaTime, -1f, 1f);
                    tankRotationTorque = -acceleration / 2f;
                }

                //if (Vector3.Angle(transform.forward, directionToTarget) < 0)
                //{
                //    tankRotationTorque = Mathf.Clamp(tankRotationTorque += Time.deltaTime * aiTank.tankMovement.turnSpeed, -1f, 1f);
                //}
                //else
                //{
                //    tankRotationTorque = Mathf.Clamp(tankRotationTorque -= Time.deltaTime * aiTank.tankMovement.turnSpeed, -1f, 1f);
                //}
                //
                // Turn the turret towards the player tank at all times.
                //if (Vector3.Angle(aiTank.tankMainGun.mainGunTransform.forward, directionToTarget) < 0)
                //{
                //    tankRotationTorque = Mathf.Clamp(tankRotationTorque += Time.deltaTime * aiTank.tankMovement.turnSpeed, -1f, 1f);
                //}
                //else
                //{
                //    tankRotationTorque = Mathf.Clamp(tankRotationTorque -= Time.deltaTime * aiTank.tankMovement.turnSpeed, -1f, 1f);
                //}
                if (AngleDir(aiTank.tankMainGun.mainGunTransform.parent.forward, directionToTarget, Vector3.up) > 0.3)
                {
                    // ...add torque to make the tank turn right.
                    //tankRotationTorque += Mathf.Clamp(Time.deltaTime * aiTank.tankMovement.turnSpeed;
                    //tankRotationTorque = Mathf.Clamp(tankRotationTorque += aiTank.tankMovement.turnSpeed * Time.deltaTime, -1f, 1f);
                    turretRotationTorque = acceleration * 5f;
                }
                // Otherwise, if the target tank is to the left of our facing...
                else if (AngleDir(aiTank.tankMainGun.mainGunTransform.parent.forward, directionToTarget, Vector3.up) < -0.3)
                {
                    // ...add torque to make the tank turn left.
                    //tankRotationTorque = Mathf.Clamp(tankRotationTorque -= aiTank.tankMovement.turnSpeed * Time.deltaTime, -1f, 1f);
                    turretRotationTorque = -acceleration * 5f;
                }

                // Move our AI tank.
                aiTank.tankMovement.HandleMovement(tankForwardThrust, tankRotationTorque, turretRotationTorque);
            }
        }

        /// <summary>
        /// Returns -1 when to the left, 1 to the right, and 0 for forward/backward.
        /// </summary>
        /// <param name="directionForward"></param>
        /// <param name="directionToTarget"></param>
        /// <param name="directionUp"></param>
        /// <returns></returns>
        public float AngleDir(Vector3 directionForward, Vector3 directionToTarget, Vector3 directionUp)
        {
            Vector3 perpendicularAngle = Vector3.Cross(directionForward, directionToTarget);
            float dotProduct = Vector3.Dot(perpendicularAngle, directionUp);

            //if (dir > 0.0f)
            //{
            //    return 1.0f;
            //}
            //else if (dir < 0.0f)
            //{
            //    return -1.0f;
            //}
            //else
            //{
            //    return 0.0f;
            //}

            return dotProduct;
        }
    }
}
