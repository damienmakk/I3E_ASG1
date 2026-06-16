using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public int collectiblesCollected;
    public int totalCollectibles = 20;

    public int deathCount;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCollectible(int points)
    {
        collectiblesCollected++;
        score += points;
    }

    public void AddDeath()
    {
        deathCount++;
    }
}