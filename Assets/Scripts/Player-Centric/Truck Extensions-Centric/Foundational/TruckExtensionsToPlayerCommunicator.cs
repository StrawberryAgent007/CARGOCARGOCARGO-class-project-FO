using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

// NOTE: This is a Mediator meant to transmit any relevant info from the Truck Extensions to the player, such as changes to the player's speed stat, whether a key on the keyboard will trigger
// an action, etc.

public class TruckExtensionsToPlayerCommunicator : MonoBehaviour
{
    public PlayerController playerTruck;
    public TruckExtensionsCoordinator truckExtensionsCoordinator;

    public struct playerTruckStats
    {
        public float moveSpeed; // The move speed of the player truck
        public float turnSpeed; // The turn speed of the player truck
    }

    // The playerTruckStats object that holds the definitive, universal player truck stats
    public playerTruckStats actualStats; // Will probably want to make this a Singleton, since it'll contain the key reference to player stats
}
