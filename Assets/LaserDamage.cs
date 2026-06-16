/*
* Author: Damien
* Description: Damages the player over time when they stay inside a laser hazard.
*/

using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    /// <summary>
    /// Amount of damage dealt each time the laser damages the player.
    /// </summary>
    [SerializeField]
    int damageAmount = 15;

    /// <summary>
    /// Time between each damage tick.
    /// </summary>
    [SerializeField]
    float damageInterval = 1f;

    /// <summary>
    /// Timer used to control how often damage is applied.
    /// </summary>
    float damageTimer = 0f;

    void OnTriggerStay(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if(playerHealth != null)
        {
            damageTimer += Time.deltaTime;

            if(damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(damageAmount);
                print("Player took laser damage.");

                damageTimer = 0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if(playerHealth != null)
        {
            damageTimer = 0f;
        }
    }
}