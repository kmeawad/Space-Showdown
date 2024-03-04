using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAndFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate;
    public float moveSpeed;
    public float radius = 1f;

    private int movementDirection = 1;
    private float camWidth;

    private float _timeRemaining; // for firing bullet

    // Start is called before the first frame update
    void Start()
    {
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement direction based on input
        Vector2 moveDirection = new Vector2(movementDirection, 0).normalized;

        // Move the player based on the input direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


        Vector3 pos = transform.position;

        if (pos.x > camWidth - radius)
        {
            movementDirection = 1;
        }
        else if (pos.x < -camWidth + radius)
        {
            movementDirection = -1;
        }



        //Shooting logic
        //make sure that cooldown has finished before shooting again
        if (_timeRemaining <= 0)
        {
            Transform bulletSpawner = gameObject.transform.Find("Bullet Spawner").gameObject.transform;
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            _timeRemaining = fireRate;
        } else
            _timeRemaining -= Time.deltaTime; // reduce the time remaining for the next bullet to shoot

    }
}
