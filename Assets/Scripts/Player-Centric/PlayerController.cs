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

        // Assigning adjustable parameters to their actual storage in playerStats struct, held by TruckExtensionsToPlayerCommuicator
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

        // Applies the player input to their direction of movement
        Vector3 moveDirection = Vector3.zero;
        moveDirection += this.forward * moveInput.y;

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
