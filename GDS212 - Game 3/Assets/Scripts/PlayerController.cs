using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float swimSpeed = 5.0f; // Adjust the swim speed as needed
    private Rigidbody rb;
    public VariableJoystick joystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get player input for horizontal and vertical axes (you can replace with your joystick input)
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // Calculate the movement vector
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply movement to the whale
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * swimSpeed;

        // Rotate the whale to face its movement direction
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}