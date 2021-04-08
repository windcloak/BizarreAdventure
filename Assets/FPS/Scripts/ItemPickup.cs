using UnityEngine;

public class ItemPickup : Interactable
{
    public Equipment item;
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
            Destroy(gameObject);
            return;
        }
        Debug.Log("Inventory full!");
    }
}
