/*
* Author: Damien
* Description: Kills the player if they enter the toxic gas room without a gas mask.
*/

using UnityEngine;

public class ToxicGasZone : MonoBehaviour
{
    /// <summary>
    /// Message shown when the player enters safely with the gas mask.
    /// </summary>
    [SerializeField]
    string safeMessage = "Gas mask equipped. You can breathe safely.";

    /// <summary>
    /// Message shown when the player enters without the gas mask.
    /// </summary>
    [SerializeField]
    string deathMessage = "You entered toxic gas without a gas mask.";

    void OnTriggerEnter(Collider other)
    {
        PlayerScript playerScript = other.GetComponentInParent<PlayerScript>();
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if(playerScript == null || playerHealth == null)
        {
            return;
        }

        if(playerScript.HasMask())
        {
            playerScript.ShowPopupMessage(safeMessage);
        }
        else
        {
            playerScript.ShowPopupMessage(deathMessage);
            playerHealth.InstantDeath();
        }
    }
}