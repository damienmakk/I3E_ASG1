using System; // Import standard .NET system types (not strictly needed here but common in C# files)
using UnityEngine; // Import Unity-specific classes like MonoBehaviour, GameObject, Collider, and print
using TMPro; // Import TextMeshPro namespace for advanced text handling (not used in this script but often included in Unity projects for UI text)

using System.Collections;

public class PlayerScript : MonoBehaviour
{
    CollectibleScript currentCollectible; // Store the collectible object the player is currently able to interact with

    DoorScript currentDoor;

    int playerScore = 0; // Keep track of how many points the player has collected so far

    int itemsCollected = 0; // Tracks total collected items, including coins, keycard, and mask

    bool hasKeycard = false; // Tracks whether the player has collected the keycard

    bool hasMask = false; // Tracks whether the player has collected the mask
    

    [SerializeField]
    int targetScore = 0; // The goal score required to complete a task, editable from the Unity Inspector

    [SerializeField]
    TextMeshProUGUI scoreText; // Reference to the UI text element that displays the player's score

    [SerializeField]
    TextMeshProUGUI collectibleText; // Reference to the UI text element that displays collectible progress

    [SerializeField]
    TextMeshProUGUI inventoryText; // Reference to the UI text element that displays inventory items

    [SerializeField]
TextMeshProUGUI popupText; // Reference to popup UI text for warnings/messages

[SerializeField]
float popupDuration = 2f; // How long the popup stays on screen

Coroutine popupCoroutine; // Stores the current popup coroutine

    void Start()
{
    UpdateUI();

    if(popupText != null)
    {
        popupText.text = "";
        popupText.gameObject.SetActive(false);
    }
}

    void OnInteract() // Custom interaction method called when the player performs an interact action
    {
        if(currentCollectible != null) // Only collect something if the player is currently near a collectible
        {
            itemsCollected++; // Increase total item count for collectible progress

            if(currentCollectible.collectibleType == CollectibleType.Coin)
            {
                playerScore += currentCollectible.collectibleScore; // Add the collectible's score value to the player's total score
            }
            else if(currentCollectible.collectibleType == CollectibleType.Keycard)
            {
                hasKeycard = true; // Player now has the keycard
                print("Keycard collected.");
            }
            else if(currentCollectible.collectibleType == CollectibleType.Mask)
            {
                hasMask = true; // Player now has the mask
                print("Mask collected.");
            }

            UpdateUI(); // Update score, collectible progress, and inventory UI

            currentCollectible.Collect(); // Call the Collect method on the collectible script to handle its collection logic
            currentCollectible = null; // Clear the reference so the player no longer has an active collectible selected

            return;
        }

        if(currentDoor != null) // Check if the player is currently near a door they can interact with
        {
            currentDoor.Interact(); // Call the Interact method on the door script to toggle its open/closed state
            return;
        }

        print("Nothing to interact with.");
    }

    void UpdateUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + playerScore;
        }

        if(collectibleText != null)
        {
            collectibleText.text = "Items: " + itemsCollected + "/20";
        }

        if(inventoryText != null)
        {
            inventoryText.text = "";

            if(hasKeycard)
            {
                inventoryText.text += "Keycard\n";
            }

            if(hasMask)
            {
                inventoryText.text += "Mask\n";
            }
        }
    }

    public bool HasKeycard()
    {
        return hasKeycard;
    }

    public bool HasMask()
    {
        return hasMask;
    }

    public int GetItemsCollected()
    {
        return itemsCollected;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }
public void ShowPopupMessage(string message)
{
    if(popupText == null)
    {
        print(message);
        return;
    }

    if(popupCoroutine != null)
    {
        StopCoroutine(popupCoroutine);
    }

    popupCoroutine = StartCoroutine(ShowPopupRoutine(message));
}

IEnumerator ShowPopupRoutine(string message)
{
    popupText.gameObject.SetActive(true);
    popupText.text = message;

    yield return new WaitForSeconds(popupDuration);

    popupText.text = "";
    popupText.gameObject.SetActive(false);
}
    void OnTriggerEnter(Collider other) // Unity event called when another collider enters this GameObject's trigger collider
    {
        if(other.gameObject.tag == "Collectible") // Check if the object entering the trigger is tagged as a collectible
        {
            currentCollectible = other.GetComponentInParent<CollectibleScript>(); // Store the collectible script so the player can interact with it later
        }

        if(other.gameObject.tag == "Door") // Check if the object entering the trigger is tagged as a door
        {
            currentDoor = other.GetComponentInParent<DoorScript>(); // Get the DoorScript component from the parent of the collider
        }

        if(other.gameObject.tag == "GoalArea" && playerScore >= targetScore) // Check if the player entered the goal area and has enough points
        {
            print("Player entered trigger zone with " + playerScore + " points"); // Print a success message when the player reaches the goal with enough score
        }
    }

    void OnTriggerExit(Collider other) // Unity event called when another collider leaves this GameObject's trigger collider
    {
        if(other.gameObject.GetComponentInParent<CollectibleScript>() == currentCollectible) // If the collectible leaving the trigger is the one we were tracking
        {
            currentCollectible = null; // Clear the current collectible because it is no longer in range
        }

        if(other.gameObject.GetComponentInParent<DoorScript>() == currentDoor) // If the door leaving the trigger is the one we were tracking
        {
            currentDoor = null; // Clear the current door because it is no longer in range
        }
    }
}