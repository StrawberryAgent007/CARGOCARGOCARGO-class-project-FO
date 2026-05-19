using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

// NOTE: This is a Mediator meant to transmit any relevant info from the Truck Extensions to the player, such as changes to the player's speed stat, whether a key on the keyboard will trigger
// an action, etc.

public class TruckExtensionsToPlayerCommunicator : MonoBehaviour
{
    public PlayerController playerTruck = null;
    public TruckExtensionsCoordinator truckExtensionsCoordinator = null;

    private TruckExtensionSelection truckExtensionSelection = null;

    public struct playerTruckStats
    {
        public float moveSpeed; // The move speed of the player truck
        public float turnSpeed; // The turn speed of the player truck
    }

    // The playerTruckStats object that holds the definitive, universal player truck stats
    public playerTruckStats actualStats; // Will probably want to make this a Singleton, since it'll contain the key reference to player stats

    // For setting the script's TruckExtensionSelection reference
    public void setTruckExtensionSelection(TruckExtensionSelection newTruckExtensionSelection)
    {
        truckExtensionSelection = newTruckExtensionSelection;
    }

    // Sets up the necessary functionality for the Speed extension (if it's active)
    private void speedExtensionService()
    {
        // Grabbing a reference to TruckExtensionSpeed component, before assigning its increasedMoveSpeed variable to the Truck's move speed
        // NOTE: This is done in two separate steps because calling the increasedMoveSpeed variable from the extended call just below doesn't work, as increasedMoveSpeed isn't a variable of TruckExtension
        // base class - its exclusive to the TruckExtensionSpeed class. Even after explicit casting, the code still checks that if the variable is from the base class of TruckExtension, hence the need
        // for the extended process of pulling increasedMoveSpeed from an explicitly declared TruckExtensionSpeed var
        TruckExtensionSpeed speedExt = (TruckExtensionSpeed)truckExtensionsCoordinator.retrieveExtensionComponent(TruckExtensionsCoordinator.Extension.SpeedExtension);
        actualStats.moveSpeed = speedExt.increasedMoveSpeed;
    }

    // Sets up the necessary functionality for the Bounce extension (if it's active)
    private void bounceExtensionService()
    {

    }

    private void Start()
    {
        // Links up this object
        GameWizard.instanceFetch.linkUpTruckExtensionsToPlayerCommunicator(this);

        if (truckExtensionSelection.ReturnSelectedExtensions().Contains(TruckExtensionsCoordinator.Extension.SpeedExtension))
        {
            speedExtensionService();
        }
        else
        {
            actualStats.moveSpeed = playerTruck.baseMoveSpeed;
            actualStats.turnSpeed = playerTruck.baseTurnSpeed;
        }
    }
}
