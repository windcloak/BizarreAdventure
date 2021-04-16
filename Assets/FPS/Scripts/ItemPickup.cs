using UnityEngine;

public class ItemPickup : Interactable
{
    [Tooltip("Item being picked up")]
    public Equipment item;
    [Tooltip("VFX spawned on pickup")]
    public GameObject pickupVFX;
    [Tooltip("Sound played on pickup")]
    public AudioClip pickupSFX;
    Pickup m_Pickup;
    bool m_HasPlayedFeedback;

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
            PlayPickupFeedback();
            Destroy(gameObject);
            return;
        }
        Debug.Log("Inventory full!");
    }

    public void PlayPickupFeedback()
    {
        if (m_HasPlayedFeedback)
            return;

        if (pickupSFX)
        {
            AudioUtility.CreateSFX(pickupSFX, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        if (pickupVFX)
        {
            var pickupVFXInstance = Instantiate(pickupVFX, transform.position, Quaternion.identity);
        }

        m_HasPlayedFeedback = true;
    }
}
