using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBulletCard : BasicAttackCard
{
    public float offset;
    public float rotationAngle; 

    public override void instantiateBullet(Transform bulletSpawner)
    {
        Vector2 firstBulletPos = new Vector2(bulletSpawner.position.x, bulletSpawner.position.y);
        Vector2 secondBulletPos = new Vector2(bulletSpawner.position.x + offset, bulletSpawner.position.y);
        Vector2 thirdBulletPos = new Vector2(bulletSpawner.position.x - offset, bulletSpawner.position.y);

        Quaternion secondBulletRotation = Quaternion.Euler(0, 0, -rotationAngle) * bulletSpawner.rotation;
        Quaternion thirdBulletRotation = Quaternion.Euler(0, 0, rotationAngle) * bulletSpawner.rotation;

        //create bullet gameobjects
        Instantiate(bulletPrefab, firstBulletPos, bulletSpawner.rotation);
        Instantiate(bulletPrefab, secondBulletPos, secondBulletRotation);
        Instantiate(bulletPrefab, thirdBulletPos, thirdBulletRotation);
    }
}
