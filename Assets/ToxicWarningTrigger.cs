/*
* Author: Damien
* Description: Shows a warning message before the player enters the toxic gas room.
*/

using UnityEngine;

public class ToxicWarningTrigger : MonoBehaviour
{
    /// <summary>
    /// Warning message shown to the player.
    /// </summary>
    [SerializeField]
    string warningMessage = "Warning: Toxic fumes. Please use a gas mask.";

    void OnTriggerEnter(Collider other)
    {
        PlayerScript playerScript = other.GetComponentInParent<PlayerScript>();

        if(playerScript != null)
        {
            playerScript.ShowPopupMessage(warningMessage);
        }
    }
}