using UnityEngine;

// The template for all TruckExtensions, which are basically states for the truck, where multiple can be active at once

public abstract class TruckExtension : MonoBehaviour
{
    public abstract TruckExtensionsCoordinator.Extension thisTruckExtension { get; } // Holds the specific extension of the respective TruckExtension as an enum
    public abstract float pointCost { get; } // Holds the point reduction for each individual Truck Extension

    protected TruckExtensionsCoordinator coordinator = null; // Essentially functions as the context
    protected TruckExtensionsToPlayerCommunicator communicator = null; // Functions as the mediator between player controller for transmitting updates to player stats or state

    // Probably need to get rid of these two and assign them to the communicator
    protected GameObject thisTruck = null; // Holds the truck as a GameObject
    protected Rigidbody thisTruckRb = null; // Holds the truck as a Rigidbody

    protected bool thisExtensionActive = false; // Flags whether this extension is currently active or not

    // Initializes the TruckExtension by assigning the coordinator, along with relevant aspects of the truck
    public void Initialize(TruckExtensionsCoordinator setCoordinator, TruckExtensionsToPlayerCommunicator setCommunicator, GameObject setTruck)
    {
        this.coordinator = setCoordinator;
        this.communicator = setCommunicator;

        this.thisTruck = setTruck;
        this.thisTruckRb = setTruck.GetComponent<Rigidbody>();
    }

    // Enables the extension by setting the active flag to true
    public void enableThisExtension() { this.thisExtensionActive = true; }
    // Disables the extension by setting the active flag to false
    public void disableThisExtension() { this.thisExtensionActive = false; }

    // Virtual functions for standard functionality
    public virtual void OnEnable() { }
    public virtual void Update() { }
    public virtual void OnDisable() { }
}
