using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // variable for the speed
    public float damage; // variable for how much damage the bullet deals

    [Header("Set Cam Configs Dynamically")]
    public float camWidth;
    public float camHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Get the forward vector of the object based on its rotation
        Vector2 forward = transform.up; // Assuming the object's forward direction is its up direction

        // Set the velocity of the Rigidbody2D
        GetComponent<Rigidbody2D>().velocity = forward * speed;

        //get the camera height and width
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    public virtual void Update()
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
