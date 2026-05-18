using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// NOTE: This is for the menu through which players will select their desired Truck Extensions. This will handle calling to the TruckExtensionsCoordinator which extensions to enable and disable,
// as well as assigning any penalties to the player's score for bringing in certain extensions

public class TruckExtensionSelection : MonoBehaviour
{
    private List<TruckExtensionsCoordinator.Extension> activatedExtensions = new List<TruckExtensionsCoordinator.Extension>(); // Holds all extensions that the player has selected or "activated"

    private void Start()
    {
        // NOTE: Something to keep in mind about making this singular object a DontDestroyOnLoad is that this means this singular Truck Extension Selection will be used across the entire game. That includes
        // when the player goes back to the Truck Extension Selection screen (if the game will be designed for players to return to that screen after completing a level...that might be past my skill level)
        GameObject.DontDestroyOnLoad(this);
        GameWizard.instanceFetch.setAsTruckExtensionSelection(this); // Sets this object as the GameWizard's TruckExtensionSelection
    }

    // Toggles an extension on or off depending on if its current toggle state
    public void ExtensionToggle(string toggledExtension)
    {
        TruckExtensionsCoordinator.Extension toggledExtensionAsExtension = (TruckExtensionsCoordinator.Extension)System.Enum.Parse(typeof(TruckExtensionsCoordinator.Extension), toggledExtension);

        if (!activatedExtensions.Contains(toggledExtensionAsExtension))
        {
            activatedExtensions.Add(toggledExtensionAsExtension);
        }
        else
        {
            activatedExtensions.Remove(toggledExtensionAsExtension);
        }
    }

    public List<TruckExtensionsCoordinator.Extension> ReturnSelectedExtensions() { return activatedExtensions; }
}