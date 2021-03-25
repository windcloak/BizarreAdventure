using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS LIKELY TEMPORARY

public class ItemPickup : MonoBehaviour
{
    Item item;
    Pickup m_Pickup;

    void Awake()
    {
        item = GetComponent<Item>();
        //DebugUtility.HandleErrorIfNullGetComponent<Item, ItemPickup>(item, this, gameObject);

        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, ItemPickup>(m_Pickup, this, gameObject);

        // subscribe to the onPick action on the Pickup component
        m_Pickup.onPick += OnPickup;
    }

    void OnPickup(PlayerCharacterController player)
    {
        Debug.Log("Attempting to pick up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("Inventory full!");
    }
}
