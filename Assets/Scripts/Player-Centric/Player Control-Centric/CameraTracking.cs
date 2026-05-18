using UnityEngine;

// NOTE:
// This is the script that handles the camera's tracking behavior. Something to note is that this is attached to an empty object named the Camera Base, which the actual camera is a child of. The reason for
// this is that the Camera Base stays at the target's position, so the camera's local position can act as the offset. And when the Camera Base is rotated to follow the target's orientation, the camera,
// by following its parent's (which is the Camera Base) rotation, will circle around the target.

public class CameraTracking : MonoBehaviour
{
    public Transform target; // What the camera will track

    // Update function
    void Update()
    {
        this.transform.position = this.target.position; // Sets the position of the camera base that of the target's
        this.transform.rotation = this.target.rotation; // Rotates the camera around the target as target changes orientation
    }
}
