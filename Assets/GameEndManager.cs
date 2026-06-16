/*
* Author: Damien
* Description: Handles the win screen and displays final game results.
*/

using UnityEngine;
using TMPro;

public class GameEndManager : MonoBehaviour
{
    /// <summary>
    /// The panel shown when the player completes the game.
    /// </summary>
    [SerializeField]
    GameObject winPanel;

    /// <summary>
    /// Text used to display the player's final results.
    /// </summary>
    [SerializeField]
    TextMeshProUGUI winResultText;

    void Start()
    {
        if(winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Shows the end screen and displays final stats.
    /// </summary>
    /// <param name="playerScript">The player's main interaction script.</param>
    public void ShowEndScreen(PlayerScript playerScript)
    {
        if(playerScript == null)
        {
            return;
        }

        PlayerHealth playerHealth = playerScript.GetComponent<PlayerHealth>();

        int totalDeaths = 0;

        if(playerHealth != null)
        {
            totalDeaths = playerHealth.GetDeathCount();
        }

        int itemsCollected = playerScript.GetItemsCollected();
        int finalScore = playerScript.GetPlayerScore();

        if(winPanel != null)
        {
            winPanel.SetActive(true);
        }

        if(winResultText != null)
        {
            winResultText.text =
                "SUCCESSFULLY ESCAPED THE FACILITY\n\n" +
                "Total Deaths: " + totalDeaths + "\n" +
                "Items Collected: " + itemsCollected + "/20\n" +
                "Final Score: " + finalScore;
        }

        Time.timeScale = 0f;
    }
}