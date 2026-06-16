using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if(playerHealth != null)
        {
            if(respawnPoint != null)
            {
                playerHealth.SetCheckpoint(respawnPoint);
            }
            else
            {
                playerHealth.SetCheckpoint(transform);
            }

            print("Checkpoint reached.");
        }
    }
}