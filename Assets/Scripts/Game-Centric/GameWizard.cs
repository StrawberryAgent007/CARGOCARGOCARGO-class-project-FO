using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// NOTE: Essentially the Game Manager. I just thought the name "Game Wizard" sounded cool, OK?

public class GameWizard : MonoBehaviour
{
    private static GameWizard singularInstance = null;
    private static bool shuttingDown = false;

    private TruckExtensionsCoordinator truckExtensionsCoordinator;
    private TruckExtensionSelection truckExtensionSelection;

    private string levelSelected;

    public static GameWizard instanceFetch
    {
        get
        {
            if (GameWizard.shuttingDown) { return null; }
            if (GameWizard.singularInstance == null)
            {
                GameObject obj = new GameObject("Game Wizard");
                GameWizard.singularInstance = obj.AddComponent<GameWizard>();
                GameObject.DontDestroyOnLoad(obj);
            }

            return GameWizard.singularInstance;
        }
    }

    public static bool Exists => GameWizard.singularInstance != null;

    private void OnApplicationQuit()
    {
        GameWizard.shuttingDown = true;
    }

    // Allows TruckExtensionSelection to set itself as the Game Wizard's truckExtensionSelection reference
    public void setAsTruckExtensionSelection(TruckExtensionSelection setTruckExtensionSelection) { truckExtensionSelection = setTruckExtensionSelection; }
    // Allows TruckExtensionsCoordinator to set itself as the Game Wizard's truckExtensionsCoordinator reference, along with the Game Wizard immediately calling the TruckExtensionsCoordinator's function to
    // enable multiple extensions at once, using its truckExtensionSelection's activeExtensions list as an argument
    public void setAsTruckExtensionsCoordinator(TruckExtensionsCoordinator setTruckExtensionsCoordinator)
    {
        // NOTE: Something I want to point out is that this function is intended to be called everytime the player loads into a level - so the truckExtensionsCoordinator reference is meant to be reset upon
        // starting a new level, since each level will have its own truckExtensionsCoordinator. Of course, this is only really a concern if we do decide to design the game so that the entire bloomin' game
        // doesn't need to be reset to play it again...which, may be too much for me to bite off, taking into account all the code and memory considerations for something seemingly simple like that
        truckExtensionsCoordinator = setTruckExtensionsCoordinator;
        // NOTE: The game is designed so that the player will enter a level only after they've gone past the Truck Extension Selection
        // screen, so it's a certainty that a truckExtensionSelection will be set by the time a truckExtensionsCoordinator is set. Regardless, that is a dependency that needs to be noted.
        truckExtensionsCoordinator.enableSelectedExtensions(truckExtensionSelection.ReturnSelectedExtensions());
    }

    public void linkUpDoneButton(Button doneButton)
    {
        doneButton.onClick.AddListener(ChangeSceneIntoLevel); // Adds the ChangeSceneIntoLevel function call to the done button manually
    }

    // Sets the level that the player selected, saving it in the Game Wizard
    public void LevelSelected(string setLevel) { levelSelected = setLevel; }

    // NOTE: The reason why the two below functions are separate instead of just one with an if statement branching off into loading the specified scene or the previously selected level is because of the
    // linkUpDoneButton() function up above. You can't add a listener to a button that needs an argument through code (to my knowledge), hence the need for a ChangeSceneIntoLevel function that doesn't require
    // an argument at all
    // Chagnes scene to previously selected level
    public void ChangeSceneIntoLevel() { SceneManager.LoadScene(levelSelected); }
    // Changes scene into specified scene
    public void ChangeSceneToSpecified(string sceneToChangeInto) { SceneManager.LoadScene(sceneToChangeInto); }
}
