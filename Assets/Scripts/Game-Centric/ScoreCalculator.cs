using UnityEngine;

// NOTE: This will be the dedicated machine for calculating the player's score at the end of each level, taking into account which extensions are in use, how fast the player delivered the packages,
// and any other variables we may introduce later down the line. This does not necessarily need to exist as an object in-game, or be independent really (it can just exist as an instance, should probably
// be a singleton!), but whenever a score is needed, it will be found by utilizing this bad boy

public class ScoreCalculator : MonoBehaviour
{

}
