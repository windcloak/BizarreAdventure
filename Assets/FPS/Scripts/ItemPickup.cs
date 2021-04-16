using UnityEngine;

public class ItemPickup : Interactable
{
    public Equipment item;
    public GameObject pickedEffect;
    Pickup m_Pickup;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public virtual void PickUp()
    {
        Debug.Log("Attempting to pick up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {

            Instantiate(pickedEffect, transform.position, transform.rotation);   // show effect
            Destroy(gameObject);
            return;
        }
        Debug.Log("Inventory full!");
    }
}
