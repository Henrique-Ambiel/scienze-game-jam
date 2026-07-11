using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType
    {
        Shoe,
        Flower,
        Shuttlecock
    }

    public ItemType itemType;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    void Collect()
    {
        PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

        switch (itemType)
        {
            case ItemType.Shoe:
                inventory.hasShoe = true;
                break;

            case ItemType.Flower:
                inventory.hasFlower = true;
                break;

            case ItemType.Shuttlecock:
                inventory.hasShuttlecock = true;
                break;
        }

        inventory.totalItems++;

        Debug.Log("Item coletado: " + itemType);
        Debug.Log("Total de itens: " + inventory.totalItems);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
