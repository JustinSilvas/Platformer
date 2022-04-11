using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//BM start
public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;
    
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
//BM end
