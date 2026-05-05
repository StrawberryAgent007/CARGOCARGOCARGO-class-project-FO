using UnityEngine;

// NOTE:
// This extension gives the truck an armored front plate that allows it to bash into certain objects, flinging them far upon impact.

public class TruckExtensionArmoredFront : TruckExtension
{
    public override TruckExtensionsCoordinator.Extension thisTruckExtension => TruckExtensionsCoordinator.Extension.ArmoredFrontExtension;

    // Adjustable parameteres
    public float ramForce = 50.0f; // The force with which a rammed object is hit

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Armored Front Vulnerable"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(this.thisTruckRb.linearVelocity * ramForce, ForceMode.Impulse);
        }
    }
}
