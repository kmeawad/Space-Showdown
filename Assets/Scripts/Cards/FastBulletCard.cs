using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletCard : BasicAttackCard
{
    public float speedUpMultiplier;
    public float damageDownMultiplier; 

    public override void instantiateBullet(Transform bulletSpawner)
    {
        //create bullet gameobjects
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        bullet.GetComponent<Bullet>().speed *= speedUpMultiplier;
        bullet.GetComponent<Bullet>().damage *= damageDownMultiplier;
    }
}
