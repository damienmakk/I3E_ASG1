using System; // Import standard .NET system types (not strictly needed here but common in C# files)
using UnityEngine; // Import Unity-specific classes like MonoBehaviour, GameObject, Collider, and print

public enum DoorRequirementType
{
    None,
    Keycard,
    MinimumCollectibles,
    Exit
}

public class DoorScript : MonoBehaviour
{
    Animator myAnimator;

    [SerializeField]
    GameObject player;

[SerializeField]
GameEndManager gameEndManager; // Used by the final exit door to show the win screen
    bool isOpen = false;

    [SerializeField]
    DoorRequirementType requirementType = DoorRequirementType.None; // Set what this door needs before it can open

    [SerializeField]
    int requiredCollectibles = 0; // Used for Area 4 door and final exit door

    [SerializeField]
    float closeDistance = 5f; // How far the player must move away before the door closes

    void Start()
    {
        myAnimator = GetComponentInParent<Animator>();

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if(player == null)
        {
            return;
        }

        if (Vector3.Distance(player.transform.position, transform.position) > closeDistance) // Closes door if player is far away
        {
            if(isOpen)
            {
                myAnimator.SetTrigger("DoorClose");
                isOpen = false;
            }
        }
    }

    public void Interact()
    {
        PlayerScript playerScript = player.GetComponent<PlayerScript>();

        if(playerScript == null)
        {
            print("Error: PlayerScript not found on player.");
            return;
        }

        if(CanOpenDoor(playerScript))
        {
            if(requirementType == DoorRequirementType.Exit)
{
    print("Successfully escaped the facility!");

    if(gameEndManager != null)
    {
        gameEndManager.ShowEndScreen(playerScript);
    }

    return;
}

            if(isOpen)
            {
                myAnimator.SetTrigger("DoorClose");
            }
            else
            {
                myAnimator.SetTrigger("DoorOpen");
            }

            isOpen = !isOpen;
        }
        else
        {
            ShowLockedMessage(playerScript);
        }
    }

    bool CanOpenDoor(PlayerScript playerScript)
    {
        if(requirementType == DoorRequirementType.None)
        {
            return true;
        }

        if(requirementType == DoorRequirementType.Keycard)
        {
            return playerScript.HasKeycard();
        }

        if(requirementType == DoorRequirementType.MinimumCollectibles)
        {
            return playerScript.GetItemsCollected() >= requiredCollectibles;
        }

        if(requirementType == DoorRequirementType.Exit)
        {
            return playerScript.GetItemsCollected() >= requiredCollectibles;
        }

        return false;
    }

    void ShowLockedMessage(PlayerScript playerScript)
{
    string message = "";

    if(requirementType == DoorRequirementType.Keycard)
    {
        message = "Door locked. Keycard required.";
    }
    else if(requirementType == DoorRequirementType.MinimumCollectibles)
    {
        message = "Door locked. You need at least " + requiredCollectibles + " collectibles.";
    }
    else if(requirementType == DoorRequirementType.Exit)
    {
        message = "Exit locked. You need " + requiredCollectibles + " collectibles to escape.";
    }

    print(message);
    playerScript.ShowPopupMessage(message);
}
}