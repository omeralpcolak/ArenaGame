using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 10f;

    // Reference to the joystick controllers
    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from the movement joystick
        float horizontalInput = movementJoystick.Horizontal;
        float verticalInput = movementJoystick.Vertical;

        // Calculate movement direction relative to the player's rotation
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // If there is input, move the player
        if (movementDirection.magnitude >= 0.1f)
        {
            MovePlayer(movementDirection);
        }

        // Get input from the rotation joystick
        float rotationInput = rotationJoystick.Horizontal;

        // If there is rotation input, rotate the player
        if (Mathf.Abs(rotationInput) >= 0.1f)
        {
            RotatePlayer(rotationInput);
        }
    }

    void MovePlayer(Vector3 direction)
    {
        // Calculate the movement velocity
        Vector3 movementVelocity = direction.normalized * movementSpeed * Time.deltaTime;

        // Apply the movement to the player's rigidbody
        rb.MovePosition(transform.position + movementVelocity);
    }

    void RotatePlayer(float rotationInput)
    {
        // Calculate the rotation angle based on input
        float rotationAngle = rotationInput * rotationSpeed * Time.deltaTime;

        // Apply the rotation to the player's orientation
        transform.Rotate(Vector3.up, rotationAngle);
    }
}
