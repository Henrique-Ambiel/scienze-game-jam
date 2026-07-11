using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasShoe;
    public bool hasFlower;
    public bool hasShuttlecock;

    public int totalItems;

    public bool HasAllItems()
    {
        return hasShoe && hasFlower && hasShuttlecock;
    }

    public bool CanTransform()
    {
        return hasFlower;
    }

}
