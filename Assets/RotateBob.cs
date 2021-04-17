using UnityEngine;

public class RotateBob : MonoBehaviour
{

    [Tooltip("Frequency at which the item will move up and down")]
    public float verticalBobFrequency = 1f;
    [Tooltip("Distance the item will move up and down")]
    public float bobbingAmount = 1f;
    [Tooltip("Rotation angle per second")]
    public float rotatingSpeed = 360f;
    [Tooltip("Direction the item rotates")]
    public RotateDirection rotateDirection;
    public Rigidbody pickupRigidbody { get; private set; }
    Collider m_Collider;
    Vector3 m_StartPosition;

    public enum RotateDirection { up, forward, right }  // there are more, but I think we just need these

    // Start is called before the first frame update

    private void Start()
    {
        pickupRigidbody = GetComponent<Rigidbody>();
        DebugUtility.HandleErrorIfNullGetComponent<Rigidbody, Pickup>(pickupRigidbody, this, gameObject);
        m_Collider = GetComponent<Collider>();
        DebugUtility.HandleErrorIfNullGetComponent<Collider, Pickup>(m_Collider, this, gameObject);

        // Remember start position for animation
        m_StartPosition = transform.position;
        // ensure the physics setup is a kinematic rigidbody trigger
        pickupRigidbody.isKinematic = true;
        m_Collider.isTrigger = true;
    }

    // Update is called once per frame

    private void Update()
    {
        // Handle bobbing

        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;
        transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;

        RotateItem();

    }

    // Handle rotate direction of item
    // If you need to add more directions, add it to the enum above
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
