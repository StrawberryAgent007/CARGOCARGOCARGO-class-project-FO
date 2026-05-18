using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// NOTE: This is solely for connecting the Done Button to the Game Wizard to set up appropriate onClick() behaviors

public class LinkDoneButton : MonoBehaviour
{
    private void Start()
    {
        GameWizard.instanceFetch.linkUpDoneButton(this.GetComponent<Button>());
    }
}