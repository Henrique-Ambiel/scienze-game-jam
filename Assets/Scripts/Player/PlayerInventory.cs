using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasShoe;
    public bool hasFlower;
    public bool hasShuttlecock;
    public bool hasFlute;

    public int totalItems;

    public bool HasAllItems()
    {
        return hasShoe && hasFlower && hasShuttlecock && hasFlute;
    }

    public bool CanTransform()
    {
        return hasFlower;
    }

    public bool CanShoot()
    {
        return hasFlute;
    }

}
