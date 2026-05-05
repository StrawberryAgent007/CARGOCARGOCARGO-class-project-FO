using UnityEngine;

// The template for all TruckExtensions, which are basically states for the truck, where multiple can be active at once

public abstract class TruckExtension : MonoBehaviour
{
    public abstract TruckExtensionsCoordinator.Extension thisTruckExtension { get; } // Holds the specific extension of the respective TruckExtension as an enum

    protected TruckExtensionsCoordinator coordinator = null; // Essentially functions as the context

    protected GameObject thisTruck = null; // Holds the truck as a GameObject
    protected Rigidbody thisTruckRb = null; // Holds the truck as a Rigidbody

    private bool thisExtensionActive = false; // Flags whether this extension is currently active or not

    // Initializes the TruckExtension by assigning the coordinator, along with relevant aspects of the truck
    public void Initialize(TruckExtensionsCoordinator setCoordinator)
    {
        this.coordinator = setCoordinator;
        this.thisTruck = this.gameObject;
        this.thisTruckRb = this.gameObject.GetComponent<Rigidbody>();
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
