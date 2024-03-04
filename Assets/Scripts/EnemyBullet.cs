using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed; // variable for the speed
    public float damage; // variable for how much damage the bullet deals

    [Header("Set Dynamically")]
    public float camWidth;
    public float camHeight;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        //get the camera height and width
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x > camWidth || pos.x < -camWidth || pos.y > camHeight || pos.y < -camHeight)
        {
            Destroy(gameObject, 0.1f);
        }

    }

    //call function when collider is triggered
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision is triggered by the hero then destroy the enemy gameobject
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
