using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if(playerHealth != null)
        {
            print("Player entered kill zone.");
            playerHealth.InstantDeath();
        }
    }
}