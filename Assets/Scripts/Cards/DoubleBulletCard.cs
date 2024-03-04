using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBulletCard : BasicAttackCard
{
    public float offset;
    public override void instantiateBullet(Transform bulletSpawner)
    {
        Vector2 firstBulletPos = new Vector2(bulletSpawner.position.x + offset, bulletSpawner.position.y);
        Vector2 secondBulletPos = new Vector2(bulletSpawner.position.x - offset, bulletSpawner.position.y);

        //create bullet gameobject
        Instantiate(bulletPrefab, firstBulletPos, bulletSpawner.rotation);
        Instantiate(bulletPrefab, secondBulletPos, bulletSpawner.rotation);
    }
}
