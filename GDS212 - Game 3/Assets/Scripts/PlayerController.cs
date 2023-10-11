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
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        // Apply movement to the whale
        rb.velocity = moveDirection.normalized * swimSpeed;
    }
}