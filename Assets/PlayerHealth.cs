/*
* Author: Damien
* Description: Handles player health, death, checkpoint respawn, death UI, and health UI updates.
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Maximum health the player can have.
    /// </summary>
    [SerializeField]
    int maxHealth = 100;

    /// <summary>
    /// Current health of the player.
    /// </summary>
    int currentHealth;

    /// <summary>
    /// Number of times the player has died.
    /// </summary>
    int deathCount = 0;

    /// <summary>
    /// Checks whether the player is already dead, to prevent death count from adding multiple times.
    /// </summary>
    bool isDead = false;

    /// <summary>
    /// Default respawn point used when the game starts.
    /// </summary>
    [SerializeField]
    Transform startCheckpoint;

    /// <summary>
    /// Current checkpoint where the player will respawn.
    /// </summary>
    Transform currentCheckpoint;

    /// <summary>
    /// Reference to the player's Character Controller.
    /// </summary>
    CharacterController characterController;

    /// <summary>
    /// Reference to the health bar slider UI.
    /// </summary>
    [SerializeField]
    Slider healthSlider;

    /// <summary>
    /// Reference to the health text UI.
    /// </summary>
    [SerializeField]
    TextMeshProUGUI healthText;

    /// <summary>
    /// Death screen UI panel shown when the player dies.
    /// </summary>
    [SerializeField]
    GameObject deathPanel;

    /// <summary>
    /// Text shown on the death screen.
    /// </summary>
    [SerializeField]
    TextMeshProUGUI deathText;

    /// <summary>
    /// Time before the player respawns after dying.
    /// </summary>
    [SerializeField]
    float respawnDelay = 2f;

    void Start()
    {
        currentHealth = maxHealth;
        characterController = GetComponent<CharacterController>();

        if(startCheckpoint != null)
        {
            currentCheckpoint = startCheckpoint;
        }
        else
        {
            currentCheckpoint = transform;
        }

        if(deathPanel != null)
        {
            deathPanel.SetActive(false);
        }

        UpdateHealthUI();
    }

    /// <summary>
    /// Reduces the player's health by a damage amount.
    /// </summary>
    /// <param name="damageAmount">Amount of damage taken.</param>
    public void TakeDamage(int damageAmount)
    {
        if(isDead)
        {
            return;
        }

        currentHealth -= damageAmount;

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Instantly kills the player.
    /// </summary>
    public void InstantDeath()
    {
        if(isDead)
        {
            return;
        }

        currentHealth = 0;
        UpdateHealthUI();
        Die();
    }

    /// <summary>
    /// Sets a new checkpoint for the player.
    /// </summary>
    /// <param name="newCheckpoint">The checkpoint transform to respawn at.</param>
    public void SetCheckpoint(Transform newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
        print("Checkpoint updated: " + newCheckpoint.name);
    }

    /// <summary>
    /// Handles player death.
    /// </summary>
    void Die()
    {
        if(isDead)
        {
            return;
        }

        isDead = true;

        deathCount++;
        print("Player died. Death count: " + deathCount);

        StartCoroutine(DeathRoutine());
    }

    /// <summary>
    /// Shows death UI, waits, then respawns the player.
    /// </summary>
    IEnumerator DeathRoutine()
    {
        if(deathPanel != null)
        {
            deathPanel.SetActive(true);
        }

        if(deathText != null)
        {
            deathText.text = "YOU DIED\nRespawning...";
        }

        if(characterController != null)
        {
            characterController.enabled = false;
        }

        yield return new WaitForSeconds(respawnDelay);

        Respawn();

        if(deathPanel != null)
        {
            deathPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Respawns the player at the latest checkpoint and restores health.
    /// </summary>
    void Respawn()
    {
        if(currentCheckpoint == null)
        {
            return;
        }

        transform.position = currentCheckpoint.position;
        transform.rotation = currentCheckpoint.rotation;

        if(characterController != null)
        {
            characterController.enabled = true;
        }

        currentHealth = maxHealth;
        UpdateHealthUI();

        isDead = false;
    }

    /// <summary>
    /// Updates the health bar and health text UI.
    /// </summary>
    void UpdateHealthUI()
    {
        if(healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if(healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
    }

    /// <summary>
    /// Gets the player's current health.
    /// </summary>
    /// <returns>The current health value.</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Gets the number of deaths.
    /// </summary>
    /// <returns>The player's death count.</returns>
    public int GetDeathCount()
    {
        return deathCount;
    }
}