using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // InputAction declaration(s)
    public InputAction moveAction;

    // Components of the GameObject
    private Rigidbody rb;
    private TruckExtensionsToPlayerCommunicator truckExtensionsCommunicator;

    // Adjustable parameters
    public float baseMoveSpeed = 10.0f;
    public float baseTurnSpeed = 10.0f;

    // Regarding movement functionality
    public Vector3 forward;
    private float moveMultiplier = 250.0f; // Mulitiples movement value by a set amount to bring speed up to a level that'll affect truck

    // Start function
    void Start()
    {
        // Assigning InputActions
        this.moveAction = InputSystem.actions.FindAction("Move");

        // Assigning components
        rb = this.GetComponent<Rigidbody>();
        truckExtensionsCommunicator = this.GetComponentInChildren<TruckExtensionsToPlayerCommunicator>();

        // Normalizing directions
        forward = this.forward.normalized;

        // Assigning adjustable parameters to their actual stats in playerStats struct, held by TruckExtensionsToPlayerCommuicator
        truckExtensionsCommunicator.actualStats.moveSpeed = baseMoveSpeed;
        truckExtensionsCommunicator.actualStats.turnSpeed = baseTurnSpeed;
    }

    // Update function
    void FixedUpdate()
    {
        executeMovement();
    }

    // Executes basic movement of truck (temp, will likely be replaced as more factors are introduced that'll influence truck controlability)
    void executeMovement()
    {
        // Reads the player's input
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Vector3 moveDirection = Vector3.zero; // Declares a base, zeroed-out moveDirection
        if (moveInput.y != 0.0) // If player is currently holding down a direction, that will be applied to player's moveDirection
        {
            // Applies the player input to their direction of movement
            moveDirection += this.forward * moveInput.y;
        }
        /*else if (moveInput.y == 0.0 && rb.linearVelocity.y != 0.0) // If player isn't holding down direction and the truck still has momentum, the truck will be brought to a stop by applying reverse momentum
        {
            moveDirection -= this.forward;
        }*/

        // Applies the player input to their direction of rotation
        Vector3 turnDirection = Vector3.zero;
        turnDirection.y = moveInput.x * truckExtensionsCommunicator.actualStats.turnSpeed;

        // Movement and rotation actually applied to player
        this.rb.AddForce(moveDirection * truckExtensionsCommunicator.actualStats.moveSpeed * moveMultiplier * Time.deltaTime, ForceMode.Force);
        this.transform.Rotate(turnDirection, Space.Self);

        // Changes forward to whatever current forward is
        this.forward = transform.forward;
    }
}
