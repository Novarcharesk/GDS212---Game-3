using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float swimSpeed = 5.0f; // Adjust the swim speed as needed
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get player input for horizontal and vertical axes (you can replace with your joystick input)
        float horizontalInput = Input.GetAxis("Horizontal"); // Change to your input axis
        float verticalInput = Input.GetAxis("Vertical"); // Change to your input axis

        // Calculate the movement vector
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        // Apply movement to the whale
        rb.velocity = moveDirection.normalized * swimSpeed;
    }
}