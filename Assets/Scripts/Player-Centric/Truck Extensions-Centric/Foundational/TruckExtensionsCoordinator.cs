using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEditor.VersionControl.Asset;

// The (soon-to-be) Singleton manager that handles and assigns the extensions

public class TruckExtensionsCoordinator : MonoBehaviour
{
    // enum for extensions
    public enum Extension
    {
        SpeedExtension,
        BoostExtension,
        ArmoredFrontExtension,
    }

    private TruckExtension[] activeExtensions; // Holds all currently active extensions
    private Dictionary<Extension, TruckExtension> allExtensions = new Dictionary<Extension, TruckExtension>(); // Holds references to each component representing each extension, with enum as the key and the actual component as the value

    private void Start()
    {
        // Gets all extensions currently attached to the GameObject (which will be the player truck)
        TruckExtension[] grabbedExtensions = this.GetComponents<TruckExtension>();

        // Adds each extension component to a Dictionary, so that all are able to be accessed
        foreach (TruckExtension grabbedExtension in grabbedExtensions)
        {
            allExtensions.Add(grabbedExtension.thisTruckExtension, grabbedExtension);
            grabbedExtension.Initialize(this); // Initializes the extension, passing in this coordinator

            // By default, disables the extensions
            grabbedExtension.enabled = false; // Literally disables the component
            grabbedExtension.disableThisExtension(); // Unchecks the internal flag controlling whether the extension is active
        }
    }

    public void enableExtension(Extension enabledExtension)
    {
        
    }
}
