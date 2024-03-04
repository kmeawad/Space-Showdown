using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on input
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player based on the input direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
