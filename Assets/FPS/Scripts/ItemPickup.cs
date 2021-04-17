using UnityEngine;

public class ItemPickup : Interactable
{
    [Tooltip("Item being picked up")]
    public Equipment item;
    [Tooltip("VFX spawned on pickup")]
    public GameObject pickupVFX;
    [Tooltip("Sound played on pickup")]
    public AudioClip pickupSFX;

    [Tooltip("Frequency at which the item will move up and down")]
    public float verticalBobFrequency = 1f;
    [Tooltip("Distance the item will move up and down")]
    public float bobbingAmount = 1f;
    [Tooltip("Rotation angle per second")]
    public float rotatingSpeed = 360f;
    [Tooltip("Direction it rotates")]
    public RotateDirection rotateDirection;

    public Rigidbody pickupRigidbody { get; private set; }
    Collider m_Collider;
    Vector3 m_StartPosition;
    Pickup m_Pickup;
    bool m_HasPlayedFeedback;

    public enum RotateDirection { up, forward, right }  // there are more, but I think we just need these

    private void Update()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;
        transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;

        RotateItem();

    }

    private void Start()
    {
        // Remember start position for animation
        m_StartPosition = transform.position;
        // ensure the physics setup is a kinematic rigidbody trigger
        pickupRigidbody.isKinematic = true;
        m_Collider.isTrigger = true;
    }

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

    // Handle rotate direction of item
    private void RotateItem()
    {
        switch (rotateDirection)
        {
            case RotateDirection.up:
                transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime, Space.Self);
                break;
            case RotateDirection.forward:
                transform.Rotate(Vector3.forward, rotatingSpeed * Time.deltaTime, Space.Self);
                break;
            case RotateDirection.right:
                transform.Rotate(Vector3.right, rotatingSpeed * Time.deltaTime, Space.Self);
                break;
        }
    }
}
