using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    public GameObject explosionPrefab;
    public float timeToExplosion;


    private float timePassed;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (timePassed >= timeToExplosion)
        {
            Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        } else
            timePassed += Time.deltaTime;

    }

    //call function when collider is triggered
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision is triggered by the hero then destroy the enemy gameobject
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        } else if (!collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }

    }


}
