using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS LIKELY TEMPORARY

public class ItemPickup : Interactable
{
    public Item item;
    Pickup m_Pickup;
    public PickupHUD pickHUD;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    //void Awake()
    //{
    //    item = GetComponent<Item>();
    //    //DebugUtility.HandleErrorIfNullGetComponent<Item, ItemPickup>(item, this, gameObject);

    //    /*m_Pickup = GetComponent<Pickup>();
    //    DebugUtility.HandleErrorIfNullGetComponent<Pickup, ItemPickup>(m_Pickup, this, gameObject);

    //    // subscribe to the onPick action on the Pickup component
    //    m_Pickup.onPick += OnPickup;*/
    //}

    void PickUp()
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
    public void OnTriggerEnter(Collider other)
    {
        // Todo: check if item is an inventory item
        pickHUD.OpenPickupPanel();
    }

    public void OnTriggerExit(Collider other)
    {
        pickHUD.ClosePickupPanel();
    }
}
