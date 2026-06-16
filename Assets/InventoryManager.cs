using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public bool hasKeycard;
    public bool hasMask;

    private void Awake()
    {
        Instance = this;
    }

    public void GetKeycard()
    {
        hasKeycard = true;
    }

    public void GetMask()
    {
        hasMask = true;
    }
}