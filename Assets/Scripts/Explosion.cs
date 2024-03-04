using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage; 

    // Start is called before the first frame update
    void Start()
    {
        float length = this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call function when collider is triggered
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision is triggered by the hero then destroy the enemy gameobject
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        } else
        {
            Destroy(collision.gameObject);
        }
    }
}
