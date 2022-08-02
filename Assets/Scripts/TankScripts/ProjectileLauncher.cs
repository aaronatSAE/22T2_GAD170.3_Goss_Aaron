using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Projectile projectileToLaunch;

    public void LaunchProjectile(Projectile projectilePrefab)
    {
        Projectile instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
        instance.GetComponent<Rigidbody>().velocity = Vector3.forward * instance.launchSpeed;
    }

    private void Update()
    {
        LaunchProjectile(projectileToLaunch);
    }
}
